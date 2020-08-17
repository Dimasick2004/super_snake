using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        static int Height = 20, Width = 20;
        Pen sn = new Pen(Color.Orange, 4);
        snake sna;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = sna.coordinats.Count()-1; i >= 0; i--)
            {
                if (i == 0)
                {
                    sna.Move();
                }
                else
                {
                    var temp = sna.coordinats[i];
                    temp.x = sna.coordinats[i - 1].x;
                    temp.y = sna.coordinats[i - 1].y;
                    sna.coordinats[i] = temp;
                }
                
            }
            
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            for(int i = 0; i<sna.coordinats.Count(); i++)
            {
                g.DrawRectangle(sn, sna.coordinats[i].x * Width, sna.coordinats[i].y * Height, Width, Height);
            }
            if ((sna.coordinats[0].x < 0) || (sna.coordinats[0].x < Width) || (sna.coordinats[0].y < 0) || (sna.coordinats[0].y < Height))
            {
                MessageBox.Show("Вы заползли слишком далеко.");
            } 
            pictureBox1.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 200;
            timer1.Enabled = true;
            sna = new snake();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "W":
                    {
                        sna.WantNavigation = 'T';
                        break;
                    }
                case "A":
                    {
                        sna.WantNavigation = 'L';
                        break;
                    }
                case "S":
                    {
                        sna.WantNavigation = 'D';
                        break;
                    }
                case "D":
                    {
                        sna.WantNavigation = 'R';
                        break;
                    }
                default:
                    {
                        sna.WantNavigation = sna.Navigation;
                        break;
                    }
            }
        }
    }
}
