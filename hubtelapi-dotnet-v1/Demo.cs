using System;
using hubtelapi_dotnet_v1.Hubtel;

namespace hubtelapi_dotnet_v1
{
    internal class Demo
    {
        private static void Main(string[] args)
        {
            const string clientId = "mcjntyvj";
            const string clientSecret = "csidlcvn";


            try {
                var host = new ApiHost(new BasicAuth(clientId, clientSecret));
                var messageApi = new MessagingApi(host);
                MessageResponse msg = messageApi.SendQuickMessage("BPCI", "+233274323816", "Welcome to BPCI HQ!", false);
                Console.WriteLine(msg.Status);         
            }
            catch (Exception e) {
                if (e.GetType() == typeof (HttpRequestException)) {
                    var ex = e as HttpRequestException;
                    if (ex != null && ex.HttpResponse != null) {
                        Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
                    }
                }
                throw;
            }

            Console.ReadKey();
        }
    }
}