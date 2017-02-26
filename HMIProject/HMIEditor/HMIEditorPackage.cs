//------------------------------------------------------------------------------
// <copyright file="HMIEditorPackage.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace HMIProject
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#210", "#212", "1.0", IconResourceID = 1400)] // Info on this package for Help/About
    [ProvideEditorExtension(typeof(HMIEditorFactory), ".page", 32,
        ProjectGuid = "{AD9C1A17-A194-4F71-B75E-D9A9A41915E4}", // 여기서 Editor가 프로젝트를 가리키는 것으로 생각됨 
        TemplateDir = "Templates/Items/HMIPage", NameResourceID = 206)]
    [ProvideEditorLogicalView(typeof(HMIEditorFactory), "{9BD7B599-14BB-4F47-8089-AD81DC2E6E67}")]
    [Guid(HMIProjectGuids.guidHMIEditorPackageString)]
    public sealed class HMIEditorPackage : Package
    {
        #region

        private HMIEditorFactory hmiEditorFactory;

        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="HMIEditorPackage"/> class.
        /// </summary>
        public HMIEditorPackage()
        {
            // Inside this method you can place any initialization code that does not require
            // any Visual Studio service because at this point the package object is created but
            // not sited yet inside Visual Studio environment. The place to do all the other
            // initialization is the Initialize method.
        }

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            hmiEditorFactory = new HMIEditorFactory();
            RegisterEditorFactory(hmiEditorFactory);
        }

        #endregion
    }
}
