using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace HMIProject
{
    public class ConditionEvent
    {
        private static bool Predecessor(string firstOperator, string secondOperator)
        {
            //string opString = "(+-*/%";
            string[] opString = { "(", "||", "&&", "|", "^", "&", "==", "!=", "<", ">", "<=", ">=", "<<", ">>", "+", "-", "*", "/", "%" };
            int[] precedence = { 0, 1, 2, 3, 4, 5, 6, 6, 7, 7, 7, 7, 8, 8, 12, 12, 13, 13, 13 };// "(" has less prececence

            int firstPoint = 0, secondPoint = 0;


            int index = 0;
            foreach (string op in opString)
            {
                if (op == firstOperator)
                    firstPoint = index;
                if (op == secondOperator)
                    secondPoint = index;
                index++;
            }

            return (precedence[firstPoint] >= precedence[secondPoint]) ? true : false;
        }

        private static string ConvertToPostFix(string inFix)
        {
            StringBuilder postFix = new StringBuilder();
            char[] inFixCharArray = inFix.ToCharArray();
            string arrival;
            Stack<string> oprerator = new Stack<string>();//Creates a new Stack
            bool isNextOfNum = false;
            bool isNextOperation = false;
            int index = 0;
            foreach (char c in inFix.ToCharArray())//Iterates characters in inFix
            {
                if (c == ' ')
                {
                    index++;
                    continue;
                }

                if (Char.IsNumber(c) || Char.IsLetter(c))
                {
                    postFix.Append(c);
                    isNextOfNum = true;
                }
                else
                {
                    string operation = c.ToString();
                    if (isNextOfNum)
                    {
                        isNextOfNum = false;
                        postFix.Append("#");
                    }

                    if (c == '(')
                        oprerator.Push(operation);
                    else if (c == ')')//Removes all previous elements from Stack and puts them in 
                                      //front of PostFix.  
                    {
                        arrival = oprerator.Pop();
                        while (arrival != "(")
                        {
                            postFix.Append(arrival);
                            arrival = oprerator.Pop();
                            postFix.Append("#");
                        }
                    }
                    else
                    {

                        if (!isNextOperation && (c == '<' || c == '>' || c == '=' || c == '!' || c == '&' || c == '|') && index < inFix.Length)
                        {
                            char tc = inFixCharArray[index + 1];
                            if (!(Char.IsNumber(tc) || Char.IsLetter(tc) || tc == ' '))
                            {
                                isNextOperation = true;
                                index++;
                                continue;
                            }
                        }

                        if (isNextOperation)
                        {
                            isNextOperation = false;
                            operation = inFixCharArray[index - 1].ToString() + c.ToString();
                        }

                        if (oprerator.Count != 0 && Predecessor(oprerator.Peek(), operation))//If find an operator
                        {
                            arrival = oprerator.Pop();
                            while (Predecessor(arrival, operation))
                            {
                                postFix.Append(arrival);
                                postFix.Append("#");

                                if (oprerator.Count == 0)
                                    break;

                                arrival = oprerator.Pop();
                            }
                            oprerator.Push(operation);
                        }
                        else
                            oprerator.Push(operation);//If Stack is empty or the operator has precedence 
                    }
                }
                index++;
            }
            if (isNextOfNum)
            {
                postFix.Append("#");
            }
            while (oprerator.Count > 0)
            {
                arrival = oprerator.Pop();
                postFix.Append(arrival);
                postFix.Append("#");
            }
            return postFix.ToString();
        }

        public ConditionEvent conditionEventTransmissionFormat()
        {
            ConditionEvent ce = new ConditionEvent();
            ce.statement = ConvertToPostFix(this.statement);
            ce.type = this.type;
            ce.gName = this.gName;
            ce.GUIOType = this.GUIOType;
            ce.property = this.property;
            ce.value = this.value;
            return ce;
        }

        [DisplayName("조건식")]
        public string statement { get; set; }
        [DisplayName("이벤트 타입")]
        public string type { get; set; }
        [DisplayName("G-Name")]
        public string gName { get; set; }
        [DisplayName("GUIO 타입")]
        public string GUIOType { get; set; }
        [DisplayName("속성")]
        public string property { get; set; }
        [DisplayName("값")]
        public string value { get; set; }

        public ConditionEvent()
        {

        }
        public ConditionEvent(string statement, string type, string gName, string GUIOType, string property, string value)
        {
            this.statement = statement;
            this.type = type;
            this.gName = gName;
            this.GUIOType = GUIOType;
            this.property = property;
            this.value = value;
        }
    }
}
