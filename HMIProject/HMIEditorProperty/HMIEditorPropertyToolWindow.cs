//------------------------------------------------------------------------------
// <copyright file="HMIEditorPropertyToolWindow.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace HMIProject
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("66229a74-c78e-4305-8838-dc87235df410")]
    public class HMIEditorPropertyToolWindow : ToolWindowPane
    {
        public static HMIEditorPropertyToolWindowControl propertyToolWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="HMIEditorPropertyToolWindow"/> class.
        /// </summary>
        public HMIEditorPropertyToolWindow() : base(null)
        {
            this.Caption = "HMIEditorPropertyToolWindow";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            
            this.Content = new HMIEditorPropertyToolWindowControl();
        }
    }
}
