using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class CommingFile : UserControl
    {
        public CommingFile()
        {
            InitializeComponent();
        }

        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; UpdateDisplay(value); }
        }

        private void UpdateDisplay(string value)
        {
            // Xóa các điều khiển hiện tại
            Controls.Clear();
            string fileName = Path.GetFileName(filePath);

            // Xác định phần mở rộng của file để xử lý đặc biệt cho hình ảnh
            string extension = Path.GetExtension(fileName).ToLower();

            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
            {
                PictureBox pictureBox = new PictureBox
                {
                    Image = Image.FromFile(filePath),
                    SizeMode = PictureBoxSizeMode.StretchImage, // Thay đổi kích thước hình ảnh
                    Size = new Size(100, 100), // Đặt kích thước cụ thể cho hình ảnh
                    Tag = filePath, // Lưu đường dẫn file trong Tag
                    Padding = new Padding(10, 0, 0, 0) // Thiết lập Padding nếu cần thêm khoảng trống bên trong
                };

                // Khi nhấp vào hình ảnh, mở hộp thoại lưu file
                pictureBox.Click += (sender, e) =>
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        FileName = fileName,
                        Filter = "Image files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(filePath, saveFileDialog.FileName, true);
                    }
                };

                Controls.Add(pictureBox);
            }
            else
            {
                // Đối với các loại file khác, tạo nút tải xuống
                Button downloadButton = new Button
                {
                    Text = fileName,
                    AutoSize = true, // Tự động điều chỉnh kích thước
                    Tag = filePath, // Lưu đường dẫn file trong Tag
                    Padding = new Padding(10, 0, 0, 0) // Thiết lập Padding nếu cần thêm khoảng trống bên trong
                };

                // Khi nhấp vào nút, mở hộp thoại lưu file
                downloadButton.Click += (sender, e) =>
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        FileName = fileName,
                        Filter = "All files (*.*)|*.*"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(filePath, saveFileDialog.FileName, true);
                    }
                };

                Controls.Add(downloadButton);
            }
            // Đổi kích thước Form Control cho khớp với nội dung
            Size = new Size(400, Controls.OfType<Control>().Max(c => c.Height));
        }
    }
}
