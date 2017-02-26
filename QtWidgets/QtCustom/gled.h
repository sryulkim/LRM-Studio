#ifndef GLED_H
#define GLED_H
#include <QColor> 
#include <QtGui> 
#include "widgetwithbackground.h"
   class GLed : public WidgetWithBackground
   {
     Q_OBJECT
    Q_CLASSINFO("ClassID", "{72F04CB6-BACF-49B7-9C29-DE0180EBA833}")
    Q_CLASSINFO("InterfaceID", "{27036263-33FF-4EED-BA44-343BE0FD3A7B}")
    Q_CLASSINFO("EventsID", "{76D935E7-62D2-409A-977E-C8C65B8DD722}")
    Q_CLASSINFO("ToSuperClass", "GLed")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")
     
    Q_PROPERTY( int ledColor READ LedColor WRITE setLedColor )
     public:  
     
     int LedColor(){
         return ledColor;
     }

     void setLedColor(int lc){
         ledColor = lc;
         m_color.setRgb(lc&0xffffff);
         m_color.setAlpha(0xff);
         updateWithBackground(); 
     }

     GLed(QWidget *parent = 0):WidgetWithBackground(parent)
    {
        m_checked = true; 
        m_color = Qt::red; 
        resize(330,330);      
    }
     virtual ~GLed() {};
     
     void paintEvent(QPaintEvent * event)
    {
        QPainter painter(this); 
        initCoordinateSystem(painter); 
        // *** Draw circle */ 
        int h,s,v,a; 
        QColor c,back = color(); 
        c=back; 
        
        // Kolor diody 
        if (!m_checked || !isEnabled()) 
        { 
            back.getHsv(&h,&s,&v,&a);
            s*=0.20; 
            back.setHsv(h,s,v,a); 
        }
        painter.setBrush(back); 
        
        // obwudka diody 
        QPen pen;
        // przyciemnienie obwudki 
        c.getHsv(&h,&s,&v,&a); 
        s*=0.5; 
        c.setHsv(h,s,v,a);  

        pen.setColor(c); 
        pen.setWidthF(3.0); 
            
        painter.drawEllipse(-149,-149,299,299);
        painter.end(); 
        
        // odblask ¶wiat³a diody 
        drawBackground(); // to maluje na tym co dotychczas to co jest w bitmapce 
    }
     
     bool isChecked () const 
    {
        return m_checked; 
    } 
        
     
     QColor color() const
    {
        return m_color; 
    }
     void setColor(QColor i)
    { 
        m_color = i; 
        updateWithBackground(); 
    }
     
     protected:
     
     void initCoordinateSystem(QPainter & painter)
    {
        int side = qMin(width(), height());
        // inicjalizacja paintera
        //painter.setRenderHint(QPainter::Antialiasing);
        painter.translate(width() / 2, height() / 2);
        painter.scale(side / 330.0, side / 330.0);
    }

     
     void paintBackground(QPainter & painter)
    {
        initCoordinateSystem(painter); 
        painter.setPen(Qt::NoPen); 
        QRadialGradient shine(QPointF(-40.0,-40.0),120.0,QPointF(-40,-40));
        QColor white1(255,255,255,200);
        QColor white0(255,255,255,0);
        
        shine.setColorAt(0.0,white1); 
        shine.setColorAt(1.0,white0); 
        
        painter.setBrush(shine); 
        painter.drawEllipse(-147,-147,297,297); 
            
    }
     
     bool m_checked; 
     QColor m_color; 
     int ledColor;
   }; 
   
#endif // QLED_H 
