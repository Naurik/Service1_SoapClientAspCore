using ISynchChannelHttpService;
using Service.Helpers.Extensions;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace Service.Helpers.Config{

	public static class ConfigHelper{


		public static string ConnectionString {
			get  {
				return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			}
		}


		public static string ShepEndPoint{
			get {
				string? endpoint = ConfigurationManager.AppSettings["endPointShep"];
                if (!string.IsNullOrEmpty(endpoint))
                {
                    endpoint = "";
                    return endpoint;
                }
                return endpoint;
			}
		}


        public static Boolean IsWssEnabled {
            get {
                var enabled = false;
                    var isWssEnabled = ConfigurationManager.AppSettings["IsWssEnabled"];
                if (!string.IsNullOrEmpty(isWssEnabled) && Boolean.TryParse(isWssEnabled, out enabled))
                    return enabled;
                return enabled;
            }
        }

        public static bool verifySignature {
            get {
                var verifySignature = ConfigurationManager.AppSettings["verifySignature"];
                if (!string.IsNullOrEmpty(verifySignature) && verifySignature.ToLower().Equals("true"))
                    return true;
                return false;
            }
        }

        public static bool IsTest
        {
            get
            {
                var isTest = ConfigurationManager.AppSettings["isTest"];
                if(!isTest.IsNullOrEmpty() && isTest.ToLower().Equals("true"))
                {
                    return true;
                }
                return false;
            }
        }

        public static SendMessageResponse Error(string errorMessage)
        {
            return new SendMessageResponse
            {
                response = new SyncSendMessageResponse
                {
                    responseData = new ResponseData
                    {
                        data = errorMessage
                    }
                }
            };
        }

        public static SendMessageResponse Success(string successMessage)
        {
            return new SendMessageResponse
            {
                response = new SyncSendMessageResponse
                {
                    responseData = new ResponseData
                    {
                        data = successMessage
                    }
                }
            };
        }
    }

}