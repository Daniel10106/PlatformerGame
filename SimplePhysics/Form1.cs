using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePhysics
{
    public partial class Form1 : Form
    {
        public double vSpeed;
        public double hSpeed;
        public bool movingRight;
        public bool jumping;
        public bool grounded;

        public Form1()
        {
            vSpeed = 0;
            hSpeed = 0;
            movingRight = true;
            InitializeComponent();
        }

        private void ballMove()
        {
            //fix the jump up part
            picBall.Top += (int)vSpeed;
            picBall.Left += (int)hSpeed;

            if (jumping)
            {
                vSpeed += 0.2;
            }
            if (picBall.Bottom > 300) { grounded = true; }
            if (picBall.Right >= this.ClientSize.Width) { hSpeed = -hSpeed; movingRight = !movingRight; }
            if (picBall.Left < 0) { hSpeed = -hSpeed; }
            if (grounded) { vSpeed = 0; }
            if (vSpeed < 0 && vSpeed > -0.4) { vSpeed = 0.4; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ballMove();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                hSpeed = -2;
            }
            if (e.KeyCode == Keys.Right)
            {
                hSpeed = 2;
            }
            if (e.KeyCode == Keys.Up)
            {
                grounded = false;
                jumping = true;
                vSpeed = 4;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                hSpeed = 0;
            }
            if (e.KeyCode == Keys.Right)
            {
                hSpeed = 0;
            }
        }
    }
}
