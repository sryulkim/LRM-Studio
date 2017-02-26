#ifndef COLOURFULSLIDER_H
#define COLOURFULSLIDER_H

#include <QWidget>
#include <QPainter>
#include <QSlider>

//! [0]
class ColourfulQSlider : public QSlider
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{035A916A-310C-4185-8DEB-8B05F285CAEA}")
    Q_CLASSINFO("InterfaceID", "{BC8D2451-96E7-4213-864D-72022978B286}")
    Q_CLASSINFO("EventsID", "{AE5ED403-2D0C-46BF-A04C-0E9F205FA688}")
    Q_CLASSINFO("ToSuperClass", "ColourfulQSlider")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY( int button_color_number READ buttonColorNumber WRITE setButtonColorNumber )
    Q_PROPERTY( int background_color_number READ backgroundColorNumber WRITE setBackgroundColorNumber)
public:
    ColourfulQSlider(QWidget *parent = 0)
        : QSlider(parent), button_color_number(0xffffff), background_color_number(0xffffff)
    {
    }

    int buttonColorNumber() const
    {
        return button_color_number;
    }

    void setButtonColorNumber(int cn)
    {
        button_color_number = cn;
        cn = cn+1;

        QPalette palette;
        QColor *color = new QColor(button_color_number);
        palette.setColor(QPalette::Button, *color);
        setPalette(palette);
    }

    int backgroundColorNumber() const
    {
        return background_color_number;
    }

    void setBackgroundColorNumber(int cn)
    {
        background_color_number = cn;

        QPalette palette;
        QColor *color = new QColor(background_color_number);
        palette.setColor(QPalette::Background, *color);
        setPalette(palette);
    }

protected:
//    void paintEvent(QPaintEvent *e)
//    {
//    }

private:
    QColor fill_color;
    int button_color_number;
    int background_color_number;
};
//! [0]

#endif // COLOURFULDIAL_H