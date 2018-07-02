#ifndef GIMAGE_H
#define GIMAGE_H
#include <QLabel>
#include <QImage>
#include <QImageReader>
class GImage : public QLabel
{
    Q_OBJECT
public:
    GImage(QWidget *parent=0):QLabel(parent)
    {
        bGrayscale = false;
        img = new QImage();
        reader = new QImageReader();
        imgFolder = "";
        objectScale = 1;
        angle = 0;
    }
    QImage convertToGrayScale(const QImage &srcImage){
        // Convert to 32bit pixel format
        QImage dstImage = srcImage.convertToFormat(srcImage.hasAlphaChannel() ?
                                                       QImage::Format_ARGB32 : QImage::Format_RGB32);

        unsigned int *data = (unsigned int*)dstImage.bits();
        int pixelCount = dstImage.width() * dstImage.height();

        // Convert each pixel to grayscale
        for(int i = 0; i < pixelCount; ++i) {
            int val = qGray(*data);
            *data = qRgba(val, val, val, qAlpha(*data));
            ++data;
        }

        return dstImage;
    }


    void setGeometry(int x, int y, int w, int h)
    {
        setOriginRect(QRect(x, y, w, h));
        draw();
    }


    void setFileName(const QString &path)
    {
        imgName = path;
        draw();
    }

    void setGrayscale(bool b)
    {
        bGrayscale = b;
        draw();
    }
    void setObjectScale(double s)
    {
        if(s > 0.2 && s < 2.0)
            objectScale = s;
        else
            objectScale = 1;
    }
    QRect* getOriginRect()
    {
        return &originRect;
    }
    void setOriginRect(QRect r)
    {
        originRect = r;
    }
    void setAngle(int angle)
    {
        this->angle = angle;
        draw();
    }
    void setVisible(bool visible)
    {
        this->visible = visible;
        if(visible){
            QLabel::setVisible(true);
        }
        else
            QLabel::setVisible(false);
    }
    void draw()
    {
        /*
        int x_s,y_s,w_s,h_s;
        w_s = originRect.width()*sqrt(objectScale);
        h_s = originRect.height()*sqrt(objectScale);
        x_s = originRect.x() + (originRect.width() - w_s)*0.5;
        y_s = originRect.y() + (originRect.height() - h_s);
    //    qDebug() << x_s << y_s << w_s << h_s;
        setGeometry(x_s,y_s,w_s,h_s);
        */
        if(!imgName.isEmpty()){

            reader->setFileName(imgFolder+imgName);
            reader->read(img);
            grayimg = convertToGrayScale(*img);
            grayimg = grayimg.scaled(originRect.width(),originRect.height()).transformed(QMatrix().rotate(angle));
            
            if(bGrayscale)
                this->setPixmap(QPixmap::fromImage(grayimg));
            else
                this->setPixmap(QPixmap::fromImage(img->scaled(originRect.width(),originRect.height()).transformed(QMatrix().rotate(angle))));
		    QLabel::setGeometry(this->x(), this->y(), this->pixmap()->size().width(), this->pixmap()->size().height());
        }
    }

protected:
    bool bGrayscale;
    bool visible;
    double objectScale;
    int angle;
    QImage grayimg;
    QImage *img;
    QImageReader *reader ;
    QString imgName;
    QString imgFolder;
    QRect originRect;
};

#endif // GIMAGE_H
