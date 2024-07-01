using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace ECatcher
{
    public class Bird : GameObject
    {
        private readonly AnimationScript _birdScript;
        private readonly Animation _bird;
        private DrawingOptions _option;
        protected readonly EggList _droppedEgg;

        public Bird(double x, double y) : base(x, y) 
        {
            // Load image and set its cell details
            ChangeBird();

            // Load the animation script
            _birdScript = SplashKit.LoadAnimationScript("BirdScript", "script.txt");

            // Create the animation
            _bird = _birdScript.CreateAnimation("FlyRight");

            // Create a drawing option
            _option = SplashKit.OptionWithAnimation(_bird);

            _droppedEgg = new EggList();
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(_image, _position.X, _position.Y, _option);
            _droppedEgg.Draw();
        }

        public override void Update()
        {
            _position.X += 3;

            if (_position.X > SplashKit.ScreenWidth()+200)
            {
                _position.X = -100;
                _position.Y = (int) SplashKit.Rnd(5, 100);
                SplashKit.RestartAnimation(_bird);
            }

            if (SplashKit.Rnd(80) == 1 && _position.X < SplashKit.ScreenWidth() - 200 && _position.X > 200)
            {
                _droppedEgg.Chicks();
                _droppedEgg.EggDropped(_position.X + 90, _position.Y + 150);
            }

            _droppedEgg.Update();
        }

        public void ChangeBird() 
        {
            float r = SplashKit.Rnd();

            if (r < 0.4)
            {
                _image = SplashKit.LoadBitmap("RedBird", "RedBird.png");
                _value = 20;
            }
            else if (r < 0.7)
                _image = SplashKit.LoadBitmap("GreenBird", "GreenBird.png");
            else
                _image = SplashKit.LoadBitmap("PinkBird", "PinkBird.png");

            _image.SetCellDetails(180, 178, 14, 4, 56);
        }

        public Animation BirdAnime 
        {
            get 
            {
                return _bird;
            }
        }

        public List<GameObject> CatchAt(Bitmap img, Point2D pt, bool r) 
        {
            return _droppedEgg.CatchAt(img,pt,r);
        }

        public void Remove(GameObject e, bool r) 
        {
            _droppedEgg.Remove(e,r);
        }

        public void ChangeBitmap(GameObject e) 
        {
            _droppedEgg.ChangeBitmap(e);
        }

        public int Score
        {
            get 
            {
                return _droppedEgg.Value;
            }
        }
    }
}
