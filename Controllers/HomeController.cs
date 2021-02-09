using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Models.ViewModels;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {

        private IContactRepository _contactRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(IContactRepository contactRepository, IWebHostEnvironment hostingEnvironment)
        {
            _contactRepository = contactRepository;
            this.hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index()
        {
            var model = _contactRepository.GetAllContacts();
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = _contactRepository.GetContact(id);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(ContactCreateViewModel model)
        {
            Console.WriteLine(model.Photo);
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(this.hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }


                Contact newContact = new Contact
                {
                    Name = model.Name,
                    Position = model.Position,
                    Address = model.Address,
                    Avatar = uniqueFileName,
                    NickName = model.NickName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email

                };

                _contactRepository.AddContact(newContact);
                return RedirectToAction("details", new { id = newContact.Id });
            }

            return View();
        }
    }
}
