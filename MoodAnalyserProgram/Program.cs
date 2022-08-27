using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyser Application\n");
            string msg = "I am in Happy Mood";
            MoodAnalyser moodAnalyser = new MoodAnalyser(msg);
            moodAnalyser.AnalyseMood();
            Console.ReadLine();
        }
    }
}