/*
 *   Copyright 20012 Maxime Haselbauer <maxime.haselbauer@googlemail.com>
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Library General Public License as
 *   published by the Free Software Foundation; either version 2, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details
 *
 *   You should have received a copy of the GNU Library General Public
 *   License along with this program; if not, write to the
 *   Free Software Foundation, Inc.,
 *   51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */


#ifndef GNUMPAD_H
#define GNUMPAD_H

#include <QWidget>
#include <QString>
#include <QDebug>
#include "ui_numpad.h"
namespace Ui {
    class GNumpad;
}

class GNumpad : public QWidget
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{DC27EB90-5309-452B-9F3D-B98B887EAECC}")
    Q_CLASSINFO("InterfaceID", "{7C16C63D-5227-48BA-8A8E-DF9561BFB14A}")
    Q_CLASSINFO("EventsID", "{AC4DDC98-235D-4DBA-90DB-E3BD94C6595B}")
    Q_CLASSINFO("ToSuperClass", "GNumpad")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY(int num_color READ numColor WRITE setNumColor)
    Q_PROPERTY(int num_button_color READ numButtonColor WRITE setNumButtonColor)
    Q_PROPERTY(int reset_color READ resetColor WRITE setResetColor)
    Q_PROPERTY(int reset_button_color READ resetButtonColor WRITE setResetButtonColor)
    Q_PROPERTY(int ok_color READ okColor WRITE setOkColor)
    Q_PROPERTY(int ok_button_color READ okButtonColor WRITE setOkButtonColor)
    Q_PROPERTY(int border_color READ borderColor WRITE setBorderColor)

public:
    GNumpad(QWidget *parent = 0) : QWidget(parent), NUMPAD(new Ui::GNumpad)
    {
        NUMPAD->setupUi(this);
        value ="";
        numBGQColor.setRgb(0x0000FF);
        num_button_color = 0xFF;
        numQColor.setRgb(0xFFFFFF);
        num_color = 0xFFFFFF;
        okBGQColor.setRgb(0x6424BD);
        ok_button_color = 0x6424BD;
        okQColor.setRgb(0xFFFFFF);
        ok_color = 0xFFFFFF;
        resetBGQColor.setRgb(0x0000B7);
        reset_button_color = 0xB7;
        resetQColor.setRgb(0xFFFFFF);
        reset_color = 0xFFFFFF;
        borderQColor.setRgb(0xFFFFFF);
        border_color = 0xFFFFFF;
        colorUpdate();
    }
    ~GNumpad()
    {
        delete NUMPAD;
    }
    double get_Value();

    int numColor()
    {
        return num_color;
    }
    int numButtonColor()
    {
        return num_button_color;
    }
    int resetColor()
    {
        return reset_color;
    }
    int resetButtonColor()
    {
        return reset_button_color;
    }
    int okColor()
    {
        return ok_color;
    }
    int okButtonColor()
    {
        return ok_button_color;
    }
    int borderColor()
    {
        return border_color;
    }

    void setNumColor(int color)
    {
        num_color = color;
        numQColor.setRgb(color&0xFFFFFF);
        colorUpdate();
    }
    void setOkColor(int color)
    {
        ok_color = color;
        okQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
    }
    void setResetColor(int color){
        reset_color = color;
        resetQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
    }
    void setNumButtonColor(int color)
    {
        num_button_color = color;
        numBGQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
    }
    void setOkButtonColor(int color)
    {
        ok_button_color = color;
        okBGQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
    }
    void setResetButtonColor(int color)
    {
        reset_button_color = color;
        resetBGQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
    }
    void setBorderColor(int color)
    {
        border_color = color;
        borderQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
    }
    void colorUpdate()
    {
        NUMPAD->QPB_0->setStyleSheet(QString("background-color: rgb(%1,%2,%3);").arg(numBGQColor.red()).arg(numBGQColor.green()).arg(numBGQColor.blue())
                                    + QString("color: rgb(%1,%2,%3);").arg(numQColor.red()).arg(numQColor.green()).arg(numQColor.blue())
                                    + QString("border: 0.5px solid rgb(%2,%3,%4);").arg(borderQColor.red()).arg(borderQColor.green()).arg(borderQColor.blue()));
        NUMPAD->QPB_1->setStyleSheet(NUMPAD->QPB_0->styleSheet());
        NUMPAD->QPB_2->setStyleSheet(NUMPAD->QPB_0->styleSheet());
        NUMPAD->QPB_3->setStyleSheet(NUMPAD->QPB_0->styleSheet());
        NUMPAD->QPB_4->setStyleSheet(NUMPAD->QPB_0->styleSheet());
        NUMPAD->QPB_5->setStyleSheet(NUMPAD->QPB_0->styleSheet());
        NUMPAD->QPB_6->setStyleSheet(NUMPAD->QPB_0->styleSheet());
        NUMPAD->QPB_7->setStyleSheet(NUMPAD->QPB_0->styleSheet());
        NUMPAD->QPB_8->setStyleSheet(NUMPAD->QPB_0->styleSheet());
        NUMPAD->QPB_9->setStyleSheet(NUMPAD->QPB_0->styleSheet());
        NUMPAD->OK_BTN->setStyleSheet(QString("background-color: rgb(%1,%2,%3);").arg(okBGQColor.red()).arg(okBGQColor.green()).arg(okBGQColor.blue())
                                    + QString("color: rgb(%1,%2,%3);").arg(okQColor.red()).arg(okQColor.green()).arg(okQColor.blue())
                                    + QString("border: 0.5px solid rgb(%2,%3,%4);").arg(borderQColor.red()).arg(borderQColor.green()).arg(borderQColor.blue()));
        NUMPAD->RST_BTN->setStyleSheet(QString("background-color: rgb(%1,%2,%3);").arg(resetBGQColor.red()).arg(resetBGQColor.green()).arg(resetBGQColor.blue())
                                    + QString("color: rgb(%1,%2,%3);").arg(resetQColor.red()).arg(resetQColor.green()).arg(resetQColor.blue())
                                    + QString("border: 0.5px solid rgb(%2,%3,%4);").arg(borderQColor.red()).arg(borderQColor.green()).arg(borderQColor.blue()));
        update();
    }

private:
    Ui::GNumpad *NUMPAD;
    QString value;
    QColor numQColor,numBGQColor;
    QColor okQColor,okBGQColor;
    QColor resetQColor,resetBGQColor;
    QColor borderQColor;

    int num_color, num_button_color;
    int reset_color, reset_button_color;
    int ok_color, ok_button_color;
    int border_color;

};

#endif // NUMPAD_H
