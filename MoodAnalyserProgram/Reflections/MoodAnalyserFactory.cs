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

        public static object CreateMoodAnalyserUsingParameterConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message });
                    return instance;
                }
                else 
                {
                    throw new CustomMoodAnalyserException("Constructor not found", CustomMoodAnalyserException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                }
            }
            else
            {
                throw new CustomMoodAnalyserException("Class not found", CustomMoodAnalyserException.ExceptionTypes.CLASS_NOT_FOUND);
            }
        }

        public static string InvokeAnalyseMood(string message,string methodName)
        {
            try
            {
                Type type=Type.GetType("MoodAnalyserProgram.MoodAnalyser");
                object moodAnalyseObject = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterConstructor("MoodAnalyserProgram.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo analyseMoodInfo=type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch(Exception)
            {
                throw new CustomMoodAnalyserException("Constructor not found", CustomMoodAnalyserException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
            }
        }
    }
}
