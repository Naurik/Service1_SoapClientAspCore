using Service.Helper.Classes.MO_RequestResponse;
using System;
using System.Configuration;
using Service.Helper;
using Service.Helper.Clients.ShepSynchService;
using SenderInfo = Service.Helper.Clients.ShepSynchService.SenderInfo;
using SendMessageResponse = Service.Helper.Clients.ShepSynchService.SendMessageResponse;
using SendMessage = Service.Helper.Clients.ShepSynchService.SendMessage;
using Service.Helper.Extensions;

namespace Service.SHEP.ShepSychService
{
    public static class ShepSychService
    {
        /// <summary>
        /// Отправка пакета(сообщения) по универсальному синхронному каналу ШЭП
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static SendMessageResponse SendMessage(SendMessage message)
        {
            var service = new ISyncChannelHttpService
            {
                Url = ConfigurationManager.AppSettings["endPoint_ShepSynchService"]
            };
            var result = service.SendMessage(message);
            return result;
        }

        /// <summary>
        /// Отправка запроса
        /// </summary>
        public static MO_DataResponse SendRequest(object moSendRequest)
        {
            try
            {
                var request = new SendMessage
                {
                    request = new SyncSendMessageRequest
                    {
                        requestInfo = new SyncMessageInfo
                        {
                            messageDate = DateTime.Now,
                            messageId = Guid.NewGuid().ToString(),
                            serviceId = "test",
                            sender = new SenderInfo
                            {
                                senderId = "pshep",
                                password = "pshep"
                            }
                        },
                        requestData = new MessageData
                        {
                            data = moSendRequest
                        }
                    }
                };

                //В логах запишется какой запрос отправляем
                Logger.Log.Info(request.SerializeObject(new Type[] { typeof(MO_DataRequest) }));

                var response = SendMessage(request);

                //В логах запишется какой ответ приходит
                Logger.Log.Info(response.SerializeObject(new Type[] { typeof(MO_DataResponse) }));

                if ((response == null) || (response.response == null) || (response.response.responseData == null) || response.response.responseData.data == null)
                {
                    Logger.Log.Debug("Нет данных ответа");
                    return new MO_DataResponse
                    {
                        //Здесь хотя бы должен был быть код и сообщение при ошибке, но этого нет в хсд ответа
                    };
                }

                if (!(response.response.responseData.data is MO_DataResponse))
                {
                    Logger.Log.Debug("Не удалось привести ответ к заданному типу");
                    return new MO_DataResponse
                    {
                        //Здесь хотя бы должен был быть код и сообщение при ошибке, но этого нет в хсд ответа
                    };
                }
                return response.response.responseData.data as MO_DataResponse;
            }
            catch (Exception ex)
            {
                Logger.Log.Debug("Системная Ошибка отправки в МО", ex);
                if (ex.InnerException != null)
                    Logger.Log.Debug("InnerException=", ex.InnerException);
                return new MO_DataResponse
                {
                    //Здесь хотя бы должен был быть код и сообщение при ошибке, но этого нет в хсд ответа
                };
            }
        }
    }
}
