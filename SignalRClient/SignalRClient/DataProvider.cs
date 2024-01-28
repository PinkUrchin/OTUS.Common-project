﻿using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Protocol.Common;
using Newtonsoft.Json;
using static SingleRClient.DataProvider;
using System.Security.Cryptography;
using System.Collections.Concurrent;

namespace SingleRClient
{
    public interface IDataProvider
    {
        /// <summary>
        /// Get list documents
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>Documents headers list</returns>
        Task<DocumentList> GetDocumentsListAsync(string userName);

        /// <summary>
        /// Get document by ID
        /// </summary>
        /// <param name="documentId">ID Document</param>
        /// <param name="userName">User name</param>
        /// <returns>Document object with document info</returns>
        Task<Protocol.Common.Document> GetDocumentByIdAsync(int docId, string userName);

        /// <summary>
        /// Create document
        /// </summary>
        /// <param name="docName">Document name</param>
        /// <param name="userName">User name</param>
        /// <returns>(Document id, status info)</returns>
        Task<(int, StatusResponse)> CreateDocumentAsync(string docName, string userName);
        /// <summary>
        /// Notify users when a new document is created
        /// </summary>
        event CreateDocument OnCreateDocument;

        /// <summary>
        /// Delete document by id
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="userName">User name</param>
        /// <returns>Status info</returns>
        Task<StatusResponse> DeleteDocumentByIdAsync(int docId, string userName);
        /// <summary>
        /// Notify users when the document is deleted
        /// </summary>
        event DeleteDocumentById OnDeleteDocumentById;

        /// <summary>
        /// Create shape in document
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="shape">Shape object</param>
        /// <param name="userName">User name</param>
        /// <returns>(Shape ID, status info)</returns>
        Task<(int?, StatusResponse)> CreateShapeAsync(Shape shape, string userName);
        /// <summary>
        /// Notify users when a new shape is created
        /// </summary>
        event CreateShape OnCreateShape;

        /// <summary>
        /// Update shape in document
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="shape">Shape object</param>
        /// <param name="userName">User name</param>
        /// <returns>Status info</returns>
        Task<StatusResponse> UpdateShapeAsync(Shape shape, string userName);
        /// <summary>
        /// Notify users when the shape is updated
        /// </summary>
        event UpdateShape OnUpdateShape;

        /// <summary>
        /// Delete shape in document
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="shape">Shape object</param>
        /// <param name="userName">User name</param>
        /// <returns>Status info</returns>
        Task<StatusResponse> DeleteShapeAsync(Shape shape, string userName);
        /// <summary>
        /// Notify users when the shape is deleted
        /// </summary>
        event DeleteShape OnDeleteShape;

        /// <summary>
        /// Notify users the connection was lost and the client is reconnecting.
        /// Start queuing or dropping messages.
        /// </summary>
        event Reconnecting OnReconnecting;
        /// <summary>
        /// Notify users the connection was reestablished.
        /// Start dequeuing messages queued while resonnecting if any.
        /// </summary>
        event Reconnected OnReconnected;
        /// <summary>
        /// Notify users the connection lost;
        /// </summary>
        event Closed OnClosed;
    }
    
    public class DataProvider : IDataProvider, IDisposable
    {
        private static DataProvider _instance;

        private HubConnection _connection;

        private ConcurrentDictionary<Guid, object> _responsesActionDict = new ConcurrentDictionary<Guid, object>();

        private DataProvider()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://85.193.81.154:8088/document")
                //.WithUrl("http://localhost:32787/document")
                .WithAutomaticReconnect()
                .Build();
            //_connection.ServerTimeout = TimeSpan.MaxValue;

            InitConnection();
            RegisterFunctions();
        }

        public static async Task<DataProvider> GetInstanceAsync(CancellationToken token)
        {
            if (_instance == null)
            {
                _instance = new DataProvider();
                await _instance.ConnectionWithRetryAsync(token);
            }

            return _instance;
        }

        public async void Dispose()
        {
            await _connection.StopAsync();
        }

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

        private event GetListDocuments OnGetListDocuments;

        private event GetDocumentById OnGetDocumentById;

        public event CreateDocument OnCreateDocument;

        public event DeleteDocumentById OnDeleteDocumentById;

        public event CreateShape OnCreateShape;

        public event UpdateShape OnUpdateShape;

        public event DeleteShape OnDeleteShape;

        /// <summary>
        /// Get list documents
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>Documents headers list</returns>
        public Task<DocumentList> GetDocumentsListAsync(string userName)
        {
            var newGuid = Guid.NewGuid();
            var tcs = new TaskCompletionSource<DocumentList>();
            _responsesActionDict[newGuid] = tcs;

            Task.Run(() =>
            {
                try
                {
                    _connection.InvokeAsync("GetListDocuments", userName, newGuid);
                }
                catch (Exception ex)
                {
                    // TODO: exception handling. Logging
                }
            });

            return tcs.Task;
        }

        /// <summary>
        /// Get document by ID
        /// </summary>
        /// <param name="documentId">ID Document</param>
        /// <param name="userName">User name</param>
        /// <returns>Document object with document info</returns>
        public Task<Protocol.Common.Document> GetDocumentByIdAsync(int documentId, string userName)
        {
            Guid newGuid = Guid.NewGuid();
            var tcs = new TaskCompletionSource<Protocol.Common.Document>();
            _responsesActionDict[newGuid] = tcs;

            Task.Run(() =>
            {
                try
                {
                    _connection.InvokeAsync("GetDocumentById", documentId, userName, newGuid);
                }
                catch (Exception ex)
                {
                    // TODO: exception handling. Logging
                }
            });

            return tcs.Task;
        }

        /// <summary>
        /// Create document
        /// </summary>
        /// <param name="docName">Document name</param>
        /// <param name="userName">User name</param>
        /// <returns>(Document id, status info)</returns>
        public Task<(int, StatusResponse)> CreateDocumentAsync(string docName, string userName)
        {
            Guid newGuid = Guid.NewGuid();
            var tcs = new TaskCompletionSource<(int, StatusResponse)>();
            _responsesActionDict[newGuid] = tcs;

            Task.Run(() =>
            {
                try
                {
                    _connection.InvokeAsync("CreateDocument", docName, userName, newGuid);
                }
                catch (Exception ex)
                {
                    // TODO: exception handling. Logging
                }
            });

            return tcs.Task;
        }

        /// <summary>
        /// Delete document by id
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="userName">User name</param>
        /// <returns>Status info</returns>
        public Task<StatusResponse> DeleteDocumentByIdAsync(int docId, string userName)
        {
            Guid newGuid = Guid.NewGuid();
            var tcs = new TaskCompletionSource<StatusResponse>();
            _responsesActionDict[newGuid] = tcs;

            Task.Run(() =>
            {
                try
                {
                    _connection.InvokeAsync("DeleteDocumentById", docId, userName, newGuid);
                }
                catch (Exception ex)
                {
                    // TODO: exception handling. Logging
                }
            });

            return tcs.Task;
        }

        /// <summary>
        /// Create shape in document
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="shape">Shape object</param>
        /// <param name="userName">User name</param>
        /// <returns>(Shape ID, status info)</returns>
        public Task<(int?, StatusResponse)> CreateShapeAsync(Shape shape, string userName)
        {
            var newGuid = Guid.NewGuid();
            var tcs = new TaskCompletionSource<(int?, StatusResponse)>();
            _responsesActionDict[newGuid] = tcs;

            Task.Run(() =>
            {
                try
                {
                    _connection.InvokeAsync("CreateShape", shape, userName, newGuid);
                }
                catch (Exception ex)
                {
                    // TODO: exception handling. Logging
                }
            });

            return tcs.Task;
        }

        /// <summary>
        /// Update shape in document
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="shape">Shape object</param>
        /// <param name="userName">User name</param>
        /// <returns>Status info</returns>
        public Task<StatusResponse> UpdateShapeAsync(Shape shape, string userName)
        {
            Guid newGuid = Guid.NewGuid();
            var tcs = new TaskCompletionSource<StatusResponse>();
            _responsesActionDict[newGuid] = tcs;

            Task.Run(() =>
            {
                try
                {
                    _connection.InvokeAsync("UpdateShape", shape, userName, newGuid);
                }
                catch (Exception ex)
                {
                    // TODO: exception handling. Logging
                }
            });

            return tcs.Task;
        }

        /// <summary>
        /// Delete shape in document
        /// </summary>
        /// <param name="docId">Document ID</param>
        /// <param name="shape">Shape object</param>
        /// <param name="userName">User name</param>
        /// <returns>Status info</returns>
        public Task<StatusResponse> DeleteShapeAsync(Shape shape, string userName)
        {
            Guid newGuid = Guid.NewGuid();
            var tcs = new TaskCompletionSource<StatusResponse>();
            _responsesActionDict[newGuid] = tcs;

            Task.Run(() =>
            {
                try
                {
                    _connection.InvokeAsync("DeleteShape", shape, userName, newGuid);
                }
                catch (Exception ex)
                {
                    // TODO: exception handling. Logging
                }
            });

            return tcs.Task;
        }

        private void InitConnection()
        {
            _connection.Reconnecting += error =>
            {
                OnReconnecting?.Invoke(error?.Message);

                return Task.CompletedTask;
            };

            _connection.Reconnected += connectionId =>
            {
                OnReconnected?.Invoke(connectionId);

                return Task.CompletedTask;
            };

            _connection.Closed += error =>
            {
                OnClosed?.Invoke(error?.Message);

                return Task.CompletedTask;
            };
        }

        private async Task<bool> ConnectionWithRetryAsync(CancellationToken token)
        {
            while (true)
            {
                try
                {
                    await _connection.StartAsync(token);
                    return true;
                }
                catch when (token.IsCancellationRequested)
                {
                    return false;
                }
                catch (Exception ex)
                {
                    // Failed to connect, trying again in 5000 ms.
                    await Task.Delay(5000);
                }
            }
        }

        private void RegisterFunctions()
        {
            _connection.On<DocumentList, string, Guid>("GetListDocuments", (list, userName, guid) =>
            {
                try
                {
                    if (_responsesActionDict.TryRemove(guid, out object tcs))
                        (tcs as TaskCompletionSource<DocumentList>)?.SetResult(list);

                    OnGetListDocuments?.Invoke(list, userName);
                }
                catch (Exception ex)
                {
                    //TODO logger
                }
            });

            _connection.On<Protocol.Common.Document, string, Guid>("GetDocumentById", (doc, userName, guid) =>
            {
                try
                {
                    if (_responsesActionDict.TryRemove(guid, out object tcs))
                        (tcs as TaskCompletionSource<Protocol.Common.Document>)?.SetResult(doc);

                    OnGetDocumentById?.Invoke(doc, userName);
                }
                catch (Exception ex)
                {
                    //TODO logger
                }
            });

            _connection.On<Protocol.Common.Document, StatusResponse, Guid>("CreateDocument", (document, status, guid) =>
            {
                try
                {
                    if (_responsesActionDict.TryRemove(guid, out object tcs))
                        (tcs as TaskCompletionSource<(int, StatusResponse)>)?.SetResult((document?.Header.Id ?? 0, status));

                    OnCreateDocument?.Invoke(document?.Header.Id ?? 0, document.Header.UserName, status);
                }
                catch (Exception ex)
                {
                    //TODO logger
                }
            });

            _connection.On<StatusResponse, string, Guid>("DeleteDocumentById", (status, userName, guid) =>
            {
                try
                {
                    if (_responsesActionDict.TryRemove(guid, out object tcs))
                        (tcs as TaskCompletionSource<StatusResponse>)?.SetResult(status);

                    OnDeleteDocumentById?.Invoke(status, userName);
                }
                catch (Exception ex)
                {
                    //TODO logger
                }
            });

            _connection.On<Shape, StatusResponse, Guid>("CreateShape", (shape, status, guid) =>
            {
                try
                {
                    if (_responsesActionDict.TryRemove(guid, out object tcs))
                        (tcs as TaskCompletionSource<(int?, StatusResponse)>)?.SetResult((shape?.Id, status));

                    OnCreateShape?.Invoke(shape, status);
                }
                catch (Exception ex)
                {
                    //TODO logger
                }
            });

            _connection.On<Shape, StatusResponse, Guid>("UpdateShape", (shape, status, guid) =>
            {
                try
                {
                    if (_responsesActionDict.TryRemove(guid, out object tcs))
                        (tcs as TaskCompletionSource<StatusResponse>)?.SetResult(status);

                    OnUpdateShape?.Invoke(shape, status);
                }
                catch
                {
                    //TODO logger
                }
            });

            _connection.On<Shape, StatusResponse, Guid>("DeleteShape", (shape, status, guid) =>
            {
                try
                {
                    if (_responsesActionDict.TryRemove(guid, out object tcs))
                        (tcs as TaskCompletionSource<StatusResponse>)?.SetResult(status);

                    OnDeleteShape?.Invoke(shape, status);
                }
                catch
                {
                    //TODO logger
                }
            });
        }

        public delegate void Reconnecting(string error);
        public delegate void Reconnected(string connectionId);
        public delegate void Closed(string error);
        public delegate void GetListDocuments(DocumentList documentsList, string userName);
        public delegate void GetDocumentById(Protocol.Common.Document doc, string userName);
        public delegate void CreateDocument(int docId, string userName, StatusResponse status);
        public delegate void DeleteDocumentById(StatusResponse status, string userName);
        public delegate void CreateShape(Shape shape, StatusResponse status);
        public delegate void UpdateShape(Shape shape, StatusResponse status);
        public delegate void DeleteShape(Shape shape, StatusResponse status);
    }
}
