using Microsoft.AspNetCore.Http;
using shep = Service.Helpers.Clients.Shep.SendToShep;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using Service.Helpers.Helpers;
using Service.DATA.DataBase.PostgresSQL.OperationsDB;
using Service.Helpers.Clients;
using Service.Helpers.Classes.MO_RequestResponse;

namespace ClientService_Integration.Controllers
{
    public class MO_SendRequestController : Controller
    {
        OperationRepo _repo;
        shep _shep;

        public MO_SendRequestController(OperationRepo repo, shep shep)
        {
            _repo = repo;
            _shep = shep;
        }

        [HttpGet]
        public IActionResult SendRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendRequest(string iin)
        {
            try
            {
                Logger.Log.Debug("RequestUser = " + iin);

                //Отправляем по синхронному каналу ШЭП 
                var response = _shep.SignXmlAndSend(iin);

                MO_DataResponse data = (MO_DataResponse)response.response.responseData.data;
                ViewBag.Message = string.Format("Send IIN");


                _repo.AddDB_Candidates(data);

                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex);
            }
        }

        public IActionResult ModalResponse()
        {
            return View();
        }
    }
}
