using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProgram;
using MoodAnalyserProgram.Reflections;
using System;

namespace MoodAnalyserTestProject
{
    [TestClass]
    public class MoodAnalyserTestClass
    {
        [TestMethod]
        [DataRow("I am in Happy Mood", "HAPPY")]
        [DataRow("I am in Sad Mood", "SAD")]
        [DataRow("I am in Any Mood", "HAPPY")]
        //[DataRow(null, "Object reference not set to an instance of an object.")] //if return ex.Message in null input (exception message)
        //[DataRow(null,"HAPPY")]
        public void GivenMessageShouldReturnMood(string msg, string expected)
        {
            //Arrnage
            MoodAnalyser moodAnalyser = new MoodAnalyser(msg);
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory ("CustomException")]
        [DataRow("", "Message having empty value")]
        [DataRow(null, "Message having null value")]
        public void GivenNullShouldReturnCustomException(string msg, string expected)
        {   
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser(msg);
                string actual = moodAnalyser.AnalyseMood();
            }
            catch(CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Reflection")]
        //[DataRow("MoodAnalyserProgram.MoodAnalyser", "MoodAnalyser")]
        public void GivenClassInfoShouldReturnDefaultConstructor()
        {
            object expected = new MoodAnalyser();
            object obj = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyserProgram.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
    }
}
