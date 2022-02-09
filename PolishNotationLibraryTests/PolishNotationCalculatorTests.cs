using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishNotationLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolishNotationLibrary.Tests
{
    [TestClass()]
    public class PolishNotationCalculatorTests
    {
        [TestMethod()]
        public void CalculatePNStringAdd()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("4", polishNotationCalculator.CalculatePNString("+ 2 2"));
        }
        [TestMethod()]
        public void CalculatePNStringSub()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("3", polishNotationCalculator.CalculatePNString("- 5 2"));
        }
        [TestMethod()]
        public void CalculatePNStringMult()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("10", polishNotationCalculator.CalculatePNString("* 5 2"));
        }
        [TestMethod()]
        public void CalculatePNStringDivide()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("2", polishNotationCalculator.CalculatePNString("/ 8 4"));
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Incorrect operator")]
        public void CalculatePNStringWrongOperator()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            string tmp = polishNotationCalculator.CalculatePNString("5 2");
        }
        [TestMethod()]
        public void CalculatePNStringAddComplicatedFirstOperand()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("6", polishNotationCalculator.CalculatePNString("+ + 2 2 2"));
        }
        [TestMethod()]
        public void CalculatePNStringAddComplicatedSecondOperand()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("6", polishNotationCalculator.CalculatePNString("+ 2 + 2 2"));
        }
        [TestMethod()]
        public void CalculatePNStringSubComplicatedFirstOperand()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("-2", polishNotationCalculator.CalculatePNString("- - 2 2 2"));
        }
        [TestMethod()]
        public void CalculatePNStringSubComplicatedSecondOperand()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("2", polishNotationCalculator.CalculatePNString("- 2 - 2 2"));
        }

        [TestMethod()]
        public void CalculatePNStringMUltComplicatedFirstOperand()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("8", polishNotationCalculator.CalculatePNString("* * 2 2 2"));
        }
        [TestMethod()]
        public void CalculatePNStringMultComplicatedSecondOperand()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("8", polishNotationCalculator.CalculatePNString("* 2 * 2 2"));
        }
        [TestMethod()]
        public void CalculatePNStringDivideComplicatedFirstOperand()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("2", polishNotationCalculator.CalculatePNString("/ / 8 2 2"));
        }
        [TestMethod()]
        public void CalculatePNStringDivideComplicatedSecondOperand()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("8", polishNotationCalculator.CalculatePNString("/ 8 / 2 2"));
        }
        [TestMethod()]
        public void CalculatePNStringComplicatedExpression()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            Assert.AreEqual("5", polishNotationCalculator.CalculatePNString("- * / 15 - 7 + 1 1 3 + 2 + 1 1"));
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Incorrect operand")]
        public void CalculatePNStringComplicatedExpressionError()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            polishNotationCalculator.CalculatePNString("- -* / 15 - 7 + 1 1 3 + 2 + 1 1");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Incorrect operand")]
        public void CalculatePNStringComplicatedExpressionErrorWithNonDigits()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            polishNotationCalculator.CalculatePNString("- afag agaqgh");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Empty expression")]
        public void CalculatePNStringdExpressionNullError()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            polishNotationCalculator.CalculatePNString("");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Incorrect splitter")]
        public void CalculatePNStringdIncorrectSplitterError()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            polishNotationCalculator.CalculatePNString("-,-*,/15-7+1,1,3,+,2,+,1,1");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Incorrect number of operators or operands")]
        public void CalculatePNStringdIncorrectnumberOfOperandsError()
        {
            PolishNotationCalculator polishNotationCalculator = new PolishNotationCalculator();
            polishNotationCalculator.CalculatePNString("- / + - 7 + 1 1 3 + 2 + 1 1");
        }
    }
}