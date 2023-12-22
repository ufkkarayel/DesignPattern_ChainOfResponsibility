using DesignPattern_ChainOfResponsibility.ChainOfResponsibility;
using DesignPattern_ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern_ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer= new Treasurer();
            Employee managerAssistant = new ManagerAsistant();
            Employee manager = new Manager();
            Employee areaDirector= new AreaDirector();

            treasurer.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector);
            treasurer.ProcessRequest(model);
            return View();

        }
    }
}
