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

namespace AppG12019
{
    public partial class frmThongTinhSinhVien : Form
    {
        string pathAvatarFolder;
        string pathAvatarImage;
        public frmThongTinhSinhVien()
        {
            InitializeComponent();
            picAvatar.AllowDrop = true;
            pathAvatarFolder = Application.StartupPath + @"\avatar";
            pathAvatarImage = pathAvatarFolder + @"\avatar.png";
            if (File.Exists(pathAvatarImage))
            {
                showImageAvatar(pathAvatarImage);
            }

        }
        void showImageAvatar(string path, bool saveOption = false)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            picAvatar.Image = Image.FromStream(fileStream);
            if (saveOption)
            {
                picAvatar.Image.Save(pathAvatarImage);
            }
            fileStream.Close();
        }

        private void LnkChooseAvatar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Chọn ảnh và lưu vào thư mục Avatar
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh đại diện";
            openFileDialog.Filter = "Bạn phải chọn file ảnh (*.png, *.jpg)|*.png;*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                showImageAvatar(fileName, true);
            }
            #endregion
        }



        private void PicAvatar_DragDrop(object sender, DragEventArgs e)
        {
            try
            {

                var lsFile = (string[])e.Data.GetData(DataFormats.FileDrop);

                showImageAvatar(lsFile.FirstOrDefault(), true);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn file ảnh");
            }
        }

        private void PicAvatar_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void MniXoaAnhDaiDien_Click(object sender, EventArgs e)
        {
            picAvatar.Image = Properties.Resources.avatar;

            if (File.Exists(pathAvatarImage))
                File.Delete(pathAvatarImage);
        }

        private void FrmThongTinhSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
