/***************************************************************************
 *   Copyright (C) 2006-2008 by Tomasz Ziobrowski                          *
 *   http://www.3electrons.com                                             *
 *   e-mail: t.ziobrowski@3electrons.com                                   *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/

#ifndef GLED_H
#define GLED_H
#include <QColor>
#include <QtGui>
#include "widgetwithbackground.h"
   class GLed : public WidgetWithBackground
   {
     Q_OBJECT


     public:

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
       drawBackground();
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

     int getLedColor()
     {
         return ledColor;
     }

     void setLedColor(int c)
     {
         ledColor = c;
         m_color.setRgb(c&0xffffff);
         m_color.setAlpha(0xff);
         updateWithBackground();
     }


     public Q_SLOTS:

     void setChecked(bool i)
     {
       m_checked = i;
       updateWithBackground();
       checkChanged( m_checked );
     }

     Q_SIGNALS:

     void checkChanged(bool val);

     protected:

     void initCoordinateSystem(QPainter & painter)
     {
       int side = qMin(width(), height());
       // inicjalizacja paintera
       painter.setRenderHint(QPainter::Antialiasing);
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

     protected:

     bool m_checked;
     bool m_modified;
     QPixmap * m_pixmap;
     QColor m_color;
     int ledColor;

   };

#endif // QLED_H
