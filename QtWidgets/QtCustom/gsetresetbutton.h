#ifndef GSETRESETBUTTON_H
#define GSETRESETBUTTON_H

#include <QWidget>
#include <QPushButton>
#include <QLayout>
class GSetResetButton : public QWidget
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{C1193D10-7C58-47CA-AF8C-2F731CBF5199}")
    Q_CLASSINFO("InterfaceID", "{502EA99F-632A-4BCB-98FF-A71A41677D44}")
    Q_CLASSINFO("EventsID", "{4E60D959-F23D-4968-85FD-2695AA7CC29D}")
    Q_CLASSINFO("ToSuperClass", "GSetResetButton")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

public:
    explicit GSetResetButton(QWidget *parent = 0,int rotate = 0): QWidget(parent)
    {

        setButton = new QPushButton("SET");
        resetButton = new QPushButton("RESET");
        QSizePolicy sizePolicy(QSizePolicy::Minimum, QSizePolicy::Expanding);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        setButton->setSizePolicy(sizePolicy);
        resetButton->setSizePolicy(sizePolicy);
        setFontColor(0x000000);
        if(rotate == 0 || rotate == 2)
        {
            vLayout = new QVBoxLayout(this);
            vLayout->setSpacing(0);
            vLayout->setContentsMargins(0,0,0,0);
        }
        else
        {
            hLayout = new QHBoxLayout(this);
            hLayout->setSpacing(0);
            hLayout->setContentsMargins(0,0,0,0);
        }
        switch(rotate)
        {
        case 0:
            vLayout->addWidget(setButton);
            vLayout->addWidget(resetButton);
            break;
        case 1:
            hLayout->addWidget(resetButton);
            hLayout->addWidget(setButton);
            break;
        case 2:
            vLayout->addWidget(resetButton);
            vLayout->addWidget(setButton);
            break;
        case 3:
            hLayout->addWidget(setButton);
            hLayout->addWidget(resetButton);
            break;
        default:
            break;
        }
    }
    
    void setImgPath(QString path)
    {
        if(!path.isEmpty())
        {
            setButton->setText("");
            setButton->setStyleSheet(QString("background-color:transparent; border-image:url(%1);").arg(path));
        }
    }
    void resetImgPath(QString path)
    {
        if(!path.isEmpty())
        {
            resetButton->setText("");
            resetButton->setStyleSheet(QString("background-color:transparent; border-image:url(%1);").arg(path));
        }
    }
    void setFontColor(int rgb)
    {
        fontColor.setRgb(rgb & 0xFFFFFF);
        resetButton->setStyleSheet(QString("background-color: rgba(255,0,0,255);") + QString("color: rgb(0,0,0);") + QString("color: rgb(%1,%2,%3);").arg(fontColor.red()).arg(fontColor.green()).arg(fontColor.blue()));
        setButton->setStyleSheet(QString("background-color: rgba(0,255,0,255);") + QString("color: rgb(0,0,0);") + QString("color: rgb(%1,%2,%3);").arg(fontColor.red()).arg(fontColor.green()).arg(fontColor.blue()));
    }

private:
    int rotate;
    QString setButtonPath;
    QString resetButtonPath;
    QPushButton *setButton;
    QPushButton *resetButton;
    QVBoxLayout *vLayout;
    QHBoxLayout *hLayout;
    QColor fontColor;
};

#endif // GSETRESETBUTTON_H
