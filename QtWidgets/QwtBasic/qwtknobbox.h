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

#ifndef QWT_KNOB_BOX_H
#define QWT_KNOB_BOX_H

#include <QWidget>
#include <qlabel.h>
#include <qlayout.h>
#include <qwt_knob.h>
#include <qwt_scale_engine.h>
#include <qwt_transform.h>

class QLabel;
class QwtDial;

//! [0]
class QwtKnobBox : public QWidget
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{031CE66B-A9DD-4C2A-B6C5-5816A775B300}")
    Q_CLASSINFO("InterfaceID", "{EC9ECB46-6DD7-4475-9A45-77CF8FFADF0F}")
    Q_CLASSINFO("EventsID", "{DDC64792-5439-4F5C-A8D5-7831361BF0F1}")
    Q_CLASSINFO("ToSuperClass", "QwtKnobBox")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY(int type READ getType WRITE setType)
public:
    QwtKnobBox(QWidget *parent = 0)
        : QWidget(parent), type(0)
    {
        d_knob = createKnob();
        d_knob->setKnobWidth( 100 );

        d_label = new QLabel( this );
        d_label->setAlignment( Qt::AlignCenter );
        d_label->setText("Knob Text");

        QVBoxLayout *layout = new QVBoxLayout( this );;
        layout->setSpacing( 0 );
        layout->addWidget( d_knob, 10 );
        layout->addWidget( d_label );
        layout->addStretch( 10 );

        connect( d_knob, SIGNAL( valueChanged( double ) ), 
            this, SLOT( setNum( double ) ) );

        setNum( d_knob->value() );
    }

    int getType() const
    {
        return type;
    }

    void setType(int tp)
    {
        type = tp;
        d_knob = createKnob();
        d_knob->setKnobWidth( 100 );
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
    QwtKnob *d_knob;
    QLabel *d_label;

    QwtKnob *createKnob() const
    {
        QwtKnob *knob = new QwtKnob();
        knob->setTracking( true );

        switch( type )
        {
            case 0:
            {
                knob->setKnobStyle( QwtKnob::Sunken );
                knob->setMarkerStyle( QwtKnob::Nub );
                knob->setWrapping( true );
                knob->setNumTurns( 4 );
                knob->setScaleStepSize( 10.0 );
                knob->setScale( 0, 400 );
                knob->setTotalSteps( 400 );
                break;
            }
            case 1:
            {
                knob->setKnobStyle( QwtKnob::Sunken );
                knob->setMarkerStyle( QwtKnob::Dot );
                break;
            }
            case 2:
            {
                knob->setKnobStyle( QwtKnob::Sunken );
                knob->setMarkerStyle( QwtKnob::Tick );
                
                QwtLinearScaleEngine *scaleEngine = new QwtLinearScaleEngine( 2 );
                scaleEngine->setTransformation( new QwtPowerTransform( 2 ) );
                knob->setScaleEngine( scaleEngine );

                QList< double > ticks[ QwtScaleDiv::NTickTypes ];
                ticks[ QwtScaleDiv::MajorTick ] << 0 << 4 
                    << 16 << 32 << 64 << 96 << 128;
                ticks[ QwtScaleDiv::MediumTick ] << 24 << 48 << 80 << 112;
                ticks[ QwtScaleDiv::MinorTick ] 
                    << 0.5 << 1 << 2 
                    << 7 << 10 << 13
                    << 20 << 28 
                    << 40 << 56 
                    << 72 << 88 
                    << 104 << 120; 
    
                knob->setScale( QwtScaleDiv( 0, 128, ticks ) );

                knob->setTotalSteps( 100 );
                knob->setStepAlignment( false );
                knob->setSingleSteps( 1 );
                knob->setPageSteps( 5 );

                break;
            }
            case 3:
            {
                knob->setKnobStyle( QwtKnob::Flat );
                knob->setMarkerStyle( QwtKnob::Notch );
                knob->setScaleEngine( new QwtLogScaleEngine() );
                knob->setScaleStepSize( 1.0 );
                knob->setScale( 0.1, 1000.0 );
                knob->setScaleMaxMinor( 10 );
                break;
            }
            case 4:
            {
                knob->setKnobStyle( QwtKnob::Raised );
                knob->setMarkerStyle( QwtKnob::Dot );
                knob->setWrapping( true );
                break;
            }
            case 5:
            {
                knob->setKnobStyle( QwtKnob::Styled );
                knob->setMarkerStyle( QwtKnob::Triangle );
                knob->setTotalAngle( 180.0 );
                knob->setScale( 100, -100 );
                break;
            }
        }

        return knob;
    }
};
//! [0]

#endif // QWT_DIAL_BOX_H
