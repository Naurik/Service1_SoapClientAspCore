using System;
using System.Text;

namespace Service.Helpers.Config{

	public static class CertificateHelper
    {
        public static bool CheckSigningXmlData(string xml)
        {
            try
            {
                var bytes = Encoding.UTF8.GetBytes(xml);
                //if (!CertificateChecker.StreamXmlCertificateIsValid(bytes))
                //{
                //    Logger.Log.Debug("Сертификат не прошел проверку");
                //    return false;
                //}
                return true;
            }
            catch(Exception ex)
            {
                Logger.Log.Debug("Ошибка в процессе проверки подписанных данных", ex);
                return false;
            }
        }
    }

}