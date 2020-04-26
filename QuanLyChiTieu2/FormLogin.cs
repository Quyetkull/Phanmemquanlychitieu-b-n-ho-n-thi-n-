using QuanLyChiTieu2.DAO;
using QuanLyChiTieu2.DTO;
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

namespace QuanLyChiTieu2
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DHFMQ88\MSSQLSERVER03;Integrated Security=SSPI;Initial Catalog=Quanlychitieu");
            try
            {
                conn.Open(); // mở kết nối database
                string tk = textBoxUserName.Text;
                string mk = textBoxPassWord.Text;
                string sql = " select * from Account where UserName = '" + tk + "'and PassWord ='" + mk + "' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    MessageBox.Show(" Đăng nhập thành công");
                    FormMain main = new FormMain();
                   
                    this.Hide();
                    main.Show();
                   
                    
                   
                }
                else
                {
                    MessageBox.Show(" Đăng nhập không thành công ");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" lỗi kết nối");
            }
            
        }

        private void labelDangki_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_dangki dk = new Form_dangki();
            dk.Show();
            
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxPassWord_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
