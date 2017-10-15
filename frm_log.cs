using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sny
{
    public partial class frm_log : Form
    {
        public frm_log()
        {
            InitializeComponent();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clz_con.con.Open();

            string q = "SELECT un,pwd FROM tbl_log";
            SqlCommand cmd = new SqlCommand(q, clz_con.con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string un = dr.GetValue(0).ToString();
                string pwd = dr.GetValue(1).ToString();

                if (un == txt_un.Text && pwd == txt_pwd.Text)
                {

                    frm_home hh = new frm_home();
                    hh.ShowDialog();
                
                
                }


            }

            dr.Dispose();

            cmd.Dispose();


            clz_con.con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
    }
}
