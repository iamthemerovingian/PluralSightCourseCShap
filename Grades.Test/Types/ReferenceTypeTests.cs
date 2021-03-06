﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Test.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;

            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
            Assert.AreEqual(99.1f, grades[2]);
        }

        private void AddGrades(float[] grades)
        {
            //grades = new float[5];
            grades[1] = 89.1f;
            grades[2] = 99.1f;
        }

        [TestMethod]
        public void UpperCaseString()
        {
            string name = "Scott";

            name = name.ToUpper();

            Assert.AreEqual("SCOTT", name);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1);
            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypesPassedByValue()
        {
            int x = 46;

            IncrementNumber(ref x);

            Assert.AreEqual(47, x);
        }

        private void IncrementNumber(ref int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassedByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(ref book2);

            Assert.AreEqual("A gradebook", book2.Name);
        }

        private void GiveBookAName(ref GradeBook book)
        {
            book = new GradeBook();;
            book.Name = "A gradebook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Scott";
            string name2 = "scott";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GreenBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Milinda's Grade Book";
            Assert.AreEqual(g1.Name, g2.Name);
        }

    }
}
