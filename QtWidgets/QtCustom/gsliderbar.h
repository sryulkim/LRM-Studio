#ifndef GSLIDERBAR_H
#define GSLIDERBAR_H

#include <qwt_slider.h>
#include <qwt_scale_engine.h>
#include <qwt_transform.h>
#include <qdrawutil.h>
#include <qpainter.h>
#include <qevent.h>
#include <QStyleOption>

class QLabel;
class QwtSlider;

class GSliderbar : public QwtSlider
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{343BE7E7-6F64-4AF0-B897-E6B289822E6A}")
    Q_CLASSINFO("InterfaceID", "{5F113DFA-7B7C-4C28-86F7-744A9A43E78A}")
    Q_CLASSINFO("EventsID", "{41069664-CC17-42C2-B034-45C4615E358D}")
    Q_CLASSINFO("ToSuperClass", "GSliderbar")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    
    Q_PROPERTY( int slider_color READ sliderColor WRITE setSliderColor )
    Q_PROPERTY( int handle_color READ handleColor WRITE setHandleColor )
    Q_PROPERTY( int min READ Min WRITE setMin)
    Q_PROPERTY( int max READ Max WRITE setMax)
    Q_PROPERTY( int minor READ Minor WRITE setMinor)
    Q_PROPERTY( int major READ Major WRITE setMajor)
    Q_PROPERTY( int orient READ Orientation WRITE setOrient)
public:
    GSliderbar(QWidget *parent = 0):QwtSlider(parent)
    ,troughQColor(Qt::white),grooveQColor(Qt::darkGray),handleQColor(Qt::darkGray)
    {
        setMinMax(0,100);
        setMajor(5);
        setMinor(5);
    }
    static QSize qwtHandleSize(const QSize &size, Qt::Orientation orientation, bool hasTrough)
    {
        QSize handleSize = size;
        if(handleSize.isEmpty())
        {
            const int handleThickness = 16;
            handleSize.setWidth(2*handleThickness);
            handleSize.setHeight(handleThickness);
            if(!hasTrough)
                handleSize.transpose();
            if(orientation == Qt::Vertical)
                handleSize.transpose();
        }

        return handleSize;
    }

    void setMinMax(int Min, int Max)
    {
        min = Min;
        max = Max;
        setScale(min,max);
    }

    void setMajor(int i)
    {
        major = i;
        setScaleMaxMajor(i);
    }

    void setMinor(int i)
    {
        minor = i;
        setScaleMaxMinor(i);
    }

    void setSliderColor(int rgb)
    {
        slider_color = rgb;
        troughQColor.setRgb(rgb);
        update();
    }

    void setHandleColor(int rgb)
    {
        handle_color = rgb;
        handleQColor.setRgb(rgb);
        update();
    }

    void setMin(int m)
    {
        min = m;
        setScale(min,max);
    }

    void setMax(int m)
    {
        max = m;
        setScale(min,max);
    }

    void setOrient(int orien)
    {
        orient = orien;
            if(orien == 1)
                setOrientation(Qt::Horizontal);
            else
                setOrientation(Qt::Vertical);
    }

    int Orientation()
    {
        return orient;
    }

    int sliderColor()
    {
        return slider_color;
    }

    int handleColor()
    {
        return handle_color;
    }

    int Min()
    {
        return min;
    }

    int Max()
    {
        return max;
    }

    int Minor()
    {
        return minor;
    }

    int Major()
    {
        return major;
    }

protected:
    void drawSlider(QPainter *painter, const QRect &sliderRect) const
    {
        QRect innerRect(sliderRect);
        QBrush brush = palette().brush(QPalette::Dark);
        if(hasTrough())
        {
            const int bw = borderWidth();
            innerRect = sliderRect.adjusted(bw,bw,-bw,-bw);
            brush.setColor(troughQColor);
            painter->fillRect(innerRect, brush);
            qDrawShadePanel(painter,sliderRect,palette(),true,bw,NULL);
        }

        const QSize handlesize = qwtHandleSize(handleSize(),orientation(),hasTrough());

        if ( hasGroove() )
        {
            const int slotExtent = 4;
            const int slotMargin = 4;

            QRect slotRect;
            if ( orientation() == Qt::Horizontal )
            {
                int slotOffset = qMax( 1, handlesize.width() / 2 - slotMargin );
                int slotHeight = slotExtent + ( innerRect.height() % 2 );

                slotRect.setWidth( innerRect.width() - 2 * slotOffset );
                slotRect.setHeight( slotHeight );

            }
            else
            {
                int slotOffset = qMax( 1, handlesize.height() / 2 - slotMargin );
                int slotWidth = slotExtent + ( innerRect.width() % 2 );

                slotRect.setWidth( slotWidth );
                slotRect.setHeight( innerRect.height() - 2 * slotOffset );
            }

            slotRect.moveCenter( innerRect.center() );

            brush.setColor(grooveQColor);
            qDrawShadePanel( painter, slotRect, palette(), true, 1 , &brush );
        }

        if ( isValid() )
            drawHandle( painter, handleRect(), transform( value() ) );;
    }
    void drawHandle(QPainter *painter, const QRect &handleRect, int pos) const
    {
        const int bw = borderWidth();
        QBrush brush(handleQColor);
        qDrawShadePanel( painter,
                        handleRect, palette(), false, bw,&brush);

        pos++; // shade line points one pixel below
        if ( orientation() == Qt::Horizontal )
        {
            qDrawShadeLine( painter, pos, handleRect.top() + bw,
                            pos, handleRect.bottom() - bw, palette(), true, 1 );
        }
        else // Vertical
        {
            qDrawShadeLine( painter, handleRect.left() + bw, pos,
                            handleRect.right() - bw, pos, palette(), true, 1 );
        }
    }
private:
    QColor  troughQColor;
    QColor grooveQColor;
    QColor handleQColor;
    int orient;
    int min,max;
    int major,minor;
    int handle_color, slider_color;
};

#endif // GSLIDERBAR_H
