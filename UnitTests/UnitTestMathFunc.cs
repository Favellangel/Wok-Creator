using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Work_Creator;

namespace UnitTests
{
    [TestClass]
    public class UnitTestMathFunc
    {
        [TestMethod]
        public void TestGetAngle()
        {
            Point pb;
            Point pe;
            pb.x = 14.142;
            pb.y = 14.142;
            pe.x = 30;
            pe.y = 30;
            MathFunc.GetAngle(pb, pe, 20, 80);

            Assert.AreEqual(30, 10);
        }
    }
}
