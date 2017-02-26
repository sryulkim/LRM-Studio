#ifndef GPANEL_H
#define GPANEL_H
#include "widgetwithbackground.h"
#include "gpanel.h"
#include <assert.h>
#include <cmath>
#include <QPainter>
#define PI 3.1415926535897932385128089
class GPanel :  public WidgetWithBackground
{
    Q_OBJECT
public:
    GPanel(QWidget *parent=0) : WidgetWithBackground(parent)
    {
        m_min = m_minimum =0.0;
        m_max = m_maximum = 100.0;
        m_digitOffset = 155.0;
        m_nominal = 50;
        m_critical = 80;
        m_opacity = 1;
        m_needleColor.setRgb(0xff0000);
        m_digitColor.setRgb(0x000000);
        m_bodyColor.setRgb(0xffffff);
        m_value =0.0;
        m_digitFont.setPointSize(12);
        m_major = 5;
        m_minor = 5;
        this->setSizePolicy(QSizePolicy::Expanding,QSizePolicy::Expanding);
        //resize(311,311);
        //resize(parent->width(),parent->height());
        assert(m_max-m_min !=0);
    }
    void setMinimum(double i)
    {
        if((m_maximum - i) > 0.00001)
        {
            m_minimum = i;
            m_min = m_minimum;
            m_value = m_min;
            updateWithBackground();
        }
    }
    void setMaximum(double i)
    {
        if((i-m_minimum) > 0.00001)
        {
            m_maximum = i;
            m_max = m_maximum;
            updateWithBackground();
        }
    }
    double value() const {return m_value;}

    void setNominal(double i) {m_nominal=i; updateWithBackground();}
    void setCritical(double i) {m_critical=i; updateWithBackground();}

    void setDigitOffset(double v){m_digitOffset = v; updateWithBackground();}
    void setDigitFont(QFont f){m_digitFont =f; updateWithBackground();}
    void setDigitColor(unsigned int color){m_digitColor=QColor(color);updateWithBackground();}
    void setNeedleColor(unsigned int color){m_needleColor=QColor(color);updateWithBackground();}
    void setBodyColor(unsigned int color){m_bodyColor=QColor(color);updateWithBackground();}

    void setOpacity(double i){m_opacity=i;updateWithBackground();}
    void setMajor(int i){m_major=i;
                         updateWithBackground();}
    void setMinor(int i){m_minor=i;
                         updateWithBackground();}
public Q_SLOTS:
    void setValue(int val)
    {
        if(m_value != val)
        {
            m_value = val;
            update();
            valueChanged(val);
            valueChanged((int)val);
        }
    }
    void setValue(double val)
    {
        if(m_value != val)
        {
            m_value = val;
            update();
            valueChanged(val);
            valueChanged((double)val);
        }
    }
Q_SIGNALS:
    void valueChanged(int val);
    void valueChanged(double val);
protected:
  void paintEvent(QPaintEvent *event)
  {
      drawBackground();
      QPainter painter(this);
      initCoordinateSystem(painter);
      static const int hand[12] = {-4, 0, -1, 129, 1, 129, 4, 0, 8, -50, -8, -50};
      QPainterPath hand_path;
      hand_path.moveTo(QPointF(hand[0],hand[1]));
      for(int i=2;i<8;i+=2)
          hand_path.lineTo(hand[i],hand[i+1]);

      painter.save();
      painter.rotate(100);
      painter.setPen(Qt::NoPen);
      painter.setOpacity(m_opacity);
      painter.setBrush(QBrush(m_needleColor));
      painter.rotate( ((value()-m_min)*160.0)/static_cast<double>(m_max - m_min));
      painter.drawPath(hand_path);
      painter.setBrush(QBrush(QColor(200,200,200)));
      painter.drawEllipse(QPointF(0,0),20,20);
      painter.restore();
  } 	 // inherited from WidgetWithBackground
  void paintBackground(QPainter & painter)
  {

      initCoordinateSystem(painter);

      QPen Pen(m_digitColor);
      Pen.setWidth(4);
      painter.setPen(Pen);
      painter.setOpacity(m_opacity);

      QRadialGradient back(QPointF(0.0,0.0),182,QPointF(-12.0, -15.0));
      back.setColorAt(0.0,Qt::white);
      back.setColorAt(0.0,QColor(250,250,250));
      back.setColorAt(1.0,QColor(215,215,215));

      painter.setBrush(QBrush(back));
      painter.setPen(Qt::NoPen);
      painter.drawPie(QRect(-142,-142,284,284),160,2560);
  //    painter.drawEllipse(-142,-142,284,284);
      //draw nominal
      painter.setPen(Qt::NoPen);
      painter.setBrush(QColor(0,200,0));
      int angle = static_cast<int>((2560*(m_nominal - m_min))/(m_max - m_min));
      if(m_min <= m_nominal && m_nominal < m_max)
          painter.drawPie(QRect(-141,-141,282,282),16*10,2560 - angle % 5760);
      //draw critical
      painter.setBrush(QBrush(Qt::red));
      angle = static_cast<int> ((2560*(m_critical - m_min))/(m_max-m_min));
      if(m_min <= m_nominal && m_nominal < m_max)
          painter.drawPie(QRect(-141,-141,282,282),16*10,2560 - angle % 5760); //16 * 160 - angle/360*16
      painter.setBrush(QBrush(m_bodyColor));
      painter.setPen(Qt::NoPen);
      painter.drawPie(QRect(-129,-129,258,258),144,2560);
  //    painter.drawEllipse(-129,-129,258,258);

      painter.rotate(100);

      //draw scale bar
      painter.save();
      painter.setBrush(QBrush(QColor(m_digitColor)));
      int line_length = 10;
      int total_scale_num = m_major+1+(m_minor-1)*m_major;
      double scaleAngle = 160/(double)(total_scale_num-1);
      for(int i=0;i<total_scale_num;i++)
      {
          Pen.setWidth(3);
          painter.setPen(Pen);
          if(i%(total_scale_num/m_major)) painter.drawLine(0,140,0,140 - line_length);
          else{
  //            painter.setPen(Qt::NoPen);
              painter.drawLine(0,140,0,140 - (line_length +15));
          }
          painter.rotate(scaleAngle);

      }
      painter.restore();

      {
          painter.setPen(m_digitColor);
          painter.rotate(-100);
          painter.setFont(m_digitFont);
          double majorScaleAngle = 160.0/m_major;
          for(int i=0;i<m_major+1;i++)
          {
              double v = m_min + i*(m_max - m_min)/m_major;
              if(fabs(v) < 0.000001) v= 0.0;
              QString val = QString("%1").arg(v);
              QSize Size = painter.fontMetrics().size(Qt::TextSingleLine, val);
              painter.save();
              painter.translate(m_digitOffset*cos((-17*PI/18.0)+i*majorScaleAngle*PI/180.0),m_digitOffset*sin((-17*PI/18.0)+i*majorScaleAngle*PI/180.0));
  //            qDebug() << "x : " << m_digitOffset*cos((-17*PI/18.0)+static_cast<double>(i)*majorScaleAngle*PI/180.0);
  //            qDebug() << "y : " << m_digitOffset*sin((-17*PI/18.0)+static_cast<double>(i)*majorScaleAngle*PI/180.0);
  //            qDebug() << "angle : " << scaleAngle;
              painter.drawText(QPointF(Size.width()/-2.0, Size.height()/4.0),val);
              painter.restore();
          }
      }
  }// inherited form WidgetWithBackground
  void initCoordinateSystem(QPainter & painter)
  {
      int side = qMin(width(), height());
      painter.setRenderHint(QPainter::Antialiasing);
      painter.translate(width()/2,height()/2);
      painter.scale(side / 335.0, side / 335.0);
  }

  bool calcMaxMin();
  double m_min ,m_max ,m_minimum ,m_maximum;
  double m_value;
  double m_nominal, m_critical;
  double m_digitOffset;
  double m_opacity;
  int m_major,m_minor;
  QFont m_digitFont;
  QColor m_needleColor;
  QColor m_digitColor;
  QColor m_bodyColor;
};

#endif // GPANEL_H
