using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public interface IContactRepository
    {
        Contact GetContact(int id);
        IEnumerable<Contact> GetAllContacts();
        Contact AddContact(Contact contact);
        Contact UpdateContact(Contact contact);
        Contact DeleteContact(int Id);
    }
}
