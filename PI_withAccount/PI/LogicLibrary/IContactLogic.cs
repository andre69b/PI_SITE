using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicModelLibrary;

namespace LogicLibrary
{
    public interface IContactLogic
    {
        IEnumerable<Contact> GetAll();
        void AddContact(Contact contact);
    }
}
