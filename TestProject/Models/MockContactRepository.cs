using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class MockContactRepository : IContactRepository
    {
        private List<Contact> _contactList;
        public MockContactRepository()
        {
            _contactList = new List<Contact>() {
            new Contact()
                { Id = 1, Name = "Camilla Tery", Position = "Software Engeneer at SoftServe", Address = "Rivne, Soborna street", Avatar = "1", NickName="CamT", PhoneNumber="+38-099-784-51-11", Email="cam@gmail.com" }
            };
        }
        public Contact GetContact(int id)
        {
            return _contactList.FirstOrDefault(e => e.Id == id);
        }
    }
}
