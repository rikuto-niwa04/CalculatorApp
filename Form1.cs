namespace CalculatorApp;

public partial class Form1 : Form
{
    private TextBox txtDisplay;
    private Button btnClear;
    private Button btn1;
    private Button btn2;
    private Button btn3;
    private Button btn4;
    private Button btn5;
    private Button btn6;
    private Button btn7;
    private Button btn8;
    private Button btn9;

    private Button btnPlus;
    private Button btnminus;
    private Button btnMultiply;
    private Button btnDivide;
    private Button btnEquals;

    private int currentValue = 0;
    private int previousValue = 0;
    private string operation = "";

    public Form1()
    {
        InitializeComponent();
        this.Size = new Size(1000, 500);

        // テキストボックス
        txtDisplay = new TextBox();
        txtDisplay.Location = new Point(10, 10);
        txtDisplay.Size = new Size(260, 30);
        Controls.Add(txtDisplay);

         // 正しいクリアボタン
        btnClear = new Button();
        btnClear.Text = "C";
        btnClear.Location = new Point(10, 50);
        btnClear.Size = new Size(60, 40);
        btnClear.Click += (sender, e) =>
        {
            txtDisplay.Text = "";
            currentValue = 0;
            previousValue = 0;
            operation = "";
        };
        Controls.Add(btnClear);

        // ボタン1
        btn1 = new Button();
        btn1.Text = "1";
        btn1.Location = new Point(80, 50);
        btn1.Size = new Size(60, 40);
        btn1.Click += (sender, e) => txtDisplay.Text += "1";
        Controls.Add(btn1);

        // ボタン2
        btn2 = new Button();
        btn2.Text = "2";
        btn2.Location = new Point(150, 50);
        btn2.Size = new Size(60, 40);
        btn2.Click += (sender, e) => txtDisplay.Text += "2";
        Controls.Add(btn2);

         // ボタン3
        btn3 = new Button();
        btn3.Text = "3";
        btn3.Location = new Point(220, 50);
        btn3.Size = new Size(60, 40);
        btn3.Click += (sender, e) => txtDisplay.Text += "3";
        Controls.Add(btn3);


          // ボタン4
        btn4 = new Button();
        btn4.Text = "4";
        btn4.Location = new Point(10, 90);
        btn4.Size = new Size(60, 40);
        btn4.Click += (sender, e) => txtDisplay.Text += "4";
        Controls.Add(btn4);

          // ボタン5
        btn5 = new Button();
        btn5.Text = "5";
        btn5.Location = new Point(80, 90);
        btn5.Size = new Size(60, 40);
        btn5.Click += (sender, e) => txtDisplay.Text += "5";
        Controls.Add(btn5);

          // ボタン6
        btn6 = new Button();
        btn6.Text = "6";
        btn6.Location = new Point(150, 90);
        btn6.Size = new Size(60, 40);
        btn6.Click += (sender, e) => txtDisplay.Text += "6";
        Controls.Add(btn6);

          // ボタン7
        btn7 = new Button();
        btn7.Text = "7";
        btn7.Location = new Point(10, 130);
        btn7.Size = new Size(60, 40);
        btn7.Click += (sender, e) => txtDisplay.Text += "7";
        Controls.Add(btn7);

          // ボタン8
        btn8 = new Button();
        btn8.Text = "8";
        btn8.Location = new Point(80, 130);
        btn8.Size = new Size(60, 40);
        btn8.Click += (sender, e) => txtDisplay.Text += "8";
        Controls.Add(btn8);

          // ボタン9
        btn9 = new Button();
        btn9.Text = "9";
        btn9.Location = new Point(150, 130);
        btn9.Size = new Size(60, 40);
        btn9.Click += (sender, e) => txtDisplay.Text += "9";
        Controls.Add(btn9);

        // 足し算ボタン
        btnPlus = new Button();
        btnPlus.Text = "+";
        btnPlus.Location = new Point(290, 50);
        btnPlus.Size = new Size(60, 40);
        btnPlus.Click += (sender, e) =>
        {
            previousValue = int.Parse(txtDisplay.Text);
            txtDisplay.Text += "+"; // ← 上書きではなく「追加」
            operation = "+";
        };
        Controls.Add(btnPlus);

        //引き算ボタン
        btnminus = new Button();
        btnminus.Text = "-";
        btnminus.Location = new Point(360, 50);
        btnminus.Size = new Size(60, 40);
        btnminus.Click += (sender, e) =>
        {
            previousValue = int.Parse(txtDisplay.Text);
            txtDisplay.Text += "-";
            operation = "-";
        };
        Controls.Add(btnminus);

        //掛け算ボタン
        btnMultiply = new Button();
        btnMultiply.Text = "*";
        btnMultiply.Location = new Point(420, 50);
        btnMultiply.Size = new Size(60, 40);
        btnMultiply.Click += (sender, e) =>
        {
            previousValue = int.Parse(txtDisplay.Text);
            txtDisplay.Text += "*";
            operation = "*";
        };
        Controls.Add(btnMultiply);

        //割り算ボタン
        btnDivide = new Button();
        btnDivide.Text = "/";
        btnDivide.Location = new Point(490, 50);
        btnDivide.Size = new Size(60, 40);
        btnDivide.Click += (sender, e) =>
        {
            previousValue = int.Parse(txtDisplay.Text);
            txtDisplay.Text += "/";
            operation = "/";
        };
        Controls.Add(btnDivide);

        // イコールボタン
        btnEquals = new Button();
        btnEquals.Text = "=";
        btnEquals.Location = new Point(560, 50);
        btnEquals.Size = new Size(60, 40);
        btnEquals.Click += (sender, e) =>
        {
            char op = txtDisplay.Text.FirstOrDefault(c => "+-*/".Contains(c));

            if (op == '\0')
            {
                MessageBox.Show("演算子が見つかりませんでした");
                return;
            }

            string[] parts = txtDisplay.Text.Split(op);

            if (parts.Length != 2)
            {
                MessageBox.Show("正しい形式ではありません（例：12+34）");
                return;
            }

            if (int.TryParse(parts[0].Trim(), out int lhs) &&
                int.TryParse(parts[1].Trim(), out int rhs))
            {
                int result = op switch
                {
                    '+' => lhs + rhs,
                    '-' => lhs - rhs,
                    '*' => lhs * rhs,
                    '/' => rhs != 0 ? lhs / rhs : 0,
                    _ => 0
                };

                txtDisplay.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("数値として認識できませんでした");
            }
        };
        Controls.Add(btnEquals);
    }
}

