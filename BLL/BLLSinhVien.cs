using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using System.Data;

namespace BLL
{
    public  class BLLSinhVien
    {
        public DataTable HienThiDanhSachSinhVien()
        {
            DALSV ds = new DALSV();           
            return  ds.HienThiDanhSachSinhVien();
        }
        public void DeleTeSinhVien(SinhVien a)
        {
            DALSV ds = new DALSV();
            ds.DeLeTeSinhVien(a);
        }
        public DataTable SortSinhVienByProperty(string p)
        {
            DALSV ds = new DALSV();
            return ds.SortSinhVienByProperty(p);
        }
        public void AddSinhVien(SinhVien sv)
        {
            DALSV ds = new DALSV();
             ds.AddSinhVien(sv);
        }
        public void EditSinhVien(SinhVien sv)
        {
            DALSV ds = new DALSV();
            ds.EditSinhVien(sv);
        }
        public DataTable getSearchClass(string s)
        {
            DALSV ds = new DALSV();
            return ds.getSearchClass(s);
        }
        public DataTable getClassSearchBy(string s,string name)
        {
            DALSV ds = new DALSV();
            return ds.getClassSearchBy(s,name);
        }
    }
}
