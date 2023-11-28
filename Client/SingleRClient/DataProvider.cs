using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Client.SingleRClient
{
    public class DataProvider: IDisposable
    {
        private static DataProvider _instance;
        
        private HubConnection _connection;

        private DataProvider()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:8000/document")
                .WithAutomaticReconnect()
                .Build();

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
        public Reconnecting OnReconnecting { get; set; }
        public delegate void Reconnecting(string error);

        /// <summary>
        /// Notify users the connection was reestablished.
        /// Start dequeuing messages queued while resonnecting if any.
        /// </summary>
        public Reconnected OnReconnected { get; set; }
        public delegate void Reconnected(string connectionId);

        /// <summary>
        /// Notify users  the connection lost;
        /// </summary>
        public Closed OnClosed { get; set; }
        public delegate void Closed(string error);

        public GetListDocuments OnGetListDocuments { get; set; }
        public delegate void GetListDocuments(List<string> documentsList, string userName);

        public GetDocumentById OnGetDocumentById { get; set; }
        public delegate void GetDocumentById(string doc, string userName);

        public CreateDocument OnCreateDocument { get; set; }
        public delegate void CreateDocument(int docId, string userName);

        public DeleteDocumentById OnDeleteDocumentById { get; set; }
        public delegate void DeleteDocumentById(bool success, string userName);

        public CreateFigure OnCreateFigure { get; set; }
        public delegate void CreateFigure(int docId, string fugureInfo, int? figureId, string userName);

        public UpdateFigure OnUpdateFigure { get; set; }
        public delegate void UpdateFigure(int docId, string fugureInfo, int? figureId, string userName);

        public DeleteFigure OnDeleteFigure { get; set; }
        public delegate void DeleteFigure(int docId, string fugureInfo, int? figureId, string userName);

        /// <summary>
        /// Get list documents
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns></returns>
        public async Task GetDocumentsListAsync(string userName)
        {
            try
            {
                await _connection.InvokeAsync("GetListDocuments", userName);
            }
            catch (Exception ex)
            {
                // TODO: exception handling. Logging
            }
        }

        /// <summary>
        /// Get document by ID
        /// </summary>
        /// <param name="documentId">ID Document</param>
        /// <param name="userName">User name</param>
        /// <returns></returns>
        public async Task GetDocumentByIdAsync(int documentId, string userName)
        {
            try
            {
                await _connection.InvokeAsync("GetDocumentById", documentId, userName);
            }
            catch (Exception ex)
            {
                // TODO: exception handling. Logging
            }
        }

        /// <summary>
        /// Create document
        /// </summary>
        /// <param name="docName">Document name</param>
        /// <param name="userName">User name</param>
        /// <returns></returns>
        public async Task CreateDocumentAsync(string docName, string userName)
        {
            try
            {
                await _connection.InvokeAsync("CreateDocument", docName, userName);
            }
            catch (Exception ex)
            {
                // TODO: exception handling. Logging
            }
        }

        /// <summary>
        /// Delete document by id
        /// </summary>
        /// <param name="idDoc">Document ID</param>
        /// <param name="userName">User name</param>
        /// <returns></returns>
        public async Task DeleteDocumentByIdAsync(int idDoc, string userName)
        {
            try
            {
                await _connection.InvokeAsync("DeleteDocumentById", idDoc, userName);
            }
            catch (Exception ex)
            {
                // TODO: exception handling. Logging
            }
        }

        /// <summary>
        /// Create figure in document
        /// </summary>
        /// <param name="idDoc">Document ID</param>
        /// <param name="figureInfo">Information about figure (coords, type) in JSON format</param>
        /// <param name="userName">User name</param>
        /// <returns></returns>
        public async Task CreateFigureAsync(int idDoc, string figureInfo, string userName)
        {
            try
            {
                await _connection.InvokeAsync("CreateFigure", idDoc, figureInfo, userName);
            }
            catch (Exception ex)
            {
                // TODO: exception handling. Logging
            }
        }

        /// <summary>
        /// Update figure in document
        /// </summary>
        /// <param name="idDoc">Document ID</param>
        /// <param name="figureInfo">Information about figure (coords, type) in JSON format</param>
        /// <param name="userName">User name</param>
        /// <returns></returns>
        public async Task UpdateFigureAsync(int idDoc, string figureInfo, string userName)
        {
            try
            {
                await _connection.InvokeAsync("UpdateFigure", idDoc, figureInfo, userName);
            }
            catch (Exception ex)
            {
                // TODO: exception handling. Logging
            }
        }

        /// <summary>
        /// Delete figure in document
        /// </summary>
        /// <param name="idDoc">Document ID</param>
        /// <param name="figureInfo">Information about figure (coords, type) in JSON format</param>
        /// <param name="userName">User name</param>
        /// <returns></returns>
        public async Task DeleteFigureAsync(int idDoc, string figureInfo, string userName)
        {
            try
            {
                await _connection.InvokeAsync("DeleteFigure", idDoc, figureInfo, userName);
            }
            catch (Exception ex)
            {
                // TODO: exception handling. Logging
            }
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
            while(true)
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
                catch
                {
                    // Failed to connect, trying again in 5000 ms.
                    await Task.Delay(5000);
                }
            }
        }

        private void RegisterFunctions()
        {
            _connection.On<List<string>, string>("GetListDocuments", (list, userName) =>
            {
                OnGetListDocuments?.Invoke(list, userName);
            });

            _connection.On<string, string>("GetDocumentById", (doc, userName) =>
            {
                OnGetDocumentById?.Invoke(doc, userName);
            });

            _connection.On<int, string>("CreateDocument", (docId, userName) =>
            {
                OnCreateDocument?.Invoke(docId, userName);
            });

            _connection.On<bool, string>("DeleteDocumentById", (success, userName) =>
            {
                OnDeleteDocumentById?.Invoke(success, userName);
            });

            _connection.On<int, string, int?, string>("CreateFigure", (docId, figureInfo, figureId, userName) =>
            {
                OnCreateFigure?.Invoke(docId, figureInfo, figureId, userName);
            });

            _connection.On<int, string, int?, string>("UpdateFigure", (docId, figureInfo, figureId, userName) =>
            {
                OnUpdateFigure?.Invoke(docId, figureInfo, figureId, userName);
            });

            _connection.On<int, string, int?, string>("DeleteFigure", (docId, figureInfo, figureId, userName) =>
            {
                OnDeleteFigure?.Invoke(docId, figureInfo, figureId, userName);
            });
        }
    }
}
