using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui
{
    public partial class Form2 : Form
    {
        // delegate 
        public delegate void MyDeLeGate(object sinhvien);
        public MyDeLeGate aa { get; set; } 
        public Form2()
        {
            InitializeComponent();
        }

        private void btnOki_Click(object sender, EventArgs e)
        {
           
            
            SinhVien a = new SinhVien()
            {
                msv = Convert.ToInt32(textMsv.Text.Trim()),
                ten = textName.Text.Trim(),
                LopHocPhan = cbbClass.SelectedItem.ToString().Trim(),
                ngaysinh = dateTimePicker1.Value,
                 dtb = Convert.ToInt32(textDtb.Text.Trim()),
                 sex = radioNam.Checked,
                 anh = checkPic.Checked,
                 hocba = checkHocBa.Checked,
                cccd = checkCCCD.Checked
            };
           
            aa(a);
        }
    }
}
