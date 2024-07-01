using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace ECatcher
{
    public class Poop : GameObject
    {
        public Poop(double x, double y) : base(x, y) 
        {
            _image = SplashKit.LoadBitmap("Poop", "Poop.png");
            _value = -10;
            _velocity.X = -0.1;
            _velocity.Y = 0.7 + SplashKit.Rnd(2) - 1;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {
            _position.X += _velocity.X;
            _position.Y += (3 + _velocity.Y);
            _velocity = SplashKit.VectorAdd(_velocity, SplashKit.VectorTo(-0.01, 0.05));

        }

        public override bool IsAt(Bitmap img, Point2D pt)
        {
            return base.IsAt(img, pt);
        }
    }
}
