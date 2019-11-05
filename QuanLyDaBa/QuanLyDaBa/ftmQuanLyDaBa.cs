using QuanLyDaBa.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuanLyDaBa
{
    public partial class ftmQuanLyDaBa : Form
    {
        string pathDataFile;
        string pathDataFile2;
        List<QuanLyNhom> quanlynhom;
        QuanLyNhom quanlynhom2;
    
        public ftmQuanLyDaBa()
        {

            InitializeComponent();

            pathDataFile = Application.StartupPath + @"\Data\Nhom.txt";
            pathDataFile2 = Application.StartupPath + @"\Data\TenLienLac.txt";
            quanlynhom = QuanLyNhom.GetListFromFile(pathDataFile);
            dgvnhom.AutoGenerateColumns = false;
            dgvtenlienlac.AutoGenerateColumns = false;
            if (quanlynhom == null)
            {
                throw new Exception(" Không tồn tại ");
            }
            else
            {
                bdsNhom.DataSource = quanlynhom;
                dgvnhom.DataSource = bdsNhom;
          
            }
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void tsbXoaNhom_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvnhom.SelectedRows)
            {
                DialogResult dlr = MessageBox.Show("Nhóm bị xóa sẽ không thể khôi phục lại dc : "+row.Cells[0].Value.ToString(), "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if(dlr==DialogResult.Yes)
                {
                    QuanLyNhom.XoaNhom(pathDataFile, row.Cells[0].Value.ToString());
                }
            }
        }
        private void dgvnhom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvnhom.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                string tennhom = row.Cells[0].Value.ToString();
                quanlynhom2 = QuanLyNhom.GetFromFile(pathDataFile, tennhom);
                quanlynhom2.ListTenLienLac = QuanlyTenLienLac.GetNhom(pathDataFile2, quanlynhom2.TenNhom);
                bdstenlienlac.DataSource = quanlynhom2.ListTenLienLac;
                dgvtenlienlac.DataSource = bdstenlienlac;
            }
           
           
        }

        private void dgvtenlienlac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvtenlienlac.Rows[e.RowIndex];
                txtTenGoi.Text = row.Cells[0].Value.ToString(); 
                txtEmail.Text = row.Cells[1].Value.ToString();
                txtSDT.Text = row.Cells[2].Value.ToString();
                QuanlyTenLienLac TenLienLac = QuanlyTenLienLac.GetTenLienLac(pathDataFile2, row.Cells[0].Value.ToString());
                txtDiaChi.Text = TenLienLac.DiaChi.ToString();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            add form = new add();
            form.Show();
        }

        private void tsbThemLienLac_Click(object sender, EventArgs e)
        {
            AddTenLienLac form = new AddTenLienLac();
            form.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvtenlienlac.SelectedRows)
            {
                DialogResult dlr = MessageBox.Show("Liên lạc bị xóa sẽ không thể khôi phục lại dc : " + row.Cells[0].Value.ToString(), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlr == DialogResult.Yes)
                {
                    QuanlyTenLienLac.XoaTenLienLac(pathDataFile2, row.Cells[2].Value.ToString());
                    Activate();
                }
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string tennhom = txtTimKiem.Text;
                quanlynhom2 = QuanLyNhom.GetFromFile(pathDataFile, tennhom);
                quanlynhom2.ListTenLienLac = QuanlyTenLienLac.GetNhom(pathDataFile2, quanlynhom2.TenNhom);
                bdstenlienlac.DataSource = quanlynhom2.ListTenLienLac;
                dgvtenlienlac.DataSource = bdstenlienlac;
              
            }
                
        }

        private void FtmQuanLyDaBa_Load(object sender, EventArgs e)
        {

        }
    }
}
