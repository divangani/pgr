using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sny
{
    public partial class frm_home : Form
    {
        public frm_home()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_log lg = new frm_log();
            lg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_add_emp et = new frm_add_emp();
            et.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_add_user ur = new frm_add_user();
            ur.ShowDialog();

        }
    }
}
