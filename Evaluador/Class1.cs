using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Evaluador
{
    public class MathParser
    {
        // Fields
        private const string Abs = "@abs";
        private const string Ch = "@ch";
        private const string Cos = "@cos";
        private const string Ctg = "@ctg";
        private readonly char decimalSeparator;
        private const string Degree = "$^";
        private const string Divide = "$/";
        private const string Exp = "@exp";
        private const string FunctionMarker = "@";
        private bool isRadians;
        private const string LeftParent = "$(";
        private const string Ln = "@ln";
        private const string Log = "@log";
        private const string Minus = "$-";
        private const string Multiply = "$*";
        private const string NumberMaker = "#";
        private const string OperatorMarker = "$";
        private const string Plus = "$+";
        private const string RightParent = "$)";
        private const string Sh = "@sh";
        private const string Sin = "@sin";
        private const string Sqrt = "@sqrt";
        private readonly Dictionary<string, string> supportedConstants;
        private readonly Dictionary<string, string> supportedFunctions;
        private readonly Dictionary<string, string> supportedOperators;
        private const string Tg = "@tg";
        private const string Th = "@th";
        private const string UnMinus = "$un-";
        private const string UnPlus = "$un+";

        // Methods
        public MathParser()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("+", "$+");
            dictionary.Add("-", "$-");
            dictionary.Add("*", "$*");
            dictionary.Add("/", "$/");
            dictionary.Add("^", "$^");
            dictionary.Add("(", "$(");
            dictionary.Add(")", "$)");
            this.supportedOperators = dictionary;
            Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
            dictionary2.Add("sqrt", "@sqrt");
            dictionary2.Add("√", "@sqrt");
            dictionary2.Add("sin", "@sin");
            dictionary2.Add("cos", "@cos");
            dictionary2.Add("tg", "@tg");
            dictionary2.Add("ctg", "@ctg");
            dictionary2.Add("sh", "@sh");
            dictionary2.Add("ch", "@ch");
            dictionary2.Add("th", "@th");
            dictionary2.Add("log", "@log");
            dictionary2.Add("exp", "@exp");
            dictionary2.Add("abs", "@abs");
            this.supportedFunctions = dictionary2;
            Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
            dictionary3.Add("pi", "#" + 3.1415926535897931.ToString());
            dictionary3.Add("e", "#" + 2.7182818284590451.ToString());
            this.supportedConstants = dictionary3;
            try
            {
                this.decimalSeparator = char.Parse(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            }
            catch (FormatException exception)
            {
                throw new FormatException("Error: can't read char decimal separator from system, check your regional settings.", exception);
            }
        }

        public MathParser(char decimalSeparator)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("+", "$+");
            dictionary.Add("-", "$-");
            dictionary.Add("*", "$*");
            dictionary.Add("/", "$/");
            dictionary.Add("^", "$^");
            dictionary.Add("(", "$(");
            dictionary.Add(")", "$)");
            this.supportedOperators = dictionary;
            Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
            dictionary2.Add("sqrt", "@sqrt");
            dictionary2.Add("√", "@sqrt");
            dictionary2.Add("sin", "@sin");
            dictionary2.Add("cos", "@cos");
            dictionary2.Add("tg", "@tg");
            dictionary2.Add("ctg", "@ctg");
            dictionary2.Add("sh", "@sh");
            dictionary2.Add("ch", "@ch");
            dictionary2.Add("th", "@th");
            dictionary2.Add("log", "@log");
            dictionary2.Add("exp", "@exp");
            dictionary2.Add("abs", "@abs");
            this.supportedFunctions = dictionary2;
            Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
            dictionary3.Add("pi", "#" + 3.1415926535897931.ToString());
            dictionary3.Add("e", "#" + 2.7182818284590451.ToString());
            this.supportedConstants = dictionary3;
            this.decimalSeparator = decimalSeparator;
        }

        private double ApplyTrigFunction(Func<double, double> func, double arg)
        {
            if (!this.isRadians)
            {
                arg = (arg * 3.1415926535897931) / 180.0;
            }
            return func(arg);
        }

        private double Calculate(string expression)
        {
            int pos = 0;
            Stack<double> stack = new Stack<double>();
            while (pos < expression.Length)
            {
                string token = this.LexicalAnalysisRPN(expression, ref pos);
                stack = this.SyntaxAnalysisRPN(stack, token);
            }
            if (stack.Count > 1)
            {
                throw new ArgumentException("Excess operand");
            }
            return stack.Pop();
        }

        private string ConvertToRPN(string expression)
        {
            int pos = 0;
            StringBuilder outputString = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            while (pos < expression.Length)
            {
                string token = this.LexicalAnalysisInfixNotation(expression, ref pos);
                outputString = this.SyntaxAnalysisInfixNotation(token, outputString, stack);
            }
            while (stack.Count > 0)
            {
                if (stack.Peek()[0] != "$"[0])
                {
                    throw new FormatException("Format exception, there is function without parenthesis");
                }
                outputString.Append(stack.Pop());
            }
            return outputString.ToString();
        }

        private string FormatString(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentNullException("Expression is null or empty");
            }
            StringBuilder builder = new StringBuilder();
            int num = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                switch (c)
                {
                    case '(':
                        num++;
                        break;

                    case ')':
                        num--;
                        break;
                }
                if (!char.IsWhiteSpace(c))
                {
                    if (char.IsUpper(c))
                    {
                        builder.Append(char.ToLower(c));
                    }
                    else
                    {
                        builder.Append(c);
                    }
                }
            }
            if (num != 0)
            {
                throw new FormatException("Number of left and right parenthesis is not equal");
            }
            return builder.ToString();
        }

        private int GetPriority(string token)
        {
            switch (token)
            {
                case "$(":
                    return 0;

                case "$+":
                case "$-":
                    return 2;

                case "$un+":
                case "$un-":
                    return 6;

                case "$*":
                case "$/":
                    return 4;

                case "$^":
                case "@sqrt":
                    return 8;

                case "@sin":
                case "@cos":
                case "@tg":
                case "@ctg":
                case "@sh":
                case "@ch":
                case "@th":
                case "@log":
                case "@ln":
                case "@exp":
                case "@abs":
                    return 10;
            }
            throw new ArgumentException("Unknown operator");
        }

        private bool IsRightAssociated(string token)
        {
            return (token == "$^");
        }

        private string LexicalAnalysisInfixNotation(string expression, ref int pos)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(expression[pos]);
            if (!this.supportedOperators.ContainsKey(builder.ToString()))
            {
                if ((char.IsLetter(builder[0]) || this.supportedFunctions.ContainsKey(builder.ToString())) || this.supportedConstants.ContainsKey(builder.ToString()))
                {
                    while ((++pos < expression.Length) && char.IsLetter(expression[pos]))
                    {
                        builder.Append(expression[pos]);
                    }
                    if (this.supportedFunctions.ContainsKey(builder.ToString()))
                    {
                        return this.supportedFunctions[builder.ToString()];
                    }
                    if (!this.supportedConstants.ContainsKey(builder.ToString()))
                    {
                        throw new ArgumentException("Unknown token");
                    }
                    return this.supportedConstants[builder.ToString()];
                }
                if (!char.IsDigit(builder[0]) && (builder[0] != this.decimalSeparator))
                {
                    throw new ArgumentException("Unknown token in expression");
                }
                if (char.IsDigit(builder[0]))
                {
                    while ((++pos < expression.Length) && char.IsDigit(expression[pos]))
                    {
                        builder.Append(expression[pos]);
                    }
                }
                else
                {
                    builder.Clear();
                }
                if ((pos < expression.Length) && (expression[pos] == this.decimalSeparator))
                {
                    builder.Append(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    while ((++pos < expression.Length) && char.IsDigit(expression[pos]))
                    {
                        builder.Append(expression[pos]);
                    }
                }
                if ((((pos + 1) >= expression.Length) || (expression[pos] != 'e')) || (!char.IsDigit(expression[pos + 1]) && ((((pos + 2) >= expression.Length) || ((expression[pos + 1] != '+') && (expression[pos + 1] != '-'))) || !char.IsDigit(expression[pos + 2]))))
                {
                    return ("#" + builder.ToString());
                }
                builder.Append(expression[pos++]);
                if ((expression[pos] == '+') || (expression[pos] == '-'))
                {
                    builder.Append(expression[pos++]);
                }
                while ((pos < expression.Length) && char.IsDigit(expression[pos]))
                {
                    builder.Append(expression[pos++]);
                }
                return ("#" + Convert.ToDouble(builder.ToString()));
            }
            bool flag = (pos == 0) || (expression[pos - 1] == '(');
            pos++;
            switch (builder.ToString())
            {
                case "+":
                    if (!flag)
                    {
                        return "$+";
                    }
                    return "$un+";

                case "-":
                    if (!flag)
                    {
                        return "$-";
                    }
                    return "$un-";
            }
            return this.supportedOperators[builder.ToString()];
        }

        private string LexicalAnalysisRPN(string expression, ref int pos)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(expression[pos++]);
            while (((pos < expression.Length) && (expression[pos] != "#"[0])) && ((expression[pos] != "$"[0]) && (expression[pos] != "@"[0])))
            {
                builder.Append(expression[pos++]);
            }
            return builder.ToString();
        }

        private int NumberOfArguments(string token)
        {
            switch (token)
            {
                case "$un+":
                case "$un-":
                case "@sqrt":
                case "@tg":
                case "@sh":
                case "@ch":
                case "@th":
                case "@ln":
                case "@ctg":
                case "@sin":
                case "@cos":
                case "@exp":
                case "@abs":
                    return 1;

                case "$+":
                case "$-":
                case "$*":
                case "$/":
                case "$^":
                case "@log":
                    return 2;
            }
            throw new ArgumentException("Unknown operator");
        }

        public double Parse(string expression, bool isRadians = true)
        {
            double num;
            this.isRadians = isRadians;
            try
            {
                num = this.Calculate(this.ConvertToRPN(this.FormatString(expression)));
            }
            catch (DivideByZeroException exception)
            {
                throw exception;
            }
            catch (FormatException exception2)
            {
                throw exception2;
            }
            catch (InvalidOperationException exception3)
            {
                throw exception3;
            }
            catch (ArgumentOutOfRangeException exception4)
            {
                throw exception4;
            }
            catch (ArgumentException exception5)
            {
                throw exception5;
            }
            catch (Exception exception6)
            {
                throw exception6;
            }
            return num;
        }

        private bool Priority(string token, string p)
        {
            if (!this.IsRightAssociated(token))
            {
                return (this.GetPriority(token) <= this.GetPriority(p));
            }
            return (this.GetPriority(token) < this.GetPriority(p));
        }

        private StringBuilder SyntaxAnalysisInfixNotation(string token, StringBuilder outputString, Stack<string> stack)
        {
            string str;
            if (token[0] == "#"[0])
            {
                outputString.Append(token);
                return outputString;
            }
            if (token[0] == "@"[0])
            {
                stack.Push(token);
                return outputString;
            }
            if (token == "$(")
            {
                stack.Push(token);
                return outputString;
            }
            if (!(token == "$)"))
            {
                while ((stack.Count > 0) && this.Priority(token, stack.Peek()))
                {
                    outputString.Append(stack.Pop());
                }
                stack.Push(token);
                return outputString;
            }
            while ((str = stack.Pop()) != "$(")
            {
                outputString.Append(str);
            }
            if ((stack.Count > 0) && (stack.Peek()[0] == "@"[0]))
            {
                outputString.Append(stack.Pop());
            }
            return outputString;
        }

        private Stack<double> SyntaxAnalysisRPN(Stack<double> stack, string token)
        {
            double num2;
            double num5;
            if (token[0] == "#"[0])
            {
                stack.Push(double.Parse(token.Remove(0, 1)));
                return stack;
            }
            if (this.NumberOfArguments(token) != 1)
            {
                double y = stack.Pop();
                double x = stack.Pop();
                switch (token)
                {
                    case "$+":
                        num5 = x + y;
                        goto Label_0323;

                    case "$-":
                        num5 = x - y;
                        goto Label_0323;

                    case "$*":
                        num5 = x * y;
                        goto Label_0323;

                    case "$/":
                        if (y == 0.0)
                        {
                            throw new DivideByZeroException("Second argument is zero");
                        }
                        num5 = x / y;
                        goto Label_0323;

                    case "$^":
                        num5 = Math.Pow(x, y);
                        goto Label_0323;

                    case "@log":
                        num5 = Math.Log(y, x);
                        goto Label_0323;
                }
                throw new ArgumentException("Unknown operator");
            }
            double d = stack.Pop();
            switch (token)
            {
                case "$un+":
                    num2 = d;
                    break;

                case "$un-":
                    num2 = -d;
                    break;

                case "@sqrt":
                    num2 = Math.Sqrt(d);
                    break;

                case "@sin":
                    num2 = this.ApplyTrigFunction(new Func<double, double>(Math.Sin), d);
                    break;

                case "@cos":
                    num2 = this.ApplyTrigFunction(new Func<double, double>(Math.Cos), d);
                    break;

                case "@tg":
                    num2 = this.ApplyTrigFunction(new Func<double, double>(Math.Tan), d);
                    break;

                case "@ctg":
                    num2 = 1.0 / this.ApplyTrigFunction(new Func<double, double>(Math.Tan), d);
                    break;

                case "@sh":
                    num2 = Math.Sinh(d);
                    break;

                case "@ch":
                    num2 = num2 = Math.Cosh(d);
                    break;

                case "@th":
                    num2 = Math.Tanh(d);
                    break;

                case "@ln":
                    num2 = Math.Log(d);
                    break;

                case "@exp":
                    num2 = Math.Exp(d);
                    break;

                case "@abs":
                    num2 = Math.Abs(d);
                    break;

                default:
                    throw new ArgumentException("Unknown operator");
            }
            stack.Push(num2);
            return stack;
        Label_0323:
            stack.Push(num5);
            return stack;
        }
    }
}