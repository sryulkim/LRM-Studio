using System;
using System.Diagnostics;
using System.Globalization;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using System.Collections.Generic;

namespace HMIProject
{
    [Guid(HMIProjectGuids.guidHMIEditorFactoryString)]
    public class HMIEditorFactory : IVsEditorFactory, IDisposable
    {
        #region Fields
        private ServiceProvider vsServiceProvider;
        #endregion

        #region Constructors

        public HMIEditorFactory()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering {0} constructory", typeof(HMIEditorFactory).ToString()));
        }

        #endregion


        #region Metods

        #region IDisposable Pattern implementation

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(vsServiceProvider != null)
                {
                    vsServiceProvider.Dispose();
                    vsServiceProvider = null;
                }
            }
        }

        #endregion

        #region IVsEditorFactory Members

        public int SetSite(Microsoft.VisualStudio.OLE.Interop.IServiceProvider psp)
        {
            vsServiceProvider = new ServiceProvider(psp);
            return VSConstants.S_OK;
        }

        public int MapLogicalView(ref Guid rguidLogicalView, out string pbstrPhysicalView)
        {
            pbstrPhysicalView = null;

            if(VSConstants.LOGVIEWID_Primary == rguidLogicalView)
            {
                return VSConstants.S_OK;
            }
            else
            {
                return VSConstants.E_NOTIMPL;
            }
        }

        public int Close()
        {
            return VSConstants.S_OK;
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public int CreateEditorInstance(uint grfCreateDoc, string pszMkDocument, string pszPhysicalView, IVsHierarchy pvHier, uint itemid, IntPtr punkDocDataExisting, out IntPtr ppunkDocView, out IntPtr ppunkDocData, out string pbstrEditorCaption, out Guid pguidCmdUI, out int pgrfCDW)
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering {0} CreateEditorInstance()", ToString()));

            // Initialize to null
            ppunkDocView = IntPtr.Zero;
            ppunkDocData = IntPtr.Zero;
            pguidCmdUI = HMIProjectGuids.guidHMIEditorFactory;
            pgrfCDW = 0;
            pbstrEditorCaption = null;

            // Validate inputs
            if ((grfCreateDoc & (VSConstants.CEF_OPENFILE | VSConstants.CEF_SILENT)) == 0)
            {
                return VSConstants.E_INVALIDARG;
            }
            if (punkDocDataExisting != IntPtr.Zero)
            {
                return VSConstants.VS_E_INCOMPATIBLEDOCDATA;
            }

            // Create the Document (editor)
            HMIEditorPane newEditor = new HMIEditorPane();

            ppunkDocView = Marshal.GetIUnknownForObject(newEditor);
            ppunkDocData = Marshal.GetIUnknownForObject(newEditor);
            
            
            pbstrEditorCaption = "";

            return VSConstants.S_OK;
        }

        #endregion

        #endregion

    }
}
