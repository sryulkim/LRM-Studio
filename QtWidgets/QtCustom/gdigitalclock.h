#ifndef GDIGITALCLOCK_H
#define GDIGITALCLOCK_H

#include <QWidget>
#include <QLabel>
#include <QTimer>
#include <QDateTime>
enum ClockType{
    YYMMDD,
    HHMMSS,
    ALL
};

class GDigitalClock:public QLabel
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{B79F6C6A-FE86-4846-898D-EF12937EECCE}")
    Q_CLASSINFO("InterfaceID", "{B2D40325-445A-4BD7-A8AE-527D91301678}")
    Q_CLASSINFO("EventsID", "{B1A85E37-66AA-46CE-B2F3-3095F682F338}")
    Q_CLASSINFO("ToSuperClass", "GDigitalClock")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY(int clockColor READ ClockColor WRITE setClockQColor)
    Q_PROPERTY(int borderColor READ BorderColor WRITE setBorderQColor)
    Q_PROPERTY(int fontColor READ FontColor WRITE setFontQColor)
    Q_PROPERTY(bool fontBold READ FontBold WRITE setFontBold)
    Q_PROPERTY(int fontSize READ FontSize WRITE setFontSize)
    
public:
    GDigitalClock(QWidget *parent=0,ClockType type=ALL):QLabel(parent)
    {
        fontQColor.setRgb(0);
        clockQColor.setRgb(0xffffff);
        borderQColor.setRgb(0);
        
        clocktype = type;
        showTime();
    }

    int ClockColor()
    {
        return clockColor;
    }

    int BorderColor()
    {
        return borderColor;
    }

    int FontColor()
    {
        return fontColor;
    }

    int FontSize()
    {
        return fontSize;
    }

    bool FontBold()
    {
        return fontBold;
    }

//    ~GClock();
    void setFontQColor(int rgba)
    {
        fontColor = rgba;
        fontQColor.setRgb(rgba&0xffffff);
        fontQColor.setAlpha(0xff);
        showTime();
    }
    void setClockQColor(int rgba)
    {
        clockColor = rgba;
        clockQColor.setRgb(rgba&0xffffff);
        clockQColor.setAlpha(0xff);
        showTime();
    }
    void setBorderQColor(int rgba)
    {
        borderColor = rgba;
        borderQColor.setRgb(rgba&0xffffff);
        borderQColor.setAlpha(0xff);
        showTime();
    }
    void setFontSize(int size)
    {
        fontSize = size;
        font.setPixelSize(size);
        this->setFont(font);
        showTime();
    }
    void setFontBold(bool bol)
    {
        fontBold = bol;
        font.setBold(bol);
        showTime();
    }
    
private Q_SLOTS:
    void showTime()
    {
        QDateTime time = QDateTime::currentDateTime();
        QString yymmdd = time.toString("yyyy-MM-dd");
        QString hhmmss = time.toString("hh:mm:ss");
        if(clocktype == ALL)
            this->setText(yymmdd +" "+ hhmmss);
        else if(clocktype == YYMMDD)
            this->setText(yymmdd);
        else if(clocktype == HHMMSS)
            this->setText(hhmmss);
        this->setStyleSheet(QString("border: 1px solid rgba(%1,%2,%3,%4);").arg(borderQColor.red()).arg(borderQColor.green()).arg(borderQColor.blue()).arg(borderQColor.alpha())
                            +QString("background-color: rgba(%1,%2,%3,%4);").arg(clockQColor.red()).arg(clockQColor.green()).arg(clockQColor.blue()).arg(clockQColor.alpha())
                            +QString("color: rgb(%1,%2,%3);").arg(fontQColor.red()).arg(fontQColor.green()).arg(fontQColor.blue()));
        setFont(font);
    }

private:
    QColor fontQColor;
    QColor clockQColor;
    QColor borderQColor;
    int fontColor, clockColor, borderColor;
    bool fontBold;
    int fontSize;
    QFont font;



    ClockType clocktype;
};

#endif // GCLOCK_H
