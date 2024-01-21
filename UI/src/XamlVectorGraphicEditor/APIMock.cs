using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Protocol.Common;
using SingleRClient;
using static SingleRClient.DataProvider;
using Newtonsoft.Json;
using XamlVectorGraphicEditor.MyShapes;

namespace XamlVectorGraphicEditor
{
    interface ITestDataProvider
    {
        void TestAddShape(int docId);
        void TestUpdateShape(int docId);
        void TestDeleteShape(int docId);
    }

    internal class APIMock : IDataProvider, ITestDataProvider
    {
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        private readonly object _lock = new object();
        private readonly Dictionary<int, Document> _docs = new Dictionary<int, Document>();
        private int _id = 0;

        public APIMock()
        {
            InitDocs();
        }

        private void Delay()
        {
            Thread.Sleep(_random.Next(200, 600));
        }

        private int GenID()
        {
            return _id++;
        }

        private Shape RandomShape(int docId, int id, string userName)
        {
            var shapeType = (MyShapes.ShapeType)_random.Next(0, 2);
            var dto = ShapeFactory.CreateShapeDTO(shapeType);
            if (dto == null)
                return null;

            var shape = new Shape();

            shape.Id = id;
            shape.ShapeType = (byte)shapeType;
            shape.DocumentId = docId;
            shape.CreateDate = DateTime.Now;
            shape.UpdateDate = shape.CreateDate;
            shape.CreateAuthor = userName;
            shape.UpdateAuthor = shape.CreateAuthor;
            shape.Coords = JsonConvert.SerializeObject(dto);

            return shape;
        }

        private List<Shape> RandomBody(int docId, string userName)
        {
            var body = new List<Shape>();

            var count = _random.Next(5, 10);
            while (count > 0)
            {
                count--;

                var shape = RandomShape(docId, GenID(), userName);
                if (shape != null)
                    body.Add(shape);
            }

            return body;
        }

        private void InitDocs()
        {
            var h1 = new DocumentHeader
            {
                Id = GenID(),
                Title = "Document from Petya",
                CreateAuthor = "Petya"
            };

            h1.UserName = h1.CreateAuthor;

            var d1 = new Document
            {
                Header = h1,
                Body = RandomBody(h1.Id, h1.UserName)
            };

            var h2 = new DocumentHeader
            {
                Id = GenID(),
                Title = "Document from Vasya",
                CreateAuthor = "Vasya"
            };

            h2.UserName = h2.CreateAuthor;

            var d2 = new Document
            {
                Header = h2,
                Body = RandomBody(h2.Id, h2.UserName)
            };

            var h3 = new DocumentHeader
            {
                Id = GenID(),
                Title = "Document from Masha",
                CreateAuthor = "Masha"
            };

            h3.UserName = h3.CreateAuthor;

            var d3 = new Document
            {
                Header = h3,
                Body = RandomBody(h3.Id, h3.UserName)
            };

            _docs.Add(d1.Header.Id, d1);
            _docs.Add(d2.Header.Id, d2);
            _docs.Add(d3.Header.Id, d3);
        }

        /// <summary>
        /// Get list documents
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>Documents headers list</returns>
        public Task<DocumentList> GetDocumentsListAsync(string userName)
        {
            return Task.Run(() =>
            {
                Delay();

                var ret = new DocumentList();
                lock (_lock)
                {
                    foreach (var h in _docs.Values.Select(x => x.Header))
                    {
                        var s = JsonConvert.SerializeObject(h);
                        ret.Documents.Add(JsonConvert.DeserializeObject<DocumentHeader>(s));
                    }
                }

                return ret;
            });
        }

        /// <summary>
        /// Get document by ID
        /// </summary>
        /// <param name="documentId">ID Document</param>
        /// <param name="userName">User name</param>
        /// <returns>Document object with document info</returns>
        public Task<Document> GetDocumentByIdAsync(int docId, string userName)
        {
            return Task.Run(() =>
            {
                Delay();

                lock (_lock)
                {
                    if (_docs.TryGetValue(docId, out var doc))
                    {
                        var s = JsonConvert.SerializeObject(doc);
                        return JsonConvert.DeserializeObject<Document>(s);
                    }
                }

                return null;
            });
        }

        /// <summary>
        /// Create document
        /// </summary>
        /// <param name="docName">Document name</param>
        /// <param name="userName">User name</param>
        /// <returns>(Document id, status info)</returns>
        public Task<(int, StatusResponse)> CreateDocumentAsync(string docName, string userName)
        {
            return Task.Run(() =>
            {
                Delay();

                var h = new DocumentHeader
                {
                    Id = GenID(),
                    Title = docName,
                    UserName = userName,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CreateAuthor = userName,
                    UpdateAuthor = userName
                };

                var d = new Document();
                d.Header = h;
                d.Body = new List<Shape>();

                lock (_lock)
                {
                    _docs.Add(d.Header.Id, d);
                }

                return (d.Header.Id, new StatusResponse { Status = Status.Success });
            });
        }

        /// <summary>
        /// Notify users when a new document is created
        /// </summary>
        public event CreateDocument OnCreateDocument;

        /// <summary>
        /// Delete document by id
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="userName">User name</param>
        /// <returns>Status info</returns>
        public Task<StatusResponse> DeleteDocumentByIdAsync(int docId, string userName)
        {
            return Task.Run(() =>
            {
                Delay();

                lock (_lock)
                {
                    if (_docs.ContainsKey(docId))
                    {
                        _docs.Remove(docId);
                        return new StatusResponse { Status = Status.Success };
                    }
                    else
                    {
                        return new StatusResponse { Status = Status.Failure, Description = $"Document [{docId}] not found" };
                    }
                }
            });
        }

        /// <summary>
        /// Notify users when the document is deleted
        /// </summary>
        public event DeleteDocumentById OnDeleteDocumentById;

        /// <summary>
        /// Create shape in document
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="shape">Shape object</param>
        /// <param name="userName">User name</param>
        /// <returns>(Shape ID, status info)</returns>
        public Task<(int?, StatusResponse)> CreateShapeAsync(Shape shape, string userName)
        {
            return Task.Run(() =>
            {
                Delay();
                lock (_lock)
                {
                    if (_docs.TryGetValue(shape.DocumentId, out var d))
                    {
                        var s = JsonConvert.SerializeObject(shape);
                        var newShape = JsonConvert.DeserializeObject<Shape>(s);

                        d.Body.Add(newShape);
                        d.Header.UpdateAuthor = userName;
                        d.Header.UpdateDate = DateTime.Now;

                        var id = GenID();
                        newShape.Id = id;

                        return (newShape.Id, new StatusResponse { Status = Status.Success });
                    }
                    else
                    {
                        return ((int?)null, new StatusResponse { Status = Status.Failure, Description = $"Document [{shape.DocumentId}] not found" });
                    }
                }
            });
        }

        /// <summary>
        /// Notify users when a new shape is created
        /// </summary>
        public event CreateShape OnCreateShape;

        /// <summary>
        /// Update shape in document
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="shape">Shape object</param>
        /// <param name="userName">User name</param>
        /// <returns>Status info</returns>
        public Task<StatusResponse> UpdateShapeAsync(Shape shape, string userName)
        {
            return Task.Run(() =>
            {
                Delay();
                lock (_lock)
                {
                    if (_docs.TryGetValue(shape.DocumentId, out var d))
                    {
                        var index = d.Body.FindIndex(x => x.Id == shape.Id);

                        if (index < 0)
                        {
                            return new StatusResponse { Status = Status.Failure, Description = $"Shape [{shape.Id}] not found" };
                        }

                        var s = JsonConvert.SerializeObject(shape);
                        d.Body[index] = JsonConvert.DeserializeObject<Shape>(s);
                        d.Header.UpdateAuthor = userName;
                        d.Header.UpdateDate = DateTime.Now;

                        return new StatusResponse { Status = Status.Success };
                    }
                    else
                    {
                        return new StatusResponse { Status = Status.Failure, Description = $"Document [{shape.DocumentId}] not found" };
                    }
                }
            });
        }

        /// <summary>
        /// Notify users when the shape is updated
        /// </summary>
        public event UpdateShape OnUpdateShape;

        /// <summary>
        /// Delete shape in document
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="shape">Shape object</param>
        /// <param name="userName">User name</param>
        /// <returns>Status info</returns>
        public Task<StatusResponse> DeleteShapeAsync(Shape shape, string userName)
        {
            return Task.Run(() =>
            {
                Delay();
                lock (_lock)
                {
                    if (_docs.TryGetValue(shape.DocumentId, out var d))
                    {
                        var index = d.Body.FindIndex(x => x.Id == shape.Id);

                        if (index < 0)
                        {
                            return new StatusResponse { Status = Status.Failure, Description = $"Shape [{shape.Id}] not found" };
                        }

                        d.Body.RemoveAt(index);
                        d.Header.UpdateAuthor = userName;
                        d.Header.UpdateDate = DateTime.Now;

                        return new StatusResponse { Status = Status.Success };
                    }
                    else
                    {
                        return new StatusResponse { Status = Status.Failure, Description = $"Document [{shape.DocumentId}] not found" };
                    }
                }
            });
        }

        /// <summary>
        /// Notify users when the shape is deleted
        /// </summary>
        public event DeleteShape OnDeleteShape;

        /// <summary>
        /// Notify users the connection was lost and the client is reconnecting.
        /// Start queuing or dropping messages.
        /// </summary>
        public event Reconnecting OnReconnecting;
        /// <summary>
        /// Notify users the connection was reestablished.
        /// Start dequeuing messages queued while resonnecting if any.
        /// </summary>
        public event Reconnected OnReconnected;
        /// <summary>
        /// Notify users the connection lost;
        /// </summary>
        public event Closed OnClosed;

        private string RandomUser()
        {
            var users = new string[] { "Petya", "Vasya", "Masha" };
            return users[_random.Next(users.Length)];
        }

        #region ITestDataProvider
        public void TestAddShape(int docId)
        {
            if (!_docs.TryGetValue(docId, out var document))
                return;

            var userName = RandomUser();
            var shape = RandomShape(docId, GenID(), userName);
            if (shape != null)
            {
                document.Body.Add(shape);
                document.Header.UpdateAuthor = userName;
                document.Header.UpdateDate = shape.UpdateDate;

                OnCreateShape?.Invoke(shape, new StatusResponse { Status = Status.Success });
            }
        }

        public void TestUpdateShape(int docId)
        {
            if (!_docs.TryGetValue(docId, out var document) || document.Body.Count == 0)
                return;

            var newShape = RandomShape(0, 0, "");
            if (newShape == null)
                return;

            var index = _random.Next(document.Body.Count);   
            var shape = document.Body[index];

            shape.UpdateDate = DateTime.Now;
            shape.Coords = newShape.Coords;

            shape.UpdateAuthor = RandomUser();
            document.Header.UpdateAuthor = shape.UpdateAuthor;
            document.Header.UpdateDate = shape.UpdateDate;

            OnUpdateShape?.Invoke(shape, new StatusResponse { Status = Status.Success });
        }

        public void TestDeleteShape(int docId)
        {
            if (!_docs.TryGetValue(docId, out var document) || document.Body.Count == 0)
                return;

            var index = _random.Next(document.Body.Count);

            var shape = document.Body[index];
            document.Body.RemoveAt(index);

            var userName = RandomUser();
            document.Header.UpdateAuthor = shape.UpdateAuthor;
            document.Header.UpdateDate = shape.UpdateDate;

            OnDeleteShape?.Invoke(shape, new StatusResponse { Status = Status.Success });
        }

        #endregion
    }
}
