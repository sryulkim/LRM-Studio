#ifndef COLOURFULLABEL_H
#define COLOURFULLABEL_H

#include <QWidget>
#include <QPainter>
#include <QLabel>
#include <QFont>

//! [0]
class ColourfulQLabel : public QLabel
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{50868389-3852-43C3-885F-A5A93FFEE35C}")
    Q_CLASSINFO("InterfaceID", "{92C0F294-C3FC-463D-A61E-8BB2CE6874EC}")
    Q_CLASSINFO("EventsID", "{6216A786-78B2-4CEA-BC41-CECAB2B4B1CE}")
    Q_CLASSINFO("ToSuperClass", "ColourfulQLabel")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY( int label_color_number READ labelColorNumber WRITE setLabelColorNumber )
    Q_PROPERTY( int background_color_number READ backgroundColorNumber WRITE setBackgroundColorNumber)
    Q_PROPERTY( QString label_text READ labelText WRITE setLabelText)
    Q_PROPERTY( int font_size READ fontSize WRITE setFontSize)

public:
    ColourfulQLabel(QWidget *parent = 0)
        : QLabel(parent), label_color_number(0xffffff), background_color_number(0xffffff)
    {
        qFont = font();
        setText("Label");
    }

    int fontSize()
    {
        return font_size;
    }

    void setFontSize(int fs)
    {
        font_size = fs;
        qFont = font();
        qFont.setPointSize(fs);
        setFont(qFont);
    }

    QString labelText()
    {
        return label_text;
    }

    void setLabelText(QString lt)
    {
        label_text = lt;
        setText(label_text);
    }

    int labelColorNumber() const
    {
        return label_color_number;
    }

    void setLabelColorNumber(int cn)
    {
        label_color_number = cn;

        QPalette palette;
        QColor *color = new QColor(label_color_number);
        palette.setColor(QPalette::WindowText, *color);
        QColor *color2 = new QColor(background_color_number);
        palette.setColor(QPalette::Background, *color2);
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
        QColor *color = new QColor(label_color_number);
        palette.setColor(QPalette::WindowText, *color);
        QColor *color2 = new QColor(background_color_number);
        palette.setColor(QPalette::Background, *color2);
        setPalette(palette);
    }

protected:
//    void paintEvent(QPaintEvent *e)
//    {
//    }

private:
    QColor fill_color;
    int label_color_number;
    int background_color_number;
    int font_size;
    QString label_text;
    QFont qFont;
};
//! [0]

#endif // COLOURFULDIAL_H