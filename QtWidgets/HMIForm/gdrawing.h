#ifndef GDRAWING_H
#define GDRAWING_H

#include <QWidget>
#include <QPainter>
#include <QPen>
#include <QSvgRenderer>
class GDrawing : public QWidget
{
    Q_OBJECT
public:
    enum figureType{Line,Rect,Polygon,Ellipse,Arrow,Svg};
    GDrawing(QWidget *parent=0,figureType type=Line):QWidget(parent)
      ,lineColor(0,0,0), fillColor(0,0,0), startpoint(0,0), endpoint(50,50), lineWidth(1)
      {
          m_type =type;
          angle = 0;
          rectsize.setSize(QSizeF(this->width()-1,this->height()-1));
          this->resize(this->size());
          viewBox = rectsize;
          renderer = new QSvgRenderer();
      }
    void setlineColor(int rgba)
    {
        lineColor.setRgb(rgba&0xffffff);
        lineColor.setAlpha(0xff);//(rgba>>24)&0xff);
        repaint();
    }
    void setfillColor(int rgba)
    {
        fillColor.setRgb(rgba&0xffffff);
        fillColor.setAlpha(0xff);//(rgba>>24)&0xff);
        repaint();
    }
    void setlinewidth(int i)
    {
        lineWidth=i;
        repaint();
    }
    void setPoint(QPointF start,QPointF end)
    {
        startpoint = start;
        endpoint = end;
    }
    void setRect(QRectF r)
    {
        rectsize = r;
        if(m_type == Arrow || m_type == Svg) setGeometry(r.x(),r.y(),r.width(),r.height());
        repaint();
    }
    void setGeometry(int x, int y, int w, int h)
    {
        QWidget::setGeometry(x, y, w, h);
        rectsize.setSize(QSizeF(w-1, h-1));
        repaint();
    }
    void setAngle(int a)
    {
        angle = a;
    }
    void setSvgPath(const QString path)
    {
        svgPath = path;
        renderer->load(path);
        repaint();
    }
    QRectF getRect(void){return rectsize;}
    void update(void);
protected:
    void paintEvent(QPaintEvent *e)
    {
        QPainterPath hand_path;
        QPainter painter(this);
        QBrush brush(Qt::red);
        QPen p;
        switch(m_type){
        case Line:
            p.setWidth(lineWidth);
            p.setColor(lineColor);
            painter.setPen(p);
            painter.drawLine(startpoint,endpoint);
            break;
        case Rect:
            p.setColor(lineColor);
            p.setWidth(lineWidth);
            painter.setPen(p);
            painter.setBrush(fillColor);
            painter.drawRect(rectsize);
            break;
        case Ellipse:
            p.setWidth(lineWidth);
            p.setCapStyle(Qt::RoundCap);
            p.setColor(lineColor);
            brush.setColor(fillColor);
            painter.setPen(p);
            painter.setBrush(brush);
            painter.drawEllipse(rectsize);
            break;
        case Arrow:
            p.setWidth(lineWidth);
            p.setColor(lineColor);
            hand_path.moveTo(QPointF(-rectsize.width()/2,0));
            hand_path.lineTo(QPointF(0,rectsize.height()/2));
            hand_path.lineTo(QPointF(0,rectsize.height()/4));
            hand_path.lineTo(QPointF(rectsize.width()/2,rectsize.height()/4));
            hand_path.lineTo(QPointF(rectsize.width()/2,-rectsize.height()/4));
            hand_path.lineTo(QPointF(0,-rectsize.height()/4));
            hand_path.lineTo(QPointF(0,-rectsize.height()/2));
            hand_path.lineTo(QPointF(-rectsize.width()/2,0));
            painter.setPen(p);
            painter.translate(QPointF(rectsize.width()/2,rectsize.height()/2));
            painter.rotate(angle);
            painter.setBrush(QBrush(QColor(fillColor)));
            painter.drawPath(hand_path);
            break;
        case Svg:
            if(!svgPath.isEmpty())
            {
                renderer->render(&painter);
            }
            break;
        default:
            break;
        }
    }
private:
    int lineWidth;
    QRectF rectsize;
    QPointF startpoint;
    QPointF endpoint;
    QColor lineColor;
    QColor fillColor;
    figureType m_type;
    int angle;
    QSvgRenderer* renderer;
    QRectF viewBox;
    QString svgPath;
};

#endif // DRAWING_H
