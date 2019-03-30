using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp6lib
{
    public class Calculator
    {
        static Stack<string> ops;
        static Stack<double> nums;
        static string[] oprators = { "+", "-", "*", "/" ,"(",")"};
        public static bool Check(string[] s)
        {
            /*            bool flag = true;
                        char[] legal = new char[]{ '+', '-', '*', '/', '.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                        foreach (char c in s)//只要有一个不在集合中，flag为false
                        {
                            bool t = false;
                            for (int i = 0; i < legal.Length; i++)//判断字符c是否在集合中
                                if (c == legal[i])
                                    t = true;
                            //t为“c在集合中？”
                            if (!t)
                                flag = false;
                        }*/
            if (s[0] == "*" || s[0] == "/" || s[0] == ")")
                return false;
            else
                return true;
        }//ResultOf前运行
        static double Handle(double a, double b, string c)
        {
            
            if (c == "+")
                return a + b;
            if (c == "-")
                return b - a;
            if (c == "*")
                return a * b;
            if (c == "/")
            {
                if (a == 0)
                {
                    wrong = true;
                    return 0;
                }
                else return b / a;
            }//栈逆序输出，先输出除数a，再输出被除数b
            return 0;
        }
        static int pr(string s) { if (s == "+" || s == "-") return 1; if (s == "*" || s == "/") return 2;  return - 1; }
        private static bool flag = false;
        public static bool wrong = false;
        public static double ResultOf(string[] s)
        {
            nums = new Stack<double>(s.Length);
            ops = new Stack<string>(s.Length);
            int index = 0;
            while (index < s.Length)
            {
                double d;
                if (double.TryParse(s[index], out d))
                    nums.Push(d);
                if (s[index] == "*" || s[index] == "/")
                    if (ops.Count == 0)
                        ops.Push(s[index]);
                    else
                    {
                        while (ops.Count!=0&&pr(ops.Peek()) >= 2)
                        {
                            if (nums.Count < 2|| ops.Count == 0)
                            {
                                wrong = true;
                                return 0;
                            }
                            nums.Push(Handle(nums.Pop(), nums.Pop(), ops.Pop()));
                        }
                        ops.Push(s[index]);
                    }
                if (s[index] == "+" || s[index] == "-")
                {
                    if (s[index] == "-" && (index==0 || s[index - 1] == "("))
                    {
                        double n;
                        if (double.TryParse(s[index + 1], out n))
                        { nums.Push(-n); index++; }
                        else if (s[index + 1] == "(")
                            flag = true;
                    }

                    else
                    {
                        while (ops.Count != 0 && ops.Peek() != "(")
                        {
                            if (nums.Count < 2||ops.Count == 0)
                            {
                                wrong = true;
                                return 0;
                            }
                            nums.Push(Handle(nums.Pop(), nums.Pop(), ops.Pop()));
                        }
                        ops.Push(s[index]);
                    }
                }
                if (s[index] =="(")
                    ops.Push(s[index]);
                if (s[index] == ")")
                {
                    while (ops.Peek() != "(")
                    {
                        if (nums.Count < 2||ops.Count == 0)
                        {
                            wrong = true;
                            return 0;
                        }
                        nums.Push(Handle(nums.Pop(), nums.Pop(), ops.Pop()));
                    }
                    ops.Pop();
                    if (flag)
                    {
                        double t = nums.Pop();
                        nums.Push(-t);
                        flag = false;
                    }
                }
                index++;
            }
            while (ops.Count != 0)
            {
                if (nums.Count < 2)
                {
                    wrong = true;
                    return 0;
                }
                nums.Push(Handle(nums.Pop(), nums.Pop(), ops.Pop()));
            }
            if(nums.Count==0)
            {
                wrong = true;
                return 0;
            }
            return nums.Peek();
        }












    }
}
