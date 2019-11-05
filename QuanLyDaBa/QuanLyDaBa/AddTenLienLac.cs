using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDaBa.DAL;

namespace QuanLyDaBa
{
    public partial class AddTenLienLac : Form
    {
        string pathDataFile;
        public AddTenLienLac()
        {
            pathDataFile = Application.StartupPath + @"\Data\TenLienLac.txt";
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ma =Int32.Parse(QuanlyTenLienLac.getma(pathDataFile))+1;
            string malienlac ="" + ma;
            string tenlienlac = txttenlienlac.Text;
            string diachi = txtDiaChi.Text;
            string email = txtEmail.Text;
            string sdt = txtSoDT.Text;
            string nhom = txtNhom.Text;
            string lienlacmoi = malienlac+"#"+tenlienlac + "#" + diachi + "#" + email + "#" + sdt + "#" + nhom;
            using (StreamWriter sw = new StreamWriter("C:/Users/VTA/Documents/Visual Studio 2015/Projects/QuanLyDaBa/QuanLyDaBa/Data/TenLienLac.txt", true))
            {
                sw.WriteLine(lienlacmoi);
                MessageBox.Show("Thêm nhóm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
