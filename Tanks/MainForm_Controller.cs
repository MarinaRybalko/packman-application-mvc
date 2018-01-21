using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Tanks
{
    
   partial class MainForm_Controller : Form
    {
      
        View view;
        Model model;
        Thread modelplay;
        bool isSound;
        SoundPlayer sp;
       
        public MainForm_Controller() : this(600)
            {

        }
        public MainForm_Controller(int size_field) : this(size_field, 5)
            {

        }
        public MainForm_Controller(int size_field, int amount_tanks) : this(size_field, amount_tanks, 5)
            {

        }
        public MainForm_Controller(int size_field, int amount_tanks, int amount_apple) : this(size_field, amount_tanks, amount_apple, 20)
            {

        }
        public MainForm_Controller(int size_field, int amount_tanks, int amount_apple, int speed_game)
        {
            InitializeComponent();

            model = new Model(size_field,amount_tanks,amount_apple,speed_game);
            view = new View(model);
            //statusL = new StatusL(ChangeStatusLabel);
            isSound = true;
            model.statusGame += new StatusL(ChangeStatusLabel);
            this.Controls.Add(view);
            sp = new SoundPlayer(Properties.Resources.battle4);
        }

       
        private void MainForm_Controller_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(modelplay != null)
            {
                model.game_status = GameStatus.stopping;
                modelplay.Abort();
            }
           DialogResult dr= MessageBox.Show("Вы хотите закрыть приложение? ","Tanks",MessageBoxButtons.YesNoCancel);
            if(dr==DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

      
        private void StartStop_Click(object sender, EventArgs e)
        {
            if (model.game_status == GameStatus.loser||model.game_status==GameStatus.winner)
            {
               

               
                model.NewGame();
                
            }
            
            if (model.game_status == GameStatus.playing)
            {
                modelplay.Abort();
                model.game_status = GameStatus.stopping;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox2.Focus();

                sp.Stop();
               
               
                ChangeStatusLabel();
                view.Invalidate();
             

            }

            else if (model.game_status==GameStatus.stopping)
            {

                pictureBox2.Visible = false;
                pictureBox1.Visible = true;
                pictureBox1.Focus();
                model.game_status = GameStatus.playing;
                modelplay = new Thread(model.Play);
                modelplay.Start();
                sp.Play();
                //ChangeStatusLabel();
                Invoke(new Action(() => { StatusMessage.Text = "You are " + model.game_status.ToString(); }));
                view.Invalidate();
                
            }
          

        }

        private void ChangeStatusLabel()
        {
            Invoke(new Action(()=>{ StatusMessage.Text = "You are " + model.game_status.ToString(); }));
            Invoke(new Action(() =>
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox2.Focus();
            }));

        }

        private void pictureBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
              
                case "A":
              
                    {
                        model.PackMan.Nextdirect_x = -1;
                        model.PackMan.Nextdirect_y = 0;
                    }
                    break;
               
                case "D":
               
                    {
                        model.PackMan.Nextdirect_x = 1;
                        model.PackMan.Nextdirect_y = 0;
                    }
                    break;
              
                case "W":
               
                    {
                        model.PackMan.Nextdirect_x = 0;
                        model.PackMan.Nextdirect_y = -1;
                    }
                    break;
               
                case "S":
              
                    {
                        model.PackMan.Nextdirect_x = 0;
                        model.PackMan.Nextdirect_y = 1;
                    }
                    break;
                case "L":
                    {
                        SetStartProjectile();
                    }
                    break;


            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.NewGame();

            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Focus();
            view.Refresh();
        }

        private void aboutGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game Tanks version 1.0. This application was created by Marina Rybalko  and Marina Levitskaya. For controlling the Packman press 'A','W','D','S' and for shooting press 'L'. Good luck! ","Tanks");
        }

        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSound = !isSound;
            if(isSound)
            {
                this.soundToolStripMenuItem.Image = global::Tanks.Properties.Resources.soundOn;
                sp = new SoundPlayer(Properties.Resources.battle4);
                sp.PlayLooping();
            }
            else
            {
                this.soundToolStripMenuItem.Image = global::Tanks.Properties.Resources.soundOff;
                sp.Stop();

            }
        }
        private void SetStartProjectile()
        {
            model.ProjecTile.X = model.PackMan.X;
            model.ProjecTile.Y = model.PackMan.Y;
            model.ProjecTile.Direct_x = model.PackMan.Direct_x;
            model.ProjecTile.Direct_y = model.PackMan.Direct_y;

            if (model.PackMan.Direct_y == -1)
            {
                model.ProjecTile.Y = model.PackMan.Y - 40;
                model.ProjecTile.X = model.PackMan.X;
            }
            if (model.PackMan.Direct_y == 1)
            {
                model.ProjecTile.X = model.PackMan.X;
                model.ProjecTile.Y = model.PackMan.Y + 40;
            }
            if (model.PackMan.Direct_x == -1)
            {
                model.ProjecTile.X = model.PackMan.X - 40;
                model.ProjecTile.Y = model.PackMan.Y;

            }
            if (model.PackMan.Direct_x == 1)
            {
                model.ProjecTile.X = model.PackMan.X + 40;
                model.ProjecTile.Y = model.PackMan.Y;
            }
        }

        private void resultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(model.game_status==GameStatus.loser || model.game_status==GameStatus.winner)
            MessageBox.Show("You are " + model.game_status.ToString());
        }
    }
}
