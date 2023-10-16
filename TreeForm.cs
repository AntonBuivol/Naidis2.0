using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naidis
{
    public partial class TreeForm : Form
    {
        TreeView tree;
        Button btn, btn_list_delelte;
        Label lbl;
        TextBox txt_box, list_text_box;
        RadioButton r1, r2;
        CheckBox c1, c2;
        PictureBox pb;
        ListBox lb;
        Kolmnurk kolmnurk;
        public TreeForm()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm põhielementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.BorderStyle= BorderStyle.Fixed3D;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode treeNode = new TreeNode("Elemendid");
            treeNode.Nodes.Add(new TreeNode("Nupp-Button"));

            btn = new Button();
            btn.Height = 50;
            btn.Width = 100;
            btn.Text = "Valjuta mind!";
            btn.Location = new Point(200, 50);
            btn.Click += Btn_Click;
            btn.MouseLeave += Btn_MouseLeave;
            btn.MouseHover += Btn_MouseHover;

            
            tree.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(tree.Width,0);
            lbl.Size = new Size(this.Width,btn.Location.Y);
            lbl.BackColor= Color.White;
            lbl.BorderStyle= BorderStyle.Fixed3D;
            lbl.Font = new Font("Tahoma",24);
            tree.Nodes.Add(treeNode);
            this.Controls.Add(tree);
            this.Controls.Add(btn);
            btn.Visible = false;
            this.Controls.Add(lbl);

            //Textkast

            treeNode.Nodes.Add(new TreeNode("Tekstikast-Textbox"));
            txt_box = new TextBox();
            txt_box.BorderStyle = BorderStyle.Fixed3D;
            txt_box.Height = 50;
            txt_box.Width = 100;
            txt_box.Text = ".....";
            txt_box.Location = new Point(tree.Width, btn.Top + btn.Height+5);
            txt_box.KeyDown += new KeyEventHandler(Txt_box_KeyDown);
            this.Controls.Add(txt_box);
            txt_box.Visible = false;

            //Radiobutton

            treeNode.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            r1 = new RadioButton();
            r1.Text = "Valik 1";
            r1.Location = new Point(tree.Width,txt_box.Location.Y+txt_box.Height);
            r1.CheckedChanged += new EventHandler(Radiobutton_Changed);
            r2 = new RadioButton();
            r2.Text = "Valik 2";
            r2.Location = new Point(r1.Location.X+r1.Width, txt_box.Location.Y + txt_box.Height);
            r2.CheckedChanged += new EventHandler(Radiobutton_Changed);
            this.Controls.Add(r1);
            r1.Visible = false;
            this.Controls.Add(r2);
            r2.Visible = false;

            //CheckBox

            treeNode.Nodes.Add(new TreeNode("CheckBox"));
            c1 = new CheckBox();
            c1.Text="Check 1";
            c1.Location = new Point(tree.Width, r1.Location.Y + r1.Height);
            this.Controls.Add(c1);
            c1.Visible = false;
            c2 = new CheckBox();
            c2.Text = "Check 2";
            c2.Location = new Point(c1.Location.X, c1.Location.Y + c1.Height);
            this.Controls.Add(c2);
            c2.Visible = false;
            c1.CheckedChanged += new EventHandler(C1_CheckedChanged);
            c2.CheckedChanged += new EventHandler(C1_CheckedChanged);

            //Image

            pb = new PictureBox();
            pb.Location = new Point(tree.Width, c2.Location.Y+c2.Height);
            pb.Image = new Bitmap("../../../france.jpg");
            pb.Size = new Size(147,100);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(pb);
            pb.Visible = false;

            //Listbox

            treeNode.Nodes.Add(new TreeNode("ListBox"));
            lb = new ListBox();
            lb.Items.Add("Roheline");
            lb.Items.Add("Sinine");
            lb.Items.Add("Hall");
            lb.Items.Add("Kollanne");
            lb.Location = new Point(tree.Width, pb.Location.Y + pb.Height);
            this.Controls.Add(lb);
            lb.Visible = false;

            list_text_box = new TextBox();
            list_text_box.Height = 50;
            list_text_box.Width = 100;
            list_text_box.Location = new Point(tree.Width, lb.Location.Y+lb.Height);
            list_text_box.KeyDown += List_text_box_KeyDown;
            this.Controls.Add(list_text_box);
            list_text_box.Visible = false;

            btn_list_delelte = new Button();
            btn_list_delelte.Height = 25;
            btn_list_delelte.Width = 100;
            btn_list_delelte.Text = "Kutsuta";
            btn_list_delelte.Location = new Point(list_text_box.Location.X+lb.Width, list_text_box.Location.Y);
            this.Controls.Add(btn_list_delelte);
            btn_list_delelte.Visible = false;
            btn_list_delelte.Click += Btn_list_delelte_Click;

            //Data

            DataSet ds = new DataSet("XML faill. Menüü");
            ds.ReadXml(@"..\..\..\Book.xml");
            DataGridView dataGrid = new DataGridView();
            dataGrid.Location = new Point(tree.Width+pb.Width+100,pb.Location.Y);
            dataGrid.Height = 300;
            dataGrid.Width = 400;
            dataGrid.DataSource = ds;
            dataGrid.AutoGenerateColumns = true;
            dataGrid.DataMember="book";
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.AutoSize = true;
            this.Controls.Add(dataGrid);

            //Kolmnurk
            treeNode.Nodes.Add(new TreeNode("Kolmnurk"));
            
        }

        private void Btn_list_delelte_Click(object? sender, EventArgs e)
        {
            if(lb.SelectedItem!=null)
            {
                lb.Items.Remove(lb.SelectedItem);
            }
        }

        private void List_text_box_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Kas sa tahad lisa seda sõna?", "Sõna lisamine", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (list_text_box.Text.Length>0)
                    {
                        string sona = list_text_box.Text;
                        lb.Items.Add(sona);
                    }
                    
                }
            }
        }

        private void Txt_box_KeyDown(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?","Küsimus",MessageBoxButtons.YesNo);
                if(result==DialogResult.Yes)
                {
                    txt_box.Enabled = false;
                    this.Text = txt_box.Text;
                }
                else
                {
                    string tekst = Interaction.InputBox("Sisesta pealkiri", "Pealkiri muutumine", "Uus pealkiri");
                    if(tekst.Length>0) //при отмене (cancel или крестик) длина текста становиться нулевой
                    {
                        this.Text = tekst;
                    }
                }
            }
        }

        private void C1_CheckedChanged(object? sender, EventArgs e)
        {
            if(c1.Checked==true && c2.Checked==true)
            {
                c1.ResetText();
                c2.ResetText();
                MessageBox.Show("Ты сломал программу! Убери одну галочку чтобы ответы снова отобразилось.","Ошибка");
                pb.Visible = true;
            }
            else if(c1.Checked == true && c2.Checked == false)
            {
                c1.Text = "No";
                c1.ForeColor = Color.DarkRed;
                pb.Visible = false;
            }

            else if(c2.Checked == true && c1.Checked == false)
            {
                c2.Text = "Yes";
                c2.ForeColor = Color.DarkGreen;
                pb.Visible = false;
            }
        }

        int x;
        private void Radiobutton_Changed(object? sender, EventArgs e)
        {
            if(r1.Checked)
            {
                r1.ForeColor = Color.Green;
                r2.ForeColor = Color.Black;
                x++;
                if(x==4)
                {
                    DialogResult result = MessageBox.Show("Ты можешь определиться с ответом!?", "Küsimus",MessageBoxButtons.YesNo);
                    if(result==DialogResult.Yes)
                    {
                        MessageBox.Show("Давай быстрее.", "Küsimus");
                    }
                    else
                    {
                        MessageBox.Show("Здесь без разницы, выбирай любой.", "Küsimus");
                    }
                }

            }
            if(r2.Checked)
            {
                r2.ForeColor = Color.Red;
                r1.ForeColor = Color.Black;
            }
            
            
        }
        private void Btn_MouseHover(object? sender, EventArgs e)
        {
            btn.BackColor = Color.Gray;
        }

        private void Btn_MouseLeave(object? sender, EventArgs e)
        {
            btn.BackColor= Color.Blue;
        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if(e.Node.Text=="Nupp-Button")
            {
                if(btn.Visible==false)
                {
                    btn.Visible = true;
                }
                else
                {
                    btn.Visible = false;
                }
            }
            else if(e.Node.Text== "Silt-Label")
            {
                if (lbl.Visible == true)
                {
                    lbl.Visible = false;
                }
                else
                {
                    lbl.Visible = true;
                }
            }
            else if (e.Node.Text == "Tekstikast-Textbox")
                if (txt_box.Visible == true)
                {
                    txt_box.Visible = false;
                }
                else
                {
                    txt_box.Visible = true;
                }

            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                if (r1.Visible == true)
                {
                    r1.Visible = false;
                    r2.Visible = false;
                }
                else
                {
                    r1.Visible = true;
                    r2.Visible = true;
                }
            }
            else if (e.Node.Text == "CheckBox")
            {
                if(c1.Visible == true)
                {
                    c1.Visible = false;
                    c2.Visible = false;
                }
                else
                {
                    c1.Visible = true;
                    c2.Visible = true;
                }
            }
            else if(e.Node.Text == "ListBox" )
            {
                if(lb.Visible == true)
                {
                    lb.Visible = false;
                    list_text_box.Visible = false;
                    btn_list_delelte.Visible = false;
                }
                else
                {
                    lb.Visible = true;
                    list_text_box.Visible = true;
                    btn_list_delelte.Visible = true;
                }
            }
            else if(e.Node.Text=="Kolmnurk")
            {
                kolmnurk = new Kolmnurk();
                kolmnurk.Show();
            }
            tree.SelectedNode = null;
            
        }
        private void Btn_Click(object? sender, EventArgs e)
        {
            if (btn.BackColor==Color.Green)
            {
                btn.BackColor = Color.Red;
            }
            else
            {
                lbl.Visible = true;
                lbl.BackColor = Color.Green;
            }
        }
    }
}
