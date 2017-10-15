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
    public partial class frm_add_emp : Form
    {
        public frm_add_emp()
        {
            InitializeComponent();
           // MessageBox.Show("Do not use text into the numbers fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            aa();
        }
        public void aa()
        {

            string q = "SELECT * FROM tbl_emp";
            SqlDataAdapter dap = new SqlDataAdapter(q, clz_con.con);
            DataTable dt = new DataTable(); dap.Fill(dt);
         
            dgv_emp.DataSource = dt;
            dgv_emp.Refresh();
            dap.Dispose();
            dt.Dispose();
     

        }


        private void button3_Click(object sender, EventArgs e)
        {
            
                if (txt_name.Text != "" && txt_address.Text != "")
                {
                    if (txt_age.Text != "" && txt_c_no.Text != "")
                    {

                        clz_con.con.Open();


                        int age = Convert.ToInt32(txt_age.Text);
                        int tel = Convert.ToInt32(txt_c_no.Text);
                        string q = "INSERT INTO tbl_emp (name,address,age,tel) VALUES ('" + txt_name.Text + "','" + txt_address.Text + "'," + age + "," + tel + ")";
                        SqlCommand cmd = new SqlCommand(q, clz_con.con);
                        int a = cmd.ExecuteNonQuery();

                        if (a > 0)
                        {
                            MessageBox.Show("Row added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            aa();
                        }
                        else MessageBox.Show("Row not added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmd.Dispose();
                        clz_con.con.Close();
                    }
                    else MessageBox.Show("Insert the data", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Insert the data", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
               
                   

              

          
        }

        private void dgv_emp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dgv_emp.CurrentRow.Cells[0].Value.ToString();
            txt_name.Text = dgv_emp.CurrentRow.Cells[1].Value.ToString();
            txt_address.Text = dgv_emp.CurrentRow.Cells[2].Value.ToString();
            txt_age.Text = dgv_emp.CurrentRow.Cells[3].Value.ToString();
            txt_c_no.Text = dgv_emp.CurrentRow.Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        { clz_con.con .Open();
        int age = Convert.ToInt32(txt_age.Text);
        int tel = Convert.ToInt32(txt_c_no.Text);
        int id = Convert.ToInt32(txt_id.Text);
        string q = "UPDATE tbl_emp SET name='" + txt_name.Text + "',address='" + txt_address.Text + "',age=" + age + ",tel=" + tel + "WHERE id="+id+"";
        SqlCommand cmd = new SqlCommand(q, clz_con.con);

        int flag = cmd.ExecuteNonQuery();

        if (flag > 0)
        {
            MessageBox.Show("Row Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            aa();

        }
        else MessageBox.Show("Row not Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        cmd.Dispose();
            clz_con.con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clz_con.con.Open();
            int dd = Convert.ToInt32(txt_id.Text);
            string q="DELETE FROM tbl_emp WHERE id= "+dd+" ";
            SqlCommand cmd = new SqlCommand(q, clz_con.con);
            int gg = cmd.ExecuteNonQuery();
            if (gg > 0)
            {

                MessageBox.Show("Row Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                aa();

            }
            else MessageBox.Show("Row not Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmd.Dispose();
            clz_con.con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_home gj = new frm_home();
            gj.ShowDialog();

        }
    }
}
