using DataProvider;

namespace apidb.Tests
{
    [TestClass]
    public class DbTest
    {
        PostgresContext ctx;

        [TestMethod]
        public void CreateDocumentTest()
        {
            ctx = new PostgresContext();
            var handler = new CreateDocumentHandler(ctx);

            var result = handler.HandleRequest(new CreateDocumentRequest
            {
                DocumentName = "document",
                UserName = "user"
            });


            //Task.Run(async () => {
            //    var result = await handler.HandleRequest(new CreateDocumentRequest
            //    {
            //        DocumentName = "document",
            //        UserName = "user"
            //    });
            //});
        }
    }
}