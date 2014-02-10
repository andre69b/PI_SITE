using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicModelLibrary;

namespace LogicLibrary
{
    public class ContactLogic
    {
        private static List<Contact> _Contact =
            new List<Contact>
            {

            };

        public IEnumerable<Contact> GetAll()
        {
            return _Contact;
        }

        public void AddContact(Contact contact)
        {
            _Contact.Add(contact);
        }
    }
}
