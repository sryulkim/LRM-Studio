//------------------------------------------------------------------------------
// <copyright file="GUIOPropertyToolWindowControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace HMIProject
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for GUIOPropertyToolWindowControl.
    /// </summary>
    public partial class GUIOPropertyToolWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GUIOPropertyToolWindowControl"/> class.
        /// </summary>
        public GUIOPropertyToolWindowControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "GUIOPropertyToolWindow");
        }
    }
}