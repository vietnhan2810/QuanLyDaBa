using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppG12019
{
    public partial class frmTinhToanCoBan : Form
    {
        public frmTinhToanCoBan()
        {
            InitializeComponent();
        }

        private void BtnTinhToan_Click(object sender, EventArgs e)
        {
            try
            { 
                #region Xử lý dữ liệu đầu vào
                errorProvider.Clear();
                float temp = 0;
                if (!float.TryParse(txtNum1.Text, out temp))
                {
                    //MessageBox.Show("Vui lòng nhập lại số thứ nhất");
                    errorProvider.SetError(txtNum1, "Vui lòng nhập lại số thứ nhất");
                    txtNum1.Focus();
                    return;
                }
                var num1 = float.Parse(txtNum1.Text);
                if (!float.TryParse(txtNum2.Text, out temp))
                {
                    //MessageBox.Show("Vui lòng nhập lại số thứ hai");
                    errorProvider.SetError(txtNum2, "Vui lòng nhập lại số thứ hai");
                    txtNum2.Focus();
                    return;
                }
                var num2 = float.Parse(txtNum2.Text);
                #endregion

                #region Kiểm tra toán tử
                string sign = "";
                float result = 0;
                if (rdbCong.Checked)
                {
                    result = num1 + num2;
                    sign = "+";
                }
                else if (rdbTru.Checked)
                {
                    result = num1 - num2;
                    sign = "-";
                }
                else if (rdbNhan.Checked)
                {
                    result = num1 * num2;
                    sign = "*";
                }
                else if (rdbChia.Checked)
                {
                    result = num1 / num2;
                    sign = "/";
                }
                #endregion

                var showResult = string.Format("Kết quả {0} {1} {2} = {3}", num1, sign, num2, result);
                MessageBox.Show(showResult, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi bạn ơi. Chi tiết lỗi: " + ex.Message + ". Vị trí lỗi: " + ex.StackTrace,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtNum2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnTinhToan.PerformClick();
            }
        }

        private void TxtNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnTinhToan.PerformClick();
            }
        }
    }
}
