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

    public partial class MainForm : Form
    {
        private BusinessLogicLayer _bussinessLogicLayer = new BusinessLogicLayer();

        
        public MainForm()
        {
            InitializeComponent();
        }

        #region EVENTS

        private void btnAdd_Click(object sender, EventArgs e)
        {
            openContactAddDialog();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            getDB();
        }
        #endregion


        #region PRIVATE METHODS

        private void openContactAddDialog()
        {
            AddContact addContact = new AddContact();
            addContact.ShowDialog(this);
        }

        public void getDB(string searchText = null)
        {
            List<Contact> contacts = _bussinessLogicLayer.GetContacts(searchText);
            gridContacts.DataSource = contacts;
        }

        #endregion

        private Contact contactFromRow(DataGridViewCellEventArgs e)
        {
            return new Contact
            {
                ID = int.Parse(gridContacts.Rows[e.RowIndex].Cells[0].Value.ToString()),
                FirstName = gridContacts.Rows[e.RowIndex].Cells[1].Value.ToString(),
                LastName = gridContacts.Rows[e.RowIndex].Cells[2].Value.ToString(),
                Phone = gridContacts.Rows[e.RowIndex].Cells[3].Value.ToString(),
                Address = gridContacts.Rows[e.RowIndex].Cells[4].Value.ToString()
            };
        }

        private void gridContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = (DataGridViewLinkCell)gridContacts.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if(cell.Value.ToString() == "Edit")
            {
                AddContact contactDetails = new AddContact();
                Contact contact = contactFromRow(e);
                contactDetails.loadContact(contact);
                contactDetails.ShowDialog(this);
            }
            else if (cell.Value.ToString() == "Delete")
            {
                int id = int.Parse(gridContacts.Rows[e.RowIndex].Cells[0].Value.ToString());
                DeleteContact(id);
                getDB();
            }

        }

        private void DeleteContact(int id)
        {
            _bussinessLogicLayer.DeleteContact(id);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getDB(searchBox.Text);
            searchBox.Text = string.Empty;
        }
    }
}
