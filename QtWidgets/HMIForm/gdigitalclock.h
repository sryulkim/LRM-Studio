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
    void setTransparent(bool i)
    {
        if(i){
            clockQColor.setAlpha(0);
            borderQColor.setAlpha(0);
        }
        else{
            clockQColor.setAlpha(255);
            borderQColor.setAlpha(255);
        }
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
