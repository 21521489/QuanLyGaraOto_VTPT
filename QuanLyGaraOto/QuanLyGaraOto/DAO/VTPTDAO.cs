using QuanLyGaraOto.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaraOto.DAO
{
   public class VTPTDAO
    {
        private static VTPTDAO instance;
        public static VTPTDAO Instance
        {
            get { if (instance == null) instance = new VTPTDAO(); return VTPTDAO.instance; }
            private set { VTPTDAO.instance = value; }
        }

        private VTPTDAO() { }

        public List<VTPT> GetListVTPT()

        {
            List<VTPT> list = new List<VTPT>();
            string query = "SELECT * FROM VATTUPHUTUNG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                VTPT vtpt = new VTPT(item);
                list.Add(vtpt);
            }
            return list;

        }
        public List<VTPT> SearchVTPTByName(string tenVTPT)
        {
            List<VTPT> list = new List<VTPT>();
            string query =string.Format("SELECT * FROM VATTUPHUTUNG WHERE TenVTPT LIKE N'%{0}%'",tenVTPT);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                VTPT vtpt = new VTPT(item);
                list.Add(vtpt);
            }
            return list;

        }
        public bool InsertVTPT(int MaVTPT, string TenVTPT, int DonGiaNhap, int DonGiaBan, int SoLuongTon)
        {
            string query = string.Format("INSERT VATTUPHUTUNG (MaVTPT, TenVTPT, DonGiaNhap,DonGiaBan,SoLuongTon) VALUES ({0},N'{1}',{2},{3},{4})",MaVTPT, TenVTPT, DonGiaNhap, DonGiaBan, SoLuongTon);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateVTPT(int MaVTPT, string TenVTPT, int DonGiaNhap, int DonGiaBan, int SoLuongTon)
        {
            string query = string.Format("UPDATE VATTUPHUTUNG SET TenVTPT=N'{0}', DonGiaNhap={1},DonGiaBan={2},SoLuongTon={3} WHERE MaVTPT={4}", TenVTPT, DonGiaNhap, DonGiaBan, SoLuongTon, MaVTPT);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteVTPT(int MaVTPT)
        {
            string query = string.Format("DELETE VATTUPHUTUNG WHERE MaVTPT={0}", MaVTPT);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
