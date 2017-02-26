#ifndef GDIAL_H
#define GDIAL_H
#include <qstring.h>
#include <qwt_dial.h>
#include <qpainter.h>
#include <qwt_dial_needle.h>
#include <qwt_round_scale_draw.h>

class GDial : public QwtDial
{
public:
    GDial(QWidget *parent = 0)
        : QwtDial(parent), dial_color(0x555555), font_color(0xf0fff0), min(0), max(100), major(10), minor(2)
    {
        QwtRoundScaleDraw *scaleDraw = new QwtRoundScaleDraw();
        scaleDraw->setSpacing(8);
        scaleDraw->enableComponent(QwtAbstractScaleDraw::Backbone, false);
        scaleDraw->setTickLength(QwtScaleDiv::MinorTick,4);
        scaleDraw->setTickLength(QwtScaleDiv::MediumTick,4);
        scaleDraw->setTickLength(QwtScaleDiv::MajorTick,8);
        setScaleDraw(scaleDraw);
        setWrapping(false);
        setReadOnly(true);
        setOrigin(135.0);
        setScaleArc(0.0, 270.0);
        QwtDialSimpleNeedle *needle = new QwtDialSimpleNeedle(QwtDialSimpleNeedle::Arrow, true, Qt::red, QColor(Qt::gray).light(130));
        setNeedle(needle);
        setAutoFillBackground(true);

        QPalette pal(palette());
        QColor *color = new QColor(font_color);
        pal.setColor(QPalette::Text, *color);
        QColor *color2 = new QColor(dial_color);
        pal.setColor(QPalette::Base, *color2);
        pal.setColor(QPalette::Foreground, *color2);
        setPalette(pal);
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

    void setMin(int m)
    {
        min = m;
        setScale(min, max);
    }

    void setMax(int m)
    {
        max = m;
        setScale(min, max);
    }

    void setMajor(int m)
    {
        major = m;
        setScaleMaxMajor(major);
    }

    void setMinor(int m)
    {
        minor = m;
        setScaleMaxMinor(minor);
    }

    int dialColor()
    {
        return dial_color;
    }

    int fontColor()
    {
        return font_color;
    }

    int needleColor()
    {
        return needle_color;
    }

    void setDialColor(int cn)
    {
        dial_color = cn;

        QPalette pal(palette());
        QColor *color = new QColor(font_color);
        pal.setColor(QPalette::Text, *color);
        QColor *color2 = new QColor(dial_color);
        pal.setColor(QPalette::Base, *color2);
        pal.setColor(QPalette::Foreground, *color2);
        setPalette(pal);
    } //set background color

    void setFontColor(int cn)
    {
        font_color = cn;

        QPalette pal(palette());
        QColor *color = new QColor(font_color);
        pal.setColor(QPalette::Text, *color);
        QColor *color2 = new QColor(dial_color);
        pal.setColor(QPalette::Base, *color2);
        pal.setColor(QPalette::Foreground, *color2);
        setPalette(pal);
    }//set number color

    void setNeedleColor(int nc)
    {
        needle_color = nc;
        QColor color(nc&0xffffff);
        QwtDialSimpleNeedle *needle = new QwtDialSimpleNeedle(QwtDialSimpleNeedle::Arrow, true, color, QColor(Qt::gray).light(130));
        setNeedle(needle);
    }

protected:
    void drawScaleContents(QPainter *painter, const QPointF &center, double radius) const
    {
        QRectF rect(0.0, 0.0, 2.0*radius, 2.0*radius - 10.0);
        rect.moveCenter(center);
        //painter->setPen(*label_color);
        //qDebug() << label_color;
        const int flags = Qt::AlignBottom | Qt::AlignHCenter;
        //painter->drawText(rect, flags, d_label);
    }

private:
    QString d_label;
    QColor *label_color;
    int dial_color;
    int font_color;
    int needle_color;
    int min;
    int max;
    int minor;
    int major;
};

#endif // GDIAL_H
