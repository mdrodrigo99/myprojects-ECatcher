using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK; 

namespace ECatcher
{
    public class EggList
    {
        private List<GameObject> _eggs;
        private int _value;

        public EggList() 
        {
            _eggs = new List<GameObject>();
        }

        public void EggDropped(double x, double y) 
        {
            GameObject egg;
            float r = SplashKit.Rnd();

            if (r < 0.5)
                egg = new WhiteEgg(x, y);
            else if (r > 0.5 && r < 0.9)
                egg = new Poop(x, y);
            else
                egg = new GoldEgg(x, y);

            _eggs.Add(egg);
        }

        public void Draw() 
        {
            foreach (GameObject e in _eggs) 
            {
                e.Draw();
            }
        }

        public void Update() 
        {
            foreach (GameObject e in _eggs)
            {
                e.Update();
            }
        }

        public List<GameObject> CatchAt(Bitmap img, Point2D pt, bool r)
        {
            List<GameObject> toRemove = new List<GameObject>();

            foreach (GameObject e in _eggs)
            {
                if (e.IsAt(img, pt))
                    toRemove.Add(e);
            }

            foreach (GameObject e in toRemove) 
            {
                if (e.Value == -10 && r)
                    Remove(e, true);
            }

            return toRemove;
        }

        public void Remove(GameObject e, bool r) 
        {
            if (r)
                _value += e.Value;
            _eggs.Remove(e);
        }

        public void ChangeBitmap(GameObject e) 
        {
            if (e.Value == 5)
                e.Image = SplashKit.LoadBitmap("BrokeWhiteEgg", "BrokeWhiteEgg.png");
            else if (e.Value == 10)
                e.Image = SplashKit.LoadBitmap("BrokeGoldEgg", "BrokeGoldEgg.png");
            else if(e.Value == -10)
                e.Image = SplashKit.LoadBitmap("DropPoop", "DropPoop.png");

            e.Velocity = SplashKit.VectorTo(0,0);
            e.Position = SplashKit.PointAt(e.Position.X,600);
        }

        public void Chicks() 
        {
            SplashKit.PlaySoundEffect("Chicks");
        }

        public int Value 
        {
            get 
            {
                return _value;
            }
            set 
            {
                _value = value;
            }
        }
    }
}
