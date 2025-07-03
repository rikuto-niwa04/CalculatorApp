using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private TextBox txtDisplay;

        private int currentValue = 0;
        private int previousValue = 0;
        private string operation = "";

        public Form1()
        {
        // TableLayoutPanelの作成
        TableLayoutPanel panel = new TableLayoutPanel();
        panel.Name = "panelButtons"; // 後で見つけやすいように名前をつけておく
        panel.RowCount = 4;
        panel.ColumnCount = 4;
        panel.Size = new Size(400, 300);
        panel.Location = new Point(10, 100);
        panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single; // 枠を見やすくする

        // 行・列を均等に分割
        for (int i = 0; i < 4; i++)
        {
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
        }

        // フォームに追加
        this.Controls.Add(panel);

        // 新規改修：ボタン「7」の作成
        Button btn7 = new Button();
        btn7.Text = "7";
        btn7.Dock = DockStyle.Fill;
        btn7.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btn7.Click += (sender, e) => txtDisplay.Text += "7";

        // 左上 (列:0, 行:0) に追加
        panel.Controls.Add(btn7, 0, 0);

        // ボタン「8」
        Button btn8 = new Button();
        btn8.Text = "8";
        btn8.Dock = DockStyle.Fill;
        btn8.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btn8.Click += (sender, e) => txtDisplay.Text += "8";
        panel.Controls.Add(btn8, 1, 0);  // 列:1, 行:0（7の右隣）

        // ボタン「9」
        Button btn9 = new Button();
        btn9.Text = "9";
        btn9.Dock = DockStyle.Fill;
        btn9.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btn9.Click += (sender, e) => txtDisplay.Text += "9";
        panel.Controls.Add(btn9, 2, 0);  // 列:2, 行:0（8の右隣）

        // ボタン「÷」
        Button btnDivide = new Button();
        btnDivide.Text = "÷";
        btnDivide.Dock = DockStyle.Fill;
        btnDivide.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btnDivide.Click += (sender, e) => txtDisplay.Text += "/";
        panel.Controls.Add(btnDivide, 3, 0);  // 列:3, 行:0（右端）

        // ボタン「4」
        Button btn4 = new Button();
        btn4.Text = "4";
        btn4.Dock = DockStyle.Fill;
        btn4.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btn4.Click += (sender, e) => txtDisplay.Text += "4";
        panel.Controls.Add(btn4, 0, 1);  // 列:0, 行:1

        // ボタン「5」
        Button btn5 = new Button();
        btn5.Text = "5";
        btn5.Dock = DockStyle.Fill;
        btn5.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btn5.Click += (sender, e) => txtDisplay.Text += "5";
        panel.Controls.Add(btn5, 1, 1);  // 列:1, 行:1

        // ボタン「6」
        Button btn6 = new Button();
        btn6.Text = "6";
        btn6.Dock = DockStyle.Fill;
        btn6.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btn6.Click += (sender, e) => txtDisplay.Text += "6";
        panel.Controls.Add(btn6, 2, 1);  // 列:2, 行:1

        // ボタン「×」
        Button btnMultiply = new Button();
        btnMultiply.Text = "×";
        btnMultiply.Dock = DockStyle.Fill;
        btnMultiply.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btnMultiply.Click += (sender, e) => txtDisplay.Text += "*";
        panel.Controls.Add(btnMultiply, 3, 1);  // 列:3, 行:1

        // ボタン「1」
        Button btn1 = new Button();
        btn1.Text = "1";
        btn1.Dock = DockStyle.Fill;
        btn1.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btn1.Click += (sender, e) => txtDisplay.Text += "1";
        panel.Controls.Add(btn1, 0, 2);  // 列:0, 行:2

        // ボタン「2」
        Button btn2 = new Button();
        btn2.Text = "2";
        btn2.Dock = DockStyle.Fill;
        btn2.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btn2.Click += (sender, e) => txtDisplay.Text += "2";
        panel.Controls.Add(btn2, 1, 2);  // 列:1, 行:2

        // ボタン「3」
        Button btn3 = new Button();
        btn3.Text = "3";
        btn3.Dock = DockStyle.Fill;
        btn3.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btn3.Click += (sender, e) => txtDisplay.Text += "3";
        panel.Controls.Add(btn3, 2, 2);  // 列:2, 行:2

        // ボタン「−」
        Button btnMinus = new Button();
        btnMinus.Text = "−";
        btnMinus.Dock = DockStyle.Fill;
        btnMinus.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btnMinus.Click += (sender, e) => txtDisplay.Text += "-";
        panel.Controls.Add(btnMinus, 3, 2);  // 列:3, 行:2

        // ボタン「0」
        Button btn0 = new Button();
        btn0.Text = "0";
        btn0.Dock = DockStyle.Fill;
        btn0.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btn0.Click += (sender, e) => txtDisplay.Text += "0";
        panel.Controls.Add(btn0, 0, 3);  // 列:0, 行:3

        // ボタン「C」（クリア）
        Button btnClear = new Button();
        btnClear.Text = "C";
        btnClear.Dock = DockStyle.Fill;
        btnClear.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btnClear.Click += (sender, e) =>
        {
            txtDisplay.Text = "";
        };
        panel.Controls.Add(btnClear, 1, 3);  // 列:1, 行:3

        // ボタン「=」
        Button btnEqual = new Button();
        btnEqual.Text = "=";
        btnEqual.Dock = DockStyle.Fill;
        btnEqual.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btnEqual.Click += (sender, e) =>
        {
            try
            {
                // 簡易評価（将来的には独自ロジックに切り替える）
                var result = new DataTable().Compute(txtDisplay.Text, null);
                txtDisplay.Text = result.ToString();
            }
            catch
            {
                MessageBox.Show("計算に失敗しました。");
            }
        };
        panel.Controls.Add(btnEqual, 2, 3);  // 列:2, 行:3

        // ボタン「＋」
        Button btnPlus = new Button();
        btnPlus.Text = "+";
        btnPlus.Dock = DockStyle.Fill;
        btnPlus.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        btnPlus.Click += (sender, e) => txtDisplay.Text += "+";
        panel.Controls.Add(btnPlus, 3, 3);  // 列:3, 行:3

        this.Size = new Size(1000, 500);

        // テキストボックス
        txtDisplay = new TextBox();
        txtDisplay.Location = new Point(10, 10);
        txtDisplay.Size = new Size(260, 30);
        Controls.Add(txtDisplay);
    }
}
}
