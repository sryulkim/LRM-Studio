using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIProject
{
    class HMIProjectGuids
    {
        public const string guidHMIProjectPkgString =
       "19EE8EB5-0806-43C2-ACAF-38B7220FB115";
        public const string guidHMIProjectCmdSetString =
            "0F8ED4DD-9384-4E92-981A-1A78D4EDB515";
        public const string guidHMIProjectFactoryString =
            "AD9C1A17-A194-4F71-B75E-D9A9A41915E4";

        public const string guidHMIEditorPackageString =
            "7A12B077-40C9-4626-91B4-AF230EF4B16F";
        public const string guidHMIEditorCmdSetString =
            "F1DDA6CE-CFBE-4FBC-BAF7-39A4AD2A20F1";
        public const string guidHMIEditorFactoryString =
            "CF31E86E-4481-4633-BAF0-8CD694958D04";



        public static readonly Guid guidHMIProjectCmdSet =
            new Guid(guidHMIProjectCmdSetString);
        public static readonly Guid guidHMIProjectFactory =
            new Guid(guidHMIProjectFactoryString);

        public static readonly Guid guidHMIEditorCmdSet =
            new Guid(guidHMIEditorCmdSetString);
        public static readonly Guid guidHMIEditorFactory =
            new Guid(guidHMIProjectFactoryString);
    }
}
