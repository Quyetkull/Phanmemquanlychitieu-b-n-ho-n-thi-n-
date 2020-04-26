using QuanLyChiTieu2.DTO;
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

namespace QuanLyChiTieu2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        // khởi tạođ database
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-DHFMQ88\MSSQLSERVER03;Integrated Security=SSPI;Initial Catalog=Quanlychitieu";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = " select * from thongtinchitieu";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table; // đổ dữ liệu lên bảng 
        }
     
        void loadGrid_keyword() // tìm kiếm
        {
            command = connection.CreateCommand();
            command.CommandText = " select * from thongtinchitieu where tenchitieu like '%"+txt_timkiem.Text+"%' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

 

        private Account loginAccount;

        //public Account LoginAccount 
        //{
        //    get { return loginAccount; }
        //    set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        //    }

        public FormMain(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
           
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBox1.ReadOnly = true;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            

        }

      

        private void FormDangnhap_Load(object sender, EventArgs e)
        {
            //datagridview
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        

       
        private void button4_Click_1(object sender, EventArgs e)
        {
            table.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e) // thêm
        {
            command = connection.CreateCommand();
            command.CommandText = " insert into thongtinchitieu values (N'" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "')"; //xli câu truy vấn
            command.ExecuteNonQuery();  //trả về kết quả câu truy vấn
            loaddata();
        }

        private void button2_Click_1(object sender, EventArgs e) //sửa
        {
            command = connection.CreateCommand();
            command.CommandText = "update thongtinchitieu set tenchitieu = N'" + textBox1.Text + "' , sotien = " + textBox2.Text + " where ngaythang = '" + dateTimePicker1.Text + "' ";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void button3_Click_1(object sender, EventArgs e) //xóa
        {
            command = connection.CreateCommand();
            command.CommandText = " delete from thongtinchitieu where ngaythang = '" + dateTimePicker1.Text + "' ";
            command.ExecuteNonQuery();
            loaddata();
        }

        int i = 0;
        private void button7_Click_1(object sender, EventArgs e) // thành tiền
        {
            int sum = 0;
            for (i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            textBox3.Text = sum.ToString();
        }

      

      

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            
        }


      

        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            loadGrid_keyword();
        }

        private void load_laibang_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
                MessageBox.Show(" ban phải nhập số");
            }
        }

        private void đăngKíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_dangki dki = new Form_dangki();
            dki.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            FormLogin loggin = new FormLogin();
            loggin.Show();
        }

        private void thốngKêBiểuĐồToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bieu_do bd = new Bieu_do();
            bd.Show();
        }

        private void lênLịchChiTiêuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKehoachchitieu lenlich = new FormKehoachchitieu();
            lenlich.Show();
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
            Tacgia tg = new Tacgia();
            tg.Show();
        }









        //private void button5_Click(object sender, EventArgs e)
        //{
        //    loadgird();
        //}
        //void ChangeAccount(int type)
        //{
        //    thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        //////}
    }
}
