using DataProvider;

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
            var handler = new CreateDocumentHandler { DbCtx = new PostgresContext() };

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
                DocumentId = 0
            });

            Assert.IsNotNull(result);
        }




    }
}