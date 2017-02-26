#ifndef GFIXPANEL_H
#define GFIXPANEL_H
#include "widgetwithbackground.h"
//#include <QPainter>
//#include <QWidget>
#include <QColor> 
#include <QtGui> 
//#include <cmath>
//#define PI 3.1415926535897932385128089

class GFixPanel :  public WidgetWithBackground
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{BC97D5C5-D71C-414D-89FE-AB953372E0EC}")
    Q_CLASSINFO("InterfaceID", "{C9704444-DCFB-42EE-A5A8-322D588048D1}")
    Q_CLASSINFO("EventsID", "{96BB162D-3E65-4EFB-B673-904B532A1957}")
    Q_CLASSINFO("ToSuperClass", "GFixPanel")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    // Q_PROPERTY( int m_min READ Min WRITE setMin)
    // Q_PROPERTY()
    // Q_PROPERTY()
    // Q_PROPERTY()
    // Q_PROPERTY()
    // Q_PROPERTY()
     public:  
     
     GFixPanel(QWidget *parent = 0):WidgetWithBackground(parent)
    {
        m_checked = true; 
        m_color = Qt::red; 
        resize(330,330);      
    }
     virtual ~GFixPanel() {};
     
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

   }; 
#endif // GPANEL_H
