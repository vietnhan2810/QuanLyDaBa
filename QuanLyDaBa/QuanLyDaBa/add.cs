using QuanLyDaBa.DAL;
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

namespace QuanLyDaBa
{
   
    public partial class add : Form
    {
         string pathDataFile;

        public add()
        {
            InitializeComponent();
            pathDataFile = Application.StartupPath + @"\Data\Nhom.txt";
        }
       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            ftmQuanLyDaBa form = new ftmQuanLyDaBa();
            form.ShowDialog();
            this.Close();
            
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            string tennhom = txtTenNhom.Text;
            try
            {
                using (StreamReader sr = new StreamReader(pathDataFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (string.Compare(line, tennhom) == 0)
                        {
                            MessageBox.Show("Tên nhóm đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter("C:/Users/VTA/Documents/Visual Studio 2015/Projects/QuanLyDaBa/QuanLyDaBa/Data/Nhom.txt", true))
                  {
                   sw.WriteLine(tennhom);
                    MessageBox.Show("Thêm nhóm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                  }
            }
            catch (Exception ex)
            {
                // thong bao loi.
                Console.WriteLine("Khong the doc du lieu tu file da cho: ");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
