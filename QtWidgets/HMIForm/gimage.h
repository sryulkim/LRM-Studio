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
        QLabel::setGeometry(x, y, w, h);
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
    void setOriginRect(QRect r)
    {
        originRect = r;
        QLabel::setGeometry(r);
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
            grayimg = grayimg.scaled(this->width(),this->height());
            *img = img->scaled(this->width(),this->height());

            if(bGrayscale)
                this->setPixmap(QPixmap::fromImage(grayimg));
            else
                this->setPixmap(QPixmap::fromImage(*img));
        }
    }

protected:
    bool bGrayscale;
    double objectScale;
    QImage grayimg;
    QImage *img;
    QImageReader *reader ;
    QString imgName;
    QString imgFolder;
    QRect originRect;
};

#endif // GIMAGE_H
