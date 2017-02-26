#ifndef GIPCAMERA_H
#define GIPCAMERA_H
#include <QPushButton>
class GIPCamera : public QPushButton
{
    Q_OBJECT
public:
    GIPCamera(QWidget *parent=0):QPushButton(parent)
    {
        setText("IPCamera");
        QColor buttonQColor;
        QColor borderQColor;
        buttonQColor.setRgb(0xFFFFFF);
        buttonQColor.setAlpha(0xFF);
        borderQColor.setRgb(0x0);
        borderQColor.setAlpha(0xFF);
        this->setStyleSheet(QString("border: %1px solid rgb(%2,%3,%4);").arg(2).arg(borderQColor.red()).arg(borderQColor.green()).arg(borderQColor.blue())
                            +QString("background-color: rgba(%1,%2,%3,%4);").arg(buttonQColor.red()).arg(buttonQColor.green()).arg(buttonQColor.blue()).arg(buttonQColor.alpha())
                            );
    }
};

#endif // GIPCAMERA_H
