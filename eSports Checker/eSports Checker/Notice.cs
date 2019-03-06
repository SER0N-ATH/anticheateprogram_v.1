using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSports_Checker
{
    public partial class Notice : Form
    {
        public Notice()
        {
            InitializeComponent();
        }

        private void Confirm_CheckedChanged(object sender, EventArgs e)
        {
          
            this.Hide();
            var Dashboard = new Dashboard();
            Dashboard.Closed += (s, args) => this.Close();
            Dashboard.Show();
        }
    }
}
