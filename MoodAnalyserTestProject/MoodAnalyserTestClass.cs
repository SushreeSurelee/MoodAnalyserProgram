using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProgram;
using System;

namespace MoodAnalyserTestProject
{
    [TestClass]
    public class MoodAnalyserTestClass
    {
        [TestMethod]
        [DataRow("I am in Happy Mood", "happy")]
        [DataRow("I am in Sad Mood", "sad")]
        [DataRow("I am in Any Mood", "happy")]
        //[DataRow(null, "Object reference not set to an instance of an object.")] //if return ex.Message in null input (exception message)
        [DataRow(null,"happy")]
        public void GivenMessageShouldReturnMood(string msg, string expected)
        {
            //Arrnage
            MoodAnalyser moodAnalyser = new MoodAnalyser(msg);
            //Act
            string actual = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
