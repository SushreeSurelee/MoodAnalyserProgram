using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProgram
{
    public class MoodAnalyser
    {
        public string message;

        public MoodAnalyser(string msg)
        {
            this.message = msg;
        }
        public string AnalyseMood()
        {
            string happyMood = "happy", sadMood = "sad";

            if (message.ToLower().Contains(happyMood))
            {
                Console.WriteLine("User is in {0} mood.", happyMood);
                return happyMood;
            }
            else if (message.ToLower().Contains(sadMood))
            {
                Console.WriteLine("User is in {0} mood.", sadMood);
                return sadMood;
            }
            else
            {
                Console.WriteLine("User is neither happy nor sad");
                return happyMood;
            }
        }
    }
}
