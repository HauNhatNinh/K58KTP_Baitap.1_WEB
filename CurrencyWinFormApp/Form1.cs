using System;
using System.Drawing;
using System.Windows.Forms;
using CurrencyDLL; // DLL đa năng bạn đã tạo

namespace CurrencyWinFormApp
{
    public class Form1 : Form
    {
        private TextBox txtAmount;
        private ComboBox cmbFrom, cmbTo;
        private Button btnConvert;
        private Label lblResult;
        private Label lblHint; // Label hướng dẫn nhập số tiền

        public Form1()
        {
            this.Text = "Chương trình quy đổi tiền tệ";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.AliceBlue;

            // Label tiêu đề
            Label lblTitle = new Label();
            lblTitle.Text = "Chương trình quy đổi tiền tệ";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(50, 20);
            this.Controls.Add(lblTitle);

            // TextBox số tiền
            txtAmount = new TextBox();
            txtAmount.Location = new Point(50, 60);
            txtAmount.Width = 300;
            this.Controls.Add(txtAmount);

            // Label hướng dẫn thay placeholder
            lblHint = new Label();
            lblHint.Text = "Nhập số tiền";
            lblHint.ForeColor = Color.Gray;
            lblHint.Location = new Point(55, 63);
            lblHint.AutoSize = true;
            this.Controls.Add(lblHint);

            // Sự kiện ẩn/hiện label hướng dẫn
            txtAmount.GotFocus += (s, e) => { lblHint.Visible = false; };
            txtAmount.LostFocus += (s, e) => { if (txtAmount.Text == "") lblHint.Visible = true; };

            // ComboBox From
            cmbFrom = new ComboBox();
            cmbFrom.Location = new Point(50, 100);
            cmbFrom.Width = 140;
            cmbFrom.Items.AddRange(new string[] { "VND", "USD", "EUR", "JPY" });
            cmbFrom.SelectedIndex = 0;
            this.Controls.Add(cmbFrom);

            // ComboBox To
            cmbTo = new ComboBox();
            cmbTo.Location = new Point(210, 100);
            cmbTo.Width = 140;
            cmbTo.Items.AddRange(new string[] { "VND", "USD", "EUR", "JPY" });
            cmbTo.SelectedIndex = 1;
            this.Controls.Add(cmbTo);

            // Button Quy đổi
            btnConvert = new Button();
            btnConvert.Text = "Quy đổi";
            btnConvert.Location = new Point(50, 140);
            btnConvert.Width = 300;
            btnConvert.Click += BtnConvert_Click;
            this.Controls.Add(btnConvert);

            // Label kết quả
            lblResult = new Label();
            lblResult.Location = new Point(50, 180);
            lblResult.Width = 300;
            lblResult.Height = 40;
            lblResult.Font = new Font("Arial", 12, FontStyle.Bold);
            lblResult.ForeColor = Color.Green;
            this.Controls.Add(lblResult);
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = decimal.Parse(txtAmount.Text);
                string from = cmbFrom.SelectedItem.ToString();
                string to = cmbTo.SelectedItem.ToString();

                CurrencyConverter converter = new CurrencyConverter();
                string result = converter.Convert(amount, from, to);

                lblResult.Text = result;
            }
            catch
            {
                lblResult.Text = "Vui lòng nhập số hợp lệ!";
            }
        }
    }
}
