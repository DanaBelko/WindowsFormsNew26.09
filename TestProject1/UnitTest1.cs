using NUnit.Framework;
using WindowsFormsNew26._09;
using System.Collections.Generic;

namespace TestProject1
{
    public class Tests
    {
        Pl pl = new Pl(); 
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string text = "student";
            string keyword = "cat";
            string alphabet = "abcdefghijklmnoprstuvwxyz";
            keyword = pl.DelDoubleChars(keyword);
            string newAlphabet = pl.DelKeywordChars(keyword, alphabet);
            char[,] matrix = pl.GetMatrix(keyword, newAlphabet);
            string code = pl.WordN(text);
            List<int> index = pl.GetIndexList(code, matrix);
            string newCode = pl.Encode(index, matrix);
            Assert.AreEqual("brzijigt", newCode);
        }
        [Test]
        public void Test2()
        {
            string text = "brzijigt";
            string keyword = "cat";
            string alphabet = "abcdefghijklmnoprstuvwxyz";
            keyword = pl.DelDoubleChars(keyword);
            string newAlphabet = pl.DelKeywordChars(keyword, alphabet);
            char[,] matrix = pl.GetMatrix(keyword, newAlphabet);
            string code = pl.WordN(text);
            List<int> index = pl.GetIndexList(code, matrix);
            string newCode = pl.Decode(index, matrix);
            Assert.AreEqual("studentx", newCode);
        }
        [Test]
        public void Test3()
        {
            string text = "rduoxt";
            string keyword = "cat";
            string alphabet = "abcdefghijklmnoprstuvwxyz";
            keyword = pl.DelDoubleChars(keyword);
            string newAlphabet = pl.DelKeywordChars(keyword, alphabet);
            char[,] matrix = pl.GetMatrix(keyword, newAlphabet);
            string code = pl.WordN(text);
            List<int> index = pl.GetIndexList(code, matrix);
            string newCode = pl.Decode(index, matrix);
            Assert.AreEqual("tusurx", newCode);
        }
        [Test]
        public void Test4()
        {
            string text = "tusur";
            string keyword = "cat";
            string alphabet = "abcdefghijklmnoprstuvwxyz";
            keyword = pl.DelDoubleChars(keyword);
            string newAlphabet = pl.DelKeywordChars(keyword, alphabet);
            char[,] matrix = pl.GetMatrix(keyword, newAlphabet);
            string code = pl.WordN(text);
            List<int> index = pl.GetIndexList(code, matrix);
            string newCode = pl.Encode(index, matrix);
            Assert.AreEqual("rduoxt", newCode);
        }
    }
}