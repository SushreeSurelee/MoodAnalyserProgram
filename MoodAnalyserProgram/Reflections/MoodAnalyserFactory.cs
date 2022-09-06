using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProgram.Reflections
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyserObject(string className,string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result=Regex.Match(className, pattern);
            if(result.Success)
            {
                try 
                {
                    Assembly executingAssembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executingAssembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch(ArgumentException)
                {
                    throw new CustomMoodAnalyserException("Class not found",CustomMoodAnalyserException.ExceptionTypes.CLASS_NOT_FOUND);
                }
            }
            else
            {
                throw new CustomMoodAnalyserException("Constructor not found", CustomMoodAnalyserException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
            }
        }
    }
}
