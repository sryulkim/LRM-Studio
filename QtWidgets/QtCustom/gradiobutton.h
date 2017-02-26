#ifndef GRADIOBUTTON_H
#define GRADIOBUTTON_H

#include <QWidget>
#include <QRadioButton>
#include <QLayout>
#include <QSignalMapper>
class GRadioButton : public QWidget
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{09D4E40E-61AE-4BA3-814F-5DE01A42FF5A}")
    Q_CLASSINFO("InterfaceID", "{D3B7CED6-76AC-4FA1-BC01-D0C1DAECD6A6}")
    Q_CLASSINFO("EventsID", "{A7968A2B-AC48-43E3-9FC5-2481065601A2}")
    Q_CLASSINFO("ToSuperClass", "GRadioButton")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY(int count READ Count WRITE setCount)
    Q_PROPERTY(int background_color READ BackgroundColor WRITE setBackgroundColor)
    Q_PROPERTY(int font_color READ FontColor WRITE setFontColor)
    Q_PROPERTY(int font_size READ FontSize WRITE setFontSize)
    Q_PROPERTY(bool font_bold READ FontBold WRITE setFontBold)
    Q_PROPERTY(bool font_underline READ FontUnderline WRITE setFontUnderline)

public:
    GRadioButton(QWidget *parent = 0): QWidget(parent)
    {
        count = 1;
        backgroundColor.setAlpha(0);
        orientation = Qt::Vertical;
        gridLayout = new QGridLayout(this);
        this->setLayout(gridLayout);
        QStringList temp; 
        temp.append("sample"); 
        setButton(temp);
    }

    int Count(){
        return count;
    }

    int BackgroundColor(){
        return background_color;
    }

    int FontColor(){
        return font_color;
    }

    int FontSize(){
        return font_size;
    }

    bool FontBold(){
        return font_bold;
    }

    bool FontUnderline(){
        return font_underline;
    }



    void setButton(QStringList textList)
    {
        //qDebug() << textList;
        if(count == textList.count()){
            for(int i=0;i<count;i++)
            {
                radioButton = new QRadioButton(textList.at(i));
                radioButton->setFont(font);
                radioButton->setStyleSheet(QString("background-color: rgba(%1,%2,%3,%4);").arg(backgroundColor.red()).arg(backgroundColor.green()).arg(backgroundColor.blue()).arg(backgroundColor.alpha())
                                        + QString("color: rgb(%1,%2,%3);").arg(fontColor.red()).arg(fontColor.green()).arg(fontColor.blue()));
                if(orientation == Qt::Vertical)
                {
                    gridLayout->addWidget(radioButton,i,0);
                }
                else
                {
                    gridLayout->addWidget(radioButton,0,i);
                }
                mapper = new QSignalMapper(this);
                mapper->setMapping(radioButton,i);
            }
        }
        else{
            //qDebug() << "Count != Text Count";
        }
    }
    void setOrientation(Qt::Orientation ori){ orientation = ori; }
    void setFontSize(int i){
        font_size = i;
        font.setPixelSize(i);
    }
    void setFontUnderline(bool i){
        font_underline = i;
        font.setUnderline(i);
    }
    void setFontBold(bool i){
        font_bold = i;
        font.setBold(i);
    }
    void setFontColor(int rgba)
    {
        font_color = rgba;
        fontColor.setRgb(rgba & 0xFFFFFF);
    }
    void setBackgroundColor(int rgba)
    {
        background_color = rgba;
        backgroundColor.setRgb(rgba & 0xFFFFFF);
        backgroundColor.setAlpha(0xFF);
    }
    void setCount(int i){count = i;}
private:
    QRadioButton *radioButton;
    QGridLayout *gridLayout;
    Qt::Orientation orientation;
    int orient;

    QSignalMapper *mapper;
    QFont font;
    QColor backgroundColor;
    QColor fontColor;
    int count;
    int background_color;
    int font_color;
    int font_size;
    bool font_bold;
    bool font_underline;
};

#endif // GRADIOBUTTON_H
