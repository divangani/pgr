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
    public partial class frm_add_user : Form
    {
        public frm_add_user()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
           /// clz_con.con.Open();
            string qry = "SELECT * FROM tbl_log";
            SqlDataAdapter dap = new SqlDataAdapter(qry,clz_con.con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dgv_user.DataSource = dt;
            dgv_user.Refresh();

            dap.Dispose();
            dt.Dispose();

           // clz_con.con.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            clz_con.con.Open();
            if (txt_name.Text != "" && txt_pwd.Text != "")
            {
          
                if (txt_pwd.Text==txt_con_pwd.Text)
                {
                    string query = "INSERT INTO tbl_log (un,pwd) VALUES ('" + txt_name.Text + "','" + txt_pwd.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, clz_con.con);
                    int flag = cmd.ExecuteNonQuery();

                    if (flag > 0)
                    {

                        MessageBox.Show("Row added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();

                    }
                    else MessageBox.Show("Row not added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmd.Dispose();
                }
                else MessageBox.Show("Both password should be in same", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Insert the data", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
            clz_con.con.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_id.Clear();

           txt_name. Clear();
           txt_pwd.Clear();
           txt_con_pwd.Clear();
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clz_con.con.Open();
            int id = Convert.ToInt32(txt_id.Text);


            string qry = "UPDATE tbl_log SET un='" + txt_name.Text + "',pwd='" + txt_pwd.Text + "' WHERE id="+id+"";
            SqlCommand cmd = new SqlCommand(qry, clz_con.con);
            if (txt_con_pwd.Text != "")
            {
                int flag = cmd.ExecuteNonQuery();

                if (flag > 0)
                {
                    MessageBox.Show("Row Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();

                }
                else MessageBox.Show("Row not Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmd.Dispose();
            }
            else MessageBox.Show("Both Password should be in same", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            clz_con.con.Close();

        }

        private void dgv_user_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dgv_user.CurrentRow.Cells[0].Value.ToString();
            txt_name.Text = dgv_user.CurrentRow.Cells[1].Value.ToString();
            txt_pwd.Text = dgv_user.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_name.Text != "" && txt_pwd.Text != "")
            {

                clz_con.con.Open();
                int d = Convert.ToInt32(txt_id.Text);
                string q = "DELETE FROM tbl_log WHERE id=" + d + "";
                SqlCommand cmd = new SqlCommand(q, clz_con.con);
                int fg = cmd.ExecuteNonQuery();
                if (fg > 0)
                {
                    MessageBox.Show("Row Delated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();


                }
                else MessageBox.Show("Row not Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmd.Dispose();

                clz_con.con.Close();
            }
            else MessageBox.Show("Insert the data", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_home gf = new frm_home();
            gf.ShowDialog();
        }
    }
}
