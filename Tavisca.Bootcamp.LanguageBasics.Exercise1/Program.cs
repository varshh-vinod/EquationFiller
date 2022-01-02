using System;
using System.Linq;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }
        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
        public static int FirstTermHasMissingDigit(string[] terms)
        {
            int LeftHandSide = Int32.Parse(terms[1]);
            int RightHandSide = Int32.Parse(terms[2]);
            if (RightHandSide % LeftHandSide != 0) //if rhs is not a multiple of lhs, then the equation is wrong
            {
                return (-1);
            }
            string CalculatedValue = (RightHandSide / LeftHandSide).ToString();
            int IndexOfQuestionMark = 0;
            int Matches = 0;
            string GivenValue = terms[0];
            if (CalculatedValue.Length == GivenValue.Length)
            {
                for (int i = 0; i < CalculatedValue.Length; i++)
                {
                    if (GivenValue[i].Equals('?'))
                    {
                        IndexOfQuestionMark = i; 
                        continue;
                    }
                    if (GivenValue[i].Equals( CalculatedValue[i]))
                    {
                        Matches = Matches + 1;
                    }
                }
            }
            else
            {
                return (-1);
            }
            if (Matches == (CalculatedValue.Length - 1))
            {
                string s1 = CalculatedValue[IndexOfQuestionMark].ToString();
                return (Int32.Parse(s1));
            }
            else
            {
                return (-1);
            }
        }
        public static int SecondTermHasMissingDigit(string[] terms)
        {
            int LeftHandSide = Int32.Parse(terms[0]);
            int RighHandSide = Int32.Parse(terms[2]);
            if (RighHandSide % LeftHandSide != 0) //if rhs is not a multiple of lhs, then the equation is wrong
            {
                return (-1);
            }
            string CalculatedValue = (RighHandSide / LeftHandSide).ToString();
            int IndexOfQuestionMark = 0;
            int Matches = 0;
            string GivenValue = terms[1];
            if (CalculatedValue.Length == GivenValue.Length) 
            {
                for (int i = 0; i < CalculatedValue.Length; i++)
                {
                    if (GivenValue[i].Equals('?'))
                    {
                        IndexOfQuestionMark = i;
                        continue;
                    }
                    if (GivenValue[i].Equals(CalculatedValue[i]))
                    {
                        Matches = Matches + 1;
                    }
                }
            }
            else
            {
                return (-1);
            }
            if (Matches == (CalculatedValue.Length - 1))
            {
                string s1 = CalculatedValue[IndexOfQuestionMark].ToString();
                return (Int32.Parse(s1));
            }
            else
            {
                return (-1);
            }
        }
        public static int RHSHasMissingDigit(string[] terms)
        {
            int LHSPart1 = Int32.Parse(terms[0]);
            int LHSPart2 = Int32.Parse(terms[1]);
            string CalculatedRHS = (LHSPart1 * LHSPart2).ToString();
            int IndexOfQuestionMark = 0;
            int Matches = 0;
            string GivenRHS = terms[2];
            if (CalculatedRHS.Length == GivenRHS.Length)
            {
                for (int i = 0; i < CalculatedRHS.Length; i++)
                {
                    if (GivenRHS[i].Equals('?'))
                    {
                        IndexOfQuestionMark = i;
                        continue;
                    }
                    if (GivenRHS[i].Equals(CalculatedRHS[i]))
                    {
                        Matches = Matches + 1;
                    }
                }
            }
            else
            {
                return (-1);
            }
            if (Matches == (CalculatedRHS.Length - 1))
            {
                string s1 = CalculatedRHS[IndexOfQuestionMark].ToString();
                return (Int32.Parse(s1));
            }
            else
            {
                return (-1);
            }
        }
        public static int FindDigit(string equation)
        {
            string[] terms = equation.Split(new Char[] { '*', '=' });
            if (terms[0].Contains('?'))
            {
                return (FirstTermHasMissingDigit(terms));
            }
            if (terms[1].Contains('?'))
            {
                return (SecondTermHasMissingDigit(terms));
            }
            if (terms[2].Contains('?'))
            {
                return (RHSHasMissingDigit(terms));
            }
            return -1;
        }
    }
}
