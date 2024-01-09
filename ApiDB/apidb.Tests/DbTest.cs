using DataProvider;
using protocol.Requests;
using System.Drawing;

namespace apidb.Tests
{
    [TestClass]
    public class DbTest
    {
        [TestMethod]
        public void GetListDocumentsTest()
        {
            var handler = new GetListDocumentsHandler { DbCtx = new PostgresContext() };

            var result = handler.HandleRequest(new GetListDocumentsRequest { UserName = "user" });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateDocumentTest()
        {
            var ctx = new PostgresContext();
            var handler = new CreateDocumentHandler { DbCtx = ctx };

            var result = handler.HandleRequest(new CreateDocumentRequest
            {
                DocumentName = "document",
                UserName = "user"
            });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDocumentByIdTest()
        {
            var handler = new GetDocumentByIdHandler { DbCtx = new PostgresContext() };

            var result = handler.HandleRequest(new GetDocumentByIdRequest
            {
                UserName = "user",
                DocumentId = 1
            });

            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void DeleteDocumentTest()
        {
            var handler = new DeleteDocumentHandler { DbCtx = new PostgresContext() };

            var result = handler.HandleRequest(new DeleteDocumentByIdRequest 
            { 
                DocumentId = 0,
                UserName = "user"
            });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateShapeTest()
        {
            var handler = new CreateShapeHandler { DbCtx = new PostgresContext() };

            var date = DateTime.Now.ToUniversalTime();

            var result = handler.HandleRequest(new ShapeRequest
            {
                DocumentId = 1,
                ShapeType = (byte)ShapeTypeEnum.Point,
                CreateDate = date,
                UpdateDate = date,
                CreateAuthor = "user",
                UpdateAuthor = "user2",
                Color = "",
                Coords = ""
            });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteShapeTest()
        {
            var handler = new DeleteShapeHandler { DbCtx = new PostgresContext() };

            var result = handler.HandleRequest(new DeleteShapeRequest 
            { 
                Id = 0,
                UserName = "user"
            });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateShapeTest()
        {
            var handler = new UpdateShapeHandler { DbCtx = new PostgresContext() };

            var result = handler.HandleRequest(new ShapeRequest
            {
                Id = 0,                
                ShapeType = (byte)ShapeTypeEnum.Point,
                UpdateDate = DateTime.Now.ToUniversalTime(),
                UpdateAuthor = "user3",
                Color = "red",
                Coords = "test"
            });

            Assert.IsNotNull(result);
        }

    }
}