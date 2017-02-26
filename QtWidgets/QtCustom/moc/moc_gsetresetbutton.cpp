/****************************************************************************
** Meta object code from reading C++ file 'gsetresetbutton.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gsetresetbutton.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gsetresetbutton.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GSetResetButton_t {
    QByteArrayData data[11];
    char stringdata0[202];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GSetResetButton_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GSetResetButton_t qt_meta_stringdata_GSetResetButton = {
    {
QT_MOC_LITERAL(0, 0, 15), // "GSetResetButton"
QT_MOC_LITERAL(1, 16, 7), // "ClassID"
QT_MOC_LITERAL(2, 24, 38), // "{C1193D10-7C58-47CA-AF8C-2F73..."
QT_MOC_LITERAL(3, 63, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 75, 38), // "{502EA99F-632A-4BCB-98FF-A71A..."
QT_MOC_LITERAL(5, 114, 8), // "EventsID"
QT_MOC_LITERAL(6, 123, 38), // "{4E60D959-F23D-4968-85FD-2695..."
QT_MOC_LITERAL(7, 162, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 175, 11), // "StockEvents"
QT_MOC_LITERAL(9, 187, 3), // "yes"
QT_MOC_LITERAL(10, 191, 10) // "Insertable"

    },
    "GSetResetButton\0ClassID\0"
    "{C1193D10-7C58-47CA-AF8C-2F731CBF5199}\0"
    "InterfaceID\0{502EA99F-632A-4BCB-98FF-A71A41677D44}\0"
    "EventsID\0{4E60D959-F23D-4968-85FD-2695AA7CC29D}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GSetResetButton[] = {

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

void GSetResetButton::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    Q_UNUSED(_o);
    Q_UNUSED(_id);
    Q_UNUSED(_c);
    Q_UNUSED(_a);
}

const QMetaObject GSetResetButton::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_GSetResetButton.data,
      qt_meta_data_GSetResetButton,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GSetResetButton::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GSetResetButton::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GSetResetButton.stringdata0))
        return static_cast<void*>(const_cast< GSetResetButton*>(this));
    return QWidget::qt_metacast(_clname);
}

int GSetResetButton::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    return _id;
}
QT_END_MOC_NAMESPACE
