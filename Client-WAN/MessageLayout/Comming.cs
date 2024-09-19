using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Comming : UserControl
    {
        public Comming()
        {
            InitializeComponent();
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; DesignMessage(value); }
        }

        public void DesignMessage(string value)
        {
            // Tạo textBox với các thông số cần thiết để tí mô phỏng các thông số của textBox này.
            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            // Độ rộng cố định, chiều cao = 1 vì tí ta sẽ tính độ giãn nở chiều cao của Textbox và đưa cho Label
            textBox.Font = new Font(textBox.Font.FontFamily, 10);
            textBox.Text = value;
            /* Ý tưởng là sẽ dùng Texbox để tính toán độ nở về chiều cao khi văn bản quá dài, còn chiều rộng dữ nguyên,
               vì Label không thể giãn nở theo chiều cao, nên phải dùng TextBox để tính độ rộng và chiều cao cho Label.
               Đó là lý do tại sao chiều cao = 1, vì hàm bên dưới sẽ tự nở độ cao cho phù hợp với văn bản.
               Tại sao không dùng TextBox luôn ? Đã thử nhiều cách, nhưng TextBox mà không tính toán chiều cao thì 
               chuỗi có dài mấy TextBox cũng chỉ thêm ScrollBar, kiểu gì cũng phải tính.*/
            // Tính toán chiều cao textBox bằng TextRenderer.MeasureText và tham chiếu kích thước TextBox cho Label
            var height = TextRenderer.MeasureText(textBox.CreateGraphics(), textBox.Text, textBox.Font, new Size(250, 1), TextFormatFlags.WordBreak).Height;
            // Đặt chiều cao của Label bằng chiều cao TextBox đã vẽ ở hàm bên trên.
            MessageIn.Height = height;
            // Thêm một số thuộc tính phụ cho Label để hiển thị cho đẹp.
            MessageIn.Width = 250;
            MessageIn.AutoSize = false;
            MessageIn.Margin = new Padding(0, 10, 0, 0);
            MessageIn.Padding = new Padding(10, 0, 0, 0);
            MessageIn.Text = value;
            // Đổi kích thước Form Control cho khớp với Label
            Size = new Size(400, height);
        }

    }
}