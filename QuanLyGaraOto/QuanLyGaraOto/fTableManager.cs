using QuanLyGaraOto.DAO;
using QuanLyGaraOto.DTO;
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

namespace QuanLyGaraOto
{
    public partial class fTableManager : Form
    {
        BindingSource VTPTList = new BindingSource();

        public fTableManager()
        {
            InitializeComponent();
            dtgVTPT.DataSource = VTPTList;
            LoadListVTPT();
            AddVTPTBinding();
        }
      
       /*void LoadVTPTList()
        {
            string query = "SELECT * FROM VATTUPHUTUNG";
            dtgVTPT.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }*/


        void LoadListVTPT()
        { dtgVTPT.DataSource = VTPTDAO.Instance.GetListVTPT();
        }

        private void btnShowVTPT_Click(object sender, EventArgs e)
        {
           LoadListVTPT();
        }
        void AddVTPTBinding()
        {
         nmMaVTPT.DataBindings.Add(new Binding("Value", dtgVTPT.DataSource, "MaVTPT",true, DataSourceUpdateMode.Never));
         txbTenVTPT.DataBindings.Add(new Binding("Text",dtgVTPT.DataSource, "TenVTPT",true, DataSourceUpdateMode.Never));
         nmDonGiaNhap.DataBindings.Add(new Binding("Value", dtgVTPT.DataSource, "DonGiaNhap", true, DataSourceUpdateMode.Never));
         nmDonGiaBan.DataBindings.Add(new Binding("Value", dtgVTPT.DataSource, "DonGiaBan", true, DataSourceUpdateMode.Never));
         nmSoLuongTon.DataBindings.Add(new Binding("Value", dtgVTPT.DataSource, "SoLuongTon", true, DataSourceUpdateMode.Never));
        }

        List<VTPT> SearchVTPTByName(string tenVTPT)
        {
            List<VTPT> listVTPT = VTPTDAO.Instance.SearchVTPTByName(tenVTPT);
            return listVTPT;
        }
        private void btnAddVTPT_Click(object sender, EventArgs e)
        {
            int maVTPT = (int)nmMaVTPT.Value;
            string ten = txbTenVTPT.Text;
            int dongianhap = (int)nmDonGiaNhap.Value;
            int dongiaban = (int)nmDonGiaBan.Value;
            int soluongton = (int)nmSoLuongTon.Value;

            if (VTPTDAO.Instance.InsertVTPT(maVTPT, ten, dongianhap, dongiaban, soluongton))
            {
                MessageBox.Show("Thêm vật tư phụ tùng thành công!");
            }
            else { MessageBox.Show("Error"); }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditVTPT_Click(object sender, EventArgs e)
        {
            int maVTPT = (int)nmMaVTPT.Value;
            string ten = txbTenVTPT.Text;
            int dongianhap = (int)nmDonGiaNhap.Value;
            int dongiaban = (int)nmDonGiaBan.Value;
            int soluongton = (int)nmSoLuongTon.Value;

            if (VTPTDAO.Instance.UpdateVTPT(maVTPT, ten, dongianhap, dongiaban, soluongton))
            {
                MessageBox.Show("Sửa vật tư phụ tùng thành công!");
            }
            else { MessageBox.Show("Error"); }

        }

        private void btnDeleteVTPT_Click(object sender, EventArgs e)
        {
            int maVTPT = (int)nmMaVTPT.Value;

            if (VTPTDAO.Instance.DeleteVTPT(maVTPT))
            {
                MessageBox.Show("Xóa vật tư phụ tùng thành công!");
            }
            else { MessageBox.Show("Error"); }
        }

        private void btnSearchVTPT_Click(object sender, EventArgs e)
        {
           VTPTList.DataSource= SearchVTPTByName(txbTimVTPTBangTen.Text);
        }
    }
}
