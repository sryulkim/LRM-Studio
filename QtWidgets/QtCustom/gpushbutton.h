#ifndef GPUSHBUTTON_H
#define GPUSHBUTTON_H

#include <QWidget>
#include <QPainter>
#include <QPushButton>

//! [0]
class GPushButton : public QPushButton
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{574AF946-CE02-4B60-92A8-879FD09855F4}")
    Q_CLASSINFO("InterfaceID", "{E496B5F2-FA7F-4880-85F3-BEDF8ECE8A6B}")
    Q_CLASSINFO("EventsID", "{37F10C34-A726-4A01-96E1-5C6E101F58AC}")
    Q_CLASSINFO("ToSuperClass", "GPushButton")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY( int button_color READ buttonColor WRITE setButtonColor )
    Q_PROPERTY( int border_color READ borderColor WRITE setBorderColor )
    Q_PROPERTY( int font_color READ fontColor WRITE setFontColor )
    Q_PROPERTY( int font_size READ fontSize WRITE setFontSize )
    Q_PROPERTY( QString button_text READ buttonText WRITE setButtonText)
    Q_PROPERTY( float thickness READ borderThickness WRITE setBorderThickness)
    Q_PROPERTY( bool font_bold READ fontBold WRITE setFontBold)
    Q_PROPERTY( bool font_underline READ fontUnderline WRITE setFontUnderline)

public:
    GPushButton(QWidget *parent = 0)
        : QPushButton(parent), button_color(0xffffff), border_color(0xffffff), font_color(0x0)
    {
        font = new QFont();
        setText("PushButton");
    }

    QString buttonText()
    {
        return button_text;
    }

    void setButtonText(QString bt)
    {
        button_text = bt;
        setText(button_text);
    }

    int buttonColor() const
    {
        return button_color;
    }

    void setButtonColor(int cn)
    {
        button_color = cn;
        buttonQColor.setRgb(cn&0xffffff);
        buttonQColor.setAlpha(0xff);
        update();
    }

    int borderColor() const
    {
        return border_color;
    }

    void setBorderColor(int bc)
    {
        border_color = bc;
        borderQColor.setRgb(bc&0xffffff);
        borderQColor.setAlpha(0xff);
        update();
    }

    int fontColor() const
    {
        return font_color;
    }

    void setFontColor(int cn)
    {
        font_color = cn;
        fontQColor.setRgb(cn&0xffffff);
        fontQColor.setAlpha(0xff);
        update();
    }

    float borderThickness() const
    {
        return thickness;
    }

    void setBorderThickness(int bt)
    {
        thickness = bt;
        update();
    }

    int fontSize() const
    {
        return font_size;
    }

    void setFontSize(int fs)
    {
        font_size = fs;
        font->setPixelSize(font_size);
        update();
    }

    bool fontBold() const
    {
        return font_bold;
    }

    void setFontBold(bool fb)
    {
        font_bold = fb;
        font->setBold(font_bold);
        update();
    }

    bool fontUnderline() const
    {
        return font_underline;
    }

    void setFontUnderline(bool fu)
    {
        font_underline = fu;
        font->setUnderline(font_underline);
        update();
    }

protected:
    void update()
    {
        bool connected = false;

        this->setFont(*font);
        this->setStyleSheet(QString("border: %1px solid rgb(%2,%3,%4);").arg(thickness).arg(borderQColor.red()).arg(borderQColor.green()).arg(borderQColor.blue())
                            +QString("background-color: rgba(%1,%2,%3,%4);").arg(buttonQColor.red()).arg(buttonQColor.green()).arg(buttonQColor.blue()).arg(buttonQColor.alpha())
                            +QString("color: rgb(%1,%2,%3);").arg(fontQColor.red()).arg(fontQColor.green()).arg(fontQColor.blue()));
    }


private:
    QFont *font;
    QString button_text;
    QColor buttonQColor,borderQColor,fontQColor;
    int button_color,border_color,font_color;
    int font_size;
    bool font_bold;
    bool font_underline;
    QRect rect;
    float thickness;
};
//! [0]

#endif // COLOURFULDIAL_H