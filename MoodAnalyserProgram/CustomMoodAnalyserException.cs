using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProgram
{
    class CustomMoodAnalyserException:Exception
    {
        public ExceptionTypes exceptionTypes;
        public enum ExceptionTypes
        {
            NULL_MESSAGE
        }
        public CustomMoodAnalyserException(string msg, ExceptionTypes exceptionTypes)
        {
            this.exceptionTypes = exceptionTypes;
        }


    }
}
