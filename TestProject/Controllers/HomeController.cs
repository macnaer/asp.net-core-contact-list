using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IContactRepository _contactRepository;

        public HomeController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            Contact model = _contactRepository.GetContact(1);
            Console.WriteLine("model ====>> " + model.Name);
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
