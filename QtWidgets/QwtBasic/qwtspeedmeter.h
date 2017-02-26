#ifndef QWT_SPEED_METER_H
#define QWT_SPEED_METER_H
#include <qstring.h>
#include <qwt_dial.h>
#include <qpainter.h>
#include <qwt_dial_needle.h>
#include <qwt_round_scale_draw.h>

class QwtSpeedMeter : public QwtDial
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{D5EDDD46-9DB4-4293-BA47-99631F6CBA52}")
    Q_CLASSINFO("InterfaceID", "{53D83080-6734-45FF-9547-955291853829}")
    Q_CLASSINFO("EventsID", "{4597230C-DA27-400F-AFB5-7C2BA9642C08}")
    Q_CLASSINFO("ToSuperClass", "QwtSpeedMeter")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY( int background_color_number READ backgroundColorNumber WRITE setBackgroundColorNumber )
    Q_PROPERTY( int number_color_number READ numberColorNumber WRITE setNumberColorNumber)
    Q_PROPERTY( int label_color_number READ labelColorNumber WRITE setLabelColorNumber)
    Q_PROPERTY( QString d_label READ dLabel WRITE setLabel)
    Q_PROPERTY( int min READ Min WRITE setMin)
    Q_PROPERTY( int max READ Max WRITE setMax)
    Q_PROPERTY( int max_minor READ maxMinor WRITE setMaxMinor)
    Q_PROPERTY( int max_major READ maxMajor WRITE setMaxMajor)
public:
    QwtSpeedMeter(QWidget *parent = 0)
        : QwtDial(parent), d_label("km/h"), label_color_number(0xf0fff0), background_color_number(0x555555), number_color_number(0xf0fff0), min(0), max(100), max_major(10), max_minor(2)
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
        QColor *color = new QColor(number_color_number);
        pal.setColor(QPalette::Text, *color);
        QColor *color2 = new QColor(background_color_number);
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

    int maxMinor()
    {
        return max_minor;
    }

    int maxMajor()
    {
        return max_major;
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

    void setMaxMajor(int m)
    {
        max_major = m;
        setScaleMaxMajor(max_major);
    }

    void setMaxMinor(int m)
    {
        max_minor = m;
        setScaleMaxMinor(max_minor);
    }

    QString dLabel()
    {
        return d_label;
    }

    void setLabel(const QString &label)
    {
        d_label = label;
        update();
    } //set label string

    int backgroundColorNumber()
    {
        return background_color_number;
    }

    int numberColorNumber()
    {
        return number_color_number;
    }

    int labelColorNumber()
    {
        return label_color_number;
    }

    void setBackgroundColorNumber(int cn)
    {
        background_color_number = cn;

        QPalette pal(palette());
        QColor *color = new QColor(number_color_number);
        pal.setColor(QPalette::Text, *color);
        QColor *color2 = new QColor(background_color_number);
        pal.setColor(QPalette::Base, *color2);
        pal.setColor(QPalette::Foreground, *color2);
        setPalette(pal);
    } //set background color

    void setNumberColorNumber(int cn)
    {
        number_color_number = cn;

        QPalette pal(palette());
        QColor *color = new QColor(number_color_number);
        pal.setColor(QPalette::Text, *color);
        QColor *color2 = new QColor(background_color_number);
        pal.setColor(QPalette::Base, *color2);
        pal.setColor(QPalette::Foreground, *color2);
        setPalette(pal);
    }//set number color

    void setLabelColorNumber(int cn)
    {
        label_color_number = cn;
        label_color = new QColor(label_color_number);
    } //set label color

protected:
    void drawScaleContents(QPainter *painter, const QPointF &center, double radius) const
    {
        QRectF rect(0.0, 0.0, 2.0*radius, 2.0*radius - 10.0);
        rect.moveCenter(center);
        //painter->setPen(*label_color);
        //qDebug() << label_color;
        const int flags = Qt::AlignBottom | Qt::AlignHCenter;
        painter->drawText(rect, flags, d_label);
    }

private:
    QString d_label;
    QColor *label_color;
    int background_color_number;
    int number_color_number;
    int label_color_number;
    int min;
    int max;
    int max_minor;
    int max_major;
};

#endif // QWT_SPEED_METER_H
