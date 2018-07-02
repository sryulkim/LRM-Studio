#ifndef GRADIOBUTTON_H
#define GRADIOBUTTON_H

#include <QWidget>
#include <QPainter>
#include <QRadioButton>
class GRadioButton : public QRadioButton
{
public:
    GRadioButton(QWidget *parent = 0)
        :QRadioButton(parent), buttonID(-1)
    {
        font = new QFont();
        setUnderline(false);
        setBold(false);
        setTransparent(false);
        setFontColor(0);
        setBorderColor(0);
        setThickness(1);
        setButtonColor(0xE0E0E0);
        this->setAutoExclusive(false);
        this->setCheckable(true);
        setText("RadioButton");
    }

    QString getButtonText(){
        return buttonText;
    }

    void setButtonText(QString text){
        buttonText = text;
        this->setText(text);
    }

    int getButtonID(){
        return buttonID;
    }
    void setButtonID(int id){
        buttonID = id;
    }

    int getButtonColor(){
        return background_color;
    }

    void setButtonColor(int cn){
        background_color = cn;
        backgroundColor.setRgb(cn&0xffffff);
        propertyUpdate();
    }

    int getBorderColor(){
        return border_color;
    }

    void setBorderColor(int cn){
        border_color = cn;
        borderColor.setRgb(cn&0xffffff);
        propertyUpdate();
    }

    bool getTransparent(){
        return transparent;
    }

    void setTransparent(bool i){
        transparent = i;
        if(i){
            borderColor.setAlpha(0);
            backgroundColor.setAlpha(0);
        }
        else{
            borderColor.setAlpha(255);
            backgroundColor.setAlpha(255);
        }
        propertyUpdate();
    }

    void setFontColor(int cn){
        font_color = cn;
        fontColor.setRgb(cn&0xffffff);
        propertyUpdate();
    }

    void setFontSize(int size){
        font_size = size;
        font->setPixelSize(size);
        propertyUpdate();
    }

    void setBold(bool i){
        font_bold = i;
        if(i)
            font->setBold(true);
        else
            font->setBold(false);
        propertyUpdate();
    }

    void setUnderline(bool i){
        font_underline = i;
        if(i)
            font->setUnderline(true);
        else
            font->setUnderline(false);
        propertyUpdate();
    }

    void setThickness(int t){
        thickness = t;
        propertyUpdate();
    }

    void propertyUpdate(void){
        setFont(*font);
        setStyleSheet(QString("border: %1px solid rgba(%2,%3,%4,%5);").arg(thickness).arg(borderColor.red()).arg(borderColor.green()).arg(borderColor.blue()).arg(backgroundColor.alpha())
                      +QString("background-color: rgba(%1,%2,%3,%4);").arg(backgroundColor.red()).arg(backgroundColor.green()).arg(backgroundColor.blue()).arg(backgroundColor.alpha())
                      +QString("color: rgb(%1,%2,%3);").arg(fontColor.red()).arg(fontColor.green()).arg(fontColor.blue()));
    }

private:
    int buttonID;
    QString buttonText;

    QFont *font;
    QColor backgroundColor;
    QColor fontColor;
    QColor borderColor;

    int thickness;
    bool transparent;
    int background_color;
    int border_color;
    int font_color;
    int font_size;
    bool font_bold;
    bool font_underline;

};

#endif // GRADIOBUTTON_H
