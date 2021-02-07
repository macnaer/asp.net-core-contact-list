using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class SQLContactRepository : IContactRepository
    {
        private readonly AppDbContext context;

        public SQLContactRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Contact AddContact(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return contact;
        }

        public Contact DeleteContact(int Id)
        {
            Contact contact = context.Contacts.Find(Id);
            if (contact != null)
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
            }
            return contact;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return context.Contacts;
        }

        public Contact GetContact(int id)
        {
            return context.Contacts.Find(id);
        }

        public Contact UpdateContact(Contact contactChange)
        {
            var contact = context.Contacts.Attach(contactChange);
            contact.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return contactChange;
        }
    }
}
