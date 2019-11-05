using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Windows.Forms;

namespace QuanLyDaBa.DAL
{
    class QuanLyNhom
    {

        public string TenNhom { get; set; }
        public ICollection<QuanlyTenLienLac> ListTenLienLac{ get; set; }

       
        public static List<QuanLyNhom> GetListFromFile(string pathDataFile)
        {
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            var arrayLines = File.ReadAllLines(pathDataFile);
            List<QuanLyNhom> ketQua = new List<QuanLyNhom>();
            foreach (var line in arrayLines)
            {
                var Nhom = new QuanLyNhom
                {
                   TenNhom = line
                };
                ketQua.Add(Nhom);
            }
            return ketQua;

        }
        public static QuanLyNhom GetFromFile(string pathDataFile, string tennhom)
        {
            List<QuanLyNhom> arrayLines = QuanLyNhom.GetListFromFile(pathDataFile);
            foreach (var nhom in arrayLines)
            {
                if (String.Compare(nhom.TenNhom, tennhom, true) == 0)
                    return nhom;

            }
            return null;
        }
        public static void XoaNhom(string pathDataFile, string tennhom)        {            List<QuanLyNhom> listNhom = QuanLyNhom.GetListFromFile(pathDataFile);
            List<QuanLyNhom> ketQua = new List<QuanLyNhom>();
            foreach (var nhom in listNhom)
            {
                if (string.Compare(nhom.TenNhom,tennhom) != 0)
                    ketQua.Add(nhom);
            }
            using (StreamWriter sw = new StreamWriter("C:/Users/VTA/Documents/Visual Studio 2015/Projects/QuanLyDaBa/QuanLyDaBa/Data/Nhom.txt"))
            {
                foreach (var x in ketQua)
                {
                    sw.WriteLine(x.TenNhom);
                }
                MessageBox.Show("Xóa nhóm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }        }
    }
}
