/*-----------------------------------------------------------------------------
 * Update Log
 * 2016 / 07 / 11
 * Class 확인
 * VSIX Project의 Package파일로써, EmCL Studio가 실행될 때, Command를 초기화한다.
 * 이 cs 파일을 통해 Package가 EmCL Studio에 등록된다.
 */

using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;

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
    [InstalledProductRegistration("#2110", "#2112", "1.0", IconResourceID = 2400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(HMIToolWindow))]
    [Guid(HMIToolWindowPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class HMIToolWindowPackage : Package
    {
        /// <summary>
        /// HMIToolWindowPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "667dd3f5-6da5-4e8c-9721-d2b1f91a68a8";

        /// <summary>
        /// Initializes a new instance of the <see cref="HMIToolWindow"/> class.
        /// </summary>
        public HMIToolWindowPackage()
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
            HMIToolWindowCommand.Initialize(this);
            base.Initialize();
        }

        #endregion
    }
}
