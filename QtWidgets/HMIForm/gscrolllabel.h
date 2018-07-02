#ifndef _WIDGETMARQUEELABEL_H_
#define _WIDGETMARQUEELABEL_H_

#include <QLabel>
#include <QTimer>
#include <QPainter>
#include <QLayout>

class GScrollLabel : public QLabel
{
    Q_OBJECT

    public: //Member Functions
        enum Direction{LeftToRight,RightToLeft};
        GScrollLabel(QWidget *parent = 0)
        {
            tParent = parent;
            labelfont = new QFont();
            labelfont->setPixelSize(14);
            m_align = Qt::AlignVCenter;

            px = 0;
            py = 10;
            speed = 1;

            thickness = 1.0;
            direction = LeftToRight;
            connect(&timer, SIGNAL(timeout()), this, SLOT(refreshLabel()));
            timer.start(10);
        }
        ~GScrollLabel()
        {}
        void start()
        {
            QLabel::show();
        }
        void setAlignment(Qt::Alignment al)
        {
            m_align = al;
            updateCoordinates();
            QLabel::setAlignment(al);
        }
        void setBackgroundColor(int c)
        {
            bgColor.setRgb(c & 0xFFFFFFFF);
            updateProperty();
        }
        void setFontColor(int c)
        {
            fontColor.setRgb(c & 0xFFFFFFFF);
            updateProperty();
        }
        void setBorderColor(int c)
        {
            borderColor.setRgb(c & 0xFFFFFF);
            updateProperty();
        }
        void setTransparent(bool b)
        {
            if(b){
                borderColor.setAlpha(0);
                bgColor.setAlpha(0);
            }
            else{
                borderColor.setAlpha(255);
                bgColor.setAlpha(255);
            }
            updateProperty();
        }
        void setgeometry(int x,int y,int w,int h)
        {
            tParent->setGeometry(x,y,w,h);
            this->setGeometry(x,y,w,h);
            switch(m_align)
            {
                case Qt::AlignTop:
                    py = 10;
                    break;
                case Qt::AlignBottom:
                    py = h-10;
                    break;
                case Qt::AlignVCenter:
                    py = h/2;
                    break;
            }
        }
        void setScrollFlag(int f)
        {
            scrollFlag = f;
        }
        void setFontSize(int s)
        {
            labelfont->setPixelSize(s);
            updateProperty();
        }
        void setUnderline(bool b)
        {
            labelfont->setUnderline(b);
            updateProperty();
        }
        void setBold(bool b)
        {
            labelfont->setBold(b);
            updateProperty();
        }
        void setThickness(double d)
        {
            thickness = d;
            updateProperty();
        }
        int getSpeed()
        {
            return speed;
        }

    public Q_SLOTS: //Public Member Slots
        void setSpeed(int s)
        {
            speed = s;
        }
        void setDirection(int d)
        {
            direction = d;
            if (direction==RightToLeft)
                px = width() - textLength;
            else
                px = 0;
            refreshLabel();
        }

    protected: //Member Functions
        void paintEvent(QPaintEvent *evt)
        {

            textLength = fontMetrics().width(text());
            fontPointSize = labelfont->pixelSize()/2;
            QPainter p(this);
            if(direction==RightToLeft)
            {
                px -= speed;
                if(px <= (-textLength))
                    px = width();
            }
            else
            {
                px += speed;
                if(px >= width())
                    px = - textLength;
            }
            p.drawText(px, py + fontPointSize, text());
            p.translate(px,0);
        }
        void resizeEvent(QResizeEvent *evt)
        {
            updateCoordinates();
            QLabel::resizeEvent(evt);
        }
        void updateCoordinates()
        {
            switch(m_align)
            {
                case Qt::AlignTop:
                    py = 10;
                    break;
                case Qt::AlignBottom:
                    py = height()-10;
                    break;
                case Qt::AlignVCenter:
                    py = height()/2;
                    break;
            }
        }

    private: //Data Members
        QWidget *tParent;
        int px;
        int py;
        QFont *labelfont;
        QColor bgColor, fontColor, borderColor;
        QTimer timer;
        Qt::Alignment m_align;
        int speed;
        int direction;
        int fontPointSize;
        int textLength;
        int scrollFlag;
        double thickness;
        void updateProperty()
        {
            setFont(*labelfont);
            setStyleSheet(QString("border: %1px solid rgba(%2,%3,%4,%5);").arg(thickness).arg(borderColor.red()).arg(borderColor.green()).arg(borderColor.blue()).arg(borderColor.alpha())
                          +QString("background-color: rgba(%1,%2,%3,%4);").arg(bgColor.red()).arg(bgColor.green()).arg(bgColor.blue()).arg(bgColor.alpha())
                          +QString("color: rgb(%1,%2,%3);").arg(fontColor.red()).arg(fontColor.green()).arg(fontColor.blue()));
        }
    private Q_SLOTS: //Private Member Slots
        void refreshLabel()
        {
            if(scrollFlag == 0 && sizeHint().width() > this->size().width())
            {
                repaint();
            }
            else if(scrollFlag == 1)
                repaint();
        }
};
#endif /*_WIDGETMARQUEELABEL_H_*/
