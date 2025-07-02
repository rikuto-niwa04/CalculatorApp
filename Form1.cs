namespace CalculatorApp;

public partial class Form1 : Form
//ショートカットでのファイルパスコピーだと、コマンドプロンプトではうまくいかないので、しっかりとショートカットじゃないものから、パスをコピーするようにする。
{
    private TextBox txtDisplay;
    private Button btnClear;
    private Button btn1;
    private Button btn2;
    private Button btn3;
    private Button btn4;
    private Button btnPlus;
    private Button btnminus;
    private Button btnEquals;

    private int currentValue = 0;
    private int previousValue = 0;
    private string operation = "";

    public Form1()
    {
        InitializeComponent();

        // テキストボックス
        txtDisplay = new TextBox();
        txtDisplay.Location = new Point(10, 10);
        txtDisplay.Size = new Size(260, 30);
        Controls.Add(txtDisplay);

        //クリアボタン
        btnClear = new Button();
        btnClear.Text = "C";
        btnClear.Location = new Point(10, 50);
        btnClear.Size = new Size(60, 40);
        btnClear.Click += (sender, e) => txtDisplay.Text += "1";
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
        btn4.Location = new Point(10, 100);
        btn4.Size = new Size(60, 40);
        btn4.Click += (sender, e) => txtDisplay.Text += "4";
        Controls.Add(btn4);

        // 足し算ボタン
        btnPlus = new Button();
        btnPlus.Text = "+";
        btnPlus.Location = new Point(290, 50);
        btnPlus.Size = new Size(60, 40);
        btnPlus.Click += (sender, e) =>
        {
            previousValue = int.Parse(txtDisplay.Text);
            txtDisplay.Text = "";
            operation = "+";
        };
        Controls.Add(btnPlus);

        //引き算ボタン
        btnminus = new Button();
        btnminus.Text = "-";
        btnminus.Location = new Point(360, 50);
        btnminus.Size = new Size(60, 40);
        btnminus.Click -= (sender, e) =>
        {
            previousValue = int.Parse(txtDisplay.Text);
            txtDisplay.Text = "";
            operation = "-";
        };

        // イコールボタン
        btnEquals = new Button();
        btnEquals.Text = "=";
        btnEquals.Location = new Point(420, 50);
        btnEquals.Size = new Size(60, 40);
        btnEquals.Click += (sender, e) =>
        {
            currentValue = int.Parse(txtDisplay.Text);
            if (operation == "+")
            {
                txtDisplay.Text = (previousValue + currentValue).ToString();
            }
            if (operation == "-")
            {
                txtDisplay.Text = (previousValue - currentValue).ToString();
            }
        };
        Controls.Add(btnEquals);
    }
}

