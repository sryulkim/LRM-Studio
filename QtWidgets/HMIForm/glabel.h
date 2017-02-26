#ifndef GLABEL_H
#define GLABEL_H

#include <QWidget>
#include <QLabel>
#include <QImage>
#include <QImageReader>
#include <QFont>
#include <QTimer>
#include <QDateTime>
#include <QTextEncoder>
#include <QStylePainter>
#include <QTextOption>
#include <QtMath>
class GLabel : public QLabel
{
    Q_OBJECT
public:
    GLabel(QWidget *parent = 0)
        : QLabel(parent),limitlength(100),thickness(1)
    {
        labelQColor.setRgb(200,200,200);
        label_color = 0xc8c8c8;
        borderQColor.setRgb(100,100,100);
        border_color = 0x646464;
        font_color = 0x0;
        font_size = 11;
        m_type=0;
        limitlength=100;
        angle = 0;
        objScale = 1.0;
        font  = new QFont();
        palette = new QPalette();
        setTextWrapper("Label");
    }
    ~GLabel()
    {
    }

    QString Text()
    {
        return label_text;
    }

    int FontSize()
    {
        return font_size;
    }

    float Thickness()
    {
        return thickness;
    }

    bool FontBold()
    {
        return font_bold;
    }

    bool FontUnderline()
    {
        return font_underline;
    }

    int LabelColor()
    {
        return label_color;
    }

    int BorderColor()
    {
        return border_color;
    }

    int FontColor()
    {
        return font_color;
    }

    int Angle()
    {
        return angle;
    }

    bool Transparent()
    {
        return transparent;
    }

    void setAngle(int a)
    {
        angle = a;
        propertyUpdate();
    }

    void setTextWrapper(const QString &t)
    {
        label_text = t;
        setText(label_text);
        propertyUpdate();
    }
    void setBackgroundImage(const QString &path)
    {
        QString fullpath = "background-image: url(:" + path +");";
        setStyleSheet(fullpath);
    }
    void setFontsize(int size)
    {
        font_size = size;
        font->setPixelSize(size);
        propertyUpdate();
    }
    void setFontQColor(int rgba)
    {
        font_color = rgba;
        fontQColor.setRgb(rgba&0xffffff);
    //    palette->setColor(QPalette::WindowText,fontQColor);
        propertyUpdate();
    }

    void setLabelQColor(int rgba)
    {
        label_color = rgba;
        labelQColor.setRgb(rgba&0xffffff);
        propertyUpdate();
    }

    void setBold(bool i)
    {
        font_bold = i;
        if(i)
            font->setBold(true);
        else
            font->setBold(false);
        propertyUpdate();
    }
    void setFontCustom(int i)
    {
        QTextCodec *codec = QTextCodec::codecForName("UTF-8");
        switch(i){
        case 0:
            font->setFamily(codec->toUnicode("맑은 고딕"));
        default:
            break;
        }
        propertyUpdate();
    }
    void setUnderline(bool i)
    {
        font_underline = i;
        if(i)
            font->setUnderline(true);
        else
            font->setUnderline(false);
        propertyUpdate();
    }
    void setLimitlength(int i)
    {
        if(i){
            limitlength = i;
        }
        propertyUpdate();
    }
    void setHorizontalAlignment(int i)
    {
        switch(i){
        case 0:
            setAlignment(Qt::AlignLeft);
            break;
        case 1:
            setAlignment(Qt::AlignCenter);
            break;
        case 2:
            setAlignment(Qt::AlignRight);
            break;
        }
    }
    void setBorderQColor(int rgba)
    {
        border_color = rgba;
        borderQColor.setRgb(rgba&0xffffff);
        propertyUpdate();
    }
    void setThickness(float i)
    {
        thickness = i;
        propertyUpdate();
    }
    void setTransparent(bool i)
    {
        transparent = i;
        if(i){
            labelQColor.setAlpha(0);
            borderQColor.setAlpha(0);
        }
        else{
            labelQColor.setAlpha(255);
            borderQColor.setAlpha(255);
        }
        propertyUpdate();
    }
    void paintEvent(QPaintEvent *e){
        QStylePainter p(this);
        p.translate(rect().center());
        p.rotate(angle);
        p.translate(-rect().center());
        p.scale(objScale,objScale);
        p.drawText(rect(),alignment(),text());

        QTextOption textOption;
        textOption.setAlignment(alignment());
        if(wordWrap()){
            textOption.setWrapMode(QTextOption::WordWrap);
        } else {
            textOption.setWrapMode(QTextOption::NoWrap);
        }
    }
    void setObjectScale(double s)
    {
        objScale = s;
    }
private:
    QFont *font;
    QPalette *palette;
    QString label_text;
    int m_type;
    int limitlength;
    float thickness;
    QColor labelQColor,borderQColor,fontQColor;
    int label_color, border_color, font_color;
    int font_size;
    bool font_bold;
    bool font_underline;
    int angle;
    bool transparent;
    int x_rot, y_rot, w_rot, h_rot;
    double objScale;
     void propertyUpdate(void)
    {
        if(text().length() > limitlength){
            text().chop(text().length() - limitlength);
        }
        setFont(*font);
        setPalette(*palette);
        setStyleSheet(QString("qproperty-alignment: AlignCenter;border: %1px solid rgba(%2,%3,%4,%5);").arg(thickness).arg(borderQColor.red()).arg(borderQColor.green()).arg(borderQColor.blue()).arg(borderQColor.alpha())
                                +QString("background-color: rgba(%1,%2,%3,%4);").arg(labelQColor.red()).arg(labelQColor.green()).arg(labelQColor.blue()).arg(labelQColor.alpha())
                                +QString("color: rgb(%1,%2,%3);").arg(fontQColor.red()).arg(fontQColor.green()).arg(fontQColor.blue()));
        update();
    }

};

#endif // GLABEL_H
