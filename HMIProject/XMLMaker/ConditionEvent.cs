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
        private string infixToPostfix(string expression)
        {
            string postfix = "";
            string temp = "";

            string savedString = "";
            bool preNumFlag = false;
            bool preOpFlag = false;

            Stack<string> operandStack = new Stack<string>();


            char[] infix = expression.ToCharArray();

            foreach (char ch in infix)
            {
                if (isNumber(ch))
                {
                    if (preOpFlag)
                    {
                        preOpFlag = false;
                        operandStack.Push(savedString + "#");
                        savedString = "";
                    }

                    if (preNumFlag)
                    {
                        savedString += ch;
                    }
                    else
                    {
                        preNumFlag = true;
                        savedString = "" + ch;
                    }
                }
                else
                {
                    if (preNumFlag)
                    {
                        preNumFlag = false;
                        temp += savedString + "#";
                        if (operandStack.Count > 0)
                            temp += operandStack.Pop();
                        savedString = "";
                    }

                    if (isOperation(ch))
                    {
                        if (preOpFlag)
                        {
                            savedString += ch;
                        }
                        else
                        {
                            preOpFlag = true;
                            savedString = "" + ch;
                        }
                    }
                    else
                    {
                        preOpFlag = false;
                        temp += savedString + "#";
                        savedString = "";
                    }
                }


            }
            temp += savedString + "#";
            temp += operandStack.Pop();

            return temp;
        }

        bool isNumber(char ch)
        {
            if (ch == '0' || ch == '1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6' || ch == '7' || ch == '8' || ch == '9'
                || (ch > 64 && ch < 91) || (ch > 96 && ch < 123))
                return true;
            return false;
        }


        bool isOperation(char ch)
        {
            if (ch == '>' || ch == '=' || ch == '<' || ch == '&' || ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '%' || ch == '|' || ch == '^')
                return true;
            return false;
        }

        public ConditionEvent conditionEventTransmissionFormat()
        {
            ConditionEvent ce = new ConditionEvent();
            ce.statement = infixToPostfix(this.statement);
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
