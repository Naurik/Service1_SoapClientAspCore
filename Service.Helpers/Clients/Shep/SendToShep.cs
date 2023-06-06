using ISynchChannelShep;
using System.Text;
using Service.Helpers.Helpers;
using Service.Helpers.Models;
using static Service.Helpers.Utils.Signing;

namespace Service.Helpers.Clients.Shep
{
    
    public class SendToShep
    {
        StringXml _xml;
        public SendToShep(StringXml xml) { _xml = xml; }
        public string SignXmlAndSend(string iin)
        {
            var reguestStr = _xml.StringXmlRequest(iin);
            var model = new RequestModel() { Attr = Guid.NewGuid().ToString(), Xml = reguestStr };
            var sign = SignWSSE(model);
            var responseResult = SendRequestToShep(sign);
            return responseResult;
        }
        public string SendRequestToShep(string signXml)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, SslPolicyErrors) => true
            };

            SendMessageResponse messageResponse;
            var resp = "";

            using ( var client = new HttpClient(httpClientHandler)) 
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("http://195.12.113.7/bip-sync-wss-gost/"),
                    Method = HttpMethod.Post
                };

                request.Content = new StringContent(signXml ?? string.Empty, Encoding.UTF8, "text/xml");

                HttpResponseMessage response = client.SendAsync(request).Result;

                resp = response.Content.ReadAsStringAsync().Result.ToString();
                //var result = response.Content.ReadAsStringAsync().Result.ToString();

                //XmlSerializer xmlSerializer = new XmlSerializer(typeof(SendMessageResponse));

                //using (StringReader reader = new StringReader(result))
                //{
                //    //messageResponse = xmlSerializer.Deserialize(reader).ToString();
                //    resp = xmlSerializer.Deserialize(reader).ToString();
                //}

            };
            return resp;
        }
        

        
    }
}
