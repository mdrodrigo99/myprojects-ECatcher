using System;
using SplashKitSDK;
using System.Threading;
using System.Diagnostics;

namespace ECatcher
{
    public class Program
    {
        public static void Main()
        {
           
            new Window("ECatcher", 800, 700);
            SplashKit.LoadSoundEffect("Chicks", "Chicks.wav");
            SplashKit.LoadSoundEffect("Background", "Background.wav");
            SplashKit.LoadFont("ROG", "ROG.otf");
            SplashKit.CreateTimer("timer");

            Stopwatch s = new Stopwatch();

            s.Start();

            bool[] isOn = new bool[5];

            isOn[0] = true;
            for (var i = 1; i < 5; i++)
                isOn[i] = false;

            Begin begin = new Begin();
            Main main = new Main();
            End end = new End(); 

            while (!SplashKit.WindowCloseRequested("ECatcher"))
            {
                if(isOn[0])
                    begin.GameWindow(isOn);

                if (isOn[1])                
                    main.GameWindow(isOn);

                if (isOn[2])
                    end.GameWindow(isOn);
            }
        }
    }
}
