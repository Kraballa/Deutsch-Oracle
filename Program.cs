using System;

namespace QSIM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Deutsch Oracle");
            for (int i = 0; i < 4; i++)
            {
                QBit input = new QBit(0);
                QBit output = new QBit(0);
                input.X().H();
                output.X().H();
                QBit.Function(i, ref input, ref output);
                input.H();
                output.H();
                if (input.Collapse() == 1 && output.Collapse() == 1)
                {
                    Console.WriteLine("the function was constant");
                }
                else if (input.Collapse() == 0 && output.Collapse() == 1)
                {
                    Console.WriteLine("the function was variable");
                }
                else
                {
                    Console.WriteLine("calculation error, retry");
                    i--;
                }
            }
        }
    }
}
