#ifndef GPUSHBUTTON_H
#define GPUSHBUTTON_H

#include <QWidget>
#include <QPainter>
#include <QPushButton>

//! [0]
class GPushButton : public QPushButton
{
    Q_OBJECT
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
