namespace Naidis
{
    public partial class MyForm1 : Form
    {
        Button btn;
        public MyForm1()
        {
            //InitializeComponent();
            this.Height = 200;
            this.Width = 200;
            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "Valjuta mind!";
            btn.Location = new Point(10,20);
            this.Controls.Add(btn);
        }

        public MyForm1(int x,int y,string nimetus)
        {
            //InitializeComponent();
            this.Height = x;
            this.Width = y;
            this.Text = nimetus;
            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "Valjuta mind!";
            btn.Location = new Point(10, 20);
            this.Controls.Add(btn);
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            MyForm1 form = new MyForm1();
            form.ShowDialog();
        }
    }
}