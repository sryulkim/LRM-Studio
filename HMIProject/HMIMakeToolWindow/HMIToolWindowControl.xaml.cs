/*-----------------------------------------------------------------------------
 * Update Log
 * 2016 / 07 / 11
 * Class 확인
 * HMI 도구 상자의 GUIO들에 대한 Drag & Drop 기능을 위한 함수들이 정의된 class
 * 뿐만 아니라 도구 상자의 다른 Control에 대해서도 정의되어 있다.
 * 
 * host는 wpf UI 정의로 xaml 파일에 정의되어 있으며
 * 이 host를 통해 Drag & Drop을 시작하는 DoDragDrop을 호출할 수 있는 Winform의 guio을 호출 할 수 있음.
 * 기존에 guio으로 진행하였으나, guio이 눌렸을 때와 Border의 모양이 이쁘지 않아 Label로 변경하였음.
 * 
 * 진행 예정 사항: HMI 도구 상자의 대분류를 나누고 그에 대한 구현이 필요하다.
 * 
 */

namespace HMIProject
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System.Drawing;

    /// <summary>
    /// Interaction logic for HMIToolWindowControl.
    /// </summary>
    public partial class HMIToolWindowControl : UserControl
    {
        public static HMIConstants.guioNumber senderItem = HMIConstants.guioNumber.NULL;
        private System.Resources.ResourceManager rm = HMIProject.Resources.ResourceManager;

        protected void makeGUIOComponent(string GUIOName)
        {
            Bitmap image = (System.Drawing.Bitmap)rm.GetObject(GUIOName);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HMIToolWindowControl"/> class.
        /// </summary>
        public HMIToolWindowControl()
        {
            this.InitializeComponent();
            
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.CAMERA));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.CIRCLE));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.RECTANGLE));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.DIAL));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.PROGRESSBAR));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.SLIDERBAR));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.NUMBERPAD));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.LOGINPAD));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.LABEL));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.SCROLLLABEL));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.DIGITALCLOCK));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.PUSHBUTTON));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.RADIOBUTTON));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.LED));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.PANEL));
            //hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.SETRESETBUTTON));
            //hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.INCDECBUTTON));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.IMAGE));
            hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.RAIL));
            hostPanel.CanHorizontallyScroll = true;
            hostPanel.CanVerticallyScroll = true;
            //hostPanel.Children.Add(makeToolBoxGUIOItem(HMIConstants.guioNumber.WEBVIEW));
        }

        private System.Windows.Forms.Integration.WindowsFormsHost makeToolBoxGUIOItem(HMIConstants.guioNumber guioNumber)
        {
            //windowsFormHost는 WPF element또는 page 내부에 Windows Form contorl을 호스팅하기위해 사용한다. 
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            host.HorizontalAlignment = HorizontalAlignment.Left;
            host.Height = 34;
            host.Width = 234;
            host.Margin = new Thickness(0, 1, 0, 0);
            host.VerticalAlignment = VerticalAlignment.Top;

            System.Windows.Forms.Label guioItem = new System.Windows.Forms.Label();
            guioItem.Size = new System.Drawing.Size(234, 34);
            guioItem.MouseDown += guio_MouseDown;
            guioItem.Image = (Bitmap)rm.GetObject(HMIConstants.getGUIOName(guioNumber));
            guioItem.Name = HMIConstants.getGUIOName(guioNumber);
            guioItem.AutoSize = false;
            guioItem.Refresh();
            host.Name = HMIConstants.getGUIOName(guioNumber);
            host.Child = guioItem;
            
            return host;
        }



        private void guio_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            senderItem = HMIConstants.getGUIONumber(((System.Windows.Forms.Label)sender).Name);
            System.Windows.Forms.Label guio = (System.Windows.Forms.Label)sender;
            guio.DoDragDrop(guio, System.Windows.Forms.DragDropEffects.Move);
        }

        private void MyToolWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.HeightChanged)
            {
                int i = 1;
                foreach (System.Windows.Forms.Integration.WindowsFormsHost host in hostPanel.Children) {
                    if (e.NewSize.Height < host.Child.Width * hostPanel.Children.Count)
                    {
                        if ((int)e.NewSize.Height / host.Height < i++)
                        {
                            host.Visibility = Visibility.Hidden;
                        }
                    }
                    else
                        host.Visibility = Visibility.Visible;
                }
            }
            if (e.WidthChanged)
            {
                foreach(System.Windows.Forms.Integration.WindowsFormsHost host in hostPanel.Children)
                {
                    if (e.NewSize.Width < 234)
                    {
                        host.Width = (int)e.NewSize.Width;
                        host.Child.Width = (int)e.NewSize.Width;
                    }
                    else
                    {
                        host.Width = 234;
                        host.Child.Width = 234;
                    }

                }
            }
        }
    }
}