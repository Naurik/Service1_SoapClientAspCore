using Microsoft.AspNetCore.Mvc;
using Service.DATA.DataBase.PostgresSQL.OperationsDB;

namespace ClientService_Integration.Controllers
{
    public class GetAllDataController : Controller
    {
        OperationRepo _repo;
        public GetAllDataController(OperationRepo repo)
        {
            _repo = repo;
        }

        public IActionResult GetAll()
        {
            var list = _repo.GetAllCandidates();

            return View(list);
        }
    }
}
