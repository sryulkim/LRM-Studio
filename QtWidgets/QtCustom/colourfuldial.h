#ifndef COLOURFULDIAL_H
#define COLOURFULDIAL_H

#include <QWidget>
#include <QPainter>
#include <QDial>

//! [0]
class ColourfulQDial : public QDial
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{877766E2-800E-48F0-83C1-F2C4F8A2D820}")
    Q_CLASSINFO("InterfaceID", "{A023D60E-5C7A-4D55-A7C0-75DCAF7E421E}")
    Q_CLASSINFO("EventsID", "{CA6514DB-A922-42A6-8CA5-9B01F49FD9C3}")
    Q_CLASSINFO("ToSuperClass", "ColourfulQDial")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY( int button_color_number READ buttonColorNumber WRITE setButtonColorNumber )
    Q_PROPERTY( int background_color_number READ backgroundColorNumber WRITE setBackgroundColorNumber)
public:
    ColourfulQDial(QWidget *parent = 0)
        : QDial(parent), button_color_number(0xffffff), background_color_number(0xffffff)
    {
    }

    int buttonColorNumber() const
    {
        return button_color_number;
    }

    void setButtonColorNumber(int cn)
    {
        button_color_number = cn;

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