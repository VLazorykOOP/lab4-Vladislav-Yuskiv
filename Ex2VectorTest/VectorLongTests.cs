using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabVector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LabVector.Tests
{
    [TestClass()]
    public class VectorLongTests
    {
        [TestMethod()]
        public void AssignValueToAllTest()
        {
            VectorLong vector = new(3);

            vector.AssignValueToAll(4);

            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(4, vector[1]);
            Assert.AreEqual(4, vector[2]);
        }

        [TestMethod()]
        public void GetVectorsCountTest()
        {
            // deleting all existing vectors in the heap
            GC.Collect();
            GC.WaitForPendingFinalizers();

            VectorLong v1 = new();
            VectorLong v2 = new();

            Assert.AreEqual(2, VectorLong.GetVectorsCount());
        }

        [TestMethod()]
        public void IncrementOperatorTest()
        {
            VectorLong vector = new(3, 3);

            vector++;

            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(4, vector[1]);
            Assert.AreEqual(4, vector[2]);
        }

        [TestMethod()]
        public void DecrementOperatorTest()
        {
            VectorLong vector = new(3, 3);

            vector--;

            Assert.AreEqual(2, vector[0]);
            Assert.AreEqual(2, vector[1]);
            Assert.AreEqual(2, vector[2]);
        }

        [TestMethod()]
        public void UnaryNotOperatorsTest()
        {
            VectorLong v1 = new(0);
            VectorLong v2 = new(2);

            Assert.IsFalse(!v1);
            Assert.IsTrue(!v2);
        }

        [TestMethod()]
        public void BitwiseNotOperatorTest()
        {
            VectorLong vector = new(1, 3);

            vector = ~vector;

            Assert.AreEqual(-4, vector[0]);
        }

        [TestMethod()]
        public void VectorAdditionOperatorTest()
        {
            VectorLong v1 = new(3, 2);
            VectorLong v2 = new(2, 5);

            v1 += v2;

            Assert.AreEqual(7, v1[0]);
            Assert.AreEqual(7, v1[1]);
            Assert.AreEqual(2, v1[2]);
        }

        [TestMethod()]
        public void ScalarAdditionOperatorTest()
        {
            VectorLong v1 = new(3, 2);

            v1 += 3;

            Assert.AreEqual(5, v1[0]);
            Assert.AreEqual(5, v1[1]);
            Assert.AreEqual(5, v1[2]);
        }

        [TestMethod()]
        public void VectorSubtractionOperatorTest()
        {
            VectorLong v1 = new(3, 2);
            VectorLong v2 = new(2, 5);

            v1 -= v2;

            Assert.AreEqual(-3, v1[0]);
            Assert.AreEqual(-3, v1[1]);
            Assert.AreEqual(2, v1[2]);
        }

        [TestMethod()]
        public void ScalarSubtractionOperatorTest()
        {
            VectorLong v1 = new(3, 2);

            v1 -= 3;

            Assert.AreEqual(-1, v1[0]);
            Assert.AreEqual(-1, v1[1]);
            Assert.AreEqual(-1, v1[2]);
        }

        [TestMethod()]
        public void VectorMultiplicationOperatorTest()
        {
            VectorLong v1 = new(3, 2);
            VectorLong v2 = new(2, 5);

            v1 *= v2;

            Assert.AreEqual(10, v1[0]);
            Assert.AreEqual(10, v1[1]);
            Assert.AreEqual(2, v1[2]);
        }

        [TestMethod()]
        public void ScalarMultiplicationOperatorTest()
        {
            VectorLong v1 = new(3, 2);

            v1 *= 3;

            Assert.AreEqual(6, v1[0]);
            Assert.AreEqual(6, v1[1]);
            Assert.AreEqual(6, v1[2]);
        }

        [TestMethod()]
        public void VectorDivisionOperatorTest()
        {
            VectorLong v1 = new(3, 2);
            VectorLong v2 = new(2, 5);

            v1 /= v2;

            Assert.AreEqual(0, v1[0]);
            Assert.AreEqual(0, v1[1]);
            Assert.AreEqual(2, v1[2]);
        }

        [TestMethod()]
        public void ScalarDivisionOperatorTest()
        {
            VectorLong v1 = new(3, 4);

            v1 /= 3;

            Assert.AreEqual(1, v1[0]);
            Assert.AreEqual(1, v1[1]);
            Assert.AreEqual(1, v1[2]);
        }

        [TestMethod()]
        public void VectorRemainderOperatorTest()
        {
            VectorLong v1 = new(3, 2);
            VectorLong v2 = new(2, 5);

            v1 %= v2;

            Assert.AreEqual(2, v1[0]);
            Assert.AreEqual(2, v1[1]);
            Assert.AreEqual(2, v1[2]);
        }

        [TestMethod()]
        public void ScalarRemainderOperatorTest()
        {
            VectorLong v1 = new(3, 4);

            v1 %= 3;

            Assert.AreEqual(1, v1[0]);
            Assert.AreEqual(1, v1[1]);
            Assert.AreEqual(1, v1[2]);
        }

        [TestMethod()]
        public void VectorBitwiseAdditionOperatorTest()
        {
            VectorLong v1 = new(3, 3);
            VectorLong v2 = new(2, 7);

            v1 |= v2;

            Assert.AreEqual(7, v1[0]);
            Assert.AreEqual(7, v1[1]);
            Assert.AreEqual(3, v1[2]);
        }

        [TestMethod()]
        public void ScalarBitwiseAdditionOperatorTest()
        {
            VectorLong v1 = new(3, 4);

            v1 |= 8;

            Assert.AreEqual(12, v1[0]);
            Assert.AreEqual(12, v1[1]);
            Assert.AreEqual(12, v1[2]);
        }

        [TestMethod()]
        public void VectorBitwiseMultiplicationOperatorTest()
        {
            VectorLong v1 = new(3, 5);
            VectorLong v2 = new(2, 4);

            v1 &= v2;

            Assert.AreEqual(4, v1[0]);
            Assert.AreEqual(4, v1[1]);
            Assert.AreEqual(5, v1[2]);
        }

        [TestMethod()]
        public void ScalarBitwiseMultiplicationOperatorTest()
        {
            VectorLong v1 = new(3, 4);

            v1 &= 8;

            Assert.AreEqual(0, v1[0]);
            Assert.AreEqual(0, v1[1]);
            Assert.AreEqual(0, v1[2]);
        }

        [TestMethod()]
        public void VectorBitwiseXorOperatorTest()
        {
            VectorLong v1 = new(3, 5);
            VectorLong v2 = new(2, 4);

            v1 ^= v2;

            Assert.AreEqual(1, v1[0]);
            Assert.AreEqual(1, v1[1]);
            Assert.AreEqual(5, v1[2]);
        }

        [TestMethod()]
        public void ScalarBitwiseXorOperatorTest()
        {
            VectorLong v1 = new(3, 4);

            v1 ^= 8;

            Assert.AreEqual(12, v1[0]);
            Assert.AreEqual(12, v1[1]);
            Assert.AreEqual(12, v1[2]);
        }

        [TestMethod()]
        public void BitwiseLeftShiftOperatorTest()
        {
            VectorLong v1 = new(1, 4);

            v1 <<= 8;

            Assert.AreEqual(1024, v1[0]);
        }

        [TestMethod()]
        public void BitwiseRightShiftOperatorTest()
        {
            VectorLong v1 = new(1, 4);

            v1 >>= 8;

            Assert.AreEqual(0, v1[0]);
        }


        [TestMethod()]
        public void EqualityOperatorsTest()
        {
            VectorLong v1 = new(1, 4);
            VectorLong v2 = new(1, 4);
            VectorLong v3 = new(1, 3);
            VectorLong v4 = new(2, 3);

            Assert.IsTrue(v1 == v2);
            Assert.IsTrue(v1 != v3);
            Assert.IsTrue(v1 != v4);
            Assert.IsFalse(v1 == v3);
            Assert.IsFalse(v1 == v4);
        }

        [TestMethod()]
        public void ComparsionOperatorsTest()
        {
            VectorLong v1 = new(1, 4);
            VectorLong v2 = new(1, 4);
            VectorLong v3 = new(1, 3);

            Assert.IsTrue(v1 >= v2);
            Assert.IsTrue(v1 <= v2);
            Assert.IsFalse(v1 > v2);
            Assert.IsFalse(v1 < v2);

            Assert.IsTrue(v1 >= v3);
            Assert.IsTrue(v1 > v3);
            Assert.IsFalse(v1 <= v3);
            Assert.IsFalse(v1 < v3);
        }
    }
}