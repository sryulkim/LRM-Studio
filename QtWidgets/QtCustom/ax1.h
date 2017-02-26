/****************************************************************************
**
** Copyright (C) 2015 The Qt Company Ltd.
** Contact: http://www.qt.io/licensing/
**
** This file is part of the examples of the Qt Toolkit.
**
** $QT_BEGIN_LICENSE:BSD$
** You may use this file under the terms of the BSD license as follows:
**
** "Redistribution and use in source and binary forms, with or without
** modification, are permitted provided that the following conditions are
** met:
**   * Redistributions of source code must retain the above copyright
**     notice, this list of conditions and the following disclaimer.
**   * Redistributions in binary form must reproduce the above copyright
**     notice, this list of conditions and the following disclaimer in
**     the documentation and/or other materials provided with the
**     distribution.
**   * Neither the name of The Qt Company Ltd nor the names of its
**     contributors may be used to endorse or promote products derived
**     from this software without specific prior written permission.
**
**
** THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
** "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
** LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
** A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
** OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
** SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
** LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
** DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
** THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
** (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
** OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE."
**
** $QT_END_LICENSE$
**
****************************************************************************/

#ifndef AX1_H
#define AX1_H

#include <QWidget>
#include <QPainter>

//! [0]
class QAxWidget1 : public QWidget
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{877766E2-800E-48F0-83C1-F2C4F8A2D820}")
    Q_CLASSINFO("InterfaceID", "{A023D60E-5C7A-4D55-A7C0-75DCAF7E421E}")
    Q_CLASSINFO("EventsID", "{CA6514DB-A922-42A6-8CA5-9B01F49FD9C3}")

    Q_PROPERTY(QColor fillColor READ fillColor WRITE setFillColor)
public:
    QAxWidget1(QWidget *parent = 0)
        : QWidget(parent), fill_color(Qt::red)
    {
    }

    QColor fillColor() const
    {
        return fill_color;
    }
    void setFillColor(const QColor &fc)
    {
        fill_color = fc;
        repaint();
    }

protected:
    void paintEvent(QPaintEvent *e)
    {
        QPainter paint(this);
        QRect r = rect();
        r.adjust(10, 10, -10, -10);
        paint.fillRect(r, fill_color);
    }

private:
    QColor fill_color;
};
//! [0]

#endif // AX1_H
