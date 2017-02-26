using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Project;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace HMIProject
{
    [Guid(HMIProjectGuids.guidHMIProjectFactoryString)]
    class HMIProjectFactory : ProjectFactory
    {
        private HMIProjectPackage package;

        public HMIProjectFactory(HMIProjectPackage package)
            : base(package)
        {
            this.package = package;
        }

        protected override ProjectNode CreateProject()
        {
            HMIProjectNode project = new HMIProjectNode(this.package);

            project.SetSite((IOleServiceProvider)((IServiceProvider)this.package).GetService(typeof(IOleServiceProvider)));
            return project;
        }
    }
}
