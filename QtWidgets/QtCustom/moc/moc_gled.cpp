/****************************************************************************
** Meta object code from reading C++ file 'gled.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gled.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gled.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GLed_t {
    QByteArrayData data[12];
    char stringdata0[200];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GLed_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GLed_t qt_meta_stringdata_GLed = {
    {
QT_MOC_LITERAL(0, 0, 4), // "GLed"
QT_MOC_LITERAL(1, 5, 7), // "ClassID"
QT_MOC_LITERAL(2, 13, 38), // "{72F04CB6-BACF-49B7-9C29-DE01..."
QT_MOC_LITERAL(3, 52, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 64, 38), // "{27036263-33FF-4EED-BA44-343B..."
QT_MOC_LITERAL(5, 103, 8), // "EventsID"
QT_MOC_LITERAL(6, 112, 38), // "{76D935E7-62D2-409A-977E-C8C6..."
QT_MOC_LITERAL(7, 151, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 164, 11), // "StockEvents"
QT_MOC_LITERAL(9, 176, 3), // "yes"
QT_MOC_LITERAL(10, 180, 10), // "Insertable"
QT_MOC_LITERAL(11, 191, 8) // "ledColor"

    },
    "GLed\0ClassID\0{72F04CB6-BACF-49B7-9C29-DE0180EBA833}\0"
    "InterfaceID\0{27036263-33FF-4EED-BA44-343BE0FD3A7B}\0"
    "EventsID\0{76D935E7-62D2-409A-977E-C8C65B8DD722}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "ledColor"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GLed[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
       1,   26, // properties
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

 // properties: name, type, flags
      11, QMetaType::Int, 0x00095103,

       0        // eod
};

void GLed::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        GLed *_t = static_cast<GLed *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->LedColor(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GLed *_t = static_cast<GLed *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setLedColor(*reinterpret_cast< int*>(_v)); break;
        default: break;
        }
    } else if (_c == QMetaObject::ResetProperty) {
    }
#endif // QT_NO_PROPERTIES
    Q_UNUSED(_o);
    Q_UNUSED(_id);
    Q_UNUSED(_c);
    Q_UNUSED(_a);
}

const QMetaObject GLed::staticMetaObject = {
    { &WidgetWithBackground::staticMetaObject, qt_meta_stringdata_GLed.data,
      qt_meta_data_GLed,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GLed::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GLed::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GLed.stringdata0))
        return static_cast<void*>(const_cast< GLed*>(this));
    return WidgetWithBackground::qt_metacast(_clname);
}

int GLed::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = WidgetWithBackground::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    
#ifndef QT_NO_PROPERTIES
   if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 1;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 1;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 1;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 1;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 1;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 1;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
