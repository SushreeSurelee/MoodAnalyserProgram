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
            try
            {
                if (message.ToLower().Contains("happy"))
                {
                    return "HAPPY";
                }
                if (message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                if (message.Equals(string.Empty)) //"" ,this is not null
                {
                    throw new CustomMoodAnalyserException("Message having empty value",CustomMoodAnalyserException.ExceptionTypes.EMPTY_MESSAGE);
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch(NullReferenceException)
            {
                //Console.WriteLine(ex.Message);
                throw new CustomMoodAnalyserException("Message having null value", CustomMoodAnalyserException.ExceptionTypes.NULL_MESSAGE);
                //return "HAPPY";
            }
        }
    }
}
