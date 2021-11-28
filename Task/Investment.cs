using System;
using System.Collections.Generic;

namespace Task {
    public class Investment {
        private DateTime Aggreementdate;
        private DateTime Calculationdate;
        private double X;
        private double R;
        private int N;

        public Investment(DateTime aggreementdate, DateTime calculationdate, double x, double r, int n) {
            Aggreementdate = aggreementdate;
            Calculationdate = calculationdate;
            X = x;
            R = r;
            N = n;
        }

        public Result Calculate() {


            int differentAllDay = (Calculationdate - Aggreementdate).Days;
            int differentDay, differentMonth, differentYear;
            int skipMonth = 0;

            if (differentAllDay > 0) {

                differentDay = Calculationdate.Day - Aggreementdate.Day;
                differentMonth = Calculationdate.Month - Aggreementdate.Month;
                differentYear = Calculationdate.Year - Aggreementdate.Year;

                skipMonth = 12 * differentYear + differentMonth - 1;

                if (differentDay > 0) {
                    skipMonth = skipMonth + 1;
                }
            }

            var fixedPayment= FixedPayment();

            double sumInterest = 0;
            List<double> allInterest = new List<double>();
            double interestPayment = 0;
            double principalPayment = 0;
            double nextinterest = 0;

            // Find All interest, Next interest, Sum of all future interest payments
            double remainingPrinciplePayment = X;
            for (int i = 0; i < 12 * N; i++) {
                interestPayment = ((R / 100) / 12) * remainingPrinciplePayment;

                if (skipMonth <= 0) {
                    sumInterest = sumInterest + interestPayment;
                }

                if (skipMonth == 0) {
                    nextinterest = Math.Round(interestPayment, 2);
                }

                allInterest.Add(Math.Round(interestPayment, 2));
                principalPayment = fixedPayment - interestPayment;
                remainingPrinciplePayment = remainingPrinciplePayment - principalPayment;

                skipMonth = skipMonth - 1;
            }

            return new Result() {
                FixedPayment = Math.Round(fixedPayment, 2),
                AllInterest = allInterest,
                Nextintrest = nextinterest,
                SumInterest = Math.Round(sumInterest, 2)
            };
        }

        private double FixedPayment() {
            int n = 12 * N; //total number of months
            double r = (R / 100) / 12; //interest rate per month
            double fixedPayment = (X * r) / (1 - Math.Pow(1 + r, -n));
            return fixedPayment;
        }
    }
}