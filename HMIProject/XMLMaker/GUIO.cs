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
            clone.address = this.address;

            clone.location.x = this.location.x;
            clone.location.y = this.location.y;
            clone.size.width = this.size.width;
            clone.size.height = this.size.height;

            clone.type = this.type;

            clone.ledColor = this.ledColor;
            clone.bodyColor = this.bodyColor;
            clone.digitColor = this.digitColor;
            clone.count = this.count;
            clone.imageName = this.imageName;
            clone.grayScale = this.grayScale;
            clone.url = this.url;
            clone.transparent = this.transparent;
            clone.angle = this.angle;

            clone.direction = this.direction;
            clone.speed = this.speed;


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
                clone.vertexes.Add(cloneVtx);
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

        public string address;

        public string digitColor;
        public string bodyColor;

        public string count;
        public string url;
        public string angle;
        public string visible;
        public string scale;

        public string transparent;

        public List<clickEvent> clickEvents;
        public List<vertex> vertexes;

        public string imageName;
        public string grayScale;
        public string direction;
        public string speed;

        [XmlAttribute]
        public string type;

        public GUIO()
        {
            this.clickEvents = new List<clickEvent>();
            this.vertexes = new List<vertex>();
            this.location = new GUIOLocation();
            this.size = new GUIOSize();
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
        [DisplayName("X Point")]
        public string x { get; set; }
        [XmlAttribute]
        [DisplayName("Y Point")]
        public string y { get; set; }
        [XmlAttribute]
        [DisplayName("Scale")]
        public string scale { get; set; }
    }
}
