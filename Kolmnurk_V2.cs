using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naidis
{
    public partial class Kolmnurk_V2 : Form
    {
        PictureBox pb;
        Label lbl, lblA, lblB, lblC, lbl_tringle;
        TextBox txtA, txtB, txtC;
        Button btn;
        ListView lv;
        public Kolmnurk_V2()
        {
            this.Width = 700;
            this.Height = 600;
            this.Text = "Kolmnurk";

            BackColor = Color.WhiteSmoke;

            lbl = new Label();
            lbl.Text = "Kolmnurk";
            lbl.Location = new Point(0, 0);
            lbl.Size = new Size(this.Width, 50);
            lbl.Font = new Font("Tahoma", 24);
            lbl.BackColor = Color.DarkGray;
            this.Controls.Add(lbl);

            lv = new ListView();
            lv.Width = 304;
            lv.Height = 230;
            // вид отображения Details для создания столбцов
            lv.View = View.Details;
            lv.Columns.Add("Andmed", 150);//столбец
            lv.Columns.Add("Value", 150);//столбец

            lv.Items.Add("Külg A:");
            lv.Items.Add("Külg B:");
            lv.Items.Add("Külg C:");
            lv.Items.Add("Olemas:");
            lv.Items.Add("Perimeeter:");
            lv.Items.Add("Ruut");
            lv.Items.Add("Kõrgus A:");
            lv.Items.Add("Kõrgus B:");
            lv.Items.Add("Kõrgus C:");
            lv.Items.Add("Pindala kõrguse järgi:");
            lv.Location = new Point(lbl.Left, lbl.Bottom + 10);
            lv.BackColor= Color.AntiqueWhite;
            this.Controls.Add(lv);
            int items= lv.Items.Count;
            for(int i = 0; i < items; i++)
            {
                lv.Items[i].SubItems.Add("");
            }


            pb = new PictureBox();
            pb.Location = new Point(this.Width - 220, lbl.Bottom);
            pb.Image = new Bitmap("../../../ravnosotonniyTringle.png");
            pb.Size = new Size(200, 200);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;
            pb.BackColor = Color.White;
            this.Controls.Add(pb);

            lbl_tringle = new Label();
            lbl_tringle.Text = "";
            lbl_tringle.Location = new Point(pb.Left, pb.Bottom + 5);
            lbl_tringle.Size = new Size(180, 25);
            this.Controls.Add(lbl_tringle);

            lblA = new Label();
            lblB = new Label();
            lblC = new Label();
            lblA.Text = "Külg A:";
            lblA.Location = new Point(lbl.Left, lv.Bottom + 10);
            lblB.Text = "Külg B:";
            lblB.Location = new Point(lbl.Left, lblA.Bottom + 10);
            lblC.Text = "Külg C:";
            lblC.Location = new Point(lbl.Left, lblB.Bottom + 10);
            this.Controls.Add(lblA);
            this.Controls.Add(lblB);
            this.Controls.Add(lblC);

            txtA = new TextBox();
            txtB = new TextBox();
            txtC = new TextBox();
            txtA.Height = 50;
            txtA.Width = 100;
            txtB.Height = 50;
            txtB.Width = 100;
            txtC.Height = 50;
            txtC.Width = 100;
            txtA.Location = new Point(lblA.Right, lblA.Location.Y);
            txtB.Location = new Point(lblB.Right, lblB.Location.Y);
            txtC.Location = new Point(lblC.Right, lblC.Location.Y);
            this.Controls.Add(txtA);
            this.Controls.Add(txtB);
            this.Controls.Add(txtC);

            btn = new Button();
            btn.Width = 100;
            btn.Height = 50;
            btn.Location = new Point(pb.Left + 50, pb.Bottom + 50);
            btn.Text = "Käivitada";
            btn.BackColor = Color.White;
            btn.Click += Btn_Click;
            this.Controls.Add(btn);

            
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            TringleType();
            double a, b, c;
            Tringle tringle;
            try
            {
                if (txtA.Text != "" && txtB.Text != "" && txtC.Text != "")
                {
                    a = Convert.ToDouble(txtA.Text);
                    b = Convert.ToDouble(txtB.Text);
                    c = Convert.ToDouble(txtC.Text);
                    tringle = new Tringle(a, b, c);
                }
                else
                {
                    throw new Exception();
                }

                lv.Items[0].SubItems[1].Text = tringle.OutputA();
                lv.Items[1].SubItems[1].Text = tringle.OutputB();
                lv.Items[2].SubItems[1].Text = tringle.OutputC();
                lv.Items[4].SubItems[1].Text = Convert.ToString(tringle.Perimete());
                lv.Items[5].SubItems[1].Text = Convert.ToString(tringle.Surface());
                lv.Items[6].SubItems[1].Text = Convert.ToString(tringle.Height(a));
                lv.Items[7].SubItems[1].Text = Convert.ToString(tringle.Height(b));
                lv.Items[8].SubItems[1].Text = Convert.ToString(tringle.Height(c));


                double h;
                h = tringle.Height(a);

                tringle = new Tringle(a, b, c, h);

                lv.Items[9].SubItems[1].Text = Convert.ToString(tringle.SurfaceH());

                if (tringle.ExistTrinage)
                {
                    lv.Items[3].SubItems[1].Text = "On olemas";
                }
                else
                {
                    lv.Items[3].SubItems[1].Text = "Ei ole olemas";
                }

            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("Valed andmed", "Error");
            }
        }
        public string TringleType()
        {
            if (txtA.Text == txtB.Text && txtB.Text == txtC.Text)
            {
                lbl_tringle.Text = "See on võrdkülgne kolmnurk";
                pb.Image = new Bitmap("../../../ravnosotonniyTringle.png");
            }
            else if (txtA.Text == txtB.Text || txtB.Text == txtC.Text || txtA.Text == txtC.Text)
            {
                lbl_tringle.Text = "See on võrdhaarne kolmnurk";
                pb.Image = new Bitmap("../../../ravnobedrenniyTringle.png");
            }
            else if (txtA.Text != txtB.Text && txtB.Text != txtC.Text)
            {
                lbl_tringle.Text = "See on skaala kolmnurk";
                pb.Image = new Bitmap("../../../raznostoronniyTringle.png");
            }
            return lbl_tringle.Text;
        }
    }
}
