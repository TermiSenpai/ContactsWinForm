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
        
        AddContact addContact = new AddContact();
        
        public MainForm()
        {
            InitializeComponent();
        }

        #region EVENTS

        private void btnAdd_Click(object sender, EventArgs e)
        {
            openContactAddDialog();
        }
        #endregion


        #region PRIVATE METHODS

        private void openContactAddDialog()
        {
            addContact.ShowDialog();
        }

        #endregion
    }
}
