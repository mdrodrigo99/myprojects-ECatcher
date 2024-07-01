using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace ECatcher
{
    public class Tools : GameObject
    {
        public Tools(Bitmap img) : base(SplashKit.ScreenWidth() / 2 - 38, SplashKit.ScreenHeight() - 150)
        {
            _image = img;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
