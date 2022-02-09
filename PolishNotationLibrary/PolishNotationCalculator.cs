using System;

namespace PolishNotationLibrary
{
    public class PolishNotationCalculator
    {
        private string[] operators = { "+", "-", "*", "/" };
        public string CalculatePNString(string input)
        {
            string output = "";

            try
            {
                if (input.Length == 0)
                {
                    throw new ArgumentNullException("Empty expression");
                }
                if(input.Split(' ').Length <= 1)
                {
                    throw new ArgumentException("Incorrect splitter");
                }
                string Operator = input.Split(' ')[0];

                if (!Array.Exists(operators, x => x == Operator))
                {
                    throw new ArgumentException("Incorrect operator");
                }

                string A = input.Split(' ')[1];


                if (Array.Exists(operators, x => x == A))
                {
                    input = Operator + " " + CalculatePNString(input.Substring(Operator.Length + 1));
                    A = input.Split(' ')[1];
                }
                if (!float.TryParse(A, out _))
                {
                    throw new ArgumentException("Incorrect operand");
                }

                string B = input.Split(' ')[2];

                if (Array.Exists(operators, x => x == B))
                {
                    input = Operator + " " + A + " " + CalculatePNString(input.Substring(Operator.Length + 1 + A.Length + 1));
                    B = input.Split(' ')[2];
                }
                if (!float.TryParse(B, out _))
                {
                    throw new ArgumentException("Incorrect operand");
                }
                switch (Operator)
                {
                    case "+":
                        output = (float.Parse(A) + float.Parse(B)).ToString() + ((Operator + " " + A + " " + B) != input ? " " + input.Substring(Operator.Length + 1 + A.Length + 1 + B.Length + 1) : "");
                        break;
                    case "-":
                        output = (float.Parse(A) - float.Parse(B)).ToString() + ((Operator + " " + A + " " + B) != input ? " " + input.Substring(Operator.Length + 1 + A.Length + 1 + B.Length + 1) : "");
                        break;
                    case "*":
                        output = (float.Parse(A) * float.Parse(B)).ToString() + ((Operator + " " + A + " " + B) != input ? " " + input.Substring(Operator.Length + 1 + A.Length + 1 + B.Length + 1) : "");
                        break;
                    case "/":
                        output = (float.Parse(A) / float.Parse(B)).ToString() + ((Operator + " " + A + " " + B) != input ? " " + input.Substring(Operator.Length + 1 + A.Length + 1 + B.Length + 1) : "");
                        break;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentException("Incorrect number of operators or operands");
            }

            return output;
        }


    }
}