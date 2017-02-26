#ifndef GWEBVIEW_H
#define GWEBVIEW_H
#include <QPushButton>
class GWebView : public QPushButton
{
    Q_OBJECT
public:
    GWebView(QWidget *parent=0):QPushButton(parent)
    {
        setText("WebView");
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

#endif // GWEBVIEW_H
