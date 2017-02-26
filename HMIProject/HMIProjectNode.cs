using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Project;

using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace HMIProject
{
    public class HMIProjectNode : ProjectNode
    {
        public static string currentProjectDirectory;
        public static string currentProjectName;

        internal static int imageIndex;
        public override int ImageIndex
        {
            get { return imageIndex; }
        }

        private HMIProjectPackage package;


        private static ImageList imageList;

        static HMIProjectNode()
        {
            //MessageBox.Show("Hello");
            imageList = Utilities.GetImageList(typeof(HMIProjectNode).Assembly.GetManifestResourceStream("HMIProject.Resources.HMIProjectNode.bmp"));
        }

        public HMIProjectNode(HMIProjectPackage package)
        {
            this.package = package;

            imageIndex = this.ImageHandler.ImageList.Images.Count;

            foreach (Image img in imageList.Images)
            {
                this.ImageHandler.AddImage(img);
            }
        }

        public override Guid ProjectGuid
        {
            get { return HMIProjectGuids.guidHMIProjectFactory; }
        }
        public override string ProjectType
        {
            get { return "HMIProjectType"; }
        }

        public override void AddFileFromTemplate(string source, string target)
        {
            string nameSpace = this.FileTemplateProcessor.GetFileNamespace(target, this);
            string className = Path.GetFileNameWithoutExtension(target);

            this.FileTemplateProcessor.AddReplace("$nameSpace$", nameSpace);
            this.FileTemplateProcessor.AddReplace("$className$", className);

            this.FileTemplateProcessor.UntokenFile(source, target);
            this.FileTemplateProcessor.Reset();
        }
    }
}