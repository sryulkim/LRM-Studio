/**
 * @file    HMIEditorPane.cs
 * @brief   Editor 화면을 관리하는 class가 있는 파일
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Constants = Microsoft.VisualStudio.OLE.Interop.Constants;
using VSConstants = Microsoft.VisualStudio.VSConstants;
using ErrorHandler = Microsoft.VisualStudio.ErrorHandler;
using IOleDataObject = Microsoft.VisualStudio.OLE.Interop.IDataObject;

namespace HMIProject
{
    /**
     * @brief   에디터 화면 관리 class로 GUIO 생성, 편집 관련 class
     * @author  Sumin Ahn(smahn@emcl.org)
     * @date    2016.7.21
     * @version 1.0.0
     */
    public sealed class HMIEditorPane : WindowPane,
        IOleCommandTarget,
        IVsPersistDocData,
        IPersistFileFormat
    {
        /** 해당 Editor의 파일 포멧 정의 */
        #region Constants
        private const uint fileFormat = 0;
        /** Editor의 파일 확장자 정의 */
        private const string fileExtension = ".page";
        /** Text Editor의 최대 라인 */
        private const char endLine = (char)10;
        #endregion

        #region Fields
        private static OleDataObject toolboxData = null;
        /** Full path to the file */
        public string fileName;
        /** Determines whether an object has changed since being saved to its current file */
        private bool isDirty;
        /** Flag true when we are loading the file. It is used to avoid to change the isDirty flag when the changes are related to the load operation. */
        private bool loading;
        /** Flag ture when we are asking the QueryEditQuerySave service if we can edit the file. it is used to avoid to have more than one request queued */
        private bool gettingCheckoutStatus;
        /** indicate that object is in NoScribble mode or in Normal mode.
         * Object enter into the NoScribble mode when IPersistFileFormat.Save() call is occured
         * This flag using to indicate SaveCompleted state (entering into the Normal mode).
         */
        private bool noScribbleMode;
        /** Object that handles the editor window */
        private HMIEditorForm editorForm;
        #endregion

        #region Constructors
        /**
         * @brief   생성자. EditorPane 인스턴스 객체를 생성하고 초기화한다.
         * @param   serviceProvider Service Provider object, previously initialized by services set
         * @return  Nothing
         */ 
        public HMIEditorPane() : base(null)
        {
            PrivateInit();
        }
        
        public Panel panel;                         ///< 현재 Panel 참조용 객체
        public TransparentPanel transparentPanel;   ///< Panel의 배경이 되는 투명 Panel. GUIO 선택시 테두리 선에 해당하는 overlayControl을 포함
        public OverlayControl overlayControl;       ///< GUIO 선택시 표시되는 테두리 Control.

        public List<GUIO> GUIOList;                 ///< 현재 Panel의 GUIO들을 저장하는 List 객체
        public Page thisPage;                       ///< Panel에 대한 정보를 XML 형식으로 저장하기 위한 Page 객체
        
        /* GUIO 추가시 추가되어야 하는 부분 */
        public static int TNOLabel = 0;             ///< 현재 Panel에 생성된 Label 개수
        public static int TNOButton = 0;            ///< 현재 Panel에 생성된 Button의 개수
        public static int TNODial = 0;              ///< 현재 Panel에 생성된 Dial 개수
        public static int TNOSlder = 0;             ///< 현재 Panel에 생성된 Slider 개수
        public static int TNOWheel = 0;             ///< 현재 Panel에 생성된 Wheel 개수
        public static int TNOKnob = 0;              ///< 현재 Panel에 생성된 Knob 개수
        public static int TNOProgressBar = 0;       ///< 현재 Panel에 생성된 ProgressBar 개수
        public static int TNONumpad = 0;            ///< 현재 Panel에 생성된 Numpad 개수
        public static int TNOLoginpad = 0;          ///< 현재 Panel에 생성된 Loginpad 개수
        public static int TNODigitalClock = 0;      ///< 현재 Panel에 생성된 DigitalClock 개수

        public static int TNOIPCamera = 0;          ///< 현재 Panel에 생성된 IPCamera 개수

        public static int TNOCircle = 0;            ///< 현재 Panel에 생성된 Circle 개수
        public static int TNORectangle = 0;         ///< 현재 Panel에 생성된 Rectangle 개수
        public static int TNOSpeedMeter = 0;        ///< 현재 Panel에 생성된 SpeedMeter 개수

        public static int TNORadioButton = 0;        ///< 현재 Panel에 생성된 RadioButton 개수
        public static int TNOLED = 0;                ///< 현재 Panel에 생성된 LED 개수
        public static int TNOSetResetButton = 0;     ///< 현재 Panel에 생성된 Set/Reset Button 개수
        public static int TNOIncDecButton = 0;       ///< 현재 Panel에 생성된 Inc/Dec Button 개수
        public static int TNOPanel = 0;              ///< 현재 Panel에 생성된 Panel 개수


        public static int TNOImage = 0;              ///< 현재 Panel에 생성된 Image 개수
        public static int TNORail = 0;              ///< 현재 Panel에 생성된 Rail 개수
        public static int TNOScrollLabel = 0;              ///< 현재 Panel에 생성된 ScrollLabel 개수

        public static int TNOWebView = 0;              ///< 현재 Panel에 생성된 Panel 개수

        public static int TNOControls = 0;          ///< 현재 Panel에 생성된 GUIO 개수
        public static int TNOPage = 0;

        public static bool startMove = false;           ///< Panel의 GUIO 선택시 이동 시작을 나타내는 flag 변수
        public static System.Drawing.Point movePoint;   ///< Panel의 이동 시작 위치를 저장하는 Point 객체

        public AxhmiformLib.AxHMIForm hmiForm;
        /**
         * @brief   GUI context objects를 초기화한다.
         * @param   Nothing
         * @return  Nothing
         */
        private void PrivateInit()
        {
            //MessageBox.Show("PrivateInit()");
            noScribbleMode = false;
            loading = false;
            gettingCheckoutStatus = false;

            editorForm = new HMIEditorForm();       ///< Form을 상속받는 HMIEditorForm 객체 생성
            editorForm.AutoScroll = true;
            editorForm.FormBorderStyle = FormBorderStyle.None;
            editorForm.ControlBox = false;
            editorForm.Text = String.Empty;
            

            GUIOList = new List<GUIO>();            ///< GUIO 객체들을 저장할 List 객체 생성

            hmiForm = new AxhmiformLib.AxHMIForm();
            
            panel = new Panel();                                                            ///< 현재 Editor Form에 GUIO control을 담는 Panel 객체 생성
            panel.Location = new System.Drawing.Point(0, 0);                                ///< panel의 시작 위치(좌상) 지정
            panel.Size = new System.Drawing.Size(1024, 768);                                ///< 초기 panel의 크기 설정 1024*768
            editorForm.Size = new System.Drawing.Size(1024, 768);                           ///< 초기 editorForm의 크기 설정 1024*768
            editorForm.Location = new System.Drawing.Point(0, 0);                           ///< 초기 editorForm의 시작 위치(좌상) 지정
            editorForm.BackColor = System.Drawing.Color.FromArgb(0xff, 0xff, 0xff, 0xff);   ///< 초기 editorForm의 배경색상 지정 0xffffffff: white
            panel.BackColor = System.Drawing.Color.FromArgb(0xffffff);                      ///< 초기 panel의 배경색상 지정 0xffffff: white
            panel.TabIndex = 1;                                                             ///< panel 객체의 TabIndex를 1로 설정

            editorForm.AllowDrop = true;                ///< Drop event를 활성화하여 HMIToolWindowControl의 GUIO를 Drag&Drop으로 생성 가능하도록 설정
            editorForm.DragEnter += panel_DragEnter;    ///< DragEnter event - Drag event를 발생시킨 객체가 들어왔을 때의 handler 등록
            editorForm.DragDrop += panel_DragDrop;      ///< DragDrop event - Drag event를 발생시킨 객체가 들어온 후 놓아졌을 때의 handler 등록

            editorForm.Controls.Add(panel);

            transparentPanel = new TransparentPanel();
            transparentPanel.MouseDown += new MouseEventHandler(transparentPanel_MouseDown);
            transparentPanel.MouseMove += new MouseEventHandler(transparentPanel_MouseMove);
            transparentPanel.MouseUp += new MouseEventHandler(transparentPanel_MouseUp);
            transparentPanel.MouseLeave += new EventHandler(transparentPanel_MouseLeave);
            transparentPanel.Location = new System.Drawing.Point(0, 0);
            transparentPanel.Size = new System.Drawing.Size(1024, 768);
            overlayControl = new OverlayControl();
            transparentPanel.Location = new System.Drawing.Point(0, 0);
            transparentPanel.Size = new System.Drawing.Size(1024, 768);

            editorForm.Controls.Add(transparentPanel);
            hmiForm.Location = new System.Drawing.Point(0, 0);
            hmiForm.Size = new System.Drawing.Size(1024, 768);
            panel.Controls.Add(hmiForm);
            panel.SendToBack();
            //editorForm.MouseDown += new MouseEventHandler(panel_MouseDown);
        }

        void transparentPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Trace.WriteLine("Filename: " + this.fileName);
            HMIEditorPropertyToolWindowControl.selectedHMIForm = hmiForm;

            try
            {
                HMIMakeVertexDialog.vtxXTextBox.Text = e.X.ToString();
                HMIMakeVertexDialog.vtxYTextBox.Text = e.Y.ToString();
            }
            catch(System.NullReferenceException ex)
            {
                // If HMIMAkeVertexDialog is not maked
            }
            foreach (GUIO c in GUIOList)
            {
                if (Int32.Parse(c.location.x) <= e.X && Int32.Parse(c.location.x) + Int32.Parse(c.size.width) >= e.X 
                    && Int32.Parse(c.location.y) <= e.Y && Int32.Parse(c.location.y) + Int32.Parse(c.size.height) >= e.Y)
                {
                    HMIEditorPropertyToolWindowControl.selectedGUIO = c;
                    break;
                }
                HMIEditorPropertyToolWindowControl.selectedGUIO = null;
            }
            if (HMIEditorPropertyToolWindowControl.selectedGUIO != null)
            {
                GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
                panel.Controls.Remove(overlayControl);
                overlayControl.Location = new System.Drawing.Point(Int32.Parse(guio.location.x) - 5, Int32.Parse(guio.location.y) - 5);
                overlayControl.Size = new System.Drawing.Size(Int32.Parse(guio.size.width) + 10, Int32.Parse(guio.size.height) + 10);
                panel.Controls.Add(overlayControl);
                hmiForm.SendToBack();
                
                startMove = true;
                movePoint = e.Location;
                try
                {
                    OLECMDF cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
                    cutPrgCmd.cmdf = (uint)cmdf;
                    copyPrgCmd.cmdf = (uint)cmdf;
                    deletePrgCmd.cmdf = (uint)cmdf;
                    switch (guio.type)
                    {
                        case "IpCamera":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.IpCamera;
                            IpCameraMouseDownEvent();
                            break;
                        case "Circle":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.Circle;
                            CircleMouseDownEvent();
                            break;
                        case "Rectangle":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.Rectangle;
                            RectangleMouseDownEvent();
                            break;
                        case "PushButton":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GPushButton;
                            GPushButtonMouseDownEvent();
                            break;
                        case "Dial":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GDial;
                            GDialMouseDownEvent();
                            break;
                        case "ProgressBar":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GProgressBar;
                            GProgressBarMouseDownEvent();
                            break;
                        case "SliderBar":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GSliderBar;
                            GSliderBarMouseDownEvent();
                            break;
                        case "NumPad":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GNumpad;
                            GNumpadMouseDownEvent();
                            break;
                        case "LoginPad":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GLoginpad;
                            GLoginpadMouseDownEvent();
                            break;
                        case "Label":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GLabel;
                            GLabelMouseDownEvent();
                            break;
                        case "DigitalClock":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GDigitalClock;
                            GDigitalClockMouseDownEvent();
                            break;
                        case "RadioButton":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GRadioBUtton;
                            GRadioButtonMouseDownEvent();
                            break;
                        case "LED":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GLed;
                            GLedMouseDownEvent();
                            break;
                        case "Panel":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GPanel;
                            GPanelMouseDownEvent();
                            break;
                        case "SetResetButton":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GSetResetButton;
                            GSetResetButtonMouseDownEvent();
                            break;
                        case "IncDecButton":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GIncDecButton;
                            GIncDecButtonMouseDownEvent();
                            break;
                        case "Image":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GImage;
                            GImageMouseDownEvent();
                            break;
                        case "Rail":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GRail;
                            GRailMouseDownEvent();
                            break;
                        case "WebView":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GWebView;
                            GWebViewMouseDownEvent();
                            break;
                        case "ScrollLabel":
                            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.GScrollLabel;
                            GScrollLabelMouseDownEvent();
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                //MessageBox.Show(e.X + " " + e.Y + " Control: " + control.Name);
            }
            else
            {
                HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.Page;
                OLECMDF cmdf = OLECMDF.OLECMDF_SUPPORTED;
                copyPrgCmd.cmdf = (uint)cmdf;
                cutPrgCmd.cmdf = (uint)cmdf;
                deletePrgCmd.cmdf = (uint)cmdf;
                
                panel_MouseDown(panel);
                panel.Controls.Remove(overlayControl);
            }
        }

        void transparentPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (startMove)
            {
                int movePointX = e.Location.X - movePoint.X;
                int movePointY = e.Location.Y - movePoint.Y;
                int controlX = Int32.Parse(HMIEditorPropertyToolWindowControl.selectedGUIO.location.x) + movePointX;
                int controlY = Int32.Parse(HMIEditorPropertyToolWindowControl.selectedGUIO.location.y) + movePointY;
                hmiForm.EditGUIOPropertyX = controlX;
                hmiForm.EditGUIOPropertyY = controlY;
                overlayControl.Location = new System.Drawing.Point(controlX - 5, controlY - 5);
                overlayControl.Refresh();
                
                HMIEditorPropertyToolWindowControl.selectedGUIO.location.x = ""+controlX;
                HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl.GUIOPropertyXTextBox.Text = HMIEditorPropertyToolWindowControl.selectedGUIO.location.x;
                HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl.FigurePropertyXTextBox.Text = HMIEditorPropertyToolWindowControl.selectedGUIO.location.x;
                HMIEditorPropertyToolWindowControl.selectedGUIO.location.y = ""+controlY;
                HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl.GUIOPropertyYTextBox.Text = HMIEditorPropertyToolWindowControl.selectedGUIO.location.y;
                HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl.FigurePropertyYTextBox.Text = HMIEditorPropertyToolWindowControl.selectedGUIO.location.y;
                movePoint = e.Location;
            }
        }

        void transparentPanel_MouseUp(object sender, MouseEventArgs e)
        {
            startMove = false;
        }

        void transparentPanel_MouseLeave(object sender, EventArgs e)
        {
            startMove = false;
        }

        void panel_MouseDown(object sender)
        {
            try
            {
                HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.Page;
                HMIEditorPane editor = StaticMethods.hmIEditorPaneList.Find(p => p.thisPage.name == ((Panel)sender).Name);
                Page page = editor.thisPage;
                HMIEditorPropertyToolWindowControl.selectedPage = page;
                HMIEditorPropertyToolWindowControl.selectedPanel = panel;
                HMIEditorPropertyToolWindowControl.selectedForm = editorForm;
                HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;
                HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

                control.PageProperty.Visibility = System.Windows.Visibility.Visible;
                control.GUIOProperty.Visibility = System.Windows.Visibility.Collapsed;
                control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;

                control.PagePropertyBackgroundColor.Text = page.backgroundColor;
                control.PagePropertyBackgroundImage.Text = page.backgroundImage;
                control.PagePropertyWidth.Text = page.size.width;
                control.PagePropertyHeight.Text = page.size.height;
                control.PagePropertyEnable.Text = page.enable;
                control.PagePropertyName.Text = thisPage.name;
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        void panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /**
         * @brief   Panel에 GUIO Drop event 발생시 실행되는 함수
         * @param   sender  
         * @param   e       
         */ 
        void panel_DragDrop(object sender, DragEventArgs e)
        {
            TNOControls++;
            switch (HMIProject.HMIToolWindowControl.senderItem)
            {
                case HMIConstants.guioNumber.CAMERA:
                    makeIPCamera(e);
                    break;
                case HMIConstants.guioNumber.CIRCLE:
                    makeCircle(e);
                    break;
                case HMIConstants.guioNumber.RECTANGLE:
                    makeRectangle(e);
                    break;
                case HMIConstants.guioNumber.PUSHBUTTON:
                    makePushButton(e);
                    break;
                case HMIConstants.guioNumber.DIAL:
                    makeDial(e);
                    break;
                case HMIConstants.guioNumber.PROGRESSBAR:
                    makeProgressBar(e);
                    break;
                case HMIConstants.guioNumber.SLIDERBAR:
                    makeSliderBar(e);
                    break;
                case HMIConstants.guioNumber.NUMBERPAD:
                    makeNumPad(e);
                    break;
                case HMIConstants.guioNumber.LOGINPAD:
                    makeLoginPad(e);
                    break;
                case HMIConstants.guioNumber.LABEL:
                    makeLabel(e);
                    break;
                case HMIConstants.guioNumber.DIGITALCLOCK:
                    makeDigitalClock(e);
                    break;
                case HMIConstants.guioNumber.RADIOBUTTON:
                    makeRadioButton(e);
                    break;
                case HMIConstants.guioNumber.LED:
                    makeLED(e);
                    break;
                case HMIConstants.guioNumber.PANEL:
                    makePanel(e);
                    break;
                case HMIConstants.guioNumber.SETRESETBUTTON:
                    makeSetResetButton(e);
                    break;
                case HMIConstants.guioNumber.INCDECBUTTON:
                    makeIncDecButton(e);
                    break;
                case HMIConstants.guioNumber.IMAGE:
                    makeImage(e);
                    break;
                case HMIConstants.guioNumber.RAIL:
                    makeRail(e);
                    break;
                case HMIConstants.guioNumber.WEBVIEW:
                    makeWebView(e);
                    break;
                case HMIConstants.guioNumber.SCROLLLABEL:
                    makeScrollLabel(e);
                    break;
                default:
                    TNOControls--;
                    break;
            }
        }

        #region Make GUIO
        private void makeIPCamera(GUIO guio)
        {
            TNOIPCamera++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "IPCamera";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
        }

        private void makeWebView(GUIO guio)
        {
            TNOWebView++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "WebView";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
        }

        private void makeCircle(GUIO guio)
        {
            TNOCircle++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "Circle";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditCircleFillColor = Int32.Parse(guio.fillColor, NumberStyles.HexNumber);
            hmiForm.EditCircleLineColor = Int32.Parse(guio.lineColor, NumberStyles.HexNumber);
            hmiForm.EditCircleLineThickness = Int32.Parse(guio.lineThickness);
        }

        private void makeRectangle(GUIO guio)
        {
            TNORectangle++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "Rectangle";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditRectangleFillColor = Int32.Parse(guio.fillColor, NumberStyles.HexNumber);
            hmiForm.EditRectangleLineColor = Int32.Parse(guio.lineColor, NumberStyles.HexNumber);
            hmiForm.EditRectangleLineThickness = Int32.Parse(guio.lineThickness);
        }

        private void makePushButton(GUIO guio)
        {
            TNOButton++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "PushButton";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditPushButtonText = guio.text;
            hmiForm.EditPushButtonColor = Int32.Parse(guio.buttonColor, NumberStyles.HexNumber);
            hmiForm.EditPushButtonThickness = Int32.Parse(guio.thickness);
            hmiForm.EditPushButtonBorderColor = Int32.Parse(guio.borderColor, NumberStyles.HexNumber);
            hmiForm.EditPushButtonFontColor = Int32.Parse(guio.fontColor, NumberStyles.HexNumber);
            hmiForm.EditPushButtonFontSize = Int32.Parse(guio.fontSize);
            
            if (Int32.Parse(guio.fontBold) == 0)
                hmiForm.EditPushButtonFontBold = false;
            else
                hmiForm.EditPushButtonFontBold = true;
            if (Int32.Parse(guio.fontUnderline) == 0)
                hmiForm.EditPushButtonFontUnderline = false;
            else
                hmiForm.EditPushButtonFontUnderline = true;
        }

        private void makeDial(GUIO guio)
        {
            TNODial++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "Dial";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditDialMax = Int32.Parse(guio.max);
            hmiForm.EditDialMin = Int32.Parse(guio.min);
            hmiForm.EditDialMajor = Int32.Parse(guio.major);
            hmiForm.EditDialMinor = Int32.Parse(guio.minor);
            hmiForm.EditDialNeedleColor = Int32.Parse(guio.needleColor, NumberStyles.HexNumber);
            hmiForm.EditDialColor = Int32.Parse(guio.dialColor, NumberStyles.HexNumber);
            hmiForm.EditDialFontColor = Int32.Parse(guio.fontColor, NumberStyles.HexNumber);
        }

        private void makeProgressBar(GUIO guio)
        {
            TNOProgressBar++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "ProgressBar";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditProgressBarMax = Int32.Parse(guio.max);
            hmiForm.EditProgressBarMin = Int32.Parse(guio.min);
            hmiForm.EditProgressBarMajor = Int32.Parse(guio.major);
            hmiForm.EditProgressBarMinor = Int32.Parse(guio.minor);
            hmiForm.EditProgressBarOrient = Int32.Parse(guio.orientation);
            hmiForm.EditProgressBarColor = Int32.Parse(guio.progressColor, NumberStyles.HexNumber);
        }

        private void makeSliderBar(GUIO guio)
        {
            TNOSlder++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "SliderBar";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditSliderBarMax = Int32.Parse(guio.max);
            hmiForm.EditSliderBarMin = Int32.Parse(guio.min);
            hmiForm.EditSliderBarMajor = Int32.Parse(guio.major);
            hmiForm.EditSliderBarMinor = Int32.Parse(guio.minor);
            hmiForm.EditSliderBarOrient = Int32.Parse(guio.orientation);
            hmiForm.EditSliderBarColor = Int32.Parse(guio.sliderColor, NumberStyles.HexNumber);
            hmiForm.EditSliderBarHandleColor = Int32.Parse(guio.handleColor, NumberStyles.HexNumber);
        }

        private void makeNumPad(GUIO guio)
        {
            TNONumpad++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "NumPad";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditNumPadNumberFontColor = Int32.Parse(guio.numColor, NumberStyles.HexNumber);
            hmiForm.EditNumPadNumberButtonColor = Int32.Parse(guio.numButtonColor, NumberStyles.HexNumber);
            hmiForm.EditNumPadResetFontColor = Int32.Parse(guio.resetColor, NumberStyles.HexNumber);
            hmiForm.EditNumPadResetButtonColor = Int32.Parse(guio.resetButtonColor, NumberStyles.HexNumber);
            hmiForm.EditNumPadOkFontColor = Int32.Parse(guio.okColor, NumberStyles.HexNumber);
            hmiForm.EditNumPadOkButtonColor = Int32.Parse(guio.okButtonColor, NumberStyles.HexNumber);
            hmiForm.EditNumPadBorderColor = Int32.Parse(guio.borderColor, NumberStyles.HexNumber);
        }

        private void makeLoginPad(GUIO guio)
        {
            TNOLoginpad++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "LoginPad";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditLoginPadBorderColor = Int32.Parse(guio.borderColor, NumberStyles.HexNumber);
            hmiForm.EditLoginPadNumberFontColor = Int32.Parse(guio.numColor, NumberStyles.HexNumber);
            hmiForm.EditLoginPadNumberButtonColor = Int32.Parse(guio.numButtonColor, NumberStyles.HexNumber);
            hmiForm.EditLoginPadResetFontColor = Int32.Parse(guio.resetColor, NumberStyles.HexNumber);
            hmiForm.EditLoginPadResetButtonColor = Int32.Parse(guio.resetButtonColor, NumberStyles.HexNumber);
            hmiForm.EditLoginPadLoginFontColor = Int32.Parse(guio.loginColor, NumberStyles.HexNumber);
            hmiForm.EditLoginPadLoginButtonColor = Int32.Parse(guio.loginButtonColor, NumberStyles.HexNumber);
            hmiForm.EditLoginPadFuncFontColor = Int32.Parse(guio.funcColor, NumberStyles.HexNumber);
            hmiForm.EditLoginPadFuncButtonColor = Int32.Parse(guio.funcButtonColor, NumberStyles.HexNumber);
            hmiForm.EditLoginPadDigitNumber = Int32.Parse(guio.digitNumber);
        }

        private void makeLabel(GUIO guio)
        {
            TNOLabel++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "Label";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditLabelColor = Int32.Parse(guio.labelColor, NumberStyles.HexNumber);
            hmiForm.EditLabelBorderColor = Int32.Parse(guio.borderColor, NumberStyles.HexNumber);
            hmiForm.EditLabelFontColor = Int32.Parse(guio.fontColor, NumberStyles.HexNumber);
            
            hmiForm.EditLabelText = guio.text.Replace("\\n", "\n");
            hmiForm.EditLabelThickness = Int32.Parse(guio.thickness);
            hmiForm.EditLabelFontSize = Int32.Parse(guio.fontSize);
            hmiForm.EditLabelAngle = Int32.Parse(guio.angle);
            
            if (Int32.Parse(guio.fontBold) == 0)
                hmiForm.EditLabelFontBold = false;
            else
                hmiForm.EditLabelFontBold = true;
            if (Int32.Parse(guio.fontUnderline) == 0)
                hmiForm.EditLabelFontUnderline = false;
            else
                hmiForm.EditLabelFontUnderline = true;
            if (Int32.Parse(guio.transparent) == 0)
                hmiForm.EditLabelTransparent = false;
            else
                hmiForm.EditLabelTransparent = true;
        }

        private void makeScrollLabel(GUIO guio)
        {
            TNOScrollLabel++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "ScrollLabel";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditScrollLabelColor = Int32.Parse(guio.labelColor, NumberStyles.HexNumber);
            hmiForm.EditScrollLabelBorderColor = Int32.Parse(guio.borderColor, NumberStyles.HexNumber);
            hmiForm.EditScrollLabelFontColor = Int32.Parse(guio.fontColor, NumberStyles.HexNumber);
            hmiForm.EditScrollLabelText = guio.text;
            hmiForm.EditScrollLabelThickness = Int32.Parse(guio.thickness);
            hmiForm.EditScrollLabelFontSize = Int32.Parse(guio.fontSize);

            hmiForm.EditScrollLabelDirection = Int32.Parse(guio.direction);
            hmiForm.EditScrollLabelSpeed = Int32.Parse(guio.speed);
            if (Int32.Parse(guio.fontBold) == 0)
                hmiForm.EditScrollLabelFontBold = false;
            else
                hmiForm.EditScrollLabelFontBold = true;
            if (Int32.Parse(guio.fontUnderline) == 0)
                hmiForm.EditScrollLabelFontUnderline = false;
            else
                hmiForm.EditScrollLabelFontUnderline = true;
            if (Int32.Parse(guio.transparent) == 0)
                hmiForm.EditScrollLabelTransparent = false;
            else
                hmiForm.EditScrollLabelTransparent = true;

        }

        private void makeDigitalClock(GUIO guio)
        {
            TNODigitalClock++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "DigitalClock";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditDigitalClockFontColor = Int32.Parse(guio.fontColor, NumberStyles.HexNumber);
            hmiForm.EditDigitalClockFontSize = Int32.Parse(guio.fontSize);
            hmiForm.EditDigitalClockBorderColor = Int32.Parse(guio.borderColor, NumberStyles.HexNumber);
            hmiForm.EditDigitalClockColor = Int32.Parse(guio.clockColor, NumberStyles.HexNumber);
            hmiForm.EditDigitalClockTransparent = Int32.Parse(guio.transparent);
            hmiForm.EditDigitalClockFontBold = Int32.Parse(guio.fontBold);
        }

        private void makeRadioButton(GUIO guio)
        {
            TNORadioButton++;
            // TODO
        }

        private void makeLED(GUIO guio)
        {
            TNOLED++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "Led";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditLedColor = Int32.Parse(guio.ledColor, NumberStyles.HexNumber);
        }

        private void makePanel(GUIO guio)
        {
            TNOPanel++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "Panel";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            hmiForm.EditPanelDigitColor = Int32.Parse(guio.digitColor, NumberStyles.HexNumber);
            hmiForm.EditPanelBodyColor = Int32.Parse(guio.bodyColor, NumberStyles.HexNumber);
            hmiForm.EditPanelNeedleColor = Int32.Parse(guio.needleColor, NumberStyles.HexNumber);
            hmiForm.EditPanelMax = Int32.Parse(guio.max);
            hmiForm.EditPanelMin = Int32.Parse(guio.min);
            hmiForm.EditPanelMajor = Int32.Parse(guio.major);
            hmiForm.EditPanelMinor = Int32.Parse(guio.minor);
        }

        private void makeSetResetButton(GUIO guio)
        {
            TNOSetResetButton++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "SetResetButton";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
        }

        private void makeIncDecButton(GUIO guio)
        {
            TNOIncDecButton++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "IncDecButton";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
        }


        private void makeImage(GUIO guio)
        {
            TNOImage++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "Image";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            string path = HMIProjectNode.currentProjectDirectory + @"\" + guio.imageName;
            hmiForm.EditImageName = path;
            if (Int32.Parse(guio.grayScale) == 0)
                hmiForm.EditImageGrayScale = false;
            else
                hmiForm.EditImageGrayScale = true;
        }


        private void makeRail(GUIO guio)
        {
            TNORail++;
            hmiForm.GUIOName = guio.name;
            hmiForm.GUIOType = "Rail";
            hmiForm.MakeGUIOCommand = true;
            hmiForm.EditGUIOPropertyHeight = Int32.Parse(guio.size.height);
            hmiForm.EditGUIOPropertyWidth = Int32.Parse(guio.size.width);
            hmiForm.EditGUIOPropertyX = Int32.Parse(guio.location.x);
            hmiForm.EditGUIOPropertyY = Int32.Parse(guio.location.y);
            hmiForm.EditGUIOPropertyLayer = Int32.Parse(guio.layer);
            string path = HMIProjectNode.currentProjectDirectory + @"\" + guio.imageName;
            hmiForm.EditRailImageName = path;
            if (Int32.Parse(guio.grayScale) == 0)
                hmiForm.EditRailGrayScale = false;
            else
                hmiForm.EditRailGrayScale = true;
        }
        /*
        private void makeRadioButton(GUIO guio)
        {
            AxcustomaxLib.AxGRadioButton radioButton = new AxcustomaxLib.AxGRadioButton();
            radioButton.Location = new System.Drawing.Point(Int32.Parse(guio.location.x), Int32.Parse(guio.location.y));
            radioButton.Size = new System.Drawing.Size(Int32.Parse(guio.size.width), Int32.Parse(guio.size.height));
            panel.Controls.Add(radioButton);
            radioButton.Name = guio.name;
            radioButton.fontColor = Int32.Parse(guio.fontColor, NumberStyles.HexNumber);
            radioButton.fontSize = Int32.Parse(guio.fontSize);
            if (Int32.Parse(guio.fontBold) == 0)
                radioButton.fontBold = false;
            else
                radioButton.fontBold = true;
            radioButton.borderColor = Int32.Parse(guio.borderColor, NumberStyles.HexNumber);
            radioButton.clockColor = Int32.Parse(guio.clockColor, NumberStyles.HexNumber);


            radioButton.Location = new System.Drawing.Point(Int32.Parse(guio.location.x), Int32.Parse(guio.location.y));
            radioButton.Size = new System.Drawing.Size(Int32.Parse(guio.size.width), Int32.Parse(guio.size.height));
        }
        */

        private void makeIPCamera(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();
            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 150);

            newGUIO.type = "IpCamera";
            newGUIO.name = "IPCamera" + TNOIPCamera;
            newGUIO.gVariable = "";
            newGUIO.backgroundColor = "" + Convert.ToString(0xFFFFFF, 16);
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;

            GUIOList.Add(newGUIO);
            makeIPCamera(newGUIO);
        }

        private void makeWebView(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();
            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(250, 250);

            newGUIO.type = "WebView";
            newGUIO.name = "WebView" + TNOWebView;
            newGUIO.gVariable = "";
            newGUIO.url = "www.google.com";
            newGUIO.backgroundColor = "" + Convert.ToString(0xFFFFFF, 16);
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;

            GUIOList.Add(newGUIO);
            makeWebView(newGUIO);
        }

        private void makeCircle(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();
            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 150);
            
            newGUIO.type = "Circle";
            newGUIO.name = "Circle" + TNOCircle;
            newGUIO.lineThickness = "1";
            newGUIO.fillColor = "" + Convert.ToString(0xFFFFFF, 16);
            newGUIO.lineColor = "" + Convert.ToString(0x000000, 16);

            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;

            GUIOList.Add(newGUIO);
            makeCircle(newGUIO);
        }
        
        private void makeRectangle(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();
            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 150);
            newGUIO.name = "Rectangle" + TNORectangle;
            newGUIO.type = "Rectangle";
            newGUIO.lineThickness = "1";
            newGUIO.fillColor = "" + Convert.ToString(0xFFFFFF, 16);
            newGUIO.lineColor = "" + Convert.ToString(0x000000, 16);


            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;

            GUIOList.Add(newGUIO);
            makeRectangle(newGUIO);
        }
        
        private void makePushButton(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();
            //pushButton.MouseDownEvent += new AxcustomaxLib.IGPushButtonEvents_MouseDownEventHandler(GPushButtonMouseDownEvent);
            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 150);
            
            newGUIO.type = "PushButton";
            newGUIO.name = "PushButton" + TNOButton;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;
            
            newGUIO.buttonColor = "E0E0E0";
            newGUIO.borderColor = "000000";
            newGUIO.fontColor = "000000";

            newGUIO.text = "PushButton";

            newGUIO.thickness = "1";
            newGUIO.fontSize = "11";
            newGUIO.fontBold = "0";
            newGUIO.fontUnderline = "0";



            GUIOList.Add(newGUIO);
            makePushButton(newGUIO);
        }

        private void makeDial(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();
            //dial.MouseDownEvent += new AxcustomaxLib.IGDialEvents_MouseDownEventHandler(GDialMouseDownEvent);

            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 150);
            newGUIO.type = "Dial";
            newGUIO.name = "Dial" + TNODial;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;

            newGUIO.max = "" + 100;
            newGUIO.min = "0";
            newGUIO.major = "5";
            newGUIO.minor = "5";
            newGUIO.needleColor = "FF0000";
            newGUIO.dialColor = "E0E0E0";
            newGUIO.fontColor = "202020";


            GUIOList.Add(newGUIO);
            makeDial(newGUIO);
        }

        private void makeProgressBar(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();
            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 150);
            newGUIO.type = "ProgressBar";
            newGUIO.name = "ProgressBar" + TNOProgressBar;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;

            newGUIO.max = "" + 100;
            newGUIO.min = "0";
            newGUIO.major = "5";
            newGUIO.minor = "5";
            newGUIO.orientation = "2";
            newGUIO.progressColor = "FF0000";

            GUIOList.Add(newGUIO);
            makeProgressBar(newGUIO);
        }

        private void makeSliderBar(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();
            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 150);

            newGUIO.type = "SliderBar";
            newGUIO.name = "SliderBar" + TNOSlder;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;

            newGUIO.max = "" + 100;
            newGUIO.min = "0";
            newGUIO.major = "5";
            newGUIO.minor = "5";
            newGUIO.orientation = "2";
            newGUIO.sliderColor = "E0E0E0";
            newGUIO.handleColor = "FF0000";

            GUIOList.Add(newGUIO);
            makeSliderBar(newGUIO);
        }

        private void makeNumPad(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();
            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(262, 335);

            newGUIO.type = "NumPad";
            newGUIO.name = "NumPad" + TNONumpad;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.layer = "" + TNOControls;

            newGUIO.numColor = Convert.ToString(0xffffff, 16);
            newGUIO.numButtonColor = Convert.ToString(0xff, 16);
            newGUIO.resetColor = Convert.ToString(0xffffff, 16);
            newGUIO.resetButtonColor = Convert.ToString(0xb7, 16);
            newGUIO.okColor = Convert.ToString(0xffffff, 16);
            newGUIO.okButtonColor = Convert.ToString(0x6424bd, 16);
            newGUIO.borderColor = Convert.ToString(0xffffff, 16);

            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;

            GUIOList.Add(newGUIO);
            makeNumPad(newGUIO);
        }

        private void makeLoginPad(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();
            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(262, 335);

            //loginpad.MouseDownEvent += new AxcustomaxLib.IGLoginpadEvents_MouseDownEventHandler(GLoginpadMouseDownEvent);

            newGUIO.type = "LoginPad";
            newGUIO.name = "LoginPad" + TNOLoginpad;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;

            newGUIO.password = "000000";

            newGUIO.numColor = Convert.ToString(0xffffff, 16);
            newGUIO.numButtonColor = Convert.ToString(0xff, 16);
            newGUIO.resetColor = Convert.ToString(0xffffff, 16);
            newGUIO.resetButtonColor = Convert.ToString(0xb7, 16);
            newGUIO.loginColor = Convert.ToString(0xffffff, 16);
            newGUIO.loginButtonColor = Convert.ToString(0x2f9d27, 16);
            newGUIO.funcColor = Convert.ToString(0xffffff, 16);
            newGUIO.funcButtonColor = Convert.ToString(0x6424bd, 16);
            newGUIO.borderColor = Convert.ToString(0xffffff, 16);
            newGUIO.digitNumber = "" + 6;

            GUIOList.Add(newGUIO);
            makeLoginPad(newGUIO);
        }

        private void makeLabel(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();

            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 50);
            //label.MouseDownEvent += new AxcustomaxLib.IGLabelEvents_MouseDownEventHandler(GLabelMouseDownEvent);

            newGUIO.type = "Label";
            newGUIO.text = "Label";
            newGUIO.name = "Label" + TNOLabel;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;
            newGUIO.transparent = "0";

            newGUIO.labelColor = "E0E0E0";
            newGUIO.borderColor = "000000";
            newGUIO.fontColor = "000000";

            newGUIO.text = "Label";

            newGUIO.thickness = "1";
            newGUIO.fontSize = "11";
            newGUIO.fontBold = "0";
            newGUIO.fontUnderline = "0";
            newGUIO.angle = "0";

            GUIOList.Add(newGUIO);
            makeLabel(newGUIO);
        }
        
        private void makeScrollLabel(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();

            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 50);
            //label.MouseDownEvent += new AxcustomaxLib.IGLabelEvents_MouseDownEventHandler(GLabelMouseDownEvent);

            newGUIO.type = "ScrollLabel";
            newGUIO.text = "ScrollLabel";
            newGUIO.name = "ScrollLabel" + TNOScrollLabel;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;
            newGUIO.transparent = "0";
            newGUIO.speed = "1";
            newGUIO.direction = "0";

            newGUIO.labelColor = "E0E0E0";
            newGUIO.borderColor = "000000";
            newGUIO.fontColor = "000000";

            newGUIO.text = "Label";

            newGUIO.thickness = "1";
            newGUIO.fontSize = "11";
            newGUIO.fontBold = "0";
            newGUIO.fontUnderline = "0";
            newGUIO.angle = "0";

            GUIOList.Add(newGUIO);
            makeScrollLabel(newGUIO);
        }

        private void makeDigitalClock(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();

            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 50);
            //digitalClock.MouseDownEvent += new AxcustomaxLib.IGDigitalClockEvents_MouseDownEventHandler(GDigitalClockMouseDownEvent);

            newGUIO.type = "DigitalClock";
            newGUIO.name = "DigitalClock" + TNODigitalClock;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;

            newGUIO.fontColor = "000000";
            newGUIO.fontSize = "11";
            newGUIO.fontBold = "0";
            newGUIO.transparent = "0";
            newGUIO.borderColor = "FFFFFF";
            newGUIO.clockColor = "FFFFFF";

            GUIOList.Add(newGUIO);
            makeDigitalClock(newGUIO);
        }

        private void makeRadioButton(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();

            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 50);
            //digitalClock.MouseDownEvent += new AxcustomaxLib.IGDigitalClockEvents_MouseDownEventHandler(GDigitalClockMouseDownEvent);

            newGUIO.type = "RadioButton";
            newGUIO.name = "RadioButton" + TNORadioButton;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;
            newGUIO.count = "" + 1;

            GUIOList.Add(newGUIO);
            makeRadioButton(newGUIO);
        }

        private void makeLED(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();

            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(50, 50);
            //digitalClock.MouseDownEvent += new AxcustomaxLib.IGDigitalClockEvents_MouseDownEventHandler(GDigitalClockMouseDownEvent);

            newGUIO.type = "LED";
            newGUIO.name = "LED" + TNOLED;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;
            newGUIO.ledColor = "FF0000";

            GUIOList.Add(newGUIO);
            makeLED(newGUIO);
        }
        
        private void makePanel(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();

            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 150);
            //digitalClock.MouseDownEvent += new AxcustomaxLib.IGDigitalClockEvents_MouseDownEventHandler(GDigitalClockMouseDownEvent);

            newGUIO.type = "Panel";
            newGUIO.name = "Panel" + TNOPanel;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;
            newGUIO.min = "0";
            newGUIO.max = "100";
            newGUIO.major = "5";
            newGUIO.minor = "5";
            newGUIO.needleColor = "ff0000";
            newGUIO.digitColor = "000000";
            newGUIO.bodyColor = "ffffff";

            GUIOList.Add(newGUIO);
            makePanel(newGUIO);
        }


        private void makeSetResetButton(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();

            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 50);
            //digitalClock.MouseDownEvent += new AxcustomaxLib.IGDigitalClockEvents_MouseDownEventHandler(GDigitalClockMouseDownEvent);

            newGUIO.type = "SetResetButton";
            newGUIO.name = "SetResetButton" + TNOSetResetButton;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;

            GUIOList.Add(newGUIO);
            makeSetResetButton(newGUIO);
        }

        private void makeIncDecButton(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();

            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(150, 50);
            //digitalClock.MouseDownEvent += new AxcustomaxLib.IGDigitalClockEvents_MouseDownEventHandler(GDigitalClockMouseDownEvent);

            newGUIO.type = "IncDecButton";
            newGUIO.name = "IncDecButton" + TNOIncDecButton;
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.layer = "" + TNOControls;

            GUIOList.Add(newGUIO);
            makeIncDecButton(newGUIO);
        }


        private void makeImage(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();

            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(100, 100);

            newGUIO.type = "Image";
            newGUIO.name = "Image" + TNOImage;
            newGUIO.imageName = "";
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.grayScale = "0";
            newGUIO.scale = "1";
            newGUIO.layer = "" + TNOControls;


            GUIOList.Add(newGUIO);
            makeImage(newGUIO);
        }


        private void makeRail(DragEventArgs e)
        {
            GUIO newGUIO = new GUIO();

            System.Drawing.Point location = panel.PointToClient(new System.Drawing.Point(e.X, e.Y));
            System.Drawing.Size size = new System.Drawing.Size(100, 100);

            newGUIO.type = "Rail";
            newGUIO.name = "Rail" + TNORail;
            newGUIO.imageName = "";
            newGUIO.gVariable = "";
            newGUIO.location.x = "" + location.X;
            newGUIO.location.y = "" + location.Y;
            newGUIO.size.width = "" + size.Width;
            newGUIO.size.height = "" + size.Height;
            newGUIO.grayScale = "0";
            

            newGUIO.layer = "" + TNOControls;

            GUIOList.Add(newGUIO);
            makeRail(newGUIO);
        }

        #endregion

        #region Mouse Down Event
        private void IpCameraMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;



            // private property
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            control.GUIOPropertyAddressTextBox.Text = guio.address;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }
        
        private void GWebViewMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;



            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            control.GUIOPropertyURLTextBox.Text = guio.url;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void CircleMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.FigureProperty.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.FigurePropertyNameTextBox.Text = guio.name;
            control.FigurePropertyFillColorTextBox.Text = guio.fillColor;
            control.FigurePropertyLineColorTextBox.Text = guio.lineColor;
            control.FigurePropertyLineThicknessTextBox.Text = guio.lineThickness;

            control.FigurePropertyXTextBox.Text = guio.location.x;
            control.FigurePropertyYTextBox.Text = guio.location.y;
            control.FigurePropertyWidthTextBox.Text = guio.size.width;
            control.FigurePropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.FigurePropertyLayerTextBox.Text = guio.layer;
        }

        private void RectangleMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.FigureProperty.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.FigurePropertyNameTextBox.Text = guio.name;
            control.FigurePropertyFillColorTextBox.Text = guio.fillColor;
            control.FigurePropertyLineColorTextBox.Text = guio.lineColor;
            control.FigurePropertyLineThicknessTextBox.Text = guio.lineThickness;

            control.FigurePropertyXTextBox.Text = guio.location.x;
            control.FigurePropertyYTextBox.Text = guio.location.y;
            control.FigurePropertyWidthTextBox.Text = guio.size.width;
            control.FigurePropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.FigurePropertyLayerTextBox.Text = guio.layer;
        }

        #region deprecated function
        /*
        private void ColourfulQDialMouseDownEvent(object sender, AxcustomaxLib.IColourfulQDialEvents_MouseDownEvent e)
        {
            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.QDial;
            HMIEditorPropertyToolWindowControl.selectedQDial = (AxcustomaxLib.AxColourfulQDial)sender;
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedGUIO = GUIOList.Find(v => v.name == HMIEditorPropertyToolWindowControl.selectedQDial.Name);
            HMIEditorPropertyToolWindowControl.selectedControl = (Control)sender;

            GUIO guio = GUIOList.Find(g => g.name == ((AxcustomaxLib.AxColourfulQDial)sender).Name);
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void ColourfulQSliderMouseDownEvent(object sender, AxcustomaxLib.IColourfulQSliderEvents_MouseDownEvent e)
        {
            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.QSlider;
            GUIO guio = GUIOList.Find(g => g.name == ((AxcustomaxLib.AxColourfulQSlider)sender).Name);
            HMIEditorPropertyToolWindowControl.selectedQSlider = (AxcustomaxLib.AxColourfulQSlider)sender;
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            HMIEditorPropertyToolWindowControl.selectedGUIO = GUIOList.Find(v => v.name == HMIEditorPropertyToolWindowControl.selectedQSlider.Name);
            HMIEditorPropertyToolWindowControl.selectedControl = (Control)sender;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void ColourfulQPushButtonMouseDownEvent(object sender, AxcustomaxLib.IColourfulQPushButtonEvents_MouseDownEvent e)
        {
            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.QPushButton;
            GUIO guio = GUIOList.Find(g => g.name == ((AxcustomaxLib.AxColourfulQPushButton)sender).Name);
            HMIEditorPropertyToolWindowControl.selectedQPushButton = (AxcustomaxLib.AxColourfulQPushButton)sender;
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            HMIEditorPropertyToolWindowControl.selectedGUIO = GUIOList.Find(v => v.name == HMIEditorPropertyToolWindowControl.selectedQPushButton.Name);
            HMIEditorPropertyToolWindowControl.selectedControl = (Control)sender;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Visible;

            // 기존 Event 제거
            int TNOClickEvent = control.ClickEventStackPanel.Children.Count;
            control.ClickEventStackPanel.Children.RemoveRange(3, TNOClickEvent);

            int index = 0;
            if(HMIEditorPropertyToolWindowControl.selectedGUIO.clickEvents.Count != 0)
                foreach (clickEvent cE in HMIEditorPropertyToolWindowControl.selectedGUIO.clickEvents)
                {
                    
                    if(index == 0)
                    {
                        if (cE.type.Equals("ChangeState"))
                        {
                            control.ClickEventTypeComboBox0.SelectedIndex = 1;
                        }
                        else if (cE.type.Equals("ChangeValue"))
                        {
                            control.ClickEventTypeComboBox0.SelectedIndex = 2;
                        }
                        else if (cE.type.Equals("IncreaseValue"))
                        {
                            control.ClickEventTypeComboBox0.SelectedIndex = 3;
                        }
                        else if (cE.type.Equals("DecreaseValue"))
                        {
                            control.ClickEventTypeComboBox0.SelectedIndex = 4;
                        }
                        else if (cE.type.Equals("ChangeProperty"))
                        {
                            control.ClickEventTypeComboBox0.SelectedIndex = 5;
                        }
                        else if (cE.type.Equals("ChangePage"))
                        {
                            control.ClickEventTypeComboBox0.SelectedIndex = 6;
                        }
                    }
                    else
                    {

                    }
                    index++;
                }
            else
            {
                control.ClickEventGNameComboBox0.Items.Clear();
                System.Windows.Controls.ComboBoxItem comboboxItem;
                comboboxItem = new System.Windows.Controls.ComboBoxItem();
                comboboxItem.Content = "G-Name";
                control.ClickEventGNameComboBox0.Items.Add(comboboxItem);
                control.ClickEventGNameComboBox0.SelectedIndex = 0;
                foreach (GUIO guio0 in GUIOList)
                {
                    comboboxItem = new System.Windows.Controls.ComboBoxItem();
                    comboboxItem.Content = guio0.name;
                    control.ClickEventGNameComboBox0.Items.Add(comboboxItem);
                }
            }


            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void ColourfulQLabelMouseDownEvent(object sender, AxcustomaxLib.IColourfulQLabelEvents_MouseDownEvent e)
        {
            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.QLabel;
            GUIO guio = GUIOList.Find(g => g.name == ((AxcustomaxLib.AxColourfulQLabel)sender).Name);
            HMIEditorPropertyToolWindowControl.selectedQLabel = (AxcustomaxLib.AxColourfulQLabel)sender;
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            HMIEditorPropertyToolWindowControl.selectedGUIO = GUIOList.Find(v => v.name == HMIEditorPropertyToolWindowControl.selectedQLabel.Name);
            HMIEditorPropertyToolWindowControl.selectedControl = (Control)sender;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void QwtWheelMouseDownEvent(object sender, AxqwtbasicaxLib.IQwtWheelBoxEvents_MouseDownEvent e)
        {
            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.Wheel;
            GUIO guio = GUIOList.Find(g => g.name == ((AxqwtbasicaxLib.AxQwtWheelBox)sender).Name);
            HMIEditorPropertyToolWindowControl.selectedWheel = (AxqwtbasicaxLib.AxQwtWheelBox)sender;
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            HMIEditorPropertyToolWindowControl.selectedGUIO = GUIOList.Find(v => v.name == HMIEditorPropertyToolWindowControl.selectedWheel.Name);
            HMIEditorPropertyToolWindowControl.selectedControl = (Control)sender;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void QwtDialMouseDownEvent(object sender, AxqwtbasicaxLib.IQwtDialBoxEvents_MouseDownEvent e)
        {
            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.Dial;
            GUIO guio = GUIOList.Find(g => g.name == ((AxqwtbasicaxLib.AxQwtDialBox)sender).Name);
            HMIEditorPropertyToolWindowControl.selectedDial = (AxqwtbasicaxLib.AxQwtDialBox)sender;
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            HMIEditorPropertyToolWindowControl.selectedGUIO = GUIOList.Find(v => v.name == HMIEditorPropertyToolWindowControl.selectedDial.Name);
            HMIEditorPropertyToolWindowControl.selectedControl = (Control)sender;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void QwtSliderMouseDownEvent(object sender, AxqwtbasicaxLib.IQwtSliderBoxEvents_MouseDownEvent e)
        {
            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.Slider;
            GUIO guio = GUIOList.Find(g => g.name == ((AxqwtbasicaxLib.AxQwtSliderBox)sender).Name);
            HMIEditorPropertyToolWindowControl.selectedSlider = (AxqwtbasicaxLib.AxQwtSliderBox)sender;
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            HMIEditorPropertyToolWindowControl.selectedGUIO = GUIOList.Find(v => v.name == HMIEditorPropertyToolWindowControl.selectedSlider.Name);
            HMIEditorPropertyToolWindowControl.selectedControl = (Control)sender;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void QwtKnobMouseDownEvent(object sender, AxqwtbasicaxLib.IQwtKnobBoxEvents_MouseDownEvent e)
        {
            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.Knob;
            GUIO guio = GUIOList.Find(g => g.name == ((AxqwtbasicaxLib.AxQwtKnobBox)sender).Name);
            HMIEditorPropertyToolWindowControl.selectedKnob = (AxqwtbasicaxLib.AxQwtKnobBox)sender;
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            HMIEditorPropertyToolWindowControl.selectedGUIO = GUIOList.Find(v => v.name == HMIEditorPropertyToolWindowControl.selectedKnob.Name);
            HMIEditorPropertyToolWindowControl.selectedControl = (Control)sender;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void QwtSpeedMeterMouseDownEvent(object sender, AxqwtbasicaxLib.IQwtSpeedMeterEvents_MouseDownEvent e)
        {
            HMIEditorPropertyToolWindowControl.selectedObjectType = HMIEditorPropertyToolWindowControl.ObjectType.SpeedMeter;
            GUIO guio = GUIOList.Find(g => g.name == ((AxqwtbasicaxLib.AxQwtSpeedMeter)sender).Name);
            HMIEditorPropertyToolWindowControl.selectedSpeedMeter = (AxqwtbasicaxLib.AxQwtSpeedMeter)sender;
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;
            HMIEditorPropertyToolWindowControl.selectedGUIO = GUIOList.Find(v => v.name == HMIEditorPropertyToolWindowControl.selectedSpeedMeter.Name);
            HMIEditorPropertyToolWindowControl.selectedControl = (Control)sender;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }
        */
        #endregion

        private void GPushButtonMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Visible;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTextTextBox.Text = guio.text;
            control.GUIOPropertyButtonColorTextBox.Text = guio.buttonColor;
            control.GUIOPropertyThicknessTextBox.Text = guio.thickness;
            control.GUIOPropertyBorderColorTextBox.Text = guio.borderColor;
            control.GUIOPropertyFontColorTextBox.Text = guio.fontColor;
            control.GUIOPropertyFontSizeTextBox.Text = guio.fontSize;
            if (Int32.Parse(guio.fontBold) == 0)
                control.GUIOPropertyFontBoldComboBox.SelectedIndex = 1;
            else
                control.GUIOPropertyFontBoldComboBox.SelectedIndex = 0;
            if (Int32.Parse(guio.fontUnderline) == 0)
                control.GUIOPropertyFontUnderlineComboBox.SelectedIndex = 1;
            else
                control.GUIOPropertyFontUnderlineComboBox.SelectedIndex = 0;


            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void GDialMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxTextBox.Text = guio.max;
            control.GUIOPropertyMinTextBox.Text = guio.min;
            control.GUIOPropertyMajorTextBox.Text = guio.major;
            control.GUIOPropertyMinorTextBox.Text = guio.minor;
            control.GUIOPropertyNeedleColorTextBox.Text = guio.needleColor;
            control.GUIOPropertyDialColorTextBox.Text = guio.dialColor;
            control.GUIOPropertyFontColorTextBox.Text = guio.fontColor;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void GProgressBarMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxTextBox.Text = guio.max;
            control.GUIOPropertyMinTextBox.Text = guio.min;
            control.GUIOPropertyMajorTextBox.Text = guio.major;
            control.GUIOPropertyMinorTextBox.Text = guio.minor;
            control.GUIOPropertyProgressColorTextBox.Text = guio.progressColor;
            if (Int32.Parse(guio.orientation) == 1)
                control.GUIOPropertyOrientationComboBox.SelectedIndex = 0;
            else
                control.GUIOPropertyOrientationComboBox.SelectedIndex = 1;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void GSliderBarMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxTextBox.Text = guio.max;
            control.GUIOPropertyMinTextBox.Text = guio.min;
            control.GUIOPropertyMajorTextBox.Text = guio.major;
            control.GUIOPropertyMinorTextBox.Text = guio.minor;
            control.GUIOPropertySliderColorTextBox.Text = guio.sliderColor;
            control.GUIOPropertyHandleColorTextBox.Text = guio.handleColor;
            if (Int32.Parse(guio.orientation) == 1)
                control.GUIOPropertyOrientationComboBox.SelectedIndex = 0;
            else
                control.GUIOPropertyOrientationComboBox.SelectedIndex = 1;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void GNumpadMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;


            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNumColorTextBox.Text = guio.numColor;
            control.GUIOPropertyNumButtonColorTextBox.Text = guio.numButtonColor;
            control.GUIOPropertyResetColorTextBox.Text = guio.resetColor;
            control.GUIOPropertyResetButtonColorTextBox.Text = guio.resetButtonColor;
            control.GUIOPropertyOkColorTextBox.Text = guio.okColor;
            control.GUIOPropertyOkButtonColorTextBox.Text = guio.okButtonColor;
            control.GUIOPropertyBorderColorTextBox.Text = guio.borderColor;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void GLoginpadMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;


            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyPasswordTextBox.Text = guio.password;
            control.GUIOPropertyNumColorTextBox.Text = guio.numColor;
            control.GUIOPropertyNumButtonColorTextBox.Text = guio.numButtonColor;
            control.GUIOPropertyResetColorTextBox.Text = guio.resetColor;
            control.GUIOPropertyResetButtonColorTextBox.Text = guio.resetButtonColor;
            control.GUIOPropertyLoginColorTextBox.Text = guio.loginColor;
            control.GUIOPropertyLoginButtonColorTextBox.Text = guio.loginButtonColor;
            control.GUIOPropertyFuncColorTextBox.Text = guio.funcColor;
            control.GUIOPropertyFuncButtonColorTextBox.Text = guio.funcButtonColor;
            control.GUIOPropertyBorderColorTextBox.Text = guio.borderColor;
            control.GUIOPropertyDigitNumberTextBox.Text = guio.digitNumber;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void GLabelMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;


            control.GUIOPropertyTextTextBox.Text = guio.text;
            control.GUIOPropertyLabelColorTextBox.Text = guio.labelColor;
            control.GUIOPropertyThicknessTextBox.Text = guio.thickness;
            control.GUIOPropertyBorderColorTextBox.Text = guio.borderColor;
            control.GUIOPropertyFontColorTextBox.Text = guio.fontColor;
            control.GUIOPropertyFontSizeTextBox.Text = guio.fontSize;
            if (Int32.Parse(guio.fontBold) == 0)
                control.GUIOPropertyFontBoldComboBox.SelectedIndex = 1;
            else
                control.GUIOPropertyFontBoldComboBox.SelectedIndex = 0;
            if (Int32.Parse(guio.fontUnderline) == 0)
                control.GUIOPropertyFontUnderlineComboBox.SelectedIndex = 1;
            else
                control.GUIOPropertyFontUnderlineComboBox.SelectedIndex = 0;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyTransparentTextBox.Text = guio.transparent;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            control.GUIOPropertyAngleTextBox.Text = guio.angle;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }


        private void GScrollLabelMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;


            control.GUIOPropertyTextTextBox.Text = guio.text;
            control.GUIOPropertyLabelColorTextBox.Text = guio.labelColor;
            control.GUIOPropertyThicknessTextBox.Text = guio.thickness;
            control.GUIOPropertyBorderColorTextBox.Text = guio.borderColor;
            control.GUIOPropertyFontColorTextBox.Text = guio.fontColor;
            control.GUIOPropertyFontSizeTextBox.Text = guio.fontSize;
            if (Int32.Parse(guio.fontBold) == 0)
                control.GUIOPropertyFontBoldComboBox.SelectedIndex = 1;
            else
                control.GUIOPropertyFontBoldComboBox.SelectedIndex = 0;
            if (Int32.Parse(guio.fontUnderline) == 0)
                control.GUIOPropertyFontUnderlineComboBox.SelectedIndex = 1;
            else
                control.GUIOPropertyFontUnderlineComboBox.SelectedIndex = 0;
            if (Int32.Parse(guio.direction) == 0)
                control.GUIOPropertyDirectionComboBox.SelectedIndex = 0;
            else
                control.GUIOPropertyDirectionComboBox.SelectedIndex = 1;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyTransparentTextBox.Text = guio.transparent;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            control.GUIOPropertyAngleTextBox.Text = guio.angle;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
            control.GUIOPropertySpeedTextBox.Text = guio.speed;
        }

        private void GDigitalClockMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorTextBox.Text = guio.clockColor;
            control.GUIOPropertyBorderColorTextBox.Text = guio.borderColor;
            control.GUIOPropertyFontColorTextBox.Text = guio.fontColor;
            control.GUIOPropertyFontSizeTextBox.Text = guio.fontSize;
            if (Int32.Parse(guio.fontBold) == 0)
                control.GUIOPropertyFontBoldComboBox.SelectedIndex = 1;
            else
                control.GUIOPropertyFontBoldComboBox.SelectedIndex = 0;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyTransparentTextBox.Text = guio.transparent;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }
        private void GRadioButtonMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyBodyColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLEDColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyCountDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyCountTextBox.Text = guio.count;
            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void GLedMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyBodyColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLEDColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyCountDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLEDColorTextBox.Text = guio.ledColor;
            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void GPanelMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyBodyColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyDigitColorDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyLEDColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyCountDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMinTextBox.Text = guio.min;
            control.GUIOPropertyMaxTextBox.Text = guio.max;
            control.GUIOPropertyMajorTextBox.Text = guio.major;
            control.GUIOPropertyMinorTextBox.Text = guio.minor;
            control.GUIOPropertyNeedleColorTextBox.Text = guio.needleColor;
            control.GUIOPropertyBodyColorTextBox.Text = guio.bodyColor;
            control.GUIOPropertyDigitColorTextBox.Text = guio.digitColor;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }
        private void GSetResetButtonMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyBodyColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLEDColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyCountDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }
        private void GIncDecButtonMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyBodyColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLEDColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyCountDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void GImageMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl; ;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyBodyColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLEDColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyCountDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyImageNameTextBox.Text = guio.imageName;
            if (guio.grayScale == "0")
            {
                control.GUIOPropertyGrayScaleComboBox.SelectedIndex = 1;
            }
            else
                control.GUIOPropertyGrayScaleComboBox.SelectedIndex = 0;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;
            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }

        private void GRailMouseDownEvent()
        {
            HMIEditorPropertyToolWindowControl.selectedPane = this;
            HMIEditorPropertyToolWindowControl.selectedPanel = panel;
            HMIEditorPropertyToolWindowControl.selectedTransparentPanel = transparentPanel;

            GUIO guio = HMIEditorPropertyToolWindowControl.selectedGUIO;
            hmiForm.selectedGUIOName = guio.name;
            HMIEditorPropertyToolWindowControl control = HMIEditorPropertyToolWindowCommand.hmiEditorPropertyToolWindowControl;

            control.PageProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOProperty.Visibility = System.Windows.Visibility.Visible;
            control.FigureProperty.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyClickEventDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            //control.ClickEventStackPanel.Visibility = System.Windows.Visibility.Collapsed;

            // private property
            control.GUIOPropertyAngleDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyURLDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyAddressDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTextDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyThicknessDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyBorderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyLabelColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyTransparentDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertySpeedDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDirectionDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyClockColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyMaxDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMajorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyMinorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNeedleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDialColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOrientationDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyProgressColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertySliderColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyHandleColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyFontColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontSizeDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontBoldDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFontUnderlineDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyPasswordDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyNumButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyResetButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLoginButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyFuncButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitNumberDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyOkColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyOkButtonColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyTempGVarDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyPageNameDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyBodyColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyDigitColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyLEDColorDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            control.GUIOPropertyCountDockPanel.Visibility = System.Windows.Visibility.Collapsed;

            control.GUIOPropertyImageNameDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyGrayScaleDockPanel.Visibility = System.Windows.Visibility.Visible;
            control.GUIOPropertyVertexesDockPanel.Visibility = System.Windows.Visibility.Visible;

            control.GUIOPropertyNameTextBox.Text = guio.name;
            control.GUIOPropertyGVarTextBox.Text = guio.gVariable;
            control.GUIOPropertyXTextBox.Text = guio.location.x;
            control.GUIOPropertyYTextBox.Text = guio.location.y;
            control.GUIOPropertyWidthTextBox.Text = guio.size.width;
            control.GUIOPropertyHeightTextBox.Text = guio.size.height;

            control.GUIOPropertyImageNameTextBox.Text = guio.imageName;
            if(guio.grayScale == "0")
            {
                control.GUIOPropertyGrayScaleComboBox.SelectedIndex = 1;
            }
            else
                control.GUIOPropertyGrayScaleComboBox.SelectedIndex = 0;


            // Index Test 160718
            control.GUIOPropertyLayerTextBox.Text = guio.layer;
        }
        #endregion
        /// <summary>
        /// This method is called when the pane is sited with a non null service provider.
        /// Here is where you can do all the initalization that requare access to
        /// services provided by the shell.
        /// </summary>
        protected override void Initialize()
        {
            // If tooboxData have initialized, skip creating a new one.
            if(toolboxData == null)
            {
                // Implement later
            }
        }

        #endregion


        #region Properties
        /// <summary>
        /// Gets extended rich text box that are hosted.
        /// This is a required override from the Microsoft.VisualStudio.Shell.WindowPane class.
        /// </summary>
        /// <remarks>The resultant handle can be used with Win32 API calls.</remarks>
        public override IWin32Window Window
        {
            get
            {
                return editorForm;
                //return editorControl;
            }
        }
        #endregion Properties

        #region Methods

        #region IDisposable Pattern implementation

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if(editorForm != null)
                    {
                        editorForm.Dispose();
                        editorForm = null;
                    }
                    GC.SuppressFinalize(this);
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #endregion

        #region IOleCommandTarget Members

        private GUIO CopyGUIO;

        private int Copy()
        {
            if (HMIEditorPropertyToolWindowControl.selectedObjectType != HMIEditorPropertyToolWindowControl.ObjectType.Page)
            {
                OLECMDF cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
                pastePrgCmd.cmdf = (uint)cmdf;
                CopyGUIO = HMIEditorPropertyToolWindowControl.selectedGUIO;
                return 0;
            }
            return 0;
        }

        private int Cut()
        {
            if (HMIEditorPropertyToolWindowControl.selectedObjectType != HMIEditorPropertyToolWindowControl.ObjectType.Page)
            {
                OLECMDF cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
                pastePrgCmd.cmdf = (uint)cmdf;

                CopyGUIO = HMIEditorPropertyToolWindowControl.selectedGUIO;
                Control CopyControl = null;
                GUIOList.Remove(CopyGUIO);
                foreach(Control control in panel.Controls)
                {
                    if (control.Name == CopyGUIO.name)
                        CopyControl = control;
                }
                if (CopyControl != null)
                    panel.Controls.Remove(CopyControl);

                return 0;
            }
            return 0;
        }

        private int Remove()
        {
            Control removeControl = null;
            GUIO removeGUIO = HMIEditorPropertyToolWindowControl.selectedGUIO;
            GUIOList.Remove(removeGUIO);
            foreach (Control control in panel.Controls)
            {
                if (control.Name == removeGUIO.name)
                    removeControl = control;
            }
            if (removeControl != null)
            {
                panel.Controls.Remove(removeControl);

                OLECMDF cmdf = OLECMDF.OLECMDF_SUPPORTED;
                copyPrgCmd.cmdf = (uint)cmdf;
                cutPrgCmd.cmdf = (uint)cmdf;
                deletePrgCmd.cmdf = (uint)cmdf;
            }
            return 0;
        }

        private int Paste()
        {
            bool isUniqueName = true;
            GUIO pasteGUIO = CopyGUIO.Clone();
            string originalName = pasteGUIO.name;
            int number = 0;
            string cloneName = originalName + "(" + (number++) + ")";

            while (true)
            {
                foreach (GUIO guio in GUIOList)
                {
                    if (cloneName == guio.name)
                        isUniqueName = false;
                }
                if (isUniqueName)
                    break;
                else {
                    cloneName = originalName + "(" + (number++) + ")";
                    isUniqueName = true;
                }
            }

            pasteGUIO.name = cloneName;
            pasteGUIO.location.x = "" + (Int32.Parse(pasteGUIO.location.x) + (10 * number));
            pasteGUIO.location.y = "" + (Int32.Parse(pasteGUIO.location.y) + (10 * number));
            GUIOList.Add(pasteGUIO);

            switch (pasteGUIO.type)
            {
                case "IpCamera":
                    makeIPCamera(pasteGUIO);
                    break;
                case "Circle":
                    makeCircle(pasteGUIO);
                    break;
                case "Rectangle":
                    makeRectangle(pasteGUIO);
                    break;
                case "PushButton":
                    makePushButton(pasteGUIO);
                    break;
                case "Dial":
                    makeDial(pasteGUIO);
                    break;
                case "ProgressBar":
                    makeProgressBar(pasteGUIO);
                    break;
                case "SliderBar":
                    makeSliderBar(pasteGUIO);
                    break;
                case "NumPad":
                    makeNumPad(pasteGUIO);
                    break;
                case "LoginPad":
                    makeLoginPad(pasteGUIO);
                    break;
                case "Label":
                    makeLabel(pasteGUIO);
                    break;
                case "DigitalClock":
                    makeDigitalClock(pasteGUIO);
                    break;

                default:
                    break;
            }

            return 0;
        }


        /**
         * @brief The shell call this function to know if a menu item should be visible and if it should be enabled/disabled.
         * Note that this function will only be called when an instance of this editor is open
         * @param 
         * 
         * 
         */ 
        /// <summary>
        /// The shell call this function to know if a menu item should be visible and
        /// if it should be enabled/disabled.
        /// Note that this function will only be called when an instance of this editor is open.
        /// </summary>
        /// <param name="pguidCmdGroup">Guid describing which set of command the current command(s) belong to.</param>
        /// <param name="cCmds">Number of command which status are being asked for.</param>
        /// <param name="prgCmds">Information for each command.</param>
        /// <param name="pCmdText">Used to dynamically change the command text.</param>
        /// <returns>S_OK if the method succeeds.</returns> 
        /// 

        private OLECMD copyPrgCmd;
        private OLECMD pastePrgCmd;
        private OLECMD cutPrgCmd;
        private OLECMD deletePrgCmd;

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            // validate parameters
            if (prgCmds == null || cCmds != 1)
            {
                return VSConstants.E_INVALIDARG;
            }

            OLECMDF cmdf = OLECMDF.OLECMDF_SUPPORTED;

            if (pguidCmdGroup == VSConstants.GUID_VSStandardCommandSet97)
            {
                // Process standard Commands
                switch (prgCmds[0].cmdID)
                {
                    case (uint)VSConstants.VSStd97CmdID.SelectAll:
                        {
                            // Always enabled
                            cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
                            break;
                        }
                    case (uint)VSConstants.VSStd97CmdID.Copy:
                            copyPrgCmd = prgCmds[0];
                            cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
                        //MessageBox.Show("Copy1");
                        break;
                    case (uint)VSConstants.VSStd97CmdID.Cut:
                        {
                            cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
                            cutPrgCmd = prgCmds[0];
                            break;
                        }
                    case (uint)VSConstants.VSStd97CmdID.Paste:
                        {
                            cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
                            pastePrgCmd = prgCmds[0];
                            break;
                        }
                    case (uint)VSConstants.VSStd97CmdID.Redo:
                        {
                            // Enable if actions that have occurred within the RichTextBox 
                            // can be reapplied

                            break;
                        }
                    case (uint)VSConstants.VSStd97CmdID.Undo:
                        {
                            break;
                        }
                    case (uint)VSConstants.VSStd97CmdID.Delete:
                        {
                            deletePrgCmd = prgCmds[0];
                            cmdf = OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
                            break;
                        }
                    default:
                        {
                            return (int)(Constants.OLECMDERR_E_NOTSUPPORTED);
                        }
                }
            }
            else if (pguidCmdGroup == HMIProjectGuids.guidHMIEditorCmdSet)
            {
                // Process our Commands
                switch (prgCmds[0].cmdID)
                {
                    // if we had commands specific to our editor, they would be processed here
                    default:
                        {
                            return (int)(Constants.OLECMDERR_E_NOTSUPPORTED);
                        }
                }
            }
            else
            {
                return (int)(Constants.OLECMDERR_E_NOTSUPPORTED); ;
            }

            prgCmds[0].cmdf = (uint)cmdf;
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Execute a specified command.
        /// </summary>
        /// <param name="pguidCmdGroup">Guid describing which set of command the current command(s) belong to.</param>
        /// <param name="nCmdID">Command that should be executed.</param>
        /// <param name="nCmdexecopt">Options for the command.</param>
        /// <param name="pvaIn">Pointer to input arguments.</param>
        /// <param name="pvaOut">Pointer to command output.</param>
        /// <returns>S_OK if the method succeeds or OLECMDERR_E_NOTSUPPORTED on unsupported command.</returns> 
        /// <remarks>Typically, only the first 2 arguments are used (to identify which command should be run).</remarks>
        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Exec() of: {0}", ToString()));

            if (pguidCmdGroup == VSConstants.GUID_VSStandardCommandSet97)
            {
                // Process standard Visual Studio Commands
                switch (nCmdID)
                {
                    case (uint)VSConstants.VSStd97CmdID.Copy:
                        {
                            Copy();
                            break;
                        }
                    case (uint)VSConstants.VSStd97CmdID.Cut:
                        {
                            Cut();
                            break;
                        }
                    case (uint)VSConstants.VSStd97CmdID.Paste:
                        {
                            Paste();
                            break;
                        }
                    case (uint)VSConstants.VSStd97CmdID.Redo:
                        {
                            break;
                        }
                    case (uint)VSConstants.VSStd97CmdID.Undo:
                        {
                            break;
                        }
                    case (uint)VSConstants.VSStd97CmdID.SelectAll:
                        {
                            break;
                        }
                    case (uint)VSConstants.VSStd97CmdID.Delete:
                        {
                            Remove();
                            break;
                        }
                    default:
                        {
                            return (int)(Constants.OLECMDERR_E_NOTSUPPORTED);
                        }
                }
            }
            else if (pguidCmdGroup == HMIProjectGuids.guidHMIEditorCmdSet)
            {
                switch (nCmdID)
                {
                    // if we had commands specific to our editor, they would be processed here
                    default:
                        {
                            return (int)(Constants.OLECMDERR_E_NOTSUPPORTED);
                        }
                }
            }
            else
            {
                return (int)Constants.OLECMDERR_E_UNKNOWNGROUP;
            }

            return VSConstants.S_OK;
        }
        #endregion

        #region IPersist
        /// <summary>
        /// Retrieves the class identifier (CLSID) of an object.
        /// </summary>
        /// <param name="pClassID">[out] Pointer to the location of the CLSID on return.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IPersist.GetClassID(out Guid pClassID)
        {
            pClassID = HMIProjectGuids.guidHMIEditorFactory;
            return VSConstants.S_OK;
        }

        #endregion

        #region IPersistFileFormat Members

        /// <summary>
        /// Returns the class identifier of the editor type.
        /// </summary>
        /// <param name="pClassID">pointer to the class identifier.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IPersistFileFormat.GetClassID(out Guid pClassID)
        {
            MessageBox.Show("IPersistFileFormat.GetClassID()");
            ((IPersist)this).GetClassID(out pClassID);
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Returns the path to the object's current working file.
        /// </summary>
        /// <param name="ppszFilename">Pointer to the file name.</param>
        /// <param name="pnFormatIndex">Value that indicates the current format of the file as a zero based index
        /// into the list of formats. Since we support only a single format, we need to return zero. 
        /// Subsequently, we will return a single element in the format list through a call to GetFormatList.</param>
        /// <returns>S_OK if the function succeeds.</returns>
        int IPersistFileFormat.GetCurFile(out string ppszFilename, out uint pnFormatIndex)
        {
            MessageBox.Show("IPersistFileFormat.GetCurFile()");
            // We only support 1 format so return its index
            pnFormatIndex = fileFormat;
            ppszFilename = fileName;
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Provides the caller with the information necessary to open the standard common "Save As" dialog box. 
        /// This returns an enumeration of supported formats, from which the caller selects the appropriate format. 
        /// Each string for the format is terminated with a newline (\n) character. 
        /// The last string in the buffer must be terminated with the newline character as well. 
        /// The first string in each pair is a display string that describes the filter, such as "Text Only 
        /// (*.txt)". The second string specifies the filter pattern, such as "*.txt". To specify multiple filter 
        /// patterns for a single display string, use a semicolon to separate the patterns: "*.htm;*.html;*.asp". 
        /// A pattern string can be a combination of valid file name characters and the asterisk (*) wildcard character. 
        /// Do not include spaces in the pattern string. The following string is an example of a file pattern string: 
        /// "HTML File (*.htm; *.html; *.asp)\n*.htm;*.html;*.asp\nText File (*.txt)\n*.txt\n."
        /// </summary>
        /// <param name="ppszFormatList">Pointer to a string that contains pairs of format filter strings.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IPersistFileFormat.GetFormatList(out string ppszFormatList)
        {
            MessageBox.Show("IPersistFileFormat.GetFormatList()");
            string formatList = string.Format(CultureInfo.CurrentCulture, "Test Editor (*{0}){1}*{0}{1}{1}", fileExtension, endLine);
            ppszFormatList = formatList;
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Notifies the object that it has concluded the Save transaction.
        /// </summary>
        /// <param name="pszFilename">Pointer to the file name.</param>
        /// <returns>S_OK if the function succeeds.</returns>
        int IPersistFileFormat.SaveCompleted(string pszFilename)
        {
            MessageBox.Show("IPersistFileFormat.SaveCompleted()");
            if (noScribbleMode)
            {
                return VSConstants.S_FALSE;
            }
            // If NoScribble mode is inactive - Save() operation was completed.
            else
            {
                return VSConstants.S_OK;
            }
        }

        /// <summary>
        /// Initialization for the object.
        /// </summary>
        /// <param name="nFormatIndex">Zero based index into the list of formats that indicates the current format
        /// of the file.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IPersistFileFormat.InitNew(uint nFormatIndex)
        {
            MessageBox.Show("IPersistFileFormat.InitNew()");
            if (nFormatIndex != fileFormat)
            {
                throw new ArgumentException(Resources.ExceptionMessageFormat);
            }
            // until someone change the file, we can consider it not dirty as
            // the user would be annoyed if we prompt him to save an empty file
            isDirty = false;
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Determines whether an object has changed since being saved to its current file.
        /// </summary>
        /// <param name="pfIsDirty">true if the document has changed.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IPersistFileFormat.IsDirty(out int pfIsDirty)
        {
            //MessageBox.Show("IPersistFileFormat.IsDirty()");
            if (isDirty)
            {
                pfIsDirty = 1;
            }
            else
            {
                pfIsDirty = 0;
            }
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Loads the file content into the TextBox.
        /// </summary>
        /// <param name="pszFilename">Pointer to the full path name of the file to load.</param>
        /// <param name="grfMode">file format mode.</param>
        /// <param name="fReadOnly">determines if the file should be opened as read only.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IPersistFileFormat.Load(string pszFilename, uint grfMode, int fReadOnly)
        {
            //MessageBox.Show("IPersistFileFormat.Load()");
            Trace.WriteLine("pszFilename:" + pszFilename);
            //Trace.WriteLine("ProjectDirectory" + );
            if ((pszFilename == null) &&
                 ((fileName == null) || (fileName.Length == 0)))
            {
                throw new ArgumentNullException("pszFilename");
            }

            loading = true;
            int hr = VSConstants.S_OK;
            try
            {
                foreach (HMIEditorPane existPane in StaticMethods.hmIEditorPaneList)
                {
                    if (Path.GetDirectoryName(existPane.fileName) != HMIProjectNode.currentProjectDirectory)
                    {
                        StaticMethods.hmIEditorPaneList.Clear();
                        break;
                    }
                    else if (existPane.fileName == pszFilename)
                    {
                        StaticMethods.hmIEditorPaneList.Clear();
                        break;
                    }
                }
                StaticMethods.hmIEditorPaneList.Add(this);
                Page page;
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Page));
                    TextReader reader = new StreamReader(@pszFilename);
                    page = (Page)serializer.Deserialize(reader);
                    reader.Close();
                }
                catch(InvalidOperationException ex)
                {
                    page = new Page();
                    page.name = Path.GetFileNameWithoutExtension(pszFilename);
                    page.number = "" + TNOPage++;
                    page.size.width = "1024";
                    page.size.height = "768";
                    page.backgroundColor = Convert.ToString(0xFFFFFF, 16);
                    page.enable = "true";
                }
                panel.Name = page.name;
                
                this.thisPage = page;
                editorForm = new HMIEditorForm();
                editorForm.AutoScroll = true;
                editorForm.FormBorderStyle = FormBorderStyle.None;
                editorForm.ControlBox = false;
                editorForm.Text = String.Empty;
                GUIOList = new List<GUIO>();
                
                panel.Location = new System.Drawing.Point(0, 0);
                panel.Size = new System.Drawing.Size(Int32.Parse(page.size.width), Int32.Parse(page.size.height));
                hmiForm.Size = new System.Drawing.Size(Int32.Parse(page.size.width), Int32.Parse(page.size.height));
                transparentPanel.Size = new System.Drawing.Size(Int32.Parse(page.size.width), Int32.Parse(page.size.height));
                editorForm.Size = new System.Drawing.Size(Int32.Parse(page.size.width), Int32.Parse(page.size.height));
                editorForm.Location = new System.Drawing.Point(0, 0);
                int bgColor = Int32.Parse(page.backgroundColor, System.Globalization.NumberStyles.HexNumber);
                System.Drawing.Color rgbColor = System.Drawing.Color.FromArgb(bgColor);
                int r = rgbColor.R;
                int g = rgbColor.G;
                int b = rgbColor.B;
                panel.TabIndex = 1;
                try
                {
                    String path = HMIProjectNode.currentProjectDirectory + @"\" + page.backgroundImage;
                    path = path.Replace(@"\", "/");
                    hmiForm.EditPageBackgroundImageName = path;
                    System.Drawing.Image image = System.Drawing.Image.FromFile(HMIProjectNode.currentProjectDirectory + @"\" + page.backgroundImage);
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(image);
                    //editorForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    //editorForm.BackgroundImage = bitmap;

                    //panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    //panel.BackgroundImage = bitmap;
                }
                catch(FileNotFoundException fnfex)
                {

                }
                editorForm.AllowDrop = true;
                editorForm.DragEnter += panel_DragEnter;
                editorForm.DragDrop += panel_DragDrop;
                
                                
                foreach (GUIO guio in page.guioGroup)
                {
                    GUIOList.Add(guio);
                    if (guio.type.Equals("IpCamera"))
                    {
                        makeIPCamera(guio);
                    }
                    else if (guio.type.Equals("Circle"))
                    {
                        makeCircle(guio);
                    }
                    else if (guio.type.Equals("Rectangle"))
                    {
                        makeRectangle(guio);
                    }
                    else if (guio.type.Equals("PushButton"))
                    {
                        makePushButton(guio);
                    }
                    else if (guio.type.Equals("Dial"))
                    {
                        makeDial(guio);
                    }
                    else if (guio.type.Equals("ProgressBar"))
                    {
                        makeProgressBar(guio);
                    }
                    else if (guio.type.Equals("SliderBar"))
                    {
                        makeSliderBar(guio);
                    }
                    else if (guio.type.Equals("NumPad"))
                    {
                        makeNumPad(guio);
                    }
                    else if (guio.type.Equals("LoginPad"))
                    {
                        makeLoginPad(guio);
                    }
                    else if (guio.type.Equals("Label"))
                    {
                        makeLabel(guio);

                    }
                    else if (guio.type.Equals("DigitalClock"))
                    {
                        makeDigitalClock(guio);
                    }
                    else if (guio.type.Equals("RadioButton"))
                    {
                        makeRadioButton(guio);
                    }
                    else if (guio.type.Equals("LED"))
                    {
                        makeLED(guio);
                    }
                    else if (guio.type.Equals("Panel"))
                    {
                        makePanel(guio);
                    }
                    else if (guio.type.Equals("SetResetButton"))
                    {
                        makeSetResetButton(guio);
                    }
                    else if (guio.type.Equals("IncDecButton"))
                    {
                        makeIncDecButton(guio);
                    }
                    else if (guio.type.Equals("Image"))
                    {
                        makeImage(guio);
                    }
                    else if (guio.type.Equals("Rail"))
                    {
                        makeRail(guio);
                    }
                    else if (guio.type.Equals("WebView"))
                    {
                        makeWebView(guio);
                    }
                    else if (guio.type.Equals("ScrollLabel"))
                    {
                        makeScrollLabel(guio);
                    }
                }


                GUIOList.Sort(ReverseCompareLayer);
                foreach (GUIO guio in GUIOList)
                {
                    System.Windows.Forms.Control[] control = panel.Controls.Find(guio.name, true);
                    control[0].SendToBack();
                }
                hmiForm.EditPageBackgroundColor = bgColor;
            }
            catch(Exception e)
            {

            }

            try
            {

                bool isReload = false;

                // If the new file name is null, then this operation is a reload
                if (pszFilename == null)
                {
                    isReload = true;
                }

                // Show the wait cursor while loading the file
                IVsUIShell vsUiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
                if (vsUiShell != null)
                {
                    // Note: we don't want to throw or exit if this call fails, so
                    // don't check the return code.
                    vsUiShell.SetWaitCursor();
                }

                // Set the new file name
                if (!isReload)
                {
                    // Unsubscribe from the notification of the changes in the previous file.
                    fileName = pszFilename;
                }
                // Load the file
                //editorControl.LoadFile(fileName, RichTextBoxStreamType.PlainText);
                isDirty = false;

                // Notify the load or reload
                //NotifyDocChanged();
            }
            finally
            {
                loading = false;
            }
            return hr;
        }

        private int CompareLayer(GUIO a, GUIO b)
        {
            if (Int32.Parse(a.layer) > Int32.Parse(b.layer))
                return -1;
            else if (Int32.Parse(a.layer) >= Int32.Parse(b.layer))
                return 0;
            else
                return 1;
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
        /// <summary>
        /// Save the contents of the TextBox into the specified file. If doing the save on the same file, we need to
        /// suspend notifications for file changes during the save operation.
        /// </summary>
        /// <param name="pszFilename">Pointer to the file name. If the pszFilename parameter is a null reference 
        /// we need to save using the current file.
        /// </param>
        /// <param name="remember">Boolean value that indicates whether the pszFileName parameter is to be used 
        /// as the current working file.
        /// If remember != 0, pszFileName needs to be made the current file and the dirty flag needs to be cleared after the save.
        ///                   Also, file notifications need to be enabled for the new file and disabled for the old file 
        /// If remember == 0, this save operation is a Save a Copy As operation. In this case, 
        ///                   the current file is unchanged and dirty flag is not cleared.
        /// </param>
        /// <param name="nFormatIndex">Zero based index into the list of formats that indicates the format in which 
        /// the file will be saved.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IPersistFileFormat.Save(string pszFilename, int fRemember, uint nFormatIndex)
        {
            MessageBox.Show("pszFilename: " + pszFilename + "\nfRemember: " + fRemember + "\nnFormatIndex: " + nFormatIndex);

            XmlSerializer serializer = new XmlSerializer(typeof(Page));
            TextWriter writer = new StreamWriter(@pszFilename);
            this.thisPage.guioGroup.RemoveAll(v => true);
            
            this.GUIOList.Sort(CompareLayer);
            foreach (GUIO pageguio in this.GUIOList)
            {
                this.thisPage.guioGroup.Add(pageguio);
            }

            serializer.Serialize(writer, thisPage);
            writer.Close();

            System.Diagnostics.Trace.WriteLine("Directory: "+Path.GetDirectoryName(pszFilename));
            

            // switch into the NoScribble mode
            noScribbleMode = true;
            try
            {
                // If file is null or same --> SAVE
                if (pszFilename == null || pszFilename == fileName)
                {
                    //editorControl.SaveFile(fileName, RichTextBoxStreamType.PlainText);
                    isDirty = false;
                }
                else
                {// If remember --> SaveAs 
                    if (fRemember != 0)
                    {
                        fileName = pszFilename;
                        //editorControl.SaveFile(fileName, RichTextBoxStreamType.PlainText);
                        isDirty = false;
                    }
                    else // Else, Save a Copy As
                    {
                        //editorControl.SaveFile(pszFilename, RichTextBoxStreamType.PlainText);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // switch into the Normal mode
                noScribbleMode = false;
            }
            return VSConstants.S_OK;
        }

        #endregion

        #region IVsPersistDocData Members

        /// <summary>
        /// Close the IVsPersistDocData object.
        /// </summary>
        /// <returns>S_OK if the function succeeds.</returns>
        int IVsPersistDocData.Close()
        {
            MessageBox.Show("IVsPersistDocData.Close()");
            if (editorForm != null)
            {
                editorForm.Dispose();
            }
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Returns the Guid of the editor factory that created the IVsPersistDocData object.
        /// </summary>
        /// <param name="pClassID">Pointer to the class identifier of the editor type.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IVsPersistDocData.GetGuidEditorType(out Guid pClassID)
        {
            MessageBox.Show("IVsPersistDocData.GetGuidEditorType()");
            return ((IPersistFileFormat)this).GetClassID(out pClassID);
        }

        /// <summary>
        /// Used to determine if the document data has changed since the last time it was saved.
        /// </summary>
        /// <param name="pfDirty">Will be set to 1 if the data has changed.</param>
        /// <returns>S_OK if the function succeeds.</returns>
        int IVsPersistDocData.IsDocDataDirty(out int pfDirty)
        {
            //MessageBox.Show("IVsPersistDocData.IsDocDataDirty()");
            return ((IPersistFileFormat)this).IsDirty(out pfDirty);
        }

        /// <summary>
        /// Determines if it is possible to reload the document data.
        /// </summary>
        /// <param name="pfReloadable">set to 1 if the document can be reloaded.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IVsPersistDocData.IsDocDataReloadable(out int pfReloadable)
        {
            // Allow file to be reloaded
            pfReloadable = 1;
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Loads the document data from the file specified.
        /// </summary>
        /// <param name="pszMkDocument">Path to the document file which needs to be loaded.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IVsPersistDocData.LoadDocData(string pszMkDocument)
        {
            //MessageBox.Show("IVsPersistDocData.LoadDocData()");
            return ((IPersistFileFormat)this).Load(pszMkDocument, 0, 0);
        }

        /// <summary>
        /// Called by the Running Document Table when it registers the document data. 
        /// </summary>
        /// <param name="docCookie">Handle for the document to be registered.</param>
        /// <param name="pHierNew">Pointer to the IVsHierarchy interface.</param>
        /// <param name="itemidNew">Item identifier of the document to be registered from VSITEM.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IVsPersistDocData.OnRegisterDocData(uint docCookie, IVsHierarchy pHierNew, uint itemidNew)
        {
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Reloads the document data.
        /// </summary>
        /// <param name="grfFlags">Flag indicating whether to ignore the next file change when reloading the document data.
        /// This flag should not be set for us since we implement the "IVsDocDataFileChangeControl" interface in order to 
        /// indicate ignoring of file changes.
        /// </param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IVsPersistDocData.ReloadDocData(uint grfFlags)
        {
            return ((IPersistFileFormat)this).Load(null, grfFlags, 0);
        }

        /// <summary>
        /// Renames the document data.
        /// </summary>
        /// <param name="grfAttribs">File attribute of the document data to be renamed. See the data type __VSRDTATTRIB.</param>
        /// <param name="pHierNew">Pointer to the IVsHierarchy interface of the document being renamed.</param>
        /// <param name="itemidNew">Item identifier of the document being renamed. See the data type VSITEMID.</param>
        /// <param name="pszMkDocumentNew">Path to the document being renamed.</param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IVsPersistDocData.RenameDocData(uint grfAttribs, IVsHierarchy pHierNew, uint itemidNew, string pszMkDocumentNew)
        {
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Saves the document data. Before actually saving the file, we first need to indicate to the environment
        /// that a file is about to be saved. This is done through the "SVsQueryEditQuerySave" service. We call the
        /// "QuerySaveFile" function on the service instance and then proceed depending on the result returned as follows:
        /// If result is QSR_SaveOK - We go ahead and save the file and the file is not read only at this point.
        /// If result is QSR_ForceSaveAs - We invoke the "Save As" functionality which will bring up the Save file name 
        ///                                dialog 
        /// If result is QSR_NoSave_Cancel - We cancel the save operation and indicate that the document could not be saved
        ///                                by setting the "pfSaveCanceled" flag
        /// If result is QSR_NoSave_Continue - Nothing to do here as the file need not be saved.
        /// </summary>
        /// <param name="dwSave">Flags which specify the file save options:
        /// VSSAVE_Save        - Saves the current file to itself.
        /// VSSAVE_SaveAs      - Prompts the User for a filename and saves the file to the file specified.
        /// VSSAVE_SaveCopyAs  - Prompts the user for a filename and saves a copy of the file with a name specified.
        /// VSSAVE_SilentSave  - Saves the file without prompting for a name or confirmation.  
        /// </param>
        /// <param name="pbstrMkDocumentNew">Pointer to the path to the new document.</param>
        /// <param name="pfSaveCanceled">value 1 if the document could not be saved.</param>
        /// <returns>S_OK if the method succeeds.</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
        int IVsPersistDocData.SaveDocData(VSSAVEFLAGS dwSave, out string pbstrMkDocumentNew, out int pfSaveCanceled)
        {
            MessageBox.Show("IVsPersistDocData.SaveDocData()");
            pbstrMkDocumentNew = null;
            pfSaveCanceled = 0;
            int hr = VSConstants.S_OK;

            switch (dwSave)
            {
                case VSSAVEFLAGS.VSSAVE_Save:
                case VSSAVEFLAGS.VSSAVE_SilentSave:
                    {
                        IVsQueryEditQuerySave2 queryEditQuerySave = (IVsQueryEditQuerySave2)GetService(typeof(SVsQueryEditQuerySave));

                        // Call QueryEditQuerySave
                        uint result = 0;
                        hr = queryEditQuerySave.QuerySaveFile(
                                            fileName,       // filename
                                            0,              // flags
                                            null,           // file attributes
                                            out result);    // result

                        if (ErrorHandler.Failed(hr))
                        {
                            return hr;
                        }

                        // Process according to result from QuerySave
                        switch ((tagVSQuerySaveResult)result)
                        {
                            case tagVSQuerySaveResult.QSR_NoSave_Cancel:
                                // Note that this is also case tagVSQuerySaveResult.QSR_NoSave_UserCanceled because these
                                // two tags have the same value.
                                pfSaveCanceled = ~0;
                                break;

                            case tagVSQuerySaveResult.QSR_SaveOK:
                                {
                                    // Call the shell to do the save for us
                                    IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
                                    hr = uiShell.SaveDocDataToFile(dwSave, this, fileName, out pbstrMkDocumentNew, out pfSaveCanceled);
                                    if (ErrorHandler.Failed(hr))
                                    {
                                        return hr;
                                    }
                                }
                                break;

                            case tagVSQuerySaveResult.QSR_ForceSaveAs:
                                {
                                    // Call the shell to do the SaveAS for us
                                    IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
                                    hr = uiShell.SaveDocDataToFile(VSSAVEFLAGS.VSSAVE_SaveAs, this, fileName, out pbstrMkDocumentNew, out pfSaveCanceled);
                                    if (ErrorHandler.Failed(hr))
                                    {
                                        return hr;
                                    }
                                }
                                break;

                            case tagVSQuerySaveResult.QSR_NoSave_Continue:
                                // In this case there is nothing to do.
                                break;

                            default:
                                throw new COMException(Resources.ExceptionMessageQEQS);
                        }
                        break;
                    }
                case VSSAVEFLAGS.VSSAVE_SaveAs:
                case VSSAVEFLAGS.VSSAVE_SaveCopyAs:
                    {
                        // Make sure the file name as the right extension
                        if (string.Compare(fileExtension, System.IO.Path.GetExtension(fileName), true, CultureInfo.CurrentCulture) != 0)
                        {
                            fileName += fileExtension;
                        }
                        // Call the shell to do the save for us
                        IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
                        hr = uiShell.SaveDocDataToFile(dwSave, this, fileName, out pbstrMkDocumentNew, out pfSaveCanceled);
                        if (ErrorHandler.Failed(hr))
                            return hr;
                        break;
                    }
                default:
                    throw new ArgumentException(Resources.ExceptionMessageSaveFlag);
            };

            return VSConstants.S_OK;
        }

        /// <summary>
        /// Used to set the initial name for unsaved, newly created document data.
        /// </summary>
        /// <param name="pszDocDataPath">String containing the path to the document.
        /// We need to ignore this parameter.
        /// </param>
        /// <returns>S_OK if the method succeeds.</returns>
        int IVsPersistDocData.SetUntitledDocPath(string pszDocDataPath)
        {
            return ((IPersistFileFormat)this).InitNew(fileFormat);
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Handles the TextChanged event of contained RichTextBox object. 
        /// Process changes occurred inside the editor.
        /// </summary>
        /// <param name="sender">The reference to contained RichTextBox object.</param>
        /// <param name="e">The event arguments.</param>
        private void OnTextChange(object sender, EventArgs e)
        {
            // During the load operation the text of the control will change, but
            // this change must not be stored in the status of the document.
            if (!loading)
            {
                // The only interesting case is when we are changing the document
                // for the first time
                if (!isDirty)
                {
                    // Check if the QueryEditQuerySave service allow us to change the file
                    if (!CanEditFile())
                    {
                        // We can not change the file (e.g. a checkout operation failed),
                        // so undo the change and exit.
                        //editorForm.Undo();
                        return;
                    }

                    // It is possible to change the file, so update the status.
                    isDirty = true;
                }
            }
        }

        /// <summary>
        /// Handles the DragEnter event of contained RichTextBox object. 
        /// Process drag effect for the toolbox item.
        /// </summary>
        /// <param name="sender">The reference to contained RichTextBox object.</param>
        /// <param name="e">The event arguments.</param>
        void OnDragEnter(object sender, DragEventArgs e)
        {
            // Check if the source of the drag is the toolbox item
            // created by this sample.
            /*
            if (e.Data.GetDataPresent(typeof(ToolboxItemData)))
            {
                // Only in this case we will enable the drop
                e.Effect = DragDropEffects.Copy;
            }*/
        }

        /// <summary>
        /// Handles the DragDrop event of contained RichTextBox object. 
        /// Process text changes on drop event.
        /// </summary>
        /// <param name="sender">The reference to contained RichTextBox object.</param>
        /// <param name="e">The event arguments.</param>
        void OnDragDrop(object sender, DragEventArgs e)
        {
            /*
            // Check if the picked item is the one we added to the toolbox.
            if (e.Data.GetDataPresent(typeof(ToolboxItemData)))
            {
                ToolboxItemData myData = (ToolboxItemData)e.Data.GetData(typeof(ToolboxItemData));
                editorControl.Text += myData.Content;

                // Specify DragDrop result
                e.Effect = DragDropEffects.Copy;
            }*/
        }

        #endregion

        #region Other methods
        /// <summary>
        /// This function asks to the QueryEditQuerySave service if it is possible to
        /// edit the file.
        /// </summary>
        /// <returns>True if the editing of the file are enabled, otherwise returns false.</returns>
        private bool CanEditFile()
        {
            // Check the status of the recursion guard
            if (gettingCheckoutStatus)
            {
                return false;
            }

            try
            {
                // Set the recursion guard
                gettingCheckoutStatus = true;

                // Get the QueryEditQuerySave service
                IVsQueryEditQuerySave2 queryEditQuerySave = (IVsQueryEditQuerySave2)GetService(typeof(SVsQueryEditQuerySave));

                // Now call the QueryEdit method to find the edit status of this file
                string[] documents = { fileName };
                uint result;
                uint outFlags;

                // Note that this function can pop up a dialog to ask the user to checkout the file.
                // When this dialog is visible, it is possible to receive other request to change
                // the file and this is the reason for the recursion guard.
                int hr = queryEditQuerySave.QueryEditFiles(
                    0,              // Flags
                    1,              // Number of elements in the array
                    documents,      // Files to edit
                    null,           // Input flags
                    null,           // Input array of VSQEQS_FILE_ATTRIBUTE_DATA
                    out result,     // result of the checkout
                    out outFlags    // Additional flags
                );
                if (ErrorHandler.Succeeded(hr) && (result == (uint)tagVSQueryEditResult.QER_EditOK))
                {
                    // In this case (and only in this case) we can return true from this function.
                    return true;
                }
            }
            finally
            {
                gettingCheckoutStatus = false;
            }
            return false;
        }

        /// <summary>
        /// Gets an instance of the RunningDocumentTable (RDT) service which manages the set of currently open 
        /// documents in the environment and then notifies the client that an open document has changed.
        /// </summary>
        private void NotifyDocChanged()
        {
            // Make sure that we have a file name
            if (fileName.Length == 0)
            {
                return;
            }

            // Get a reference to the Running Document Table
            IVsRunningDocumentTable runningDocTable = (IVsRunningDocumentTable)GetService(typeof(SVsRunningDocumentTable));

            // Lock the document
            uint docCookie;
            IVsHierarchy hierarchy;
            uint itemID;
            IntPtr docData;
            int hr = runningDocTable.FindAndLockDocument(
                (uint)_VSRDTFLAGS.RDT_ReadLock,
                fileName,
                out hierarchy,
                out itemID,
                out docData,
                out docCookie
            );
            ErrorHandler.ThrowOnFailure(hr);

            // Send the notification
            hr = runningDocTable.NotifyDocumentChanged(docCookie, (uint)__VSRDTATTRIB.RDTA_DocDataReloaded);

            // Unlock the document.
            // Note that we have to unlock the document even if the previous call failed.
            runningDocTable.UnlockDocument((uint)_VSRDTFLAGS.RDT_ReadLock, docCookie);

            // Check ff the call to NotifyDocChanged failed.
            ErrorHandler.ThrowOnFailure(hr);
        }
        #endregion Other methods

        #endregion
    }
}
