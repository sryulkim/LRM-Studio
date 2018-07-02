using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace HMIProject
{
    public class GUIO
    {
        public GUIO Clone()
        {
            GUIO clone = new GUIO();
            clone.name = this.name;
            clone.gVariable = this.gVariable;
            clone.tempGVariable = this.tempGVariable;
            clone.initialState = this.initialState;
            clone.backgroundColor = this.backgroundColor;
            clone.layer = this.layer;

            clone.fillColor = this.fillColor;
            clone.lineColor = this.lineColor;
            clone.lineThickness = this.lineThickness;

            clone.buttonColor = this.buttonColor;
            clone.thickness = this.thickness;
            clone.borderColor = this.borderColor;
            clone.fontSize = this.fontSize;
            clone.fontColor = this.fontColor;
            clone.fontBold = this.fontBold;
            clone.fontUnderline = this.fontUnderline;
            clone.text = this.text;

            clone.min = this.min;
            clone.max = this.max;
            clone.major = this.major;
            clone.minor = this.minor;
            clone.needleColor = this.needleColor;
            clone.dialColor = this.dialColor;

            clone.progressColor = this.progressColor;
            clone.orientation = this.orientation;

            clone.sliderColor = this.sliderColor;
            clone.handleColor = this.handleColor;

            clone.password = this.password;
            clone.pageName = this.pageName;
            clone.numColor = this.numColor;
            clone.numButtonColor = this.numButtonColor;
            clone.resetColor = this.resetColor;
            clone.resetButtonColor = this.resetButtonColor;
            clone.loginColor = this.loginColor;
            clone.loginButtonColor = this.loginButtonColor;
            clone.funcColor = this.funcColor;
            clone.funcButtonColor = this.funcButtonColor;
            clone.digitNumber = this.digitNumber;
            clone.okColor = this.okColor;
            clone.okButtonColor = this.okButtonColor;
            clone.labelColor = this.labelColor;
            clone.clockColor = this.clockColor;
            clone.ipAddress = this.ipAddress;
            clone.port = this.port;

            clone.location.x = this.location.x;
            clone.location.y = this.location.y;
            clone.size.width = this.size.width;
            clone.size.height = this.size.height;

            clone.type = this.type;
            clone.groupID = this.groupID;

            clone.ledColor = this.ledColor;
            clone.bodyColor = this.bodyColor;
            clone.digitColor = this.digitColor;
            clone.count = this.count;
            clone.imageName = this.imageName;
            clone.flickering = this.flickering;
            clone.grayScale = this.grayScale;
            clone.url = this.url;
            clone.transparent = this.transparent;
            clone.angle = this.angle;
            clone.alignment = this.alignment;

            clone.direction = this.direction;
            clone.speed = this.speed;

            clone.startPointID = this.startPointID;
            clone.endPointID = this.endPointID;
            clone.duration = this.duration;
            clone.visibleDuration = this.visibleDuration;
            clone.invisibleDuration = this.invisibleDuration;
            clone.state = this.state;
            clone.scrollFlag = this.scrollFlag;
            clone.startFrame = this.startFrame;
            clone.endFrame = this.endFrame;

            foreach (clickEvent Event in this.clickEvents)
            {
                clickEvent cloneEvent = new clickEvent();
                cloneEvent.type = Event.type;
                cloneEvent.number = Event.number;
                cloneEvent.gName = Event.gName;
                cloneEvent.GUIOType = Event.GUIOType;
                cloneEvent.property = Event.property;
                cloneEvent.value = Event.value;
                clone.clickEvents.Add(cloneEvent);
            }

            foreach (vertex vtx in this.vertexes)
            {
                vertex cloneVtx = new vertex();
                cloneVtx.x = vtx.x;
                cloneVtx.y = vtx.y;
                cloneVtx.angle = vtx.angle;
                cloneVtx.pointID = vtx.pointID;
                cloneVtx.scale = vtx.scale;
                clone.vertexes.Add(cloneVtx);
            }

            foreach (flickeringImage img in this.flickeringImages)
            {
                flickeringImage cloneImg = new flickeringImage();
                cloneImg.imageName = img.imageName;
                clone.flickeringImages.Add(cloneImg);
            }

            return clone;
        }
        #region Global Property
        public string name;
        public string gVariable;
        public string tempGVariable;
        public string initialState;
        public string backgroundColor;
        public string layer;
        #endregion
        public GUIOLocation location;
        public GUIOSize size;

        #region Figure Property
        public string fillColor;
        public string lineColor;
        public string lineThickness;
        #endregion

        #region Button Property
        public string buttonColor;
        public string thickness;
        public string borderColor;
        public string fontSize;
        public string fontColor;
        public string fontBold;
        public string fontUnderline;
        public string text;
        #endregion

        #region Dial Property
        public string min;
        public string max;
        public string major;
        public string minor;
        public string needleColor;
        public string dialColor;
        #endregion

        #region ProgressBar Property
        public string progressColor;
        public string orientation;
        #endregion

        #region SliderBar Property
        public string sliderColor;
        public string handleColor;
        #endregion

        #region login pad property
        public string password;
        public string pageName;
        public string numColor;
        public string numButtonColor;
        public string resetColor;
        public string resetButtonColor;
        public string loginColor;
        public string loginButtonColor;
        public string funcColor;
        public string funcButtonColor;
        public string digitNumber;
        #endregion
        public string okColor;
        public string okButtonColor;

        public string labelColor;

        public string clockColor;

        public string ledColor;

        public string ipAddress;
        public string port;

        public string digitColor;
        public string bodyColor;

        public string groupID;
        public string count;
        public string url;
        public string angle;
        public string alignment;
        public string state;
        public string startFrame;
        public string endFrame;
        public string visible;
        public string scale;

        public string transparent;

        public List<clickEvent> clickEvents;
        public List<vertex> vertexes;
        public List<flickeringImage> flickeringImages;

        public string imageName;
        public string flickering;
        public string grayScale;
        public string direction;
        public string speed;
        public string scrollFlag;

        public string startPointID;
        public string endPointID;
        public string duration; public string visibleDuration;
        public string invisibleDuration;

        [XmlAttribute]
        public string type;

        public GUIO()
        {
            this.clickEvents = new List<clickEvent>();
            this.vertexes = new List<vertex>();
            this.location = new GUIOLocation();
            this.size = new GUIOSize();
            this.flickeringImages = new List<flickeringImage>();

            #region Global Property
            this.name="";
            this.gVariable="";
            this.tempGVariable="";
            this.initialState="";
            this.backgroundColor="";
            this.layer="";
            #endregion

            #region Figure Property
            this.fillColor="";
            this.lineColor="";
            this.lineThickness="";
            #endregion

            #region Button Property
            this.buttonColor="";
            this.thickness="";
            this.borderColor="";
            this.fontSize="";
            this.fontColor="";
            this.fontBold="";
            this.fontUnderline="";
            this.text="";
            #endregion

            #region Dial Property
            this.min="";
            this.max="";
            this.major="";
            this.minor="";
            this.needleColor="";
            this.dialColor="";
            #endregion

            #region ProgressBar Property
            this.progressColor="";
            this.orientation="";
            #endregion

            #region SliderBar Property
            this.sliderColor="";
            this.handleColor="";
            #endregion

            #region login pad property
            this.password="";
            this.pageName="";
            this.numColor="";
            this.numButtonColor="";
            this.resetColor="";
            this.resetButtonColor="";
            this.loginColor="";
            this.loginButtonColor="";
            this.funcColor="";
            this.funcButtonColor="";
            this.digitNumber="";
            #endregion

            this.okColor="";
            this.okButtonColor="";

            this.labelColor="";

            this.clockColor="";

            this.ledColor="";

            this.ipAddress="";
            this.port="";

            this.digitColor="";
            this.bodyColor="";

            this.groupID="";
            this.count="";
            this.url="";
            this.angle="";
            this.alignment="";
            this.state="";
            this.startFrame="";
            this.endFrame="";
            this.visible="";
            this.scale="";

            this.transparent="";

            this.imageName="";
            this.flickering="";
            this.grayScale="";
            this.direction="";
            this.speed="";
            this.scrollFlag="";

            this.startPointID="";
            this.endPointID="";
            this.duration=""; this.visibleDuration="";
            this.invisibleDuration="";

            this.type="";


        }
    } 

    public class GUIOLocation
    {
        [XmlAttribute]
        public string x;
        [XmlAttribute]
        public string y;
    }

    public class GUIOSize
    {
        [XmlAttribute]
        public string width;
        [XmlAttribute]
        public string height;
    }

    public class clickEvent
    {
        [DisplayName("이벤트 타입")]
        public string type { get; set; }
        public string number { get; set; }
        [DisplayName("G-Name")]
        public string gName { get; set; }
        [DisplayName("GUIO 타입")]
        public string GUIOType { get; set; }
        [DisplayName("속성")]
        public string property { get; set; }
        [DisplayName("값")]
        public string value { get; set; }
    }


    public class vertex
    {
        [XmlAttribute]
        [DisplayName("Point ID")]
        public string pointID { get; set; }
        [XmlAttribute]
        [DisplayName("X Point")]
        public string x { get; set; }
        [XmlAttribute]
        [DisplayName("Y Point")]
        public string y { get; set; }
        [XmlAttribute]
        [DisplayName("Scale")]
        public string scale { get; set; }
        [XmlAttribute]
        [DisplayName("Angle")]
        public string angle { get; set; }
    }

    public class flickeringImage
    {
        [XmlAttribute]
        [DisplayName("Image Name")]
        public string imageName { get; set; }
    }
}
