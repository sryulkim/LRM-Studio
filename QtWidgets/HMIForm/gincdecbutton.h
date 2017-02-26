#ifndef GINCDECBUTTON_H
#define GINCDECBUTTON_H

#include <QPushButton>
#include <QLayout>
#include <QIcon>
#include <QPainter>
class GIncDecButton : public QWidget
{
    Q_OBJECT
public:
    GIncDecButton(QWidget *parent = 0,int rotate = 0) : QWidget(parent)
    {
        currentValue = 0;
        changeValue = 1;

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
        connect(incButton,SIGNAL(clicked(bool)),this,SLOT(incValue()));
        connect(decButton,SIGNAL(clicked(bool)),this,SLOT(decValue()));
    }
    void setChangeValue(double v)
    {
        changeValue = v;
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
    void setRepeatInterval(int i=10)
    {
        if(i > 0){
            incButton->setAutoRepeatInterval(i);
            decButton->setAutoRepeatInterval(i);
        }
    }
    void setRepeatDelay(int d=10)
    {
        if(d > 0){
            incButton->setAutoRepeatDelay(d);
            decButton->setAutoRepeatDelay(d);
        }
    }
Q_SIGNALS:
    void getIntValue(int);
    void getDoubleValue(double);
public Q_SLOTS:
    void incValue(void)
    {
        currentValue += changeValue;
        if(currentValue < 0.000001 && currentValue > -0.000001)
            currentValue = 0;
        getIntValue((int)currentValue);
        getDoubleValue(currentValue);
    }
    void decValue(void)
    {
        currentValue -= changeValue;
        if(currentValue < 0.000001 && currentValue > -0.000001)
            currentValue = 0;
        getIntValue((int)currentValue);
        getDoubleValue(currentValue);
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
    void setImage(QString path)
    {
        int width,height;
        if(orientation == Qt::Vertical)
        {
            width = this->width();
            height = this->height()/2;
        }
        else
        {
            width = this->width()/2;
            height = this->height();
        }
        QPixmap pic(path);
        pic = pic.scaled(QSize(this->width(),this->height()));
        QMatrix rm;
        //qDebug() << pic.width() << pic.height();
        rm.rotate(180);
        QIcon icon(pic);
        incButton->setIcon(icon);
        incButton->setIconSize(QSize(width,height));
        pic = pic.transformed(rm);
        icon.addPixmap(pic);
        decButton->setIcon(icon);
        decButton->setIconSize(QSize(width,height));
    }
};

#endif // GINCDECBUTTON_H
