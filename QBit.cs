using System;
using System.Collections.Generic;
using System.Text;

namespace QSIM
{
    public class QBit
    {
        private static Random rand = new Random();

        public double A { get; set; }
        public double B { get; set; }

        public QBit(int val)
        {
            Set(val);
        }

        // (!) this is a disgusting/elegant kernelization of what CNOT actually does and this only works in this specific instance
        public QBit CNOT(ref QBit b)
        {
            if (B == 0)
            {
                b.X();
            }
            else
            {
                B *= -1;
            }
            return this;
        }

        public QBit H()
        {
            double val = 1 / Math.Sqrt(2);
            double newA = A * val + B * val;
            B = A * val - B * val;
            A = newA;
            return this;
        }

        public QBit X()
        {
            double val = B;
            B = A;
            A = val;
            return this;
        }

        public QBit Set(int i)
        {
            switch (i)
            {
                case 0:
                    A = 1; B = 0; break;
                case 1:
                    A = 0; B = 1; break;
            }
            return this;
        }

        public QBit Set(QBit b)
        {
            A = b.A;
            B = b.B;
            return this;
        }

        public double Measure()
        {
            return Math.Abs(0.5 - A * A / 2 + B * B / 2);
        }

        public int Collapse()
        {
            return rand.NextDouble() < Measure() ? 1 : 0;
        }

        public override string ToString()
        {
            return string.Format("[{0}|{1}]", A, B);
        }

        public static void CNOT(ref QBit a, ref QBit b)
        {
            a.CNOT(ref b);
        }

        /// <summary>
        /// Define the 4 possible functions on one bit, to operate them on a qbit,
        /// as well as doubling input for reversability, and have them be iterable by i.
        /// </summary>
        public static void Function(int i, ref QBit input, ref QBit output)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("function {set 0}");
                    break;
                case 1:
                    Console.WriteLine("function {set 1}");
                    output.X();
                    break;
                case 2: //invert
                    Console.WriteLine("function {invert}");
                    CNOT(ref input, ref output);
                    output.X();
                    break;
                case 3: //identity
                    Console.WriteLine("function {identity}");
                    CNOT(ref input, ref output);
                    break;
            }
        }
    }
}
