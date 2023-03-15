using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace Dal
{
    public class DALSV
    {
        public DataTable HienThiDanhSachSinhVien()
        {
           // List<SinhVien> ds = new List<SinhVien>();
            DataTable dt = new DataTable();
            //cau leng truy van 
            string query = "select sv.Msv,sv.Ten,sv.NgaySinh,sv.Dtb,sv.Sex,sv.Pic,sv.HocBa,sv.Cccd,Lsh.TenLop from  LopSinhHoat as Lsh , SV as sv where Lsh.IdLop = sv.idLop";
            /* foreach( DataRow i in DBHelper.getInStance.getInrecord(query).Rows)
            {
                ds.Add(GetSinhVienByDaTaRow(i));
            }*/
            dt = DBHelper.getInStance.getInrecord(query);

            return dt;
        }

        // ham lay gia tri trong Datarow i
        public SinhVien GetSinhVienByDaTaRow(DataRow i)
        {
            return new SinhVien
            {
                msv = Convert.ToInt32(i["Msv"].ToString()),
                ten = i["Ten"].ToString(),
                ngaysinh = Convert.ToDateTime(i["NgaySinh"].ToString()),
                dtb = float.Parse(i["Dtb"].ToString()),
                sex = Convert.ToBoolean(i["Sex"].ToString()),
                anh = Convert.ToBoolean(i["Pic"].ToString()),
                hocba = Convert.ToBoolean(i["HocBa"].ToString()),
                cccd = Convert.ToBoolean(i["Cccd"].ToString()),
                LopHocPhan = i["TenLop"].ToString() // ko co dau , ; here 
            };// loi here 
        }

        public void DeLeTeSinhVien(SinhVien a)
        {
            int msv = a.msv;
            string query = "delete from SV where Msv = "+msv;
            DBHelper.getInStance.ExectuteNonQuery(query);

        }
        public DataTable SortSinhVienByProperty(string property)
        {
            DataTable dt = new DataTable();
            string query = "select * from SV ORDER BY " + property + " DESC";
            dt = DBHelper.getInStance.getInrecord(query);
            return dt;
        }

        public void AddSinhVien(SinhVien sv)
        {
            string idlop = sv.LopHocPhan.Substring(0, 2) + sv.LopHocPhan.Substring(sv.LopHocPhan.Length - 3);
            DataTable dt = new DataTable();
            SqlParameter[] listPar =
            {
                new SqlParameter("@msv", sv.msv),
                new SqlParameter("@ten", sv.ten),
                new SqlParameter("@lopsh", idlop),
                new SqlParameter("@ngaysinh", sv.ngaysinh),
                new SqlParameter("@dtb", sv.dtb),
                new SqlParameter("@nam", sv.sex),               
                new SqlParameter("@anh", sv.anh),
                new SqlParameter("@hb", sv.hocba),
                new SqlParameter("@cccd",sv.cccd)
            };
            string  query = "insert into SV(Msv,Ten,NgaySinh,dtb,sex,pic,HocBa,Cccd,idLop) values (@msv,@ten,@ngaysinh,@dtb,@nam,@anh,@hb,@cccd,@lopsh)";
            DBHelper.getInStance.ExecuteNonQuery(query, listPar);
        }
        public void EditSinhVien(SinhVien sv)
        {
            string idlop = sv.LopHocPhan.Substring(0, 2) + sv.LopHocPhan.Substring(sv.LopHocPhan.Length - 3);
            DataTable dt = new DataTable();
            SqlParameter[] listPar =
            {
                new SqlParameter("@msv", sv.msv),
                new SqlParameter("@ten", sv.ten),
                new SqlParameter("@lopsh", idlop),
                new SqlParameter("@ngaysinh", sv.ngaysinh),
                new SqlParameter("@dtb", sv.dtb),
                new SqlParameter("@nam", sv.sex),

                new SqlParameter("@anh", sv.anh),
                new SqlParameter("@hb", sv.hocba),
                new SqlParameter("@cccd",sv.cccd)
            };
            string query = "update SV set Msv = @msv,Ten =@ten,NgaySinh=@ngaysinh,dtb = @dtb,sex= @nam,pic = @anh,HocBa = @hb,Cccd = @cccd,idLop = @lopsh where Msv = @msv";
            DBHelper.getInStance.ExecuteNonQuery(query, listPar);
        }
        public DataTable getSearchClass(string s)
        {
            DataTable dt = new DataTable();
            SqlParameter[] listPar = 
            {
                new SqlParameter("@class", s)
            };
            string query = "select sv.Msv,sv.Ten,sv.NgaySinh,sv.Dtb,sv.Sex,sv.Pic,sv.HocBa,sv.Cccd,Lsh.TenLop from  LopSinhHoat as Lsh , SV as sv where Lsh.IdLop = sv.idLop and Lsh.TenLop = @class ";
            dt = DBHelper.getInStance.getInfo(query, listPar);
            return dt;
        }
        public DataTable getClassSearchBy(string s,string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] listPar =
            {
                new SqlParameter("@class", s),
               
            };
            string query = "select sv.Msv,sv.Ten,sv.NgaySinh,sv.Dtb,sv.Sex,sv.Pic,sv.HocBa,sv.Cccd,Lsh.TenLop from  LopSinhHoat as Lsh , SV as sv where Lsh.IdLop = sv.idLop and Lsh.TenLop = @class and sv.Ten Like N'%"+name+"%' ";
            dt = DBHelper.getInStance.getInfo(query, listPar);
            return dt;
            
        }

    }
}
