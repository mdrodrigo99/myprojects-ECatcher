using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;
using System.Threading;

namespace ECatcher
{
    public class Main : WindowInterface
    {
        readonly ToolList tool = new ToolList();
        readonly BirdList bird = new BirdList();
        readonly Bitmap bkg1 = SplashKit.LoadBitmap("Background1", "Background1.png");
        readonly Bitmap bkg2 = SplashKit.LoadBitmap("Background2", "Background2.png"); 
        int score = 0;
        int hiscore = HiScore.GetHiScore().ReadHiScore();

        public void GameWindow(bool[] isOn) 
        {
            SplashKit.ClearScreen();
            SplashKit.DrawBitmap(bkg1, 0, 0);
            SplashKit.DrawBitmap(bkg2, 0, 600);
            tool.Draw();
            bird.Draw();
            score = bird.Score();
            if (score > hiscore)
            {
                HiScore.GetHiScore().WriteHiScore(score);
                hiscore = HiScore.GetHiScore().ReadHiScore();
            }
            SplashKit.DrawTextOnWindow(SplashKit.CurrentWindow(), score.ToString(), Color.White,SplashKit.FontNamed("ROG"),15, 725, 675.9);
            SplashKit.DrawTextOnWindow(SplashKit.CurrentWindow(), hiscore.ToString(), Color.White, SplashKit.FontNamed("ROG"), 15, 585, 675.9);

            SplashKit.RefreshScreen(60);

            bird.Update();
            tool.Update();
            tool.CatchAtRemoveAt(bird);
            bird.BreakAt(bkg2, SplashKit.PointAt(0, 650));
            
            SplashKit.ProcessEvents();

            if (SplashKit.TimerTicks("timer") / 1000 == 17 && !isOn[3])
                isOn[3] = NewBird(isOn[3]);

            if (SplashKit.TimerTicks("timer") / 1000 == 30 && isOn[3])
                isOn[3] = NewBird(isOn[3]);

            if (SplashKit.TimerTicks("timer") / 1000 == 44 && !isOn[3])
                isOn[3] = NewBird(isOn[3]);

            if (SplashKit.TimerTicks("timer") / 1000 == 300) 
            {
                isOn[1] = false;
                isOn[2] = true;
            }
        }

        public bool NewBird(bool on) 
        {
            Point2D pt = bird.LastBirdLocation();
            bird.AddBird(new Bird(pt.X - 200, pt.Y + 20));

            return !on;
        }
    }
}
