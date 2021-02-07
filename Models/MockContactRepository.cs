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
                { Id = 1, Name = "Camilla Tery", Position = "Software Engeneer at SoftServe", Address = "Rivne, Soborna street", Avatar = "avatar3.png", NickName="CamT", PhoneNumber="+38-099-784-51-11", Email="cam@gmail.com" },
            new Contact()
                { Id = 2, Name = "Linus Torvalds", Position = "Linux kernel CTO", Address = "San Francisco, Banderu street", Avatar = "avatar2.png", NickName="LT", PhoneNumber="+38-068-784-51-12", Email="linus@kernel.com" },

            };  
        }
        public Contact GetContact(int id)
        {
            return _contactList.FirstOrDefault(e => e.Id == id);
        }
        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactList;
        }
        public Contact AddContact(Contact contact)
        {
            contact.Id = _contactList.Max(e => e.Id) + 1;
            _contactList.Add(contact);
            return contact;
        }

        public Contact UpdateContact(Contact contactChange)
        {
            Contact contact = _contactList.FirstOrDefault(e => e.Id == contactChange.Id);
            if (contact != null)
            {
                contact.Name = contactChange.Name;
                contact.Email = contactChange.Email;
                contact.Address = contactChange.Address;
                contact.Avatar = contactChange.Avatar;
                contact.NickName = contactChange.NickName;
                contact.Position = contactChange.Position;
            }
            return contact;
        }

        public Contact DeleteContact(int Id)
        {
            Contact contact = _contactList.FirstOrDefault(e => e.Id == Id);
            if (contact != null)
            {
                _contactList.Remove(contact);
            }
            return contact;
        }
    }
}
