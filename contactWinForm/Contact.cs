using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactWinForm
{
    public class Contact
    {
        DataAccessLayer _dataAccessLayer = new DataAccessLayer();
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public void saveContact()
        {
            if (this.ID == 0) _dataAccessLayer.InsertContact(this);
            else _dataAccessLayer.UpdateContact(this);
        }

        public void DeleteContact(int id)
        {
            _dataAccessLayer.DeleteContact(id);
        }
    }

}
