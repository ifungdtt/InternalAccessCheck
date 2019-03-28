using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace InternalAccessCheck
{
    public class RestService
    {
        private string TAG = "INTERNAL_ACCESS_CHECK";
        HttpClient client;


        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<bool> IsReachable(string target)
        {
            try
            {

                Console.WriteLine(TAG + ":IsReachable");
                var connectivity = CrossConnectivity.Current;
                if (!connectivity.IsConnected)
                {
                    Console.WriteLine(TAG + ":!connectivity.IsConnected");
                    return false;
                }
                else
                {
                    Console.WriteLine(TAG + ":connectivity.IsConnected");
                }

                var reachable = await connectivity.IsRemoteReachable(target);
                Console.WriteLine(TAG + ":reachable - "+reachable);
                return reachable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(TAG + ":" + ex.Message + ", " + ex.StackTrace);
                return false;
            }
        }

    }
}