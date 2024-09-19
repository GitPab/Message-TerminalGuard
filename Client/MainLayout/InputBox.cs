using System.Windows.Forms;

public class InputBox : Form
{
    private TextBox textBox;
    private Button okButton;
    private Button cancelButton;
    public string InputText { get; private set; }

    public InputBox(string prompt)
    {
        this.Text = "Nhập tên nhóm";
        this.Size = new System.Drawing.Size(300, 150);
        this.StartPosition = FormStartPosition.CenterParent;

        Label promptLabel = new Label
        {
            Left = 10,
            Top = 20,
            Width = 260,
            Text = prompt
        };

        textBox = new TextBox
        {
            Left = 10,
            Top = 50,
            Width = 260
        };

        okButton = new Button
        {
            Text = "OK",
            Left = 110,
            Width = 80,
            Top = 80,
            DialogResult = DialogResult.OK
        };
        okButton.Click += (sender, e) => { InputText = textBox.Text; };

        cancelButton = new Button
        {
            Text = "Cancel",
            Left = 200,
            Width = 80,
            Top = 80,
            DialogResult = DialogResult.Cancel
        };

        this.Controls.Add(promptLabel);
        this.Controls.Add(textBox);
        this.Controls.Add(okButton);
        this.Controls.Add(cancelButton);

        this.AcceptButton = okButton;
        this.CancelButton = cancelButton;
    }
}
