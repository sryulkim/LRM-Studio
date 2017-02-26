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

#ifndef QWT_DIAL_BOX_H
#define QWT_DIAL_BOX_H

#include <QWidget>
#include <qlabel.h>
#include <qlayout.h>
#include <qwt_dial.h>
#include <qwt_dial_needle.h>
#include <qwt_scale_engine.h>
#include <qwt_transform.h>
#include <qwt_round_scale_draw.h>

class QLabel;
class QwtDial;

//! [0]
class QwtDialBox : public QWidget
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{D426AA45-DAF9-48A8-9180-B2E4E2CCDDF4}")
    Q_CLASSINFO("InterfaceID", "{35575BD4-36F2-4A53-9588-DEE57F683A0D}")
    Q_CLASSINFO("EventsID", "{7F2737D1-B922-4F11-ABCF-640C29CBAA78}")
    Q_CLASSINFO("ToSuperClass", "QwtDialBox")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY(int type READ getType WRITE setType)
public:
    QwtDialBox(QWidget *parent = 0)
        : QWidget(parent), type(0)
    {
        d_dial = createDial();
        d_label = new QLabel( this );
        d_label->setText("Dial Text");
        d_label->setAlignment( Qt::AlignCenter );

        QVBoxLayout *layout = new QVBoxLayout( this );;
        layout->setSpacing( 0 );
        layout->addWidget( d_dial );
        layout->addWidget( d_label );

        connect( d_dial, SIGNAL( valueChanged( double ) ), 
            this, SLOT( setNum( double ) ) );

        setNum( d_dial->value() );
    }

    int getType() const
    {
        return type;
    }

    void setType(int tp)
    {
        type = tp;
        d_dial = createDial();
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
    QwtDial *d_dial;
    QLabel *d_label;

    
    QwtDial *createDial() const
    {
        QwtDial *dial = new QwtDial();
        dial->setTracking( true );
        dial->setFocusPolicy( Qt::StrongFocus );
        dial->setObjectName( QString( "Dial %1" ).arg( type + 1 ) );

        QColor needleColor( Qt::red );

        switch( type )
        {
            case 0:
            {
                dial->setOrigin( 135.0 );
                dial->setScaleArc( 0.0, 270.0 );
                dial->setScaleMaxMinor( 4 );
                dial->setScaleMaxMajor( 10 );
                dial->setScale( -100.0, 100.0 );

                needleColor = QColor( "Goldenrod" );

                break;
            }
            case 1:
            {
                dial->setOrigin( 135.0 );
                dial->setScaleArc( 0.0, 270.0 );
                dial->setScaleMaxMinor( 10 );
                dial->setScaleMaxMajor( 10 );
                dial->setScale( 10.0, 0.0 );

                QwtRoundScaleDraw *scaleDraw = new QwtRoundScaleDraw();
                scaleDraw->setSpacing( 8 );
                scaleDraw->enableComponent( 
                    QwtAbstractScaleDraw::Backbone, false );
                scaleDraw->setTickLength( QwtScaleDiv::MinorTick, 2 );
                scaleDraw->setTickLength( QwtScaleDiv::MediumTick, 4 );
                scaleDraw->setTickLength( QwtScaleDiv::MajorTick, 8 );
                dial->setScaleDraw( scaleDraw );

                break;
            }
            case 2:
            {
                dial->setOrigin( 150.0 );
                dial->setScaleArc( 0.0, 240.0 );

                QwtLinearScaleEngine *scaleEngine = new QwtLinearScaleEngine( 2 );
                scaleEngine->setTransformation( new QwtPowerTransform( 2 ) );
                dial->setScaleEngine( scaleEngine );

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
 
                dial->setScale( QwtScaleDiv( 0, 128, ticks ) );
                break;
            }
            case 3:
            {
                dial->setOrigin( 135.0 );
                dial->setScaleArc( 0.0, 270.0 );
                dial->setScaleMaxMinor( 9 );
                dial->setScaleEngine( new QwtLogScaleEngine );
                dial->setScale( 1.0e-2, 1.0e2 );

                break;
            }
            case 4:
            {
                dial->setOrigin( 225.0 );
                dial->setScaleArc( 0.0, 360.0 );
                dial->setScaleMaxMinor( 5 );
                dial->setScaleStepSize( 20 );
                dial->setScale( 100.0, -100.0 );
                dial->setWrapping( true );
                dial->setTotalSteps( 40 );
                dial->setMode( QwtDial::RotateScale );
                dial->setValue( 70.0 );

                needleColor = QColor( "DarkSlateBlue" );

                break;
            }
            case 5:
            {
                dial->setOrigin( 45.0 );
                dial->setScaleArc( 0.0, 225.0 );
                dial->setScaleMaxMinor( 5 );
                dial->setScaleMaxMajor( 10 );
                dial->setScale( 0.0, 10.0 );

                break;
            }
        }

        QwtDialSimpleNeedle *needle = new QwtDialSimpleNeedle(
            QwtDialSimpleNeedle::Arrow, true, needleColor,
            QColor( Qt::gray ).light( 130 ) );
        dial->setNeedle( needle );

        //const QColor base( QColor( "DimGray" ) );
        const QColor base( QColor( Qt::darkGray ).dark( 150 ) );

        QPalette palette;
        palette.setColor( QPalette::Base, base );
        palette.setColor( QPalette::Window, base.dark( 150 ) );
        palette.setColor( QPalette::Mid, base.dark( 110 ) );
        palette.setColor( QPalette::Light, base.light( 170 ) );
        palette.setColor( QPalette::Dark, base.dark( 170 ) );
        palette.setColor( QPalette::Text, base.dark( 200 ).light( 800 ) );
        palette.setColor( QPalette::WindowText, base.dark( 200 ) );

        dial->setPalette( palette );
        dial->setLineWidth( 4 );
        dial->setFrameShadow( QwtDial::Sunken );

        return dial;
    }
};
//! [0]

#endif // QWT_DIAL_BOX_H
