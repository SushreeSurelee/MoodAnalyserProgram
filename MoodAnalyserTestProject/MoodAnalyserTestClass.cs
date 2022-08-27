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
