/****************************************************************************
** Meta object code from reading C++ file 'gincdecbutton.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gincdecbutton.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gincdecbutton.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GIncDecButton_t {
    QByteArrayData data[11];
    char stringdata0[200];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GIncDecButton_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GIncDecButton_t qt_meta_stringdata_GIncDecButton = {
    {
QT_MOC_LITERAL(0, 0, 13), // "GIncDecButton"
QT_MOC_LITERAL(1, 14, 7), // "ClassID"
QT_MOC_LITERAL(2, 22, 38), // "{30D1EE34-A304-4D03-AADE-ADEE..."
QT_MOC_LITERAL(3, 61, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 73, 38), // "{66B03BE6-0248-4FE3-8BF7-7FF1..."
QT_MOC_LITERAL(5, 112, 8), // "EventsID"
QT_MOC_LITERAL(6, 121, 38), // "{2E304017-D1AA-48B4-8680-A443..."
QT_MOC_LITERAL(7, 160, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 173, 11), // "StockEvents"
QT_MOC_LITERAL(9, 185, 3), // "yes"
QT_MOC_LITERAL(10, 189, 10) // "Insertable"

    },
    "GIncDecButton\0ClassID\0"
    "{30D1EE34-A304-4D03-AADE-ADEE44F9C77A}\0"
    "InterfaceID\0{66B03BE6-0248-4FE3-8BF7-7FF1A819EBA0}\0"
    "EventsID\0{2E304017-D1AA-48B4-8680-A4439B17B4CC}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GIncDecButton[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // classinfo: key, value
       1,    2,
       3,    4,
       5,    6,
       7,    0,
       8,    9,
      10,    9,

       0        // eod
};

void GIncDecButton::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    Q_UNUSED(_o);
    Q_UNUSED(_id);
    Q_UNUSED(_c);
    Q_UNUSED(_a);
}

const QMetaObject GIncDecButton::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_GIncDecButton.data,
      qt_meta_data_GIncDecButton,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GIncDecButton::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GIncDecButton::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GIncDecButton.stringdata0))
        return static_cast<void*>(const_cast< GIncDecButton*>(this));
    return QWidget::qt_metacast(_clname);
}

int GIncDecButton::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    return _id;
}
QT_END_MOC_NAMESPACE
