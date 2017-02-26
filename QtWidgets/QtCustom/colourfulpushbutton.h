#ifndef COLOURFULPUSHBUTTON_H
#define COLOURFULPUSHBUTTON_H

#include <QWidget>
#include <QPainter>
#include <QPushButton>

//! [0]
class ColourfulQPushButton : public QPushButton
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{EBCEB291-AF3B-40AB-ABCF-E7893CD9967F}")
    Q_CLASSINFO("InterfaceID", "{88364BE2-A839-4384-A062-C7F61D466B11}")
    Q_CLASSINFO("EventsID", "{6B519C9A-B6A2-432D-BDEB-23D608491DFB}")
    Q_CLASSINFO("ToSuperClass", "ColourfulQPushButton")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY( int button_color_number READ buttonColorNumber WRITE setButtonColorNumber )
    Q_PROPERTY( int background_color_number READ backgroundColorNumber WRITE setBackgroundColorNumber)
    Q_PROPERTY( QString button_text READ buttonText WRITE setButtonText)
public:
    ColourfulQPushButton(QWidget *parent = 0)
        : QPushButton(parent), button_color_number(0xffffff), background_color_number(0xffffff)
    {
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
    QString button_text;
};
//! [0]

#endif // COLOURFULDIAL_H