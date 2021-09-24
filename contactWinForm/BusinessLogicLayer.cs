using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactWinForm
{
    public class BusinessLogicLayer
    {

        private DataAccessLayer _dataAccessLayer;

        public BusinessLogicLayer()
        {
            _dataAccessLayer = new DataAccessLayer();
        }

        /*public Contact saveContact(Contact contact)
        {
            if (contact.ID == 0) _dataAccessLayer.InsertContact(contact);
            else _dataAccessLayer.UpdateContact(contact);

            return contact;
        }*/

        public List<Contact> GetContacts(string searchText = null)
        {
            return _dataAccessLayer.GetContacts(searchText);
        }

        public void DeleteContact(int id)
        {
            _dataAccessLayer.DeleteContact(id);
        }

    }
}
