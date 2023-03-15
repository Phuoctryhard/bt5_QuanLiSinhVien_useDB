using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
            DisPlayItemsInCbb();
        }
        BLLSinhVien bllsv = new BLLSinhVien();
        private void HienThiDanhSach()
        {
            DataTable a = new DataTable();
            
             a = bllsv.HienThiDanhSachSinhVien();
            dataGridView1.DataSource = a;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            SinhVien a = new SinhVien();
            a.msv = msv;
            DialogResult result = MessageBox.Show("Bạn Có chắc là xóa ", "Hiển Thị", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                bllsv.DeleTeSinhVien(a);
                MessageBox.Show("Xoa Thanh Công");
                HienThiDanhSach();
            }
            else
            {
                Application.Exit();
            }
          
        }
        int vitri;
        int msv = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;// lay ra vi tri kick 
            DataGridViewRow i = dataGridView1.Rows[vitri];// lay hang 
            msv = Convert.ToInt32(i.Cells[0].Value.ToString().Trim());
        }

        private void cbbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string property = cbbSearch.SelectedItem.ToString().Trim();
            dt = bllsv.SortSinhVienByProperty( property);
            dataGridView1.DataSource = dt;
        }
        private void AddSv(object aaa)
        {

            DataTable dt = new DataTable();
            SinhVien sinhVien = (SinhVien)aaa;
            bllsv.AddSinhVien(sinhVien);
            MessageBox.Show("Thêm Thành Công");
            HienThiDanhSach();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.aa  += new Form2.MyDeLeGate(AddSv);
            DisPlayItemsInCbb();
        }
        private void EditSV(object aaa)
        {

            DataTable dt = new DataTable();
            SinhVien sinhVien = (SinhVien)aaa;
            bllsv.EditSinhVien(sinhVien);
            MessageBox.Show("Edit Thành Công");
            HienThiDanhSach();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.aa += new Form2.MyDeLeGate(EditSV);
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string textbySearch = textName.Text.ToString().Trim();
            dt = bllsv.getClassSearchBy(cbbClassItem,textbySearch);
            dataGridView1.DataSource = dt;


        }
        string cbbClassItem = "";
        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {   
            
            DataTable dt=new DataTable();
            cbbClassItem =  cbbClass.SelectedItem.ToString().Trim();
            dt = bllsv.getSearchClass(cbbClassItem);
            dataGridView1.DataSource = dt;       
        }
        private void DisPlayItemsInCbb()
        {
            cbbClass.Items.Clear();
            List<object> list = new List<object>();
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                object s = i.Cells["TenLop"].Value;
                if (s != null)
                {
                    if (list.Contains(s) == false)
                    {
                        list.Add(s);
                        cbbClass.Items.Add(s);

                    }
                }
            }
        }
    }
}
