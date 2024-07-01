using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace ECatcher
{
    public class End : WindowInterface
    {
        readonly Bitmap end = SplashKit.LoadBitmap("End", "End.png");

        public void GameWindow(bool[] isOn)
        {
            SplashKit.ClearScreen();
            SplashKit.DrawBitmap(end, 0, 0);
            SplashKit.DrawTextOnWindow(SplashKit.CurrentWindow(), HiScore.GetHiScore().ReadHiScore().ToString(), Color.White, SplashKit.FontNamed("ROG"), 50, 350, 400);
            SplashKit.RefreshScreen(60);

            SplashKit.ProcessEvents();
        }
    }
}
