#ifndef GINCDECBUTTON_H
#define GINCDECBUTTON_H

#include <QPushButton>
#include <QLayout>
#include <QIcon>
#include <QPainter>
class GIncDecButton : public QWidget
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{30D1EE34-A304-4D03-AADE-ADEE44F9C77A}")
    Q_CLASSINFO("InterfaceID", "{66B03BE6-0248-4FE3-8BF7-7FF1A819EBA0}")
    Q_CLASSINFO("EventsID", "{2E304017-D1AA-48B4-8680-A4439B17B4CC}")
    Q_CLASSINFO("ToSuperClass", "GIncDecButton")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")
public:
    explicit GIncDecButton(QWidget *parent = 0,int rotate = 0) : QWidget(parent)
    {
        incButton = new QPushButton();
        decButton = new QPushButton();
        QSizePolicy sizePolicy(QSizePolicy::Minimum, QSizePolicy::Expanding);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        incButton->setSizePolicy(sizePolicy);
        decButton->setSizePolicy(sizePolicy);
        incButton->setAutoRepeat(true);
        decButton->setAutoRepeat(true);
        setIncImage("D:/One Drive/OneDrive/Visual Studio 2015/Projects/EmCL Studio/QtWidgets/QtCustom/image/arrow_up.png");
        setDecImage("D:/One Drive/OneDrive/Visual Studio 2015/Projects/EmCL Studio/QtWidgets/QtCustom/image/arrow_down.png");
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
            vLayout->addWidget(incButton);
            vLayout->addWidget(decButton);
            break;
        case 1:
            hLayout->addWidget(decButton);
            hLayout->addWidget(incButton);
            break;
        case 2:
            vLayout->addWidget(decButton);
            vLayout->addWidget(incButton);
            break;
        case 3:
            hLayout->addWidget(incButton);
            hLayout->addWidget(decButton);
            break;
        default:
            break;
        }
    }

    void setIncImage(QString path)
    {
        if(!path.isEmpty())
            incButton->setStyleSheet(QString("background-color:transparent; border-image:url(%1);").arg(path));
    }
    void setDecImage(QString path)
    {
        if(!path.isEmpty())
            decButton->setStyleSheet(QString("background-color:transparent; border-image:url(%1);").arg(path));
    }

private:
    Qt::Orientation orientation;
    QVBoxLayout *vLayout;
    QHBoxLayout *hLayout;
    QPushButton *incButton;
    QPushButton *decButton;
    double currentValue;
    double changeValue;
    QString imgPath;
    void setImage(QString path);
};

#endif // GINCDECBUTTON_H
