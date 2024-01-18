using Protocol.Common;
using SingleRClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XamlVectorGraphicEditor
{
    internal static class Context
    {
        private static IDataProvider _instance;

        static Context() {
            UserName = Environment.UserName;
        }

        public static async Task<IDataProvider> Init(CancellationToken ct)
        {

#if MOCK
            _instance = new APIMock();
#else
            
            _instance = await SingleRClient.DataProvider.GetInstanceAsync(ct);
#endif
            
            return _instance;
        }

        public static IDataProvider DataProvider()
        {
            return _instance;
        }

        public static string UserName { get; set; }

        /// <summary>
        /// Текущий документ
        /// </summary>
        public static Document Document { get; set; } 
    }
}
