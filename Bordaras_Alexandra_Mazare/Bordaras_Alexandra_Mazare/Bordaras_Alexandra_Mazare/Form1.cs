using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bordaras_Alexandra_Mazare
{
    public partial class Form1 : Form
    {
        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion

        #region .. code for Flucuring ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion
       

        public Form1()
        {
            InitializeComponent();
            floare.Visible = false;
            viespe.Visible = false;
            viespe2.Visible = false; SetDoubleBuffered(flowLayoutPanel1);
         

        }
        bool right = false;
        bool left = false;
        bool up = false;
        bool rotate = false;
        int vieti = 3;
        bool v = false;
        bool f = false;
        bool vies = false;
        bool ok = false;
        bool ok1 = false;
        bool ok2 = false;
        Random random = new Random();
      
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) up = true;
            if (e.KeyCode == Keys.Left) left = true;
            if (e.KeyCode == Keys.Right) right = true;
        }
     
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up) up = false;
            if (e.KeyCode == Keys.Left) left = false;
            if (e.KeyCode == Keys.Right) right = false;
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void aparitie()
        {
            ok = false;
            int r;
            r = random.Next(2, 35);
            if (r == 2&&viespe.Visible==false)
            {
                viespe.Location = new Point(565, 141);
                viespe.Visible = true;
                v = true;

            }
            if(r==15&&floare.Visible==false)
            {
                floare.Location = new Point(584, 291);
                floare.Visible = true;
                f = true;
            }
            if(r==30&&viespe2.Visible==false&&v==false)
            {
                viespe2.Location = new Point(574, 3);
                viespe2.Visible = true;
                vies = true;
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
          
            lbl_vieti.Text = Convert.ToString(vieti);
            if (bondaras.Top <= this.Height - bondaras.Height - 80) bondaras.Top += 8;
            if (up && bondaras.Top >= 4) bondaras.Top -= 16;
         
            aparitie();
            if (right == true)
            {
                bondaras.Left += 6;
                if (rotate == true)
                {
                    bondaras.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bondaras.Invalidate();
                    rotate = false;
                }
            }
            if (left == true)
            {
                bondaras.Left -= 6;
                if (rotate == false)
                {
                    bondaras.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    bondaras.Invalidate();
                    rotate = true;
                }
            }
            if (v == true)
            {
                ok1 = false;
                viespe.Left -= 6;
            }
            if (f == true)
            {
                ok = false;
                floare.Location = new Point(floare.Location.X - 5, floare.Location.Y);
            }
            if(vies==true)
            {
                ok2 = false;
                viespe2.Left -= 6;
            }
            if (bondaras.Bounds.IntersectsWith(viespe.Bounds))
            {

                if (ok1 == false && viespe.Visible == true)
                {
                    ok1 = true;
                    vieti = vieti - 1;
                    viespe.Visible = false;
                    viespe.Location = new Point(584, 291);
                    v = false;
                }
                lbl_vieti.Text = Convert.ToString(vieti);
            }

                if (viespe.Top<=0||viespe.Left<=0)
                {
                    viespe.Visible = false;
                v = false;
                }
            if (bondaras.Bounds.IntersectsWith(viespe2.Bounds))
            {
                if (ok2 == false && viespe2.Visible == true)
                {
                    ok2 = true;
                    vieti = vieti - 1;
                    viespe2.Visible = false;
                    viespe2.Location = new Point(584, 291);
                    vies = false;
                }
                lbl_vieti.Text = Convert.ToString(vieti);
            }

                if (viespe2.Top <= 0 || viespe2.Left <= 0)
            {
                viespe2.Visible = false;
                vies = false;
            }

            if (bondaras.Bounds.IntersectsWith(floare.Bounds))
            {
                if (ok == false&& floare.Visible==true)
                {
                    ok = true;
                    vieti = vieti + 1; 
                    floare.Visible = false;
                    floare.Location = new Point(584, 291);
                    f = false;
                }
                lbl_vieti.Text = Convert.ToString(vieti);
            }
                if (floare.Top <= 0 || viespe.Left <= 0)
            {
                floare.Visible = false;
                f = false;
            }

            if (vieti == 0)
            {
                Form2 da = new Form2();
                da.Show();
                this.Hide();
                timer1.Stop();
            }

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {

        }
    }
    }

