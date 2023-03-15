using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class SinhVien
    {
        public int msv { get; set; }
        public string ten { get; set; }
        public string LopHocPhan { get; set; }
        public DateTime ngaysinh { get; set; }
        public float dtb { get;set; }
        public bool sex { get; set; }
        public bool anh { get; set; }   
        public bool hocba { get; set; }
        public bool cccd { get; set; }

        public SinhVien()
        {

        }
        public SinhVien(int msv,string ten,string LopHocPhan,DateTime ngaysinh,float dtb,bool sex,bool anh,bool hocba,bool cccd)
        {
            this.msv = msv;
            this.ten = ten;
            this.LopHocPhan = LopHocPhan;
            this.ngaysinh=ngaysinh;
            this.dtb = dtb;
            this.sex = sex;
            this.anh = anh;
            this.hocba = hocba;
            this.cccd = cccd;
        }

    }
}
