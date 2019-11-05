using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDaBa.DAL
{
    class QuanlyTenLienLac
    {
        public string MaLienLac { get; set; }
        public string TenLienLac { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string TenNhom { get; set; }
        public virtual QuanLyNhom quanlynhom { get; set; }

        public static List<QuanlyTenLienLac> GetListFromFile (string pathData)
        {
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            var arrayLines = File.ReadAllLines(pathData);
            List<QuanlyTenLienLac> ketQua = new List<QuanlyTenLienLac>();
            foreach (var line in arrayLines)
            {
                var lsValue = line.Split(new char[] { '#' });

                var listTenLacMa = new QuanlyTenLienLac
                {
                    MaLienLac = lsValue[0],
                    TenLienLac = lsValue[1],
                    DiaChi = lsValue[2],
                    Email = lsValue[3],
                    SoDienThoai = lsValue[4],
                    TenNhom = lsValue[5]
                };
                ketQua.Add(listTenLacMa);
            }
            return ketQua;
        }
        public static List<QuanlyTenLienLac> GetNhom(string pathData, string tennhom)
        {
            List<QuanlyTenLienLac> listtenlienlac = QuanlyTenLienLac.GetListFromFile(pathData);
            List<QuanlyTenLienLac> ketQua = new List<QuanlyTenLienLac>();
            foreach (var LienLac in listtenlienlac)
            {
                if (LienLac.TenNhom == tennhom)
                    ketQua.Add(LienLac);
            }
            return ketQua;
        }
        public static QuanlyTenLienLac GetTenLienLac(string pathDataFile, string tenlienlac)
        {
            List<QuanlyTenLienLac> listtenlienlac = QuanlyTenLienLac.GetListFromFile(pathDataFile);
            foreach (var LienLac in listtenlienlac)
            {
                if (String.Compare(LienLac.TenLienLac,tenlienlac, true) == 0)
                    return LienLac;
            }
            return null;

        }
        public static string getma(string pathDataFile)
        {
            List<QuanlyTenLienLac> listtenlienlac = QuanlyTenLienLac.GetListFromFile(pathDataFile);
            string ma="";
            foreach (var x in listtenlienlac)
            {
                ma = x.MaLienLac;
            }
            return ma;
        }
        public static void XoaTenLienLac(string pathDataFile, string sdt)
        {
            List<QuanlyTenLienLac> listtenlienlac = QuanlyTenLienLac.GetListFromFile(pathDataFile);
            List<QuanlyTenLienLac> ketQua = new List<QuanlyTenLienLac>();
            foreach (var x in listtenlienlac)
            {
                if (string.Compare(x.SoDienThoai, sdt) != 0)
                    ketQua.Add(x);
            }
            using (StreamWriter sw = new StreamWriter("C:/Users/VTA/Documents/Visual Studio 2015/Projects/QuanLyDaBa/QuanLyDaBa/Data/Tenlienlac.txt"))
            {
                foreach (var x in ketQua)
                {
                    string line = x.MaLienLac + "#" + x.TenLienLac + "#" + x.DiaChi + "#" + x.Email + "#" + x.SoDienThoai + "#" + x.TenNhom;
                    sw.WriteLine(line);
                }
                MessageBox.Show("Xóa liên lạc thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
        }
    }
}
