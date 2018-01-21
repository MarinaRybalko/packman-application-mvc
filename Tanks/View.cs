using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Tanks
{
    partial class View : UserControl
    {
        Model model;
        public View(Model model)
        {
            InitializeComponent();
            this.model = model;
          
        }
        
        void Draw(PaintEventArgs e)
        {
            DrawWall(e);
            DrawFireTank(e);
            DrawApple(e);
            DrawTank(e);
            DrawPackman(e);
            DrawProjecTile(e);
            
            if (model.game_status != GameStatus.playing)
                return;
            

                Thread.Sleep(model.speed_game);
                Invalidate();
            
        }
        private  void DrawWall(PaintEventArgs e)
        {

            for (int y = 40; y < 520; y += 80)
                for (int x = 40; x < 520; x += 80)
                    e.Graphics.DrawImage(model.wall.Img, new Point(x, y));
        }
        private void DrawTank(PaintEventArgs e)
        {
            for (int i = 0; i < model.TanKs.Count; i++)
                e.Graphics.DrawImage(model.TanKs[i].Curimg, new Point(model.TanKs[i].X, model.TanKs[i].Y));
        }
        private void DrawApple(PaintEventArgs e)
        {
            for(int i=0;i<model.Apples.Count;i++)
            {
                e.Graphics.DrawImage(model.Apples[i].Img,new Point(model.Apples[i].X,model.Apples[i].Y));
            }
        }
        private void DrawProjecTile(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.ProjecTile.Img, new Point(model.ProjecTile.X-6,model.ProjecTile.Y-6));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
           
        }
        private void DrawPackman(PaintEventArgs e)
        {
          
            e.Graphics.DrawImage(model.PackMan.Curimg,new Point(model.PackMan.X,model.PackMan.Y));
        }
        private void DrawFireTank(PaintEventArgs e)
        {
            foreach(FireTank ft in model.FiretanksR)
            e.Graphics.DrawImage(ft.Curimg, new Point(ft.X,ft.Y));
            foreach (FireTank ft in model.FiretanksUp)
                e.Graphics.DrawImage(ft.Curimg, new Point(ft.X, ft.Y));
        }
    }
}
