using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockSystems
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Products_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-BVU2UB5\\ISHSQL;Initial Catalog=Stock;Integrated Security=True");
            //Insert logic
            con.Open();
            bool status = false;
            if (comboBox1.SelectedIndex == 0)
            {
                status = true;
            }
            else {
                status = false;
            }
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Products]
           ([productCode]
           ,[productName]
           ,[productStatus])
            VALUES
           ('" + textBox1.Text +"','" + textBox2.Text +"','" + status +"')", con);
           cmd.ExecuteNonQuery();
           con.Close();

           //reading data
           SqlDataAdapter sda = new SqlDataAdapter(" select * from [stock].[dbo].[Products]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["productCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["productName"].ToString();
                if ((bool)item["productStatus"])
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
