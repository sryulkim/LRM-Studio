using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIProject
{
    public class HMIConstants
    {
        public enum guioNumber
        {
            NULL = 100,
            CAMERA = 100, CIRCLE, RECTANGLE, PUSHBUTTON, DIAL,
            PROGRESSBAR, SLIDERBAR, NUMBERPAD, LOGINPAD, LABEL, DIGITALCLOCK,
            RADIOBUTTON, LED, PANEL, SETRESETBUTTON, INCDECBUTTON, IMAGE, RAIL, WEBVIEW, SCROLLLABEL
        }

        public static String getGUIOName(guioNumber number)
        {
            switch(number)
            {
                case guioNumber.CAMERA:
                    return "GUIOCamera";
                case guioNumber.CIRCLE:
                    return "GUIOCircle";
                case guioNumber.RECTANGLE:
                    return "GUIORectangle";
                case guioNumber.PUSHBUTTON:
                    return "GPushButton";
                case guioNumber.DIAL:
                    return "GDial";
                case guioNumber.PROGRESSBAR:
                    return "GProgressBar";
                case guioNumber.SLIDERBAR:
                    return "GSliderBar";
                case guioNumber.NUMBERPAD:
                    return "GNumpad";
                case guioNumber.LOGINPAD:
                    return "GLoginpad";
                case guioNumber.LABEL:
                    return "GLabel";
                case guioNumber.DIGITALCLOCK:
                    return "GDigitalClock";
                case guioNumber.RADIOBUTTON:
                    return "GRadioButton";
                case guioNumber.LED:
                    return "GLed";
                case guioNumber.PANEL:
                    return "GPanel";
                case guioNumber.SETRESETBUTTON:
                    return "GSetResetButton";
                case guioNumber.INCDECBUTTON:
                    return "GIncDecButton";
                case guioNumber.IMAGE:
                    return "GImage";
                case guioNumber.RAIL:
                    return "GRail";
                case guioNumber.WEBVIEW:
                    return "GWebView";
                case guioNumber.SCROLLLABEL:
                    return "GScrollLabel";
                default:
                    return "NULL";
            }
        }

        public static guioNumber getGUIONumber(string guioName)
        {
            switch(guioName)
            {
                case "GUIOCamera":
                    return guioNumber.CAMERA;
                case "GUIOCircle":
                    return guioNumber.CIRCLE;
                case "GUIORectangle":
                    return guioNumber.RECTANGLE;
                case "GPushButton":
                    return guioNumber.PUSHBUTTON;
                case "GDial":
                    return guioNumber.DIAL;
                case "GProgressBar":
                    return guioNumber.PROGRESSBAR;
                case "GSliderBar":
                    return guioNumber.SLIDERBAR;
                case "GNumpad":
                    return guioNumber.NUMBERPAD;
                case "GLoginpad":
                    return guioNumber.LOGINPAD;
                case "GLabel":
                    return guioNumber.LABEL;
                case "GDigitalClock":
                    return guioNumber.DIGITALCLOCK;
                case "GRadioButton":
                    return guioNumber.RADIOBUTTON;
                case "GLed":
                    return guioNumber.LED;
                case "GPanel":
                    return guioNumber.PANEL;
                case "GSetResetButton":
                    return guioNumber.SETRESETBUTTON;
                case "GIncDecButton":
                    return guioNumber.INCDECBUTTON;
                case "GImage":
                    return guioNumber.IMAGE;
                case "GRail":
                    return guioNumber.RAIL;
                case "GWebView":
                    return guioNumber.WEBVIEW;
                case "GScrollLabel":
                    return guioNumber.SCROLLLABEL;
                default:
                    return guioNumber.NULL;
            }
        }

        public static string getCurDir()
        {
            //Microsoft.VisualStudio.Project.ProjectConfig config = new Microsoft.VisualStudio.Project.ProjectConfig();
            string property = "";

            //property = config.GetConfigurationProperty("WorkingDirectory", false);
            return property;
        }
    }
}
