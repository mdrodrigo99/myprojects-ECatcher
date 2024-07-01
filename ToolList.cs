using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace ECatcher
{
    public class ToolList
    {
        private readonly List<Tools> _toolLists;

        public ToolList() 
        {
            _toolLists = new List<Tools>
            {
                new Basket()
            };
        }

        public void AddTool(Tools t) 
        {
            _toolLists.Add(t);
        }

        public void Draw() 
        {
            foreach (Tools t in _toolLists)
                t.Draw();
        }

        public void Update() 
        {
            List<Tools> toRemove = new List<Tools>();
            foreach (Tools t in _toolLists)
            {
                if (SplashKit.MouseDown(MouseButton.LeftButton))
                {
                    if (t.GetType().Equals(typeof(Basket)))
                        t.Position = SplashKit.PointAt(SplashKit.MousePosition().X - 38, SplashKit.MousePosition().Y - 13);
                    else
                        t.Position = SplashKit.PointAt(SplashKit.MousePosition().X - 13, SplashKit.MousePosition().Y - 51);
                }

                if (t.Position.Y > 500)
                    t.Position = SplashKit.PointAt(t.Position.X, 500);

                if (t.Position.Y < 200)
                    t.Position = SplashKit.PointAt(t.Position.X, 200);
                
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    toRemove.Add(t);
                }
            }

            if (SplashKit.MouseClicked(MouseButton.RightButton))
            {
                foreach (Tools t in toRemove) 
                {
                    if(t.GetType().Equals(typeof(Basket)))
                        _toolLists.Add(new Fork());
                    else
                        _toolLists.Add(new Basket());
                }
            }

            foreach (Tools t in toRemove)
                _toolLists.Remove(t);
        }

        public void CatchAtRemoveAt(BirdList bird) 
        {
            foreach (Tools t in _toolLists)
            {
                if (t.GetType().Equals(typeof(Basket)))
                    bird.CatchAt(t.Image, t.Position);
            }

            foreach (Tools t in _toolLists)
            {
                if (t.GetType().Equals(typeof(Fork)))
                    bird.KillAt(t.Image, t.Position);
            }
        }
    }
}
