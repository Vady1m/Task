using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Task.Tests {
    [TestClass]
    public class TestInvestment {

        [TestMethod]
        public void TestCalculateAgreementDateEqualsCalculationDate() {
            DateTime agreementDate = new DateTime(2021, 11, 27);
            DateTime calculationdateDate = new DateTime(2021, 11, 27);
            double X = 5000;
            double R = 6;
            int N = 1;
            var investment = new Investment(agreementDate, calculationdateDate, X, R, N);
            Result result = investment.Calculate();
            Assert.AreEqual(430.33, result.FixedPayment);
            Assert.AreEqual(163.99, result.SumInterest);
            Assert.AreEqual(25, result.Nextintrest);


            List<double> expectedAllInterest = new List<double>() {
                25.00,
                22.97,
                20.94,
                18.89,
                16.83,
                14.76,
                12.69,
                10.60,
                8.50,
                6.39,
                4.27,
                2.14
            };
            CollectionAssert.AreEqual(expectedAllInterest, result.AllInterest);
        }

        [TestMethod]
        public void TestCalculateAgreementDateLessThanCalculationDate() {

            DateTime agreementDate = new DateTime(2021, 11, 27);
            DateTime calculationdateDate = new DateTime(2022, 03, 28);
            double X = 5000;
            double R = 6;
            int N = 1;
            var investment = new Investment(agreementDate, calculationdateDate, X, R, N);
            Result result = investment.Calculate();
            Assert.AreEqual(430.33, result.FixedPayment);
            Assert.AreEqual(76.19, result.SumInterest);
            Assert.AreEqual(16.83, result.Nextintrest);


            List<double> expectedAllInterest = new List<double>() {
                25.00,
                22.97,
                20.94,
                18.89,
                16.83,
                14.76,
                12.69,
                10.60,
                8.50,
                6.39,
                4.27,
                2.14
            };
            CollectionAssert.AreEqual(expectedAllInterest, result.AllInterest);

        }

        [TestMethod]
        public void TestCalculateWhenCalculationDateIsHigh()
        {
            DateTime agreementDate = new DateTime(2021, 11, 27);
            DateTime calculationdateDate = new DateTime(2023, 11, 27);
            double X = 5000;
            double R = 6;
            int N = 1;
            var investment = new Investment(agreementDate, calculationdateDate, X, R, N);
            Result result = investment.Calculate();
            Assert.AreEqual(430.33, result.FixedPayment);
            Assert.AreEqual(0, result.SumInterest);
            Assert.AreEqual(0, result.Nextintrest);


            List<double> expectedAllInterest = new List<double>() {
                25.00,
                22.97,
                20.94,
                18.89,
                16.83,
                14.76,
                12.69,
                10.60,
                8.50,
                6.39,
                4.27,
                2.14
            };
            CollectionAssert.AreEqual(expectedAllInterest, result.AllInterest);


        }
    }
}
