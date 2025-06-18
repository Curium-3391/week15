using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace week15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\week15\week15\week15\Northwind.mdf;Integrated Security=True";
            cn.Open();
            String sql = "Select 公司名稱, 連絡人, 連絡人職稱, 電話 from 客戶";
            if (textBox2.Text != "")
            {
                sql = "Select 公司名稱,連絡人,連絡人職稱,電話 from 客戶 Where 公司名稱 Like '%" + textBox2.Text + "%'";
            }
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            for (int i = 0; i < dr.FieldCount; i++)
            {
                textBox1.Text += dr.GetName(i) + "\t";
            }
            textBox1.Text += "\r\n============================================\r\n";
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    if(dr.GetName(i) == "連絡人")
                    {
                        char[] name = dr[i].ToString().ToCharArray();
                        name[1] = 'O';
                        textBox1.Text += new string(name) + "\t";
                    }
                    else
                    {
                        textBox1.Text += dr[i].ToString() + "\t";
                    }  
                }
                textBox1.Text += "\r\n";
            }
            cn.Close();
        }
    }
}
