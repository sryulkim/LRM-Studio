#ifndef GPROGRESSBAR_H
#define GPROGRESSBAR_H
#include <qwt_thermo.h>
#include <qwt_scale_engine.h>
#include <qwt_transform.h>
#include <qwt_color_map.h>
class GProgressBar : public QwtThermo
{
    Q_OBJECT
public:
    enum sectionType{
        first, second, third
    };
    GProgressBar(QWidget *parent=0): QwtThermo(parent)
    {
        value = 50.0;
        sectionNumber = 2;
        min = 0;
        max = 100;
        section[0] = 40;
        section[1] = 60;
        sectionEnable = false;
        progressColor = 0xBDBDBD;
        this->setOrientation(Qt::Vertical);
        this->setScale(min, max);
        this->setValue(value);
        drawSectionColor();
    }
    int Min()
    {
        return min;
    }

    int Max()
    {
        return max;
    }
    int Major()
    {
        return major;
    }
    int Minor()
    {
        return minor;
    }
    int Orient()
    {
        return orient;
    }
    int ProgressColor()
    {
        return progressColor;
    }

    void setMin(int mi)
    {
        min = mi;
        setMinMax(min, max);
    }
    void setMax(int ma)
    {
        max = ma;
        setMinMax(min, max);
    }

    void setMinMax(int mi, int ma)
    {
        setScale(mi,ma);
        drawSectionColor();
    } //set Range
    void setMaxminor(int i)
    {
        minor = i;
        setScaleMaxMinor(i);
        drawSectionColor();
    } //set the number of minor scale
    void setMaxmajor(int i)
    {
        major = i;
        setScaleMaxMajor(i);
        drawSectionColor();
    } //set the number of major scale
    void setSection(double first,double second)
    {
        section[0] = first;
        section[1] = second;
        drawSectionColor();
    } //set section value
    void drawSectionColor(void)
    {
        QColor temp1(sectionColor[first]);
        QColor temp2(sectionColor[second]);
        QColor temp3(sectionColor[third]);
        colorMap = new QwtLinearColorMap();
        colorMap->setMode(QwtLinearColorMap::FixedColors);
        if(sectionEnable){
            colorMap->addColorStop(0,temp1);
            colorMap->addColorStop((section[0]-lowerBound())/(upperBound()-lowerBound()),temp2);
            if(section[0] < section[1]){
                colorMap->addColorStop((section[1]-lowerBound())/(upperBound()-lowerBound()),temp3);
            }
        }
        else{
            colorMap->addColorStop(0,QColor(progressColor));
        }
        this->setColorMap(colorMap);
        setScaleStepSize((upperBound()-lowerBound())/scaleMaxMajor());
        update();
    } //set section color
    void setDirection(int i)
    {
        orient = i;
        if(i==2)
            setOrientation(Qt::Vertical);
        else if(i==1)
            setOrientation(Qt::Horizontal);
    } //set Orientation
    void setProgressColor(int color)
    {
        progressColor = color;
        drawSectionColor();
    } //set Default ProgressBar Color
    void setSectionEnable(bool i){sectionEnable = i; drawSectionColor();} //set Section Enable
private:
    int min,max;
    int major,minor;
    int orient;

    double value;
    double section[2];
    int sectionColor[3]={0xFF0000,0xFFE400,0x2F9D27};
    int sectionNumber;
    int progressColor;
    bool sectionEnable;
    QwtLinearColorMap *colorMap;
};

#endif // GPROGRESSBAR_H
