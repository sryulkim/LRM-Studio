/*-----------------------------------------------------------------------------
 * Update Log
 * 2016 / 07 / 11
 * Class 확인
 * GUIO를 담고있는 도구상자로써, Caption의 값을 변경하면 도구 상자의 제목 표시줄의 제목이 변경됨.
 * Content는 이 ToolWindow가 가지고 있는 WPF control으로, 화면을 뿌려주도록 구현됨
 */

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
    [Guid("b14ab72a-4316-4fb7-8fd0-6d8645704430")]
    public class HMIToolWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HMIToolWindow"/> class.
        /// </summary>
        public HMIToolWindow() : base(null)
        {
            this.Caption = "HMI 도구 상자";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new HMIToolWindowControl();
        }
    }
}
