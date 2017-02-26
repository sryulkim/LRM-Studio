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
#include <qwt_dial.h>

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
        list << "QwtDial";
        return list;
    }
    QObject *createObject(const QString &key)
    {
        if ( key == "QwtDial" ){
            return new QwtDial(0);
        }

        return 0;
    }
    const QMetaObject *metaObject( const QString &key ) const
    {
        if ( key == "QwtDial" )
            return &QwtDial::staticMetaObject;

        return 0;
    }
    QUuid classID( const QString &key ) const
    {
        if ( key == "QwtDial" )
            return "{6A842ACF-7668-4726-B471-0B114571452C}";

        return QUuid();
    }
    QUuid interfaceID( const QString &key ) const
    {
        if ( key == "QwtDial" )
            return "{7B345FCD-70B4-45F1-89DE-3FE9D124EF66}";

        return QUuid();
    }
    QUuid eventsID( const QString &key ) const
    {
        if ( key == "QwtDial" )
            return "{2A0A0462-FD7A-4D99-9E31-964EE8014569}";

        return QUuid();
    }
};
//! [0] //! [1]

QAXFACTORY_EXPORT( ActiveQtFactory, "{DD66E3AF-2506-4779-98AD-C6437D753F52}", "{B2FB84C2-9E16-4AB0-9761-5017DA403743}" )
//! [1]
