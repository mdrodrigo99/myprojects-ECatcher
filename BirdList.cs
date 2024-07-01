using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace ECatcher
{
    public class BirdList
    {
        List<Bird> _birds = new List<Bird>();
        private int _value;

        public BirdList()
        {
            AddBird(new Bird(150, 100));
            _value = 0;
        }

        public void AddBird(Bird bird)
        {
            _birds.Add(bird);
        }

        public void RemoveBird(Bird bird) 
        {
            _birds.Remove(bird);
        }

        public void Draw()
        {
            foreach (Bird b in _birds)
            {
                b.Draw();
            }
        }

        public void Update()
        {
            foreach (Bird b in _birds)
            {
                b.Update();
                b.BirdAnime.Update();
            }
        }

        public void CatchAt(Bitmap img, Point2D pt)
        {
            List<GameObject> list;
            int count = 0;
            var i = -15;

            foreach (Bird b in _birds)
            {
                list = b.CatchAt(img, pt, true);
                count += list.Count;
                foreach (GameObject e in list)
                {
                    if (e.Value == -10)
                        count--;
                }
            }

            foreach (Bird b in _birds)
            {
                list = b.CatchAt(img, pt, true);
                if (count > 3)
                {
                    foreach (GameObject e in list)
                    {
                        b.Remove(e,true);
                    }
                }
                else 
                {
                    foreach (GameObject e in list)
                    {
                        e.Velocity = SplashKit.VectorTo(0, 0);
                        e.Position = SplashKit.PointAt((pt.X + 38 + i) - (SplashKit.BitmapWidth(e.Image) / 2), pt.Y - 35);
                        i += 15;
                    }
                }
            }
        }

        public void KillAt(Bitmap img, Point2D pt) 
        {
            List<GameObject> toRemove = new List<GameObject>();
            foreach (Bird b in _birds)
            {
                if(SplashKit.BitmapCollision(b.Image, b.Position, img, pt) && _birds.Count > 1 && b.Value == 20)
                    toRemove.Add(b);
            }
            foreach (Bird b in toRemove)
            {
                _value += b.Value;
                _birds.Remove(b);
            }
        }

        public void BreakAt(Bitmap img, Point2D pt) 
        {
            List<GameObject> list;
            List<GameObject> toRemove = new List<GameObject>();
            int count = 0;

            foreach (Bird b in _birds)
            {
                list = b.CatchAt(img, pt, false);
                count += list.Count;
            }

            foreach (Bird b in _birds)
            {
                list = b.CatchAt(img, pt, false);
                foreach (GameObject e in list)
                {
                    b.ChangeBitmap(e);
                    toRemove.Add(e);
                }
                if (count > 2)
                {
                    foreach (GameObject e in toRemove)
                    {
                        b.Remove(e,false);
                    }
                }
            }
        }

        public int Score() 
        {
            int score = 0;

            foreach (Bird b in _birds) 
            {
                score += b.Score;
            }

            score += _value;

            return score;
        }

        public Point2D LastBirdLocation()
        {
            return _birds[_birds.Count - 1].Position;
        }
    }
}
