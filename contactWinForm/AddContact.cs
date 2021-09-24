using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contactWinForm
{
    public partial class AddContact : Form
    {
        Contact _contact;

        private BusinessLogicLayer _businessLogicLayer;

        public AddContact()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeDialog();
        }

        public void closeDialog()
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            newContact();
            this.Close();
            ((MainForm)this.Owner).getDB();
        }

        private void newContact()
        {
            Contact contact = new Contact();

            contact.FirstName = nameBox.Text;
            contact.LastName = lastNameBox.Text;
            contact.Phone = phoneBox.Text;
            contact.Address = addressBox.Text;

            contact.ID = _contact != null ? _contact.ID : 0;

            _businessLogicLayer.saveContact(contact);
        }

        public void loadContact(Contact contact)
        {
            _contact = contact;

            if (contact != null)
            {
                clearForm();
                nameBox.Text = contact.FirstName;
                lastNameBox.Text = contact.LastName;
                phoneBox.Text = contact.Phone;
                addressBox.Text = contact.Address;
            }
        }
        
        public void clearForm()
        {
            nameBox.Text = string.Empty;
            lastNameBox.Text = string.Empty;
            phoneBox.Text = string.Empty;
            addressBox.Text = string.Empty;
        }
    }
}
