using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foosball_Lib.Validations;
using System.Text.RegularExpressions;

namespace Foosball_MIFTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void UsernamePatternMatchTest()
        {
            //arrange
            string string1 = "Jonas";
            string string2 = ".";
            string string3 = "";
            string string4 = "Jonas%";
            string string5 = "/n";
            bool returned1;
            bool returned2;
            bool returned3;
            bool returned4;
            bool returned5;
            bool expected1 = true;
            bool expected2 = false;
            bool expected3 = false;
            bool expected4 = false;
            bool expected5 = false;

            //act
            returned1 = Validation.UsernamePatternMatch(string1);
            returned2 = Validation.UsernamePatternMatch(string2);
            returned3 = Validation.UsernamePatternMatch(string3);
            returned4 = Validation.UsernamePatternMatch(string4);
            returned5 = Validation.UsernamePatternMatch(string5);

            //assert
            Assert.AreEqual(returned1, expected1);
            Assert.AreEqual(returned2, expected2);
            Assert.AreEqual(returned3, expected3);
            Assert.AreEqual(returned4, expected4);
            Assert.AreEqual(returned5, expected5);
        }
        [TestMethod]
        public void EmailPatternMatchTest()
        {
            //arrange
            string string1 = "Jonas";
            string string2 = "Jonas@gmail.com";
            string string3 = "@gmail.com";
            string string4 = "jonas@.com";
            string string5 = "";
            string string6 = "jonas.com";
            string string7 = "jonas.kazlauskas@mif.stud.vu.lt";
            bool returned1;
            bool returned2;
            bool returned3;
            bool returned4;
            bool returned5;
            bool returned6;
            bool returned7;
            bool expected1 = false;
            bool expected2 = true;
            bool expected3 = false;
            bool expected4 = false;
            bool expected5 = false;
            bool expected6 = false;
            bool expected7 = true;

            //act
            returned1 = Validation.EmailPatternMatch(string1);
            returned2 = Validation.EmailPatternMatch(string2);
            returned3 = Validation.EmailPatternMatch(string3);
            returned4 = Validation.EmailPatternMatch(string4);
            returned5 = Validation.EmailPatternMatch(string5);
            returned6 = Validation.EmailPatternMatch(string6);
            returned7 = Validation.EmailPatternMatch(string7);

            //assert
            Assert.AreEqual(returned1, expected1);
            Assert.AreEqual(returned2, expected2);
            Assert.AreEqual(returned3, expected3);
            Assert.AreEqual(returned4, expected4);
            Assert.AreEqual(returned5, expected5);
            Assert.AreEqual(returned6, expected6);
            Assert.AreEqual(returned7, expected7);

        }
    }
}
