using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Task {
    public class Result {
        public double FixedPayment { get; set; }
        public List<double> AllInterest { get; set; }
        public double Nextintrest { get; set; }
        public double SumInterest { get; set; }
    }
}