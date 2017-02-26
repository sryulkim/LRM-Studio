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

#ifndef QWT_SLIDER_BOX_H
#define QWT_SLIDER_BOX_H

#include <QWidget>
#include <qlabel.h>
#include <qlayout.h>
#include <qwt_slider.h>
#include <qwt_scale_engine.h>
#include <qwt_transform.h>

class QLabel;
class QwtSlider;

//! [0]
class QwtSliderBox : public QWidget
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{9EAF79A4-4A50-410C-88DD-CEC5657F2A51}")
    Q_CLASSINFO("InterfaceID", "{EC9B495C-C7DD-4F1E-B786-16CC0D0168BB}")
    Q_CLASSINFO("EventsID", "{96D0F72A-E414-4DB5-9AEE-42D6FE9AB960}")
    Q_CLASSINFO("ToSuperClass", "QwtSliderBox")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY(int type READ getType WRITE setType)
public:
    QwtSliderBox(QWidget *parent = 0)
        : QWidget(parent), type(0)
    {
        d_slider = createSlider();

        QFlags<Qt::AlignmentFlag> alignment;

        if ( d_slider->orientation() == Qt::Horizontal )
        {
            if ( d_slider->scalePosition() == QwtSlider::TrailingScale )
                alignment = Qt::AlignBottom;
            else
                alignment = Qt::AlignTop;

            alignment |= Qt::AlignHCenter;
        }
        else
        {
            if ( d_slider->scalePosition() == QwtSlider::TrailingScale )
                alignment = Qt::AlignRight;
            else
                alignment = Qt::AlignLeft;

            alignment |= Qt::AlignVCenter;
        }

        d_label = new QLabel( this );
        d_label->setAlignment( alignment );
        d_label->setFixedWidth( d_label->fontMetrics().width( "10000.9" ) );

        connect( d_slider, SIGNAL( valueChanged( double ) ), SLOT( setNum( double ) ) );

        QBoxLayout *layout;
        if ( d_slider->orientation() == Qt::Horizontal )
            layout = new QHBoxLayout( this );
        else
            layout = new QVBoxLayout( this );

        layout->addWidget( d_slider );
        layout->addWidget( d_label );

        setNum( d_slider->value() );
    }

    int getType() const
    {
        return type;
    }

    void setType(int tp)
    {
        type = tp;
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
    QwtSlider *d_slider;
    QLabel *d_label;

    
    QwtSlider *createSlider() const
    {
        QwtSlider *slider = new QwtSlider();

        switch( type )
        {
            case 0:
            {
                slider->setOrientation( Qt::Horizontal );
                slider->setScalePosition( QwtSlider::TrailingScale );
                slider->setTrough( true );
                slider->setGroove( false );
                slider->setSpacing( 0 );
                slider->setHandleSize( QSize( 30, 16 ) );
                slider->setScale( 10.0, -10.0 ); 
                slider->setTotalSteps( 8 ); 
                slider->setSingleSteps( 1 ); 
                slider->setPageSteps( 1 ); 
                slider->setWrapping( true );
                break;
            }
            case 1:
            {
                slider->setOrientation( Qt::Horizontal );
                slider->setScalePosition( QwtSlider::NoScale );
                slider->setTrough( true );
                slider->setGroove( true );
                slider->setScale( 0.0, 1.0 );
                slider->setTotalSteps( 100 );
                slider->setSingleSteps( 1 );
                slider->setPageSteps( 5 );
                break;
            }
            case 2:
            {
                slider->setOrientation( Qt::Horizontal );
                slider->setScalePosition( QwtSlider::LeadingScale );
                slider->setTrough( false );
                slider->setGroove( true );
                slider->setHandleSize( QSize( 12, 25 ) );
                slider->setScale( 1000.0, 3000.0 );
                slider->setTotalSteps( 200.0 );
                slider->setSingleSteps( 2 );
                slider->setPageSteps( 10 );
                break;
            }
            case 3:
            {
                slider->setOrientation( Qt::Horizontal );
                slider->setScalePosition( QwtSlider::TrailingScale );
                slider->setTrough( true );
                slider->setGroove( true );

                QwtLinearScaleEngine *scaleEngine = new QwtLinearScaleEngine( 2 );
                scaleEngine->setTransformation( new QwtPowerTransform( 2 ) );
                slider->setScaleEngine( scaleEngine );
                slider->setScale( 0.0, 128.0 );
                slider->setTotalSteps( 100 );
                slider->setStepAlignment( false );
                slider->setSingleSteps( 1 );
                slider->setPageSteps( 5 );
                break;
            }
            case 4:
            {
                slider->setOrientation( Qt::Vertical );
                slider->setScalePosition( QwtSlider::TrailingScale );
                slider->setTrough( false );
                slider->setGroove( true );
                slider->setScale( 100.0, 0.0 );
                slider->setInvertedControls( true );
                slider->setTotalSteps( 100 );
                slider->setPageSteps( 5 );
                slider->setScaleMaxMinor( 5 );
                break;
            }
            case 5:
            {
                slider->setOrientation( Qt::Vertical );
                slider->setScalePosition( QwtSlider::NoScale );
                slider->setTrough( true );
                slider->setGroove( false );
                slider->setScale( 0.0, 100.0 );
                slider->setTotalSteps( 100 );
                slider->setPageSteps( 10 );
                break;
            }
            case 6:
            {
                slider->setOrientation( Qt::Vertical );
                slider->setScalePosition( QwtSlider::LeadingScale );
                slider->setTrough( true );
                slider->setGroove( true );
                slider->setScaleEngine( new QwtLogScaleEngine );
                slider->setStepAlignment( false );
                slider->setHandleSize( QSize( 20, 32 ) );
                slider->setBorderWidth( 1 );
                slider->setScale( 1.0, 1.0e4 );
                slider->setTotalSteps( 100 );
                slider->setPageSteps( 10 );
                slider->setScaleMaxMinor( 9 );
                break;
            }
        }

        if ( slider )
        {
            QString name( "Slider %1" );
            slider->setObjectName( name.arg( type ) );
        }

        return slider;
    }
    
};
//! [0]

#endif // QWT_DIAL_BOX_H
