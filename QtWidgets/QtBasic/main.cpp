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

#include <QAxFactory>
#include <QCheckBox>
#include <QRadioButton>
#include <QPushButton>
#include <QToolButton>
#include <QPixmap>
#include <QSlider>
#include <QDial>
#include <QLCDNumber>


/* XPM */
static const char *fileopen[] = {
"    16    13        5            1",
". c #040404",
"# c #808304",
"a c None",
"b c #f3f704",
"c c #f3f7f3",
"aaaaaaaaa...aaaa",
"aaaaaaaa.aaa.a.a",
"aaaaaaaaaaaaa..a",
"a...aaaaaaaa...a",
".bcb.......aaaaa",
".cbcbcbcbc.aaaaa",
".bcbcbcbcb.aaaaa",
".cbcb...........",
".bcb.#########.a",
".cb.#########.aa",
".b.#########.aaa",
"..#########.aaaa",
"...........aaaaa"
};


//! [0]
class ActiveQtFactory : public QAxFactory
{
public:
    ActiveQtFactory( const QUuid &lib, const QUuid &app )
        : QAxFactory( lib, app )
    {}
    QStringList featureList() const
    {
        QStringList list;
        list << "QtBasicCheckBox";
        list << "QtBasicRadioButton";
        list << "QtBasicPushButton";
        list << "QtBasicToolButton";
        list << "QtBasicDial";
        list << "QtBasicSlider";
        list << "QtBasicLCDNumber";
        return list;
    }
    QObject *createObject(const QString &key)
    {
        if ( key == "QtBasicCheckBox" )
            return new QCheckBox(0);
        if ( key == "QtBasicRadioButton" )
            return new QRadioButton(0);
        if ( key == "QtBasicPushButton" )
            return new QPushButton(0 );
        if ( key == "QtBasicToolButton" ) {
            QToolButton *tb = new QToolButton(0);
//          tb->setIcon( QPixmap(fileopen) );
            return tb;
        }
        if ( key == "QtBasicDial" )
            return new QDial(0);
        if ( key == "QtBasicSlider" )
            return new QSlider(0);
        if ( key == "QtBasicLCDNumber" )
            return new QLCDNumber(5, 0);

        return 0;
    }
    const QMetaObject *metaObject( const QString &key ) const
    {
        if ( key == "QtBasicCheckBox" )
            return &QCheckBox::staticMetaObject;
        if ( key == "QtBasicRadioButton" )
            return &QRadioButton::staticMetaObject;
        if ( key == "QtBasicPushButton" )
            return &QPushButton::staticMetaObject;
        if ( key == "QtBasicToolButton" )
            return &QToolButton::staticMetaObject;
        if ( key == "QtBasicDial" )
            return &QDial::staticMetaObject;
        if ( key == "QtBasicSlider" )
            return &QSlider::staticMetaObject;
        if ( key == "QtBasicLCDNumber" )
            return &QLCDNumber::staticMetaObject;

        return 0;
    }
    QUuid classID( const QString &key ) const
    {
        if ( key == "QtBasicCheckBox" )
            return "{EA16C348-6740-4C6B-A8B7-F167AFE53500}";
        if ( key == "QtBasicRadioButton" )
            return "{88315AFA-3950-48CD-83ED-FDAB0CF4EBA3}";
        if ( key == "QtBasicPushButton" )
            return "{7C17F12A-3A9A-4CBD-94C9-FB9C075F1E78}";
        if ( key == "QtBasicToolButton" )
            return "{EA9828A3-2083-405E-BCAF-99BCA4A94EFF}";
        if ( key == "QtBasicDial" )
            return "{0D67EB4B-78D9-4808-A422-E032E646C70E}";
        if ( key == "QtBasicSlider" )
            return "{C65B6C96-3F59-43BA-B49A-EAB2A7751C4B}";
        if ( key == "QtBasicLCDNumber" )
            return "{697290A5-90D1-4B03-B653-318730D71253}";
        return QUuid();
    }
    QUuid interfaceID( const QString &key ) const
    {
        if ( key == "QtBasicCheckBox" )
            return "{CFD3E492-8E9C-46E8-8D95-A9659DE09999}";
        if ( key == "QtBasicRadioButton" )
            return "{0142889D-D5B5-432D-B87B-C6C1F229D0E1}";
        if ( key == "QtBasicPushButton" )
            return "{5C3AEEE0-28A7-4D0D-BBF5-A1196E11243C}";
        if ( key == "QtBasicToolButton" )
            return "{1FBECBBD-B606-4F2A-9A14-5026B81629C9}";
        if ( key == "QtBasicDial" )
            return "{50600F92-01DF-47EB-A6B8-5AE32C3BF1ED}";
        if ( key == "QtBasicSlider" )
            return "{36C82FFF-E885-4E14-A66C-8A7F3BD7C6CD}";
        if ( key == "QtBasicLCDNumber" )
            return "{A48DB9C2-6C1D-47DE-A6D8-C425DCF819D0}";

        return QUuid();
    }
    QUuid eventsID( const QString &key ) const
    {
        if ( key == "QtBasicCheckBox" )
            return "{2A864F9B-1F4F-4A74-9AEC-98DF7B6E6844}";
        if ( key == "QtBasicRadioButton" )
            return "{B9B2D02B-872D-49D8-856B-0647990705B2}";
        if ( key == "QtBasicPushButton" )
            return "{71E8EF2D-1C61-40C4-ABD0-14F3BE7F537B}";
        if ( key == "QtBasicToolButton" )
            return "{E71486BA-6172-42C1-87AC-EA306258A1B4}";
        if ( key == "QtBasicDial" )
            return "{443A6A9C-BD1C-4F63-BA80-F5807E7D0288}";
        if ( key == "QtBasicSlider" )
            return "{DAC2391D-C261-45F8-9EC0-657A231E45D7}";
        if ( key == "QtBasicLCDNumber" )
            return "{F1EC1009-EF79-4154-B583-5EF8561A9204}";

        return QUuid();
    }
};
//! [0] //! [1]

QAXFACTORY_EXPORT( ActiveQtFactory, "{C832B1CB-DF6F-4380-9BE3-60EE49899A2F}", "{04669EC4-6E80-447D-B122-FB670A89F07A}" )
//! [1]
