using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;

namespace ECatcher
{
    public class Begin : WindowInterface
    {
        readonly Bitmap bkg = SplashKit.LoadBitmap("StartMenu", "StartMenu.png");

        public void GameWindow(bool[] isOn) 
        {
            SplashKit.ClearScreen();
            SplashKit.DrawBitmap(bkg, 0, 0);

            SplashKit.RefreshScreen(60);

            SplashKit.ProcessEvents();

            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                SplashKit.PlaySoundEffect("Background", 5);
                isOn[0] = false;
                SplashKit.StartTimer("timer");
                isOn[1] = true;
            }
        }
    }
}
