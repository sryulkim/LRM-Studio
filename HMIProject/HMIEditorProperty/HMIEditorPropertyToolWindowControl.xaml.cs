//------------------------------------------------------------------------------
// <copyright file="HMIEditorPropertyToolWindowControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace HMIProject
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Windows.Media;
    using System.Windows.Navigation;

    /// <summary>
    /// Interaction logic for HMIEditorPropertyToolWindowControl.
    /// </summary>
    public partial class HMIEditorPropertyToolWindowControl : UserControl
    {
        public enum ObjectType { Page, QDial, QSlider, QPushButton, QLabel, IpCamera, Wheel, Dial, Slider, Knob, Circle, Rectangle, SpeedMeter, GPushButton, GDial, GProgressBar, GSliderBar, GNumpad, GLoginpad, GLabel, GDigitalClock, GRadioBUtton, GLed, GPanel, GSetResetButton, GIncDecButton, GImage, GRail, GWebView, GScrollLabel };


        public static ObjectType selectedObjectType = ObjectType.Page;
        public static HMIEditorPane selectedPane;
        public static System.Windows.Forms.Panel selectedPanel;
        public static HMIEditorForm selectedForm;
        public static TransparentPanel selectedTransparentPanel;
        public static AxhmiformLib.AxHMIForm selectedHMIForm;
        

        public static GUIO selectedGUIO;
        public static Page selectedPage;


        /// <summary>
        /// Initializes a new instance of the <see cref="HMIEditorPropertyToolWindowControl"/> class.
        /// </summary>
        public HMIEditorPropertyToolWindowControl()
        {
            this.InitializeComponent();

            HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl = this;
            if (selectedObjectType != ObjectType.Page)
            {
                HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl.GUIOProperty.Visibility = Visibility.Visible;
                HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl.PageProperty.Visibility = Visibility.Collapsed;
            }
            else
            {
                HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl.GUIOProperty.Visibility = Visibility.Collapsed;
                HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl.PageProperty.Visibility = Visibility.Visible;
            }
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
                "HMIEditorPropertyToolWindow");
        }

        private void PagePropertyWidth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GUIOPropertyState2StyleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void PagePropertyName_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedHMIForm.EditPageName = PagePropertyName.Text;
                selectedPage.name = PagePropertyName.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show("올바른 Page 이름을 입력하세요");

            }

        }

        private void PagePropertyNumber_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int num = Int32.Parse(PagePropertyNumber.Text);
                    selectedPage.number = PagePropertyNumber.Text;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Page 번호는 정수값만 가질 수 있습니다.");
                }
        }

        private void PagePropertyWidth_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int width = Int32.Parse(PagePropertyWidth.Text);
                    selectedPage.size.width = PagePropertyWidth.Text;
                    selectedTransparentPanel.Size = new System.Drawing.Size(width, selectedTransparentPanel.Height);
                    selectedForm.HorizontalScroll.Maximum = width;
                    selectedHMIForm.Width = width;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("화면의 너비는 정수값만 가질 수 있습니다.");
                }
        }

        private void PagePropertyHeight_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int height = Int32.Parse(PagePropertyHeight.Text);
                    selectedPage.size.height = PagePropertyHeight.Text;
                    selectedTransparentPanel.Size = new System.Drawing.Size(selectedTransparentPanel.Width, height);
                    selectedForm.VerticalScroll.Maximum = height;
                    selectedHMIForm.Height = height;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("화면의 높이는 정수값만 가질 수 있습니다.");
                }
        }

        private void PagePropertyBackgroundColor_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = System.Int32.Parse(PagePropertyBackgroundColor.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedPage.backgroundColor = PagePropertyBackgroundColor.Text;
                    selectedHMIForm.EditPageBackgroundColor = rgb;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("배경 색상 값은 16진수 숫자값만 가능합니다.");
                }
        }

        private void PagePropertyEnable_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void GUIOPropertyNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // if (e.Key == System.Windows.Input.Key.Enter)
            // {
            //    foreach (GUIO guio in selectedPane.GUIOList)
            //   {
            //      if (guio.name == GUIOPropertyNameTextBox.Text)
            //     {
            //        MessageBox.Show("중복되는 이름을 가진 GUIO가 존재합니다.");
            //       return;
            //  }
            // }
            try
            {
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedHMIForm.EditGUIOPropertyName = GUIOPropertyNameTextBox.Text;
                selectedGUIO.name = GUIOPropertyNameTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("올바른 이름을 입력하세요");
            }
         
            //}
        }
        //private void GUIOPropertyNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        //{
         //   int count = 0;
          //  string temp1 = selectedHMIForm.selectedGUIOName;

            
            //selectedHMIForm.selectedGUIOName = selectedGUIO.name;
            //selectedHMIForm.EditGUIOPropertyName = GUIOPropertyNameTextBox.Text;
            //selectedGUIO.name = GUIOPropertyNameTextBox.Text;
           // selectedHMIForm.selectedGUIOName = GUIOPropertyNameTextBox.Text;
            //selectedGUIO.name = GUIOPropertyNameTextBox.Text;

          //  foreach (GUIO guio in selectedPane.GUIOList)
           // {
            //    if (guio.name == GUIOPropertyNameTextBox.Text)
             //   {
              //      count++;                
               // }
      //      }
       //     if (count > 1)
        //    {
         //       MessageBox.Show("중복되는 GUIO 이름이 있습니다.");
          //      selectedHMIForm.selectedGUIOName = temp1;
           //     selectedGUIO.name = temp1;
            //    GUIOPropertyNameTextBox.Text = temp1;
                //selectedHMIForm.selectedGUIOName = temp1;
                //selectedHMIForm.EditGUIOPropertyName = temp1;
                //selectedGUIO.name = temp1;
           // }
       // }
        private void GUIOPropertyGVarTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedGUIO.gVariable = GUIOPropertyGVarTextBox.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show("올바른 이름을 입력하세요");
            }
        }

        /*
        private void GUIOPropertyBackgroundColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (selectedObjectType == ObjectType.QDial)
                {
                    selectedQDial.background_color_number = System.Int32.Parse(GUIOPropertyBackgroundColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedGUIO.backgroundColor = GUIOPropertyBackgroundColorTextBox.Text;
                }
                else
                if (selectedObjectType == ObjectType.QLabel)
                {
                    selectedQLabel.background_color_number = System.Int32.Parse(GUIOPropertyBackgroundColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedGUIO.backgroundColor = GUIOPropertyBackgroundColorTextBox.Text;
                }
                else
                if (selectedObjectType == ObjectType.QPushButton)
                {
                    selectedQPushButton.background_color_number = System.Int32.Parse(GUIOPropertyBackgroundColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedGUIO.backgroundColor = GUIOPropertyBackgroundColorTextBox.Text;
                }
                else
                if (selectedObjectType == ObjectType.QSlider)
                {
                    selectedQSlider.background_color_number = System.Int32.Parse(GUIOPropertyBackgroundColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedGUIO.backgroundColor = GUIOPropertyBackgroundColorTextBox.Text;
                }
                else
                if (selectedObjectType == ObjectType.SpeedMeter)
                {
                    selectedSpeedMeter.background_color_number = System.Int32.Parse(GUIOPropertyBackgroundColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedGUIO.backgroundColor = GUIOPropertyBackgroundColorTextBox.Text;
                }

            }
        }
        */

        private void GUIOPropertyXTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int xPoint = Int32.Parse(GUIOPropertyXTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedHMIForm.EditGUIOPropertyX = xPoint;
                    selectedGUIO.location.x = GUIOPropertyXTextBox.Text;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("올바른 양의 정수 값을 입력해주세요.");
                }
        }

        private void GUIOPropertyYTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int yPoint = Int32.Parse(GUIOPropertyYTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedHMIForm.EditGUIOPropertyY = yPoint;
                    selectedGUIO.location.y = GUIOPropertyYTextBox.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("올바른 양의 정수 값을 입력해주세요.");
                }
        }

        private void GUIOPropertyWidthTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int width = Int32.Parse(GUIOPropertyWidthTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedHMIForm.EditGUIOPropertyWidth = width;
                    selectedGUIO.size.width = GUIOPropertyWidthTextBox.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("올바른 양의 정수 값을 입력해주세요.");
                }
        }

        private void GUIOPropertyHeightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int height = Int32.Parse(GUIOPropertyHeightTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedHMIForm.EditGUIOPropertyHeight = height;
                    selectedGUIO.size.height = GUIOPropertyHeightTextBox.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("올바른 양의 정수 값을 입력해주세요.");
                }
        }

        private void GUIOPropertyLayerTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int layer = Int32.Parse(GUIOPropertyLayerTextBox.Text);
                    selectedGUIO.layer = GUIOPropertyLayerTextBox.Text;
                    selectedPane.GUIOList.Sort(CompareLayer);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedHMIForm.EditGUIOPropertyLayer = layer;
                }
                catch (System.FormatException ex)
                {
                    MessageBox.Show("\nLayer값은 정수 값만 가질 수 있습니다.");
                }
        }

        private int CompareLayer(GUIO a, GUIO b)
        {
            if (Int32.Parse(a.layer) > Int32.Parse(b.layer))
                return 1;
            else if (Int32.Parse(a.layer) >= Int32.Parse(b.layer))
                return 0;
            else
                return -1;
        }
        private int ReverseCompareLayer(GUIO a, GUIO b)
        {
            if (Int32.Parse(a.layer) > Int32.Parse(b.layer))
                return 1;
            else if (Int32.Parse(a.layer) >= Int32.Parse(b.layer))
                return 0;
            else
                return -1;
        }

        private void FigurePropertyNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedHMIForm.EditGUIOPropertyName = GUIOPropertyNameTextBox.Text;
                selectedGUIO.name = GUIOPropertyNameTextBox.Text;
        }

        private void FigurePropertyFillColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = System.Int32.Parse(FigurePropertyFillColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.fillColor = FigurePropertyFillColorTextBox.Text;
                    selectedHMIForm.EditCircleFillColor = rgb;
                    selectedHMIForm.EditRectangleFillColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 숫자값만 가능합니다.");
                }
        }

        private void FigurePropertyFillColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.fillColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                FigurePropertyFillColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.fillColor = FigurePropertyFillColorTextBox.Text;
                selectedHMIForm.EditCircleFillColor = rgb;
                selectedHMIForm.EditRectangleFillColor = rgb;
            }
        }

        private void FigurePropertyLineColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = System.Int32.Parse(FigurePropertyLineColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.lineColor = FigurePropertyLineColorTextBox.Text;
                    selectedHMIForm.EditCircleLineColor = rgb;
                    selectedHMIForm.EditRectangleLineColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 숫자값만 가능합니다.");
                }
        }

        private void FigurePropertyLineColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.lineColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                FigurePropertyLineColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.lineColor = FigurePropertyLineColorTextBox.Text;
                selectedHMIForm.EditCircleLineColor = rgb;
                selectedHMIForm.EditRectangleLineColor = rgb;
            }
        }

        private void FigurePropertyLineThicknessTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int thickness = System.Int32.Parse(FigurePropertyLineThicknessTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.lineThickness = FigurePropertyLineThicknessTextBox.Text;
                    selectedHMIForm.EditCircleLineThickness = thickness;
                    selectedHMIForm.EditRectangleLineThickness = thickness;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 숫자값만 가능합니다.");
                }
        }

        private void FigurePropertyLayerTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int layer = System.Int32.Parse(FigurePropertyLayerTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedHMIForm.EditGUIOPropertyLayer = layer;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 숫자값만 가능합니다.");
                }
        }

        private void FigurePropertyXTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int xPoint = Int32.Parse(FigurePropertyXTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedHMIForm.EditGUIOPropertyX = xPoint;
                    selectedGUIO.location.x = FigurePropertyXTextBox.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("올바른 양의 정수 값을 입력해주세요.");
                }
        }

        private void FigurePropertyYTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int yPoint = Int32.Parse(FigurePropertyYTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedHMIForm.EditGUIOPropertyY = yPoint;
                    selectedGUIO.location.y = FigurePropertyYTextBox.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("올바른 양의 정수 값을 입력해주세요.");
                }
        }

        private void FigurePropertyWidthTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int width = Int32.Parse(FigurePropertyWidthTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedHMIForm.EditGUIOPropertyWidth = width;
                    selectedGUIO.size.width = FigurePropertyWidthTextBox.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("올바른 양의 정수 값을 입력해주세요.");
                }
        }

        private void FigurePropertyHeightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int height = Int32.Parse(FigurePropertyHeightTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedHMIForm.EditGUIOPropertyHeight = height;
                    selectedGUIO.size.height = FigurePropertyHeightTextBox.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("올바른 양의 정수 값을 입력해주세요.");
                }
        }

        /*
        private void ClickEventTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                TextBox thisTextBox = (TextBox)sender;
                ComboBox typeComboBox = null, gNameComboBox = null, propertyComboBox = null;
                DockPanel bottomPanel = null;

                int index = Int32.Parse(thisTextBox.Name.Substring(17));
                foreach (UIElement element in ClickEventStackPanel.Children)
                {
                    if (element as DockPanel != null)
                    {
                        if (((DockPanel)element).Name.StartsWith("ClickAboveDockPanel"))
                        {
                            if (index == Int32.Parse(((DockPanel)element).Name.Substring(19)))
                            {
                                foreach (UIElement comboboxElement in ((DockPanel)element).Children)
                                {
                                    if (comboboxElement as ComboBox != null)
                                    {
                                        if (((ComboBox)comboboxElement).Name.StartsWith("ClickEventGNameComboBox"))
                                        {
                                            gNameComboBox = (ComboBox)comboboxElement;
                                        }
                                        else if (((ComboBox)comboboxElement).Name.StartsWith("ClickEventTypeComboBox"))
                                        {
                                            typeComboBox = (ComboBox)comboboxElement;
                                        }
                                    }
                                }
                            }
                        }
                        else if (((DockPanel)element).Name.StartsWith("ClickBottomDockPanel"))
                        {
                            if (index == Int32.Parse(((DockPanel)element).Name.Substring(20)))
                            {
                                bottomPanel = (DockPanel)element;
                                foreach (UIElement comboboxElement in bottomPanel.Children)
                                {
                                    if (comboboxElement as ComboBox != null)
                                    {
                                        if (((ComboBox)comboboxElement).Name.StartsWith("ClickEventPropertyComboBox"))
                                        {
                                            propertyComboBox = (ComboBox)comboboxElement;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                clickEvent thisEvent = null;
                if (gNameComboBox != null && typeComboBox != null && propertyComboBox != null)
                {
                    foreach (clickEvent ce in selectedGUIO.clickEvents)
                    {
                        if (index == Int32.Parse(ce.number))
                        {
                            thisEvent = ce;
                        }
                    }


                    if (typeComboBox.SelectedIndex > 0 && typeComboBox.SelectedIndex < 4)
                    {
                        if (gNameComboBox.SelectedIndex != 0)
                        {
                            if (thisEvent == null)
                            {
                                thisEvent = new clickEvent();
                                thisEvent.number = "" + index;
                                selectedGUIO.clickEvents.Add(thisEvent);
                            }
                            thisEvent.type = ((ComboBoxItem)typeComboBox.SelectedItem).Content.ToString();
                            thisEvent.gName = ((ComboBoxItem)gNameComboBox.SelectedItem).Content.ToString();
                            thisEvent.GUIOType = null;
                            thisEvent.property = null;
                            thisEvent.value = thisTextBox.Text;
                        }
                    }
                    else if (typeComboBox.SelectedIndex == 4)
                    {
                        if (gNameComboBox.SelectedIndex != 0 && propertyComboBox.SelectedIndex != 0)
                        {
                            if (thisEvent == null)
                            {
                                thisEvent = new clickEvent();
                                thisEvent.number = "" + index;
                                selectedGUIO.clickEvents.Add(thisEvent);
                            }
                            thisEvent.type = ((ComboBoxItem)typeComboBox.SelectedItem).Content.ToString();
                            thisEvent.gName = ((ComboBoxItem)gNameComboBox.SelectedItem).Content.ToString();
                            foreach (GUIO guio in selectedPane.GUIOList)
                            {
                                if (guio.name == thisEvent.gName)
                                    thisEvent.GUIOType = guio.type;
                            }
                            thisEvent.property = ((ComboBoxItem)propertyComboBox.SelectedItem).Content.ToString();
                            thisEvent.value = thisTextBox.Text;
                        }
                    }
                    else if (typeComboBox.SelectedIndex == 5)
                    {
                        if (gNameComboBox.SelectedIndex != 0)
                        {
                            if (thisEvent == null)
                            {
                                thisEvent = new clickEvent();
                                thisEvent.number = "" + index;
                                selectedGUIO.clickEvents.Add(thisEvent);
                            }
                            thisEvent.type = ((ComboBoxItem)typeComboBox.SelectedItem).Content.ToString();
                            thisEvent.gName = ((ComboBoxItem)gNameComboBox.SelectedItem).Content.ToString();
                            thisEvent.GUIOType = null;
                            thisEvent.property = null;
                            thisEvent.value = null;
                        }
                    }
                }

            }
        }
        private System.Resources.ResourceManager rm = HMIProject.Resources.ResourceManager;

        private System.Collections.Generic.List<DockPanel> clickEventDockPanelAboveList = new System.Collections.Generic.List<DockPanel>();
        private System.Collections.Generic.List<DockPanel> clickEventDockPanelBottomList = new System.Collections.Generic.List<DockPanel>();
        private int dockPanelNumber = 1;


        private void ClickEventAddButton_Click(object sender, RoutedEventArgs e)
        {
            int lastIndex = 0;
            // 마지막 Event 번호 검사
            foreach (UIElement element in ClickEventStackPanel.Children)
            {
                if ((element as DockPanel) != null)
                    if (((DockPanel)element).Name.StartsWith("ClickAboveDockPanel")) {
                        if (lastIndex < Int32.Parse(((DockPanel)element).Name.Substring(19)))
                        {
                            lastIndex = Int32.Parse(((DockPanel)element).Name.Substring(19));
                        }
                    }
            }
            dockPanelNumber = lastIndex + 1;

            DockPanel aboveDockPanel = new DockPanel();
            aboveDockPanel.Name = "ClickAboveDockPanel" + dockPanelNumber;
            aboveDockPanel.Margin = new Thickness(0, 5, 0, 0);
            aboveDockPanel.Name.Substring(19);

            DockPanel bottomDockPanel = new DockPanel();
            bottomDockPanel.Name = "ClickBottomDockPanel" + dockPanelNumber;
            bottomDockPanel.Margin = new Thickness(0, 5, 0, 0);
            bottomDockPanel.Name.Substring(20);

            Button clickEventMinusButton = new Button()
            {
                BorderBrush = System.Windows.Media.Brushes.Transparent,
                BorderThickness = new Thickness(0)
            };
            clickEventMinusButton.Name = "ClickMinusButton" + dockPanelNumber;
            clickEventMinusButton.Name.Substring(16);
            clickEventMinusButton.Margin = new Thickness(5, 0, 0, 0);
            clickEventMinusButton.Height = 17;
            clickEventMinusButton.Width = 17;
            System.Drawing.Bitmap image = (System.Drawing.Bitmap)rm.GetObject("minus");
            System.Windows.Media.Imaging.BitmapImage bitmapImage = StaticMethods.ToBitmapImage(image);
            var img = new System.Windows.Controls.Image { Source = bitmapImage };
            clickEventMinusButton.Content = img;
            //var brush = new System.Windows.Media.ImageBrush();
            //brush.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri("Images/minus.png", UriKind.RelativeOrAbsolute));

            //clickEventMinusButton.Background = brush;
            aboveDockPanel.Children.Add(clickEventMinusButton);

            clickEventMinusButton.Click += ClickEventMinusButtonClick;
            ComboBox comboBox = new ComboBox();
            comboBox.Name = "ClickEventTypeComboBox" + dockPanelNumber;
            comboBox.SelectionChanged += ClickEventTypeComboBox_SelectionChanged;
            ComboBoxItem comboBoxItem = new ComboBoxItem();
            comboBoxItem.Content = "Event Type";
            comboBox.Items.Add(comboBoxItem);
            comboBoxItem = new ComboBoxItem();
            comboBoxItem.Content = "ChangeValue";
            comboBox.Items.Add(comboBoxItem);
            comboBoxItem = new ComboBoxItem();
            comboBoxItem.Content = "IncreaseValue";
            comboBox.Items.Add(comboBoxItem);
            comboBoxItem = new ComboBoxItem();
            comboBoxItem.Content = "DecreaseValue";
            comboBox.Items.Add(comboBoxItem);
            comboBoxItem = new ComboBoxItem();
            comboBoxItem.Content = "ChangeProperty";
            comboBox.Items.Add(comboBoxItem);
            comboBoxItem = new ComboBoxItem();
            comboBoxItem.Content = "ChangePage";
            comboBox.Items.Add(comboBoxItem);
            comboBox.Margin = new Thickness(25, 0, 0, 0);
            comboBox.HorizontalAlignment = HorizontalAlignment.Left;
            comboBox.SelectedIndex = 0;
            comboBox.Width = 120;
            comboBox.Height = 22;
            aboveDockPanel.Children.Add(comboBox);

            comboBox = new ComboBox();
            comboBox.Name = "ClickEventGNameComboBox" + dockPanelNumber;
            comboBox.SelectionChanged += ClickEventGNameComboBox_SelectionChanged;
            comboBoxItem = new ComboBoxItem();
            comboBoxItem.Content = "G-Name";
            comboBox.Items.Add(comboBoxItem);
            comboBox.Margin = new Thickness(15, 0, 0, 0);
            comboBox.HorizontalAlignment = HorizontalAlignment.Left;
            comboBox.SelectedIndex = 0;
            comboBox.Width = 120;
            comboBox.Height = 22;
            aboveDockPanel.Children.Add(comboBox);

            comboBox = new ComboBox();
            comboBoxItem = new ComboBoxItem();
            comboBox.Name = "ClickEventPropertyComboBox" + dockPanelNumber;
            comboBoxItem.Content = "Property";
            comboBox.Items.Add(comboBoxItem);
            comboBox.Margin = new Thickness(47, 0, 0, 0);
            comboBox.SelectedIndex = 0;
            comboBox.Width = 120;
            comboBox.Height = 22;
            bottomDockPanel.Children.Add(comboBox);

            TextBox textBox = new TextBox();
            textBox.LostFocus += ClickEventTextBox_LostFocus;
            textBox.Name = "ClickEventTextBox" + dockPanelNumber;
            textBox.Height = 22;
            textBox.Width = 120;
            textBox.HorizontalAlignment = HorizontalAlignment.Left;
            textBox.Margin = new Thickness(15, 0, 0, 0);
            bottomDockPanel.Children.Add(textBox);

            clickEventDockPanelAboveList.Add(aboveDockPanel);
            ClickEventStackPanel.Children.Add(aboveDockPanel);
            clickEventDockPanelBottomList.Add(bottomDockPanel);
            ClickEventStackPanel.Children.Add(bottomDockPanel);
        }

        private void ClickEventMinusButtonClick(object sender, RoutedEventArgs e)
        {
            DockPanel removeAbovePanel = null;
            DockPanel removeBottomPanel = null;
            int index = System.Int32.Parse(((Button)sender).Name.Substring(16));

            foreach (DockPanel dockpanel in clickEventDockPanelAboveList)
            {
                if (System.Int32.Parse(((Button)sender).Name.Substring(16)) == System.Int32.Parse(dockpanel.Name.Substring(19)))
                {
                    removeAbovePanel = dockpanel;
                }
            }

            foreach (DockPanel dockpanel in clickEventDockPanelBottomList)
            {
                if (System.Int32.Parse(((Button)sender).Name.Substring(16)) == System.Int32.Parse(dockpanel.Name.Substring(20)))
                {
                    removeBottomPanel = dockpanel;
                }
            }
            clickEventDockPanelAboveList.Remove(removeAbovePanel);
            clickEventDockPanelBottomList.Remove(removeBottomPanel);
            ClickEventStackPanel.Children.Remove(removeAbovePanel);
            ClickEventStackPanel.Children.Remove(removeBottomPanel);
        }

        private void ClickEventGNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedPane != null)
            {
                ComboBox thisComboBox = (ComboBox)sender;
                if (thisComboBox.SelectedIndex != 0 && thisComboBox.Items.Count != 0)
                {
                    int index = Int32.Parse(thisComboBox.Name.Substring(23));
                    ComboBox propertyComboBox = null;
                    ComboBox typeComboBox = null;
                    DockPanel bottomPanel = null;

                    foreach (UIElement element in ClickEventStackPanel.Children)
                    {
                        if (element as DockPanel != null)
                        {
                            if (((DockPanel)element).Name.StartsWith("ClickAboveDockPanel"))
                            {
                                if (index == Int32.Parse(((DockPanel)element).Name.Substring(19)))
                                {
                                    foreach (UIElement comboboxElement in ((DockPanel)element).Children)
                                    {
                                        if (comboboxElement as ComboBox != null)
                                        {
                                            if (((ComboBox)comboboxElement).Name.StartsWith("ClickEventTypeComboBox"))
                                            {
                                                typeComboBox = (ComboBox)comboboxElement;
                                            }
                                        }
                                    }
                                }
                            }
                            else if (((DockPanel)element).Name.StartsWith("ClickBottomDockPanel"))
                            {
                                if (index == Int32.Parse(((DockPanel)element).Name.Substring(20)))
                                {
                                    bottomPanel = (DockPanel)element;
                                    foreach (UIElement comboboxElement in bottomPanel.Children)
                                    {
                                        if (comboboxElement as ComboBox != null)
                                        {
                                            if (((ComboBox)comboboxElement).Name.StartsWith("ClickEventPropertyComboBox"))
                                            {
                                                propertyComboBox = (ComboBox)comboboxElement;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (typeComboBox.SelectedIndex == 5)
                    {
                        clickEvent thisEvent = null;
                        foreach (clickEvent ce in selectedGUIO.clickEvents)
                        {
                            if (index == Int32.Parse(ce.number))
                            {
                                thisEvent = ce;
                            }
                        }
                        if (thisEvent == null)
                        {
                            thisEvent = new clickEvent();
                            thisEvent.number = "" + index;
                            selectedGUIO.clickEvents.Add(thisEvent);
                        }
                        thisEvent.type = ((ComboBoxItem)typeComboBox.SelectedItem).Content.ToString();
                        thisEvent.gName = ((ComboBoxItem)thisComboBox.SelectedItem).Content.ToString();
                        thisEvent.GUIOType = null;
                        thisEvent.property = null;
                        thisEvent.value = null;
                    }
                    else
                    {
                        string itemValue = ((ComboBoxItem)thisComboBox.SelectedItem).Content.ToString();
                        string type = "";
                        foreach (GUIO guio in selectedPane.GUIOList)
                        {
                            if (guio.name.Equals(itemValue))
                            {
                                type = guio.type;
                            }
                        }
                        propertyComboBox.Items.Clear();

                        ComboBoxItem comboBoxItem;
                        comboBoxItem = new ComboBoxItem();
                        comboBoxItem.Content = "Property";
                        propertyComboBox.Items.Add(comboBoxItem);
                        comboBoxItem = new ComboBoxItem();
                        comboBoxItem.Content = "x";
                        propertyComboBox.Items.Add(comboBoxItem);
                        comboBoxItem = new ComboBoxItem();
                        comboBoxItem.Content = "y";
                        propertyComboBox.Items.Add(comboBoxItem);
                        comboBoxItem = new ComboBoxItem();
                        comboBoxItem.Content = "width";
                        propertyComboBox.Items.Add(comboBoxItem);
                        comboBoxItem = new ComboBoxItem();
                        comboBoxItem.Content = "height";
                        propertyComboBox.Items.Add(comboBoxItem);

                        switch (type)
                        {
                            case "IpCamera":
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "address";
                                propertyComboBox.Items.Add(comboBoxItem);
                                break;
                            case "Circle":
                            case "Rectangle":
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fillColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "lineColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "lineThickness";
                                propertyComboBox.Items.Add(comboBoxItem);

                                break;
                            case "PushButton":
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "text";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "buttonColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "thickness";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "borderColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontSize";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontBold";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontUnderline";
                                propertyComboBox.Items.Add(comboBoxItem);
                                break;
                            case "Dial":
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "max";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "min";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "major";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "minor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "needleColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "dialColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontColor";
                                propertyComboBox.Items.Add(comboBoxItem);

                                break;
                            case "ProgressBar":
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "max";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "min";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "major";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "minor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "orientation";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "progressColor";
                                propertyComboBox.Items.Add(comboBoxItem);

                                break;
                            case "SliderBar":
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "max";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "min";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "major";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "minor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "orientation";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "sliderColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "handleColor";
                                propertyComboBox.Items.Add(comboBoxItem);

                                break;
                            case "NumPad":
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "numColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "numButtonColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "resetColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "resetButtonColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "okColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "okButtonColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "borderColor";
                                propertyComboBox.Items.Add(comboBoxItem);

                                break;
                            case "LoginPad":
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "password";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "numColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "numButtonColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "resetColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "resetButtonColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "loginColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "loginButtonColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "funcColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "funcButtonColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "borderColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "digitNumber";
                                propertyComboBox.Items.Add(comboBoxItem);

                                break;
                            case "Label":

                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "labelColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "text";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "borderColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "thickness";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontSize";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontBold";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontUnderline";
                                propertyComboBox.Items.Add(comboBoxItem);
                                break;
                            case "DigitalClock":
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "clockColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "borderColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontSize";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontColor";
                                propertyComboBox.Items.Add(comboBoxItem);
                                comboBoxItem = new ComboBoxItem();
                                comboBoxItem.Content = "fontBold";
                                propertyComboBox.Items.Add(comboBoxItem);

                                break;

                            default:
                                break;

                        }
                        propertyComboBox.SelectedIndex = 0;
                    }
                }
            }
        }

        private void ClickEventTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox thisComboBox = (ComboBox)sender;
            int index = Int32.Parse(thisComboBox.Name.Substring(22));
            ComboBox gNameComboBox = null;
            ComboBox propertyComboBox = null;
            TextBox valueTextBox = null;
            DockPanel bottomPanel = null;

            foreach (UIElement element in ClickEventStackPanel.Children)
            {
                if (element as DockPanel != null)
                {
                    if (((DockPanel)element).Name.StartsWith("ClickAboveDockPanel"))
                    {
                        if (index == Int32.Parse(((DockPanel)element).Name.Substring(19)))
                        {
                            foreach (UIElement comboboxElement in ((DockPanel)element).Children)
                            {
                                if (comboboxElement as ComboBox != null)
                                {
                                    if (((ComboBox)comboboxElement).Name.StartsWith("ClickEventGNameComboBox"))
                                    {
                                        gNameComboBox = (ComboBox)comboboxElement;
                                    }
                                }
                            }
                        }
                    }
                    else if (((DockPanel)element).Name.StartsWith("ClickBottomDockPanel"))
                    {
                        if (index == Int32.Parse(((DockPanel)element).Name.Substring(20)))
                        {
                            bottomPanel = (DockPanel)element;
                            foreach (UIElement comboboxElement in bottomPanel.Children)
                            {
                                if (comboboxElement as ComboBox != null)
                                {
                                    if (((ComboBox)comboboxElement).Name.StartsWith("ClickEventPropertyComboBox"))
                                    {
                                        propertyComboBox = (ComboBox)comboboxElement;
                                    }
                                }
                                else if (comboboxElement as TextBox != null)
                                {
                                    valueTextBox = (TextBox)comboboxElement;
                                }
                            }
                        }
                    }
                }
            }


            if ((thisComboBox.SelectedIndex > 0 && thisComboBox.SelectedIndex < 4))
            {
                propertyComboBox.Visibility = Visibility.Hidden;
                bottomPanel.Visibility = Visibility.Visible;
                gNameComboBox.Visibility = Visibility.Visible;
                valueTextBox.Visibility = Visibility.Visible;

                gNameComboBox.Items.Clear();
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = "G-Variable Name";
                gNameComboBox.Items.Add(comboBoxItem);
                // 저장된 G-Variable Name을 출력하는 부분 필요
                foreach (GVariable gvar in GViewDlg.SList)
                {
                    comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = gvar.name;
                    gNameComboBox.Items.Add(comboBoxItem);
                }
                foreach (GVariable gvar in GViewDlg.MList)
                {
                    comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = gvar.name;
                    gNameComboBox.Items.Add(comboBoxItem);
                }
                foreach (GVariable gvar in GViewDlg.NEList)
                {
                    comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = gvar.name;
                    gNameComboBox.Items.Add(comboBoxItem);
                }
                gNameComboBox.SelectedIndex = 0;

            }
            else if (thisComboBox.SelectedIndex == 4)
            {
                propertyComboBox.Visibility = Visibility.Visible;
                bottomPanel.Visibility = Visibility.Visible;
                gNameComboBox.Visibility = Visibility.Visible;
                valueTextBox.Visibility = Visibility.Visible;

                gNameComboBox.Items.Clear();
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = "GUIO Name";
                gNameComboBox.Items.Add(comboBoxItem);
                foreach (GUIO guio in selectedPane.GUIOList)
                {
                    comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = guio.name;
                    gNameComboBox.Items.Add(comboBoxItem);
                }


                gNameComboBox.SelectedIndex = 0;
            }
            else if (thisComboBox.SelectedIndex == 5)
            {
                propertyComboBox.Visibility = Visibility.Hidden;
                bottomPanel.Visibility = Visibility.Hidden;
                gNameComboBox.Visibility = Visibility.Visible;
                valueTextBox.Visibility = Visibility.Hidden;

                gNameComboBox.Items.Clear();
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = "Page Name";
                gNameComboBox.Items.Add(comboBoxItem);
                foreach (HMIEditorPane pane in HMIEditorFactory.hmIEditorPaneList)
                {
                    comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = pane.thisPage.name;
                    gNameComboBox.Items.Add(comboBoxItem);
                }
                gNameComboBox.SelectedIndex = 0;
            }
        }
        */

        private void GUIOPropertyTextTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.text = GUIOPropertyTextTextBox.Text;
                if (selectedObjectType == ObjectType.GPushButton)
                {
                    selectedHMIForm.EditPushButtonText = selectedGUIO.text;
                }
                else
                if (selectedObjectType == ObjectType.GLabel)
                {
                    selectedHMIForm.EditLabelText = selectedGUIO.text.Replace("\\n", "\n");
                }
                else
                if (selectedObjectType == ObjectType.GScrollLabel)
                {
                    selectedHMIForm.EditScrollLabelText = selectedGUIO.text;
                }
                else
                if(selectedObjectType == ObjectType.GRadioBUtton)
                {
                    selectedHMIForm.EditRadioButtonText = selectedGUIO.text;
                }

        }

        private void GUIOPropertyButtonColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    if (selectedObjectType == ObjectType.GPushButton)
                    {
                        int rgb = Int32.Parse(selectedGUIO.buttonColor, System.Globalization.NumberStyles.HexNumber);
                        selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                        selectedGUIO.buttonColor = GUIOPropertyButtonColorTextBox.Text;
                        selectedHMIForm.EditPushButtonColor = rgb;
                    }
                    else
                    if (selectedObjectType == ObjectType.GRadioBUtton)
                    {
                        int rgb = Int32.Parse(selectedGUIO.buttonColor, System.Globalization.NumberStyles.HexNumber);
                        selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                        selectedGUIO.buttonColor = GUIOPropertyButtonColorTextBox.Text;
                        selectedHMIForm.EditRadioButtonColor = rgb;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 숫자 값만 가능합니다.");
                }

        }

        private void GUIOPropertyButtonColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.buttonColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyButtonColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                try
                {
                    if (selectedObjectType == ObjectType.GPushButton)
                    {
                        selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                        selectedGUIO.buttonColor = GUIOPropertyButtonColorTextBox.Text;
                        selectedHMIForm.EditPushButtonColor = rgb;
                    }
                    else
                    if (selectedObjectType == ObjectType.GRadioBUtton)
                    {
                        selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                        selectedGUIO.buttonColor = GUIOPropertyButtonColorTextBox.Text;
                        selectedHMIForm.EditRadioButtonColor = rgb;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 숫자 값만 가능합니다.");
                }
            }
        }

        private void GUIOPropertyThicknessTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int thickness = Int32.Parse(GUIOPropertyThicknessTextBox.Text);
                    
                    selectedGUIO.thickness = GUIOPropertyThicknessTextBox.Text;
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    if (selectedObjectType == ObjectType.GPushButton)
                    {
                        selectedHMIForm.EditPushButtonThickness = thickness;
                    }
                    if (selectedObjectType == ObjectType.GLabel)
                    {
                        selectedHMIForm.EditLabelThickness = thickness;
                    }
                    if (selectedObjectType == ObjectType.GScrollLabel)
                    {
                        selectedHMIForm.EditScrollLabelThickness = thickness;
                    }
                    if (selectedObjectType == ObjectType.GRadioBUtton)
                    {
                        selectedHMIForm.EditRadioButtonThickness = thickness;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("테두리 두께 값은 양의 정수 값만 가질 수 있습니다.");
                }

        }

        private void GUIOPropertyBorderColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.borderColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyBorderColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedGUIO.borderColor = GUIOPropertyBorderColorTextBox.Text;

                if (selectedObjectType == ObjectType.GPushButton)
                {
                    selectedHMIForm.EditPushButtonBorderColor = rgb;
                }
                if (selectedObjectType == ObjectType.GLabel)
                {
                    selectedHMIForm.EditLabelBorderColor = rgb;
                }
                if (selectedObjectType == ObjectType.GScrollLabel)
                {
                    selectedHMIForm.EditScrollLabelBorderColor = rgb;
                }
                if (selectedObjectType == ObjectType.GDigitalClock)
                {
                    selectedHMIForm.EditDigitalClockBorderColor = rgb;
                }
                if (selectedObjectType == ObjectType.GLoginpad)
                {
                    selectedHMIForm.EditLoginPadBorderColor = rgb;
                }
                if (selectedObjectType == ObjectType.GNumpad)
                {
                    selectedHMIForm.EditNumPadBorderColor = rgb;
                }
                if (selectedObjectType == ObjectType.GRadioBUtton)
                {
                    selectedHMIForm.EditRadioButtonBorderColor = rgb;
                }
            }
        }

        private void GUIOPropertyBorderColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyBorderColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.borderColor = GUIOPropertyBorderColorTextBox.Text;
                    if (selectedObjectType == ObjectType.GPushButton)
                    {
                        selectedHMIForm.EditPushButtonBorderColor = rgb;
                    }
                    if (selectedObjectType == ObjectType.GLabel)
                    {
                        selectedHMIForm.EditLabelBorderColor = rgb;
                    }
                    if (selectedObjectType == ObjectType.GScrollLabel)
                    {
                        selectedHMIForm.EditScrollLabelBorderColor = rgb;
                    }
                    if (selectedObjectType == ObjectType.GDigitalClock)
                    {
                        selectedHMIForm.EditDigitalClockBorderColor = rgb;
                    }
                    if (selectedObjectType == ObjectType.GLoginpad)
                    {
                        selectedHMIForm.EditLoginPadBorderColor = rgb;
                    }
                    if (selectedObjectType == ObjectType.GNumpad)
                    {
                        selectedHMIForm.EditNumPadBorderColor = rgb;
                    }
                    if (selectedObjectType == ObjectType.GRadioBUtton)
                    {
                        selectedHMIForm.EditRadioButtonBorderColor = rgb;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수값만 가능합니다.");
                }

        }

        private void GUIOPropertyMaxTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int max = Int32.Parse(GUIOPropertyMaxTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.max = GUIOPropertyMaxTextBox.Text;
                    if (selectedObjectType == ObjectType.GDial)
                    {
                        selectedHMIForm.EditDialMax = max;
                    }
                    else if (selectedObjectType == ObjectType.GProgressBar)
                    {
                        selectedHMIForm.EditProgressBarMax = max;
                    }
                    else if (selectedObjectType == ObjectType.GSliderBar)
                    {
                        selectedHMIForm.EditSliderBarMax = max;
                    }
                    else if (selectedObjectType == ObjectType.GPanel)
                    {
                        selectedHMIForm.EditPanelMax = max;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Max 값은 정수 값만 가능합니다.");
                }

        }

        private void GUIOPropertyMinTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int min = Int32.Parse(GUIOPropertyMinTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.min = GUIOPropertyMinTextBox.Text;
                    if (selectedObjectType == ObjectType.GDial)
                    {
                        selectedHMIForm.EditDialMin = min;
                    }
                    else if (selectedObjectType == ObjectType.GProgressBar)
                    {
                        selectedHMIForm.EditProgressBarMin = min;
                    }
                    else if (selectedObjectType == ObjectType.GSliderBar)
                    {
                        selectedHMIForm.EditSliderBarMin = min;
                    }
                    else if (selectedObjectType == ObjectType.GPanel)
                    {
                        selectedHMIForm.EditPanelMin = min;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Min 값은 정수 값만 가능합니다.");
                }

        }

        private void GUIOPropertyMajorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int major = Int32.Parse(GUIOPropertyMajorTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.major = GUIOPropertyMajorTextBox.Text;
                    if (selectedObjectType == ObjectType.GDial)
                    {
                        selectedHMIForm.EditDialMajor = major;
                    }
                    else if (selectedObjectType == ObjectType.GProgressBar)
                    {
                        selectedHMIForm.EditProgressBarMajor = major;
                    }
                    else if (selectedObjectType == ObjectType.GSliderBar)
                    {
                        selectedHMIForm.EditSliderBarMajor = major;
                    }
                    else if (selectedObjectType == ObjectType.GPanel)
                    {
                        selectedHMIForm.EditPanelMajor = major;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Major 값은 정수 값만 가능합니다.");
                }

        }

        private void GUIOPropertyMinorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int minor = Int32.Parse(GUIOPropertyMinorTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.minor = GUIOPropertyMinorTextBox.Text;
                    if (selectedObjectType == ObjectType.GDial)
                    {
                        selectedHMIForm.EditDialMinor = minor;
                    }
                    else if (selectedObjectType == ObjectType.GProgressBar)
                    {
                        selectedHMIForm.EditProgressBarMinor = minor;
                    }
                    else if (selectedObjectType == ObjectType.GSliderBar)
                    {
                        selectedHMIForm.EditSliderBarMinor = minor;
                    }
                    else if (selectedObjectType == ObjectType.GPanel)
                    {
                        selectedHMIForm.EditPanelMinor = minor;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Max 값은 정수 값만 가능합니다.");
                }

        }

        private void GUIOPropertyNeedleColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int needleColor = Int32.Parse(GUIOPropertyNeedleColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedGUIO.needleColor = GUIOPropertyNeedleColorTextBox.Text;
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    if (selectedObjectType == ObjectType.GDial)
                    {
                        selectedHMIForm.EditDialNeedleColor = needleColor;
                    }
                    else if (selectedObjectType == ObjectType.GPanel)
                    {
                        selectedHMIForm.EditPanelNeedleColor = needleColor;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyNeedleColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.needleColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyNeedleColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);

                selectedGUIO.needleColor = GUIOPropertyNeedleColorTextBox.Text;
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                if (selectedObjectType == ObjectType.GDial)
                {
                    selectedHMIForm.EditDialNeedleColor = rgb;
                }
                else if (selectedObjectType == ObjectType.GPanel)
                {
                    selectedHMIForm.EditPanelNeedleColor = rgb;
                }
            }
        }

        private void GUIOPropertyDialColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int dailColor = Int32.Parse(GUIOPropertyDialColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedGUIO.dialColor = GUIOPropertyDialColorTextBox.Text;
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    if (selectedObjectType == ObjectType.GDial)
                    {
                        selectedHMIForm.EditDialColor = dailColor;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("생상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyDialColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.dialColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyDialColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);

                selectedGUIO.dialColor = GUIOPropertyDialColorTextBox.Text;
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                if (selectedObjectType == ObjectType.GDial)
                {
                    selectedHMIForm.EditDialColor = rgb;
                }
            }
        }

        private void GUIOPropertyFontColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int fontColor = Int32.Parse(GUIOPropertyFontColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedGUIO.fontColor = GUIOPropertyFontColorTextBox.Text;
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    if (selectedObjectType == ObjectType.GPushButton)
                    {
                        selectedHMIForm.EditPushButtonFontColor = fontColor;
                    }
                    else
                    if (selectedObjectType == ObjectType.GDial)
                    {
                        selectedHMIForm.EditDialFontColor = fontColor;
                    }
                    else
                    if (selectedObjectType == ObjectType.GLabel)
                    {
                        selectedHMIForm.EditLabelFontColor = fontColor;
                    }
                    else
                    if (selectedObjectType == ObjectType.GScrollLabel)
                    {
                        selectedHMIForm.EditScrollLabelFontColor = fontColor;
                    }
                    else
                    if (selectedObjectType == ObjectType.GDigitalClock)
                    {
                        selectedHMIForm.EditDigitalClockFontColor = fontColor;
                    }
                    else
                    if (selectedObjectType == ObjectType.GRadioBUtton)
                    {
                        selectedHMIForm.EditRadioButtonFontColor = fontColor;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 숫자값만 가능합니다.");
                }

        }

        private void GUIOPropertyFontColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.fontColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int fontColor = colorDialog.Color.ToArgb();
                GUIOPropertyFontColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);

                selectedGUIO.fontColor = GUIOPropertyFontColorTextBox.Text;
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                if (selectedObjectType == ObjectType.GPushButton)
                {
                    selectedHMIForm.EditPushButtonFontColor = fontColor;
                }
                else
                if (selectedObjectType == ObjectType.GDial)
                {
                    selectedHMIForm.EditDialFontColor = fontColor;
                }
                else
                if (selectedObjectType == ObjectType.GLabel)
                {
                    selectedHMIForm.EditLabelFontColor = fontColor;
                }
                else
                if (selectedObjectType == ObjectType.GScrollLabel)
                {
                    selectedHMIForm.EditScrollLabelFontColor = fontColor;
                }
                else
                if (selectedObjectType == ObjectType.GDigitalClock)
                {
                    selectedHMIForm.EditDigitalClockFontColor = fontColor;
                }
                else
                if (selectedObjectType == ObjectType.GRadioBUtton)
                {
                    selectedHMIForm.EditRadioButtonFontColor = fontColor;
                }
            }
        }

        private void GUIOPropertyFontSizeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int fontSize = Int32.Parse(GUIOPropertyFontSizeTextBox.Text);
                    selectedGUIO.fontSize = GUIOPropertyFontSizeTextBox.Text;
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    if (selectedObjectType == ObjectType.GPushButton)
                    {
                        selectedHMIForm.EditPushButtonFontSize = fontSize;
                    }
                    if (selectedObjectType == ObjectType.GLabel)
                    {
                        selectedHMIForm.EditLabelFontSize = fontSize;
                    }
                    if (selectedObjectType == ObjectType.GScrollLabel)
                    {
                        selectedHMIForm.EditScrollLabelFontSize = fontSize;
                    }
                    if (selectedObjectType == ObjectType.GDigitalClock)
                    {
                        selectedHMIForm.EditDigitalClockFontSize = fontSize;
                    }
                    if (selectedObjectType == ObjectType.GRadioBUtton)
                    {
                        selectedHMIForm.EditRadioButtonFontSize = fontSize;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Font 크기는 정수값만 가능합니다.");
                }

        }

        private void GUIOPropertyFontBoldComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedHMIForm.selectedGUIOName = selectedGUIO.name;
            if (selectedObjectType == ObjectType.GPushButton)
            {
                if (((ComboBox)sender).SelectedIndex == 1)
                {
                    selectedGUIO.fontBold = "0";
                    selectedHMIForm.EditPushButtonFontBold = false;
                }
                else
                {
                    selectedGUIO.fontBold = "1";
                    selectedHMIForm.EditPushButtonFontBold = true;
                }
            }
            if (selectedObjectType == ObjectType.GLabel)
            {
                if (((ComboBox)sender).SelectedIndex == 1)
                {
                    selectedGUIO.fontBold = "0";
                    selectedHMIForm.EditLabelFontBold = false;
                }
                else
                {
                    selectedGUIO.fontBold = "1";
                    selectedHMIForm.EditLabelFontBold = true;
                }
            }
            if (selectedObjectType == ObjectType.GScrollLabel)
            {
                if (((ComboBox)sender).SelectedIndex == 1)
                {
                    selectedGUIO.fontBold = "0";
                    selectedHMIForm.EditScrollLabelFontBold = false;
                }
                else
                {
                    selectedGUIO.fontBold = "1";
                    selectedHMIForm.EditScrollLabelFontBold = true;
                }
            }
            if (selectedObjectType == ObjectType.GDigitalClock)
            {
                if (((ComboBox)sender).SelectedIndex == 1)
                {
                    selectedGUIO.fontBold = "0";
                    selectedHMIForm.EditDigitalClockFontBold = 0;
                }
                else
                {
                    selectedGUIO.fontBold = "1";
                    selectedHMIForm.EditDigitalClockFontBold = 1;
                }
            }
            if (selectedObjectType == ObjectType.GRadioBUtton)
            {
                if (((ComboBox)sender).SelectedIndex == 1)
                {
                    selectedGUIO.fontBold = "0";
                    selectedHMIForm.EditRadioButtonFontBold = false;
                }
                else
                {
                    selectedGUIO.fontBold = "1";
                    selectedHMIForm.EditRadioButtonFontBold = true;
                }
            }
        }

        private void GUIOPropertyAlignmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    selectedGUIO.alignment = "0";
                    selectedHMIForm.EditLabelAlignment = 0;
                }
                else if (((ComboBox)sender).SelectedIndex == 1)
                {
                    selectedGUIO.alignment = "1";
                    selectedHMIForm.EditLabelAlignment = 1;
                }
                else
                {
                    selectedGUIO.alignment = "2";
                    selectedHMIForm.EditLabelAlignment = 2;
                }
        }


        private void GUIOPropertyScrollFlagComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedObjectType == ObjectType.GScrollLabel)
            {
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    selectedGUIO.scrollFlag = "0";
                    selectedHMIForm.EditScrollLabelScrollFlag = 0;
                }
                else if (((ComboBox)sender).SelectedIndex == 1)
                {
                    selectedGUIO.scrollFlag = "1";
                    selectedHMIForm.EditScrollLabelScrollFlag = 1;
                }
                else
                {
                    selectedGUIO.scrollFlag = "2";
                    selectedHMIForm.EditScrollLabelScrollFlag = 2;
                }
            }
        }

        private void GUIOPropertyFontUnderlineComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedHMIForm.selectedGUIOName = selectedGUIO.name;
            if (selectedObjectType == ObjectType.GPushButton)
            {
                if (((ComboBox)sender).SelectedIndex == 1)
                {
                    selectedGUIO.fontUnderline = "0";
                    selectedHMIForm.EditPushButtonFontUnderline = false;
                }
                else
                {
                    selectedGUIO.fontBold = "1";
                    selectedHMIForm.EditPushButtonFontUnderline = true;
                }
            }
            else if(selectedObjectType == ObjectType.GLabel)
            {
                if (((ComboBox)sender).SelectedIndex == 1)
                {
                    selectedGUIO.fontUnderline = "0";
                    selectedHMIForm.EditLabelFontUnderline = false;
                }
                else
                {
                    selectedGUIO.fontBold = "1";
                    selectedHMIForm.EditLabelFontUnderline = true;
                }
            }
            else if (selectedObjectType == ObjectType.GScrollLabel)
            {
                if (((ComboBox)sender).SelectedIndex == 1)
                {
                    selectedGUIO.fontUnderline = "0";
                    selectedHMIForm.EditScrollLabelFontUnderline = false;
                }
                else
                {
                    selectedGUIO.fontBold = "1";
                    selectedHMIForm.EditScrollLabelFontUnderline = true;
                }
            }
            else if (selectedObjectType == ObjectType.GRadioBUtton)
            {
                if (((ComboBox)sender).SelectedIndex == 1)
                {
                    selectedGUIO.fontUnderline = "1";
                    selectedHMIForm.EditRadioButtonFontUnderline = true;
                }
                else
                {
                    selectedGUIO.fontBold = "0";
                    selectedHMIForm.EditRadioButtonFontUnderline = false;
                }
            }
        }

        private void GUIOPropertyProgressColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyProgressColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.progressColor = GUIOPropertyProgressColorTextBox.Text;
                    selectedHMIForm.EditProgressBarColor = rgb;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyProgressColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.progressColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyProgressColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.progressColor = GUIOPropertyProgressColorTextBox.Text;
                selectedHMIForm.EditProgressBarColor = rgb;
            }
        }

        private void GUIOPropertyOrientationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedHMIForm.selectedGUIOName = selectedGUIO.name;
            if (((ComboBox)sender).SelectedIndex == 0)
            {
                selectedGUIO.orientation = "1";
                selectedHMIForm.EditProgressBarOrient = 1;
                selectedHMIForm.EditSliderBarOrient = 1;
            }
            else
            {
                selectedGUIO.orientation = "2";
                selectedHMIForm.EditProgressBarOrient = 2;
                selectedHMIForm.EditSliderBarOrient = 2;
            }
        }

        private void GUIOPropertySliderColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertySliderColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.sliderColor = GUIOPropertySliderColorTextBox.Text;
                    selectedHMIForm.EditSliderBarColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertySliderColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.sliderColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertySliderColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);

                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.sliderColor = GUIOPropertySliderColorTextBox.Text;
                selectedHMIForm.EditSliderBarColor = rgb;
            }
        }

        private void GUIOPropertyHandleColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyHandleColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.handleColor = GUIOPropertyHandleColorTextBox.Text;
                    selectedHMIForm.EditSliderBarHandleColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyHandleColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.handleColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyHandleColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);

                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.handleColor = GUIOPropertyHandleColorTextBox.Text;
                selectedHMIForm.EditSliderBarHandleColor = rgb;
            }
        }

        private void GUIOPropertyLabelColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyLabelColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.labelColor = GUIOPropertyLabelColorTextBox.Text;
                    selectedHMIForm.EditLabelColor = rgb;
                    selectedHMIForm.EditScrollLabelColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyLabelColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.labelColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyLabelColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);

                try
                {
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.labelColor = GUIOPropertyLabelColorTextBox.Text;
                    selectedHMIForm.EditLabelColor = rgb;
                    selectedHMIForm.EditScrollLabelColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
            }
        }

        private void GUIOPropertyClockColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.clockColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyClockColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);

                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.clockColor = GUIOPropertyClockColorTextBox.Text;
                selectedHMIForm.EditDigitalClockColor = rgb;
            }
        }

        private void GUIOPropertyClockColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyClockColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.clockColor = GUIOPropertyClockColorTextBox.Text;
                    selectedHMIForm.EditDigitalClockColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyIPAddressTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                if (selectedObjectType == ObjectType.IpCamera)
                {
                    selectedGUIO.ipAddress = GUIOPropertyIPAddressTextBox.Text;
                }
        }

        private void GUIOPropertyPortTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                if (selectedObjectType == ObjectType.IpCamera)
                {
                    selectedGUIO.port = GUIOPropertyPortTextBox.Text;
                }
        }

        private void GUIOPropertyPasswordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                if (selectedObjectType == ObjectType.GLoginpad)
                {
                    selectedGUIO.password = GUIOPropertyPasswordTextBox.Text;
                }
        }

        private void GUIOPropertyNumColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyNumColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.numColor = GUIOPropertyNumColorTextBox.Text;
                    selectedHMIForm.EditLoginPadNumberFontColor = rgb;
                    selectedHMIForm.EditNumPadNumberFontColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyNumColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.numColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyNumColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);

                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.numColor = GUIOPropertyNumColorTextBox.Text;
                selectedHMIForm.EditLoginPadNumberFontColor = rgb;
                selectedHMIForm.EditNumPadNumberFontColor = rgb;
            }
        }

        private void GUIOPropertyNumButtonColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyNumButtonColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.numButtonColor = GUIOPropertyNumButtonColorTextBox.Text;
                    selectedHMIForm.EditLoginPadNumberButtonColor = rgb;
                    selectedHMIForm.EditNumPadNumberButtonColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyNumButtonColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.numButtonColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyNumButtonColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.numButtonColor = GUIOPropertyNumButtonColorTextBox.Text;
                selectedHMIForm.EditLoginPadNumberButtonColor = rgb;
                selectedHMIForm.EditNumPadNumberButtonColor = rgb;
            }
        }

        private void GUIOPropertyResetColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyResetColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.resetColor = GUIOPropertyResetColorTextBox.Text;
                    selectedHMIForm.EditLoginPadResetFontColor = rgb;
                    selectedHMIForm.EditNumPadResetFontColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyResetColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.resetColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyResetColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.resetColor = GUIOPropertyResetColorTextBox.Text;
                selectedHMIForm.EditLoginPadResetFontColor = rgb;
                selectedHMIForm.EditNumPadResetFontColor = rgb;
            }
        }

        private void GUIOPropertyResetButtonColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyResetButtonColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.resetButtonColor = GUIOPropertyResetButtonColorTextBox.Text;
                    selectedHMIForm.EditLoginPadResetButtonColor = rgb;
                    selectedHMIForm.EditNumPadResetButtonColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }

        }

        private void GUIOPropertyResetButtonColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.resetButtonColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyResetButtonColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.resetButtonColor = GUIOPropertyResetButtonColorTextBox.Text;
                selectedHMIForm.EditLoginPadResetButtonColor = rgb;
                selectedHMIForm.EditNumPadResetButtonColor = rgb;
            }
        }

        private void GUIOPropertyLoginColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyLoginColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.loginColor = GUIOPropertyLoginColorTextBox.Text;
                    selectedHMIForm.EditLoginPadLoginFontColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }

        }

        private void GUIOPropertyLoginColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.loginColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyLoginColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.loginColor = GUIOPropertyLoginColorTextBox.Text;
                selectedHMIForm.EditLoginPadLoginFontColor = rgb;
            }
        }

        private void GUIOPropertyLoginButtonColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyLoginButtonColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.loginButtonColor = GUIOPropertyLoginButtonColorTextBox.Text;
                    selectedHMIForm.EditLoginPadLoginButtonColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyLoginButtonColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.loginButtonColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyLoginButtonColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.loginButtonColor = GUIOPropertyLoginButtonColorTextBox.Text;
                selectedHMIForm.EditLoginPadLoginButtonColor = rgb;
            }
        }

        private void GUIOPropertyFuncColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyFuncColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.funcColor = GUIOPropertyFuncColorTextBox.Text;
                    selectedHMIForm.EditLoginPadFuncFontColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }

        }

        private void GUIOPropertyFuncColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.funcColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyFuncColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.funcColor = GUIOPropertyFuncColorTextBox.Text;
                selectedHMIForm.EditLoginPadFuncFontColor = rgb;
            }
        }

        private void GUIOPropertyFuncButtonColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

                try
                {
                    int rgb = Int32.Parse(GUIOPropertyFuncButtonColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.funcButtonColor = GUIOPropertyFuncButtonColorTextBox.Text;
                    selectedHMIForm.EditLoginPadFuncButtonColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyFuncButtonColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.funcButtonColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyFuncButtonColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.funcButtonColor = GUIOPropertyFuncButtonColorTextBox.Text;
                selectedHMIForm.EditLoginPadFuncButtonColor = rgb;
            }
        }

        private void GUIOPropertyDigitNumberTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int digitNumber = Int32.Parse(GUIOPropertyDigitNumberTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.digitNumber = GUIOPropertyDigitNumberTextBox.Text;
                    selectedHMIForm.EditLoginPadDigitNumber = digitNumber;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("양의 정수 값만 입력해주세요.");
                }
        }

        private void GUIOPropertyOkColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyOkColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.okColor = GUIOPropertyOkColorTextBox.Text;
                    selectedHMIForm.EditNumPadOkFontColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyOkColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.okColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyOkColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.okColor = GUIOPropertyOkColorTextBox.Text;
                selectedHMIForm.EditNumPadOkFontColor = rgb;
            }
        }

        private void GUIOPropertyOkButtonColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int rgb = Int32.Parse(GUIOPropertyOkButtonColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.okButtonColor = GUIOPropertyOkButtonColorTextBox.Text;
                    selectedHMIForm.EditNumPadOkButtonColor = rgb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수만 가능합니다.");
                }
        }

        private void GUIOPropertyOkButtonColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.okButtonColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyOkButtonColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.okButtonColor = GUIOPropertyOkButtonColorTextBox.Text;
                selectedHMIForm.EditNumPadOkButtonColor = rgb;
            }
        }

        private void GUIOPropertyTempGVarTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                selectedGUIO.tempGVariable = GUIOPropertyTempGVarTextBox.Text;
        }

        private void GUIOPropertyPageNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                selectedGUIO.pageName = GUIOPropertyPageNameTextBox.Text;
                selectedHMIForm.EditPageName = selectedGUIO.pageName;
        }

        private void PagePropertyBackgroundImage_LostFocus(object sender, RoutedEventArgs e)
        {
                selectedPage.backgroundImage = PagePropertyBackgroundImage.Text;
                try
                {
                    bool hasw = false;
                    string path = HMIProjectNode.currentProjectDirectory + @"\" + PagePropertyBackgroundImage.Text;
                    System.Diagnostics.Trace.WriteLine(path);
                    path = path.Replace(@"\", "/");
                    System.Drawing.Image image = System.Drawing.Image.FromFile(path);
                    Bitmap bitmap = new Bitmap(path);
                    selectedHMIForm.EditPageBackgroundImageName = path;

                    //selectedPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    //selectedPanel.BackgroundImage = bitmap;
                }
                catch
                {
                    MessageBox.Show("정확한 이미지 파일 이름을 입력해주세요.");
                }
        }

        private void GUIOPropertyGroupIDTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int groupID = Int32.Parse(GUIOPropertyGroupIDTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.groupID = GUIOPropertyGroupIDTextBox.Text;
                    selectedHMIForm.EditRadioButtonID = groupID;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Group ID 값은 정수값만 가능합니다.");
                }
        }

        private void GUIOPropertyDigitColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int digitColor = Int32.Parse(GUIOPropertyDigitColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.digitColor = GUIOPropertyDigitColorTextBox.Text;
                    selectedHMIForm.EditPanelDigitColor = digitColor;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수값만 가능합니다.");
                }
        }

        private void GUIOPropertyDigitColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.digitColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyDigitColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);

                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.digitColor = GUIOPropertyDigitColorTextBox.Text;
                selectedHMIForm.EditPanelDigitColor = rgb;
            }
        }

        private void GUIOPropertyBodyColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int bodyColor = Int32.Parse(GUIOPropertyBodyColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.bodyColor = GUIOPropertyBodyColorTextBox.Text;
                    selectedHMIForm.EditPanelBodyColor = bodyColor;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수값만 가능합니다.");
                }
        }

        private void GUIOPropertyBodyColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.bodyColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyBodyColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.bodyColor = GUIOPropertyBodyColorTextBox.Text;
                selectedHMIForm.EditPanelBodyColor = rgb;
            }
        }

        private void GUIOPropertyLEDColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int ledColor = Int32.Parse(GUIOPropertyLEDColorTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.ledColor = GUIOPropertyLEDColorTextBox.Text;
                    selectedHMIForm.EditLedColor = ledColor;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("색상 값은 16진수 정수값만 가능합니다.");
                }
        }

        private void GUIOPropertyLEDColor_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedGUIO.ledColor, System.Globalization.NumberStyles.HexNumber));

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                GUIOPropertyLEDColorTextBox.Text = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);

                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.ledColor = GUIOPropertyLEDColorTextBox.Text;
                selectedHMIForm.EditLedColor = rgb;
            }
        }

        private void GUIOPropertyImageNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                selectedGUIO.imageName = GUIOPropertyImageNameTextBox.Text;
                try
                {
                    string path = HMIProjectNode.currentProjectDirectory + @"\" + GUIOPropertyImageNameTextBox.Text;
                    System.Diagnostics.Trace.WriteLine("Edit\\ Image Name: " + path);
                    System.Drawing.Image image = System.Drawing.Image.FromFile(path);
                    Bitmap bitmap = new Bitmap(image);
                    selectedHMIForm.EditImageName = path;
                    selectedHMIForm.EditRailImageName = path;

                    selectedHMIForm.EditGUIOPropertyHeight = image.Height;
                    selectedHMIForm.EditGUIOPropertyWidth = image.Width;

                    selectedGUIO.size.height = image.Height.ToString();
                    selectedGUIO.size.width = image.Width.ToString();

                    GUIOPropertyHeightTextBox.Text = selectedGUIO.size.height;
                    GUIOPropertyWidthTextBox.Text = selectedGUIO.size.width;
                    //selectedPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    //selectedPanel.BackgroundImage = bitmap;
                }
                catch
                {
                    MessageBox.Show("정확한 이미지 파일 이름을 입력해주세요.");
                }
        }

        private void GUIOPropertyImageStartFrameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int startFrame = Int32.Parse(GUIOPropertyImageStartFrameTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.startFrame = GUIOPropertyImageStartFrameTextBox.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Start Frame 값은 정수 값만 가능합니다.");
                }
        }

        private void GUIOPropertyImageEndFrameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int endFrame = Int32.Parse(GUIOPropertyImageEndFrameTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.endFrame = GUIOPropertyImageEndFrameTextBox.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("End Frame 값은 정수 값만 가능합니다.");
                }
        }

        private void GUIOPropertyImageStateTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int state = Int32.Parse(GUIOPropertyImageStateTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.state = GUIOPropertyImageStateTextBox.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("State 값은 정수 값만 가능합니다.");
                }
        }

        private void GUIOPropertyGrayScaleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedObjectType == ObjectType.GImage || selectedObjectType == ObjectType.GRail)
            {
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    selectedGUIO.grayScale = "1";
                    selectedHMIForm.EditImageGrayScale = true;
                    selectedHMIForm.EditRailGrayScale = true;
                }
                else
                {
                    selectedGUIO.grayScale = "0";
                    selectedHMIForm.EditImageGrayScale = false;
                    selectedHMIForm.EditRailGrayScale = false;
                }
            }
        }

        private void GUIOPropertyURLTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                selectedGUIO.url = GUIOPropertyURLTextBox.Text;
        }

        private void GUIOPropertyAngleTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int angle = Int32.Parse(GUIOPropertyAngleTextBox.Text);
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedGUIO.angle = GUIOPropertyAngleTextBox.Text;
                    selectedHMIForm.EditLabelAngle = angle;
                    selectedHMIForm.EditImageAngle = angle;
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("회전 각도 값은 정수 값만 가능합니다.");
                }
        }

        private void GUIOPropertyClickEventButton_Click(object sender, RoutedEventArgs e)
        {
            HMIClickEventsDialog clickEventDialog = new HMIClickEventsDialog();
            clickEventDialog.Show();
        }

        private void GUIOPropertyVertexButton_Click(object sender, RoutedEventArgs e)
        {
            HMIEditVertexesDialog editVertexesDialog = new HMIEditVertexesDialog();
            editVertexesDialog.Show();
        }

        private void GUIOPropertyTransparentTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    int transparent = Int32.Parse(GUIOPropertyTransparentTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    selectedGUIO.transparent = GUIOPropertyTransparentTextBox.Text;
                    selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                    selectedHMIForm.EditDigitalClockTransparent = transparent;
                    if (transparent == 0)
                    {
                        selectedHMIForm.EditLabelTransparent = false;
                        selectedHMIForm.EditScrollLabelTransparent = false;
                        selectedHMIForm.EditRadioButtonTransparent = false;
                    }
                    else
                    {
                        selectedHMIForm.EditLabelTransparent = true;
                        selectedHMIForm.EditScrollLabelTransparent = true;
                        selectedHMIForm.EditRadioButtonTransparent = true;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("투명도 값은 0과 1만 가능합니다.");
                }
        }

        private void GUIOPropertyDirectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    selectedGUIO.direction = "0";
                    selectedHMIForm.EditScrollLabelDirection = 0;
                }
                else
                {
                    selectedGUIO.direction = "1";
                    selectedHMIForm.EditScrollLabelDirection = 1;
                }
        }

        private void GUIOPropertySpeedTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                if (selectedObjectType == ObjectType.GScrollLabel)
                {
                    selectedGUIO.speed = GUIOPropertySpeedTextBox.Text;
                }
        }

        private void GUIOPropertyEndPointIDTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                if (selectedObjectType == ObjectType.GRail)
                {
                    try
                    {
                        int id = Int32.Parse(GUIOPropertyEndPointIDTextBox.Text);
                        if (id >= 0)
                            selectedGUIO.endPointID = GUIOPropertyEndPointIDTextBox.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("End Point ID 값은 0 이상의 정수 값만 가능합니다.");
                    }
                }
        }

        private void GUIOPropertyStartPointIDTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                if (selectedObjectType == ObjectType.GRail)
                {
                    try
                    {
                        int id = Int32.Parse(GUIOPropertyStartPointIDTextBox.Text);
                        if (id >= 0)
                            selectedGUIO.startPointID = GUIOPropertyStartPointIDTextBox.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Start Point ID 값은 0 이상의 정수 값만 가능합니다.");
                    }
                }
        }

        private void GUIOPropertyDurationTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                if (selectedObjectType == ObjectType.GRail)
                {
                    try
                    {
                        int duration = Int32.Parse(GUIOPropertyDurationTextBox.Text);
                        if (duration >= 0)
                            selectedGUIO.duration = GUIOPropertyDurationTextBox.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Duration 값(ms 단위)은 0이상의 정수 값만 가능합니다.");
                    }
                }
        }

        private void GUIOPropertyFlickeringImageButton_Click(object sender, RoutedEventArgs e)
        {
            HMIEditFlickeringImagesDialog flickeringImageDialog = new HMIEditFlickeringImagesDialog();
            flickeringImageDialog.Show();
        }

        private void GUIOPropertyFlickeringComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedObjectType == ObjectType.GImage)
            {
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    selectedGUIO.flickering = "1";
                }
                else
                {
                    selectedGUIO.flickering = "0";
                }
            }
        }

        private void GUIOPropertyVisibleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedObjectType == ObjectType.GImage || selectedObjectType == ObjectType.GLabel || selectedObjectType == ObjectType.GScrollLabel)
            {
                selectedHMIForm.selectedGUIOName = selectedGUIO.name;
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    selectedGUIO.visible = "1";
                    selectedHMIForm.EditImageVisible = 1;
                    selectedHMIForm.EditLabelVisible = 1;
                    selectedHMIForm.EditScrollLabelVisible = 1;
                }
                else
                {
                    selectedGUIO.visible = "0";
                    selectedHMIForm.EditImageVisible = 0;
                    selectedHMIForm.EditLabelVisible = 0;
                    selectedHMIForm.EditScrollLabelVisible = 0;
                }
            }
        }

        private void GUIOPropertyVisibleDurationTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                if (selectedObjectType == ObjectType.GImage)
                {
                    try
                    {
                        int duration = Int32.Parse(GUIOPropertyVisibleDurationTextBox.Text);
                        if (duration >= 0)
                            selectedGUIO.visibleDuration = GUIOPropertyVisibleDurationTextBox.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Duration 값(ms 단위)은 0이상의 정수 값만 가능합니다.");
                    }
                }
        }

        private void GUIOPropertyInvisibleDurationTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                if (selectedObjectType == ObjectType.GImage)
                {
                    try
                    {
                        int duration = Int32.Parse(GUIOPropertyInvisibleDurationTextBox.Text);
                        if (duration >= 0)
                            selectedGUIO.invisibleDuration = GUIOPropertyInvisibleDurationTextBox.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Duration 값(ms 단위)은 0이상의 정수 값만 가능합니다.");
                    }
                }
        }

        private void PagePropertyBackgroundColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(Int32.Parse(selectedPage.backgroundColor, System.Globalization.NumberStyles.HexNumber));

            if(colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int rgb = colorDialog.Color.ToArgb();
                PagePropertyBackgroundColor.Text  = String.Format("{0:X}", colorDialog.Color.ToArgb()).Substring(2);
                selectedPage.backgroundColor = PagePropertyBackgroundColor.Text;
                selectedHMIForm.EditPageBackgroundColor = rgb;
            }
        }
    }
}