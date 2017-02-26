/****************************************************************************
**
** Copyright (C) 2015 The Qt Company Ltd.
** Contact: http://www.qt.io/licensing/
**
** This file is part of the examples of the Qt Toolkit.
**
** $QT_BEGIN_LICENSE:BSD$
** You may use this file under the terms of the BSD license as follows:
**
** "Redistribution and use in source and binary forms, with or without
** modification, are permitted provided that the following conditions are
** met:
**   * Redistributions of source code must retain the above copyright
**     notice, this list of conditions and the following disclaimer.
**   * Redistributions in binary form must reproduce the above copyright
**     notice, this list of conditions and the following disclaimer in
**     the documentation and/or other materials provided with the
**     distribution.
**   * Neither the name of The Qt Company Ltd nor the names of its
**     contributors may be used to endorse or promote products derived
**     from this software without specific prior written permission.
**
**
** THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
** "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
** LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
** A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
** OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
** SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
** LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
** DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
** THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
** (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
** OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE."
**
** $QT_END_LICENSE$
**
****************************************************************************/

#ifndef QWT_WHEEL_BOX_H
#define QWT_WHEEL_BOX_H

#include <QWidget>
#include <qlabel.h>
#include <qlayout.h>
#include <qwt_wheel.h>
#include <qwt_thermo.h>
#include <qwt_scale_engine.h>
#include <qwt_transform.h>
#include <qwt_color_map.h>

class QLabel;
class QwtThermo;
class QwtWheel;

//! [0]
class QwtWheelBox : public QWidget
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{DA0A3A80-F4A2-4088-8E28-34D6D9413867}")
    Q_CLASSINFO("InterfaceID", "{BA9EA385-0956-46EE-ACA9-053B406E2DE6}")
    Q_CLASSINFO("EventsID", "{36CF7C41-FB09-4888-B972-F35F525B6511}")
    Q_CLASSINFO("ToSuperClass", "QwtWheelBox")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY(int type READ getType WRITE setType)
    Q_PROPERTY(int orientation READ getOrientation WRITE setOrientation)
public:
    QwtWheelBox(QWidget *parent = 0)
        : QWidget(parent), type(0), orientation(1)
    {
        QWidget *box = createBox();
        d_label = new QLabel( this );
        d_label->setAlignment( Qt::AlignHCenter | Qt::AlignTop );

        QBoxLayout *layout = new QVBoxLayout( this );
        layout->addWidget( box );
        layout->addWidget( d_label );

        setNum( d_wheel->value() );

        connect( d_wheel, SIGNAL( valueChanged( double ) ), 
            this, SLOT( setNum( double ) ) );
    }

    int getType() const
    {
        return type;
    }

    void setType(int tp)
    {
        type = tp;
    }

    int getOrientation() const
    {
        return orientation;
    }

    void setOrientation(int o)
    {
        if(o == 1)
        {
            orientation = o;
            e_orientation = Qt::Horizontal;
        }
        else if(o == 2)
        {
            orientation = o;
            e_orientation = Qt::Vertical;
        }
        else
        {
            orientation = 1;
            e_orientation = Qt::Horizontal;
        }
    }

private Q_SLOTS:
    void setNum( double v )
    {
        QString text;
        text.setNum( v, 'f', 2 );

        d_label->setText( text );
    }

private:
    int type;
    int orientation;
    Qt::Orientation e_orientation;
    QwtWheel *d_wheel;
    QwtThermo *d_thermo;
    QLabel *d_label;

    
    QWidget *createBox()
    {
        d_wheel = new QwtWheel();
        d_wheel->setValue( 80 );
        d_wheel->setWheelWidth( 20 );
        d_wheel->setMass( 1.0 );

        d_thermo = new QwtThermo();
        d_thermo->setOrientation( e_orientation );

        if ( e_orientation == Qt::Horizontal )
        {
            d_thermo->setScalePosition( QwtThermo::LeadingScale );
            d_wheel->setOrientation( Qt::Vertical );
        }
        else
        {
            d_thermo->setScalePosition( QwtThermo::TrailingScale );
            d_wheel->setOrientation( Qt::Horizontal );
        }

        switch( type )
        {
            case 0:
            {
                QwtLinearColorMap *colorMap = new QwtLinearColorMap(); 
                colorMap->setColorInterval( Qt::blue, Qt::red );
                d_thermo->setColorMap( colorMap );

                break;
            }
            case 1:
            {
                QwtLinearColorMap *colorMap = new QwtLinearColorMap();
                colorMap->setMode( QwtLinearColorMap::FixedColors );

                int idx = 4;

                colorMap->setColorInterval( Qt::GlobalColor( idx ),
                    Qt::GlobalColor( idx + 10 ) );
                for ( int i = 1; i < 10; i++ )
                {
                    colorMap->addColorStop( i / 10.0, 
                        Qt::GlobalColor( idx + i ) );
                }

                d_thermo->setColorMap( colorMap );
                break;
            }
            case 2:
            {
                d_wheel->setRange( 10, 1000 );
                d_wheel->setSingleStep( 1.0 );

                d_thermo->setScaleEngine( new QwtLogScaleEngine );
                d_thermo->setScaleMaxMinor( 10 );

                d_thermo->setFillBrush( Qt::darkCyan );
                d_thermo->setAlarmBrush( Qt::magenta );
                d_thermo->setAlarmLevel( 500.0 );

                d_wheel->setValue( 800 );

                break;
            }
            case 3:
            {
                d_wheel->setRange( -1000, 1000 );
                d_wheel->setSingleStep( 1.0 );
                d_wheel->setPalette( QColor( "Tan" ) );

                QwtLinearScaleEngine *scaleEngine = new QwtLinearScaleEngine();
                scaleEngine->setTransformation( new QwtPowerTransform( 2 ) );

                d_thermo->setScaleMaxMinor( 5 );
                d_thermo->setScaleEngine( scaleEngine );

                QPalette pal = palette();
                pal.setColor( QPalette::Base, Qt::darkGray );
                pal.setColor( QPalette::ButtonText, QColor( "darkKhaki" ) );

                d_thermo->setPalette( pal );
                break;
            }
            case 4:
            {
                d_wheel->setRange( -100, 300 );
                d_wheel->setInverted( true );

                QwtLinearColorMap *colorMap = new QwtLinearColorMap(); 
                colorMap->setColorInterval( Qt::darkCyan, Qt::yellow );
                d_thermo->setColorMap( colorMap );

                d_wheel->setValue( 243 );

                break;
            }
            case 5:
            {
                d_thermo->setFillBrush( Qt::darkCyan );
                d_thermo->setAlarmBrush( Qt::magenta );
                d_thermo->setAlarmLevel( 60.0 );

                break;
            }
            case 6:
            {
                d_thermo->setOriginMode( QwtThermo::OriginMinimum );
                d_thermo->setFillBrush( QBrush( "DarkSlateBlue" ) );
                d_thermo->setAlarmBrush( QBrush( "DarkOrange" ) );
                d_thermo->setAlarmLevel( 60.0 );

                break;
            }
            case 7:
            {
                d_wheel->setRange( -100, 100 );

                d_thermo->setOriginMode( QwtThermo::OriginCustom );
                d_thermo->setOrigin( 0.0 );
                d_thermo->setFillBrush( Qt::darkBlue );

                break;
            }
        }

        double min = d_wheel->minimum();
        double max = d_wheel->maximum();

        if ( d_wheel->isInverted() )
            qSwap( min, max );

        d_thermo->setScale( min, max );
        d_thermo->setValue( d_wheel->value() );

        connect( d_wheel, SIGNAL( valueChanged( double ) ), 
            d_thermo, SLOT( setValue( double ) ) );

        QWidget *box = new QWidget();

        QBoxLayout *layout;

        if ( e_orientation == Qt::Horizontal )
            layout = new QHBoxLayout( box );
        else
            layout = new QVBoxLayout( box );

        layout->addWidget( d_thermo, Qt::AlignCenter );
        layout->addWidget( d_wheel );

        return box;
    }

};
//! [0]

#endif // QWT_DIAL_BOX_H
