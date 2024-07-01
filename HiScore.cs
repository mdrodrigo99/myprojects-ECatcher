using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ECatcher
{
    public class HiScore
    {
        private static HiScore instance;

        private HiScore() { }

        public static HiScore GetHiScore() 
        {
            if (instance == null)
                instance = new HiScore();
            return instance;
        }

        public int ReadHiScore() 
        {
            string filePath = "E:/SwinburneModules/Projects/TProjects/ECatcher/hiscore.txt";
            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath)) { }
            }

            StreamReader reader = new StreamReader(filePath);
            int hiscore = 0;
            try
            { 
                hiscore = Convert.ToInt32(reader.ReadLine());
            }
            finally 
            {
                reader.Close();
            }
            return hiscore;
        }

        public void WriteHiScore(int hiscore) 
        {
            StreamWriter writer = new StreamWriter("E:/SwinburneModules/Projects/TProjects/ECatcher/hiscore.txt");
            try
            {
                writer.WriteLine(hiscore);
            }
            finally 
            {
                writer.Close();
            }
        }
    }
}
