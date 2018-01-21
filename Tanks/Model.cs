using System;
using System.Threading;
using System.Collections.Generic;
using Tanks;
using System.Media;
using System.Windows.Forms;
namespace Tanks
{
    public delegate void StatusL();
    class Model
    {
       
        private SoundPlayer sp;
        private int collectedApples;
        private int size_field;
        private int amount_tanks;
        private int amount_apple;
        private int step;
       
        private static Random rn;
        private Packman packMan;
        private Projectile projecTile;
        private FireTank ft;


        private List<Tank> tanks;
        private List<Apple> apples;
        private List<FireTank> firetanksR;
        private List<FireTank> firetanksUp;

        public event StatusL statusGame;
        public int speed_game;
        public Wall wall;
        public Tanks.GameStatus game_status;

        private void CreateTanks()
        {

            int x; int y;
            while (tanks.Count < amount_tanks + 1)
            {
                if (tanks.Count == 0)
                {
                    tanks.Add(new Hunter(size_field, rn.Next(6) * 80, rn.Next(6) * 80));

                }
                else
                {
                    x = rn.Next(6) * 80;
                    y = rn.Next(6) * 80;

                    bool flag = true;
                    foreach (Tank t in TanKs)

                    {
                        if (t.X == x && t.Y == y)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        tanks.Add(new Tank(size_field, x, y));
                    }
                }

            }

        }
        private void CreateApples(int applesNew)
        {
            int x; int y;
            while (apples.Count < amount_apple + applesNew)
            {
                x = rn.Next(6) * 80;
                y = rn.Next(6) * 80;

                bool flag = true;
                foreach (Apple a in apples)
                {
                    foreach (FireTank ft in FiretanksR)
                    {
                        foreach (FireTank ft1 in FiretanksUp)
                        {
                            if ((a.X == x && a.Y == y) || (ft.X == x && ft.Y == y) || (ft1.X == x && ft1.Y == y))
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                }
                if (flag)
                {
                    apples.Add(new Apple(x, y));
                }

            }
        }
        private void TryDestroyTank()
        {
            for (int i = 1; i < tanks.Count; i++)
                if ((Math.Abs(tanks[i].X - 10 - projecTile.X) < 26 && Math.Abs(tanks[i].Y - 10 - projecTile.Y) < 26) &&
                    (Math.Abs(tanks[i].X - 10 - projecTile.X) > 4 && Math.Abs(tanks[i].Y - 10 - projecTile.Y) > 4))
                {
                    {
                        if (tanks[i].Direct_x == 1 || tanks[i].Direct_x == -1)
                        {
                            ft.PutCurImgUp();
                            firetanksUp.Add(new FireTank(tanks[i].X, tanks[i].Y));
                            tanks.RemoveAt(i);
                            projecTile.DefaultSettings();
                        }
                        else if (tanks[i].Direct_y == 1 || tanks[i].Direct_y == -1)
                        {
                            ft.PutCurImgR();
                            FiretanksR.Add(new FireTank(tanks[i].X, tanks[i].Y));
                            tanks.RemoveAt(i);
                            projecTile.DefaultSettings();
                        }
                    }
                }

        }
        private void IfCollisionOfTank()
        {
            for (int i = 0; i < tanks.Count - 1; i++)
            {
                for (int j = i + 1; j < tanks.Count; j++)
                {
                    if ((Math.Abs(tanks[i].X - tanks[j].X) <= 40 && (tanks[i].Y == tanks[j].Y))
                        ||
                      (Math.Abs(tanks[i].Y - tanks[j].Y) <= 40 && (tanks[i].X == tanks[j].X))
                        ||
                     (Math.Abs(tanks[i].X - tanks[j].X) <= 40 && Math.Abs(tanks[i].Y - tanks[j].Y) <= 40))
                    {
                        if (i == 0)
                            ((Hunter)tanks[i]).TurnAround();
                        else
                        {
                            tanks[i].TurnAround();

                        }

                        tanks[j].TurnAround();
                    }
                }
            }
        }
        private void IfCollisionOfTankAndPackman()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                if ((Math.Abs(tanks[i].X - packMan.X) <= 30 && (tanks[i].Y == packMan.Y))
                       ||
                     (Math.Abs(tanks[i].Y - packMan.Y) <= 30 && (tanks[i].X == packMan.X))
                       ||
                    (Math.Abs(tanks[i].X - packMan.X) <= 30 && Math.Abs(tanks[i].Y - packMan.Y) <= 30))
                {
                    game_status = GameStatus.loser;
                    SetSound();
                    if (statusGame != null)
                    {
                        statusGame();

                    }

                }
            }
        }
        private void IfPickApple()
        {
            for (int i = 0; i < apples.Count; i++)
            {

                if (packMan.X == apples[i].X && packMan.Y == apples[i].Y)
                {
                    apples[i] = new Apple(step += 40, 170);
                    collectedApples++;
                    CreateApples(collectedApples);

                }
            }
        }
        private void RunAllComponents()
        {
            projecTile.Run();
            packMan.Run();
            ((Hunter)tanks[0]).Run(packMan.X, packMan.Y);
            for (int i = 1; i < tanks.Count; i++)
            {
                tanks[i].Run();
            }

            foreach (FireTank ft in FiretanksR)
            {
                ft.FireR();
            }
            foreach (FireTank ft in FiretanksUp)
            {
                ft.FireUp();
            }
        }

     

        internal List<Tank> TanKs
        {
            get
            {
                return tanks;
            }

            set
            {
                tanks = value;
            }
        }
        internal List<Apple> Apples
        {
            get
            {
                return apples;
            }


        }
        internal Packman PackMan
        {
            get
            {
                return packMan;
            }


        }
        internal Projectile ProjecTile
        {
            get
            {
                return projecTile;
            }

            set
            {
                projecTile = value;
            }
        }
        internal List<FireTank> FiretanksR
        {
            get
            {
                return firetanksR;
            }


        }
        internal List<FireTank> FiretanksUp
        {
            get
            {
                return firetanksUp;
            }


        }

        public void SetSound()
        {
            if (game_status == GameStatus.playing)
            {
                sp.PlayLooping();
            }
            else if (game_status == GameStatus.winner)
            {
                sp = new SoundPlayer(Properties.Resources.win);
                sp.Play();

            }
            else if (game_status == GameStatus.loser)
            {
                sp = new SoundPlayer(Properties.Resources.lose);
                sp.Play();
               

            }
            else if (game_status == GameStatus.stopping)
            {
                sp.Stop();
            }
        }
        public Model()
        {

        }
        public Model(int size_field, int amount_tanks, int amount_apple, int speed_game)
        {
            this.size_field = size_field;
            this.amount_tanks = amount_tanks;
            this.amount_apple = amount_apple;
            this.speed_game = speed_game;
            rn = new Random();
            sp = new SoundPlayer(Properties.Resources.battle4);
            ft = new FireTank(-20, -40);
            NewGame();
        }
        public void Play()
        {
            SetSound();
            while (game_status == global::Tanks.GameStatus.playing)
            {
                Thread.Sleep(speed_game);
                RunAllComponents();
                TryDestroyTank();
                IfCollisionOfTank();
                IfCollisionOfTankAndPackman();
                IfPickApple();

               
                if (collectedApples > 4)
                {
                    game_status = GameStatus.winner;
                    SetSound();
                    if (statusGame != null)
                    {
                        statusGame();
                    }

                }
            }
        }
        public void NewGame()
        {
            tanks = new List<Tank>();

            apples = new List<Apple>();
            firetanksR = new List<FireTank>();
            firetanksUp = new List<FireTank>();
            wall = new Wall();
            CreateTanks();
            CreateApples(0);
            game_status = GameStatus.stopping;
            packMan = new Packman(size_field);
            projecTile = new Projectile();
            collectedApples = 0;
            step = 560;
            sp = new SoundPlayer(Properties.Resources.battle4);
        }
      
    }
}
