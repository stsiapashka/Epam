using System;
using Unit;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TriangleUnitTest1
    {       
        [TestCase(10, 15.32, 19.7)]
        [TestCase(3.19, 6, 8.08)]
        public void TestObtuseTriangleTrue(double a, double b, double c)
        {
            Assert.IsTrue(Triangles.IsObtuseTringele(a, b, c));
        }

        [TestCase(7, 3.72, 7.34)]
        [TestCase(5, 4.32, 6)]
        public void TestObtuseTriangleFalse(double a, double b, double c)
        {
            Assert.IsFalse(Triangles.IsObtuseTringele(a, b, c));
        }

        [TestCase(7, 3.72, 7.34)]
        [TestCase(5, 4.32, 6)]
        public void TestAcuteTriangleTrue(double a, double b, double c)
        {
            Assert.IsTrue(Triangles.IsAcuteTriangle(a, b, c));
        }

        [TestCase(1.1, 2.2, 0.8)]
        [TestCase(10, 7, 19)]
        public void TestAcuteTriangleFalse(double a, double b, double c)
        {
            Assert.IsFalse(Triangles.IsAcuteTriangle(a, b, c));
        }

        [TestCase(6, 8, 10)]
        [TestCase(2.5, 3.5, 4.5)]
        public void TestTriangleTrue(double a, double b, double c)
        {
            Assert.IsTrue(Triangles.IsTringele(a,b,c));
        }

        [TestCase(1.1,2.2,0.8)]
        [TestCase(10,7,19)]
        public void TestTriangleFalse(double a,double b,double c)
        {
            Assert.IsFalse(Triangles.IsTringele(a,b,c));
        }       
    }
}
