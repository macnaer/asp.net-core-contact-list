using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models.ViewModels
{
    public class ContactCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public IFormFile Photo { get; set; }
        public string NickName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
