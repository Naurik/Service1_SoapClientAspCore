namespace Service.Helpers.Helpers
{
    public class StringXml
    {
        public string StringXmlRequest(string iin) 
        {
            var guid = Guid.NewGuid();
            var dateTime = DateTime.Now;
            string login = "pshep";
            string password = "pshep";
            var request =
                    $"<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:typ=\"http://bip.bee.kz/SyncChannel/v10/Types\">" +
                        $"<soapenv:Body  Id=\"{guid}\">" +
                            $"<typ:SendMessage>" +
                                $"<request>" +
                                    $"<requestInfo>" +
                                        $"<messageId>{Guid.NewGuid()}</messageId>" +
                                        $"<serviceId>test</serviceId>" +
                                        $"<messageDate>{dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz")}</messageDate>" +
                                        $"<sender>" +
                                        $"<senderId>{login}</senderId>" +
                                        $"<password>{password}</password>" +
                                        $"</sender>" +
                                        $"<sessionId>{Guid.NewGuid()}</sessionId>" +
                                    $"</requestInfo>" +
                                    $"<requestData>" +
                                    $"<data>" +
                                        $"<iin>{iin}</iin>" +
                                    $"</data>" +
                                    $"</requestData>" +
                                $"</request>" +
                            $"</typ:SendMessage>" +
                        $"</soapenv:Body>" +
                    $"</soapenv:Envelope>";

            return request;
        }
    }
}
