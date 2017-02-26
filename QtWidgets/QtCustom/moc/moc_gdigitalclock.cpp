/****************************************************************************
** Meta object code from reading C++ file 'gdigitalclock.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gdigitalclock.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gdigitalclock.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GDigitalClock_t {
    QByteArrayData data[18];
    char stringdata0[261];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GDigitalClock_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GDigitalClock_t qt_meta_stringdata_GDigitalClock = {
    {
QT_MOC_LITERAL(0, 0, 13), // "GDigitalClock"
QT_MOC_LITERAL(1, 14, 7), // "ClassID"
QT_MOC_LITERAL(2, 22, 38), // "{B79F6C6A-FE86-4846-898D-EF12..."
QT_MOC_LITERAL(3, 61, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 73, 38), // "{B2D40325-445A-4BD7-A8AE-527D..."
QT_MOC_LITERAL(5, 112, 8), // "EventsID"
QT_MOC_LITERAL(6, 121, 38), // "{B1A85E37-66AA-46CE-B2F3-3095..."
QT_MOC_LITERAL(7, 160, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 173, 11), // "StockEvents"
QT_MOC_LITERAL(9, 185, 3), // "yes"
QT_MOC_LITERAL(10, 189, 10), // "Insertable"
QT_MOC_LITERAL(11, 200, 8), // "showTime"
QT_MOC_LITERAL(12, 209, 0), // ""
QT_MOC_LITERAL(13, 210, 10), // "clockColor"
QT_MOC_LITERAL(14, 221, 11), // "borderColor"
QT_MOC_LITERAL(15, 233, 9), // "fontColor"
QT_MOC_LITERAL(16, 243, 8), // "fontBold"
QT_MOC_LITERAL(17, 252, 8) // "fontSize"

    },
    "GDigitalClock\0ClassID\0"
    "{B79F6C6A-FE86-4846-898D-EF12937EECCE}\0"
    "InterfaceID\0{B2D40325-445A-4BD7-A8AE-527D91301678}\0"
    "EventsID\0{B1A85E37-66AA-46CE-B2F3-3095F682F338}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "showTime\0\0clockColor\0borderColor\0"
    "fontColor\0fontBold\0fontSize"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GDigitalClock[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       1,   26, // methods
       5,   32, // properties
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

 // slots: name, argc, parameters, tag, flags
      11,    0,   31,   12, 0x08 /* Private */,

 // slots: parameters
    QMetaType::Void,

 // properties: name, type, flags
      13, QMetaType::Int, 0x00095003,
      14, QMetaType::Int, 0x00095003,
      15, QMetaType::Int, 0x00095003,
      16, QMetaType::Bool, 0x00095103,
      17, QMetaType::Int, 0x00095103,

       0        // eod
};

void GDigitalClock::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        GDigitalClock *_t = static_cast<GDigitalClock *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->showTime(); break;
        default: ;
        }
    }
#ifndef QT_NO_PROPERTIES
    else if (_c == QMetaObject::ReadProperty) {
        GDigitalClock *_t = static_cast<GDigitalClock *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->ClockColor(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->BorderColor(); break;
        case 2: *reinterpret_cast< int*>(_v) = _t->FontColor(); break;
        case 3: *reinterpret_cast< bool*>(_v) = _t->FontBold(); break;
        case 4: *reinterpret_cast< int*>(_v) = _t->FontSize(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GDigitalClock *_t = static_cast<GDigitalClock *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setClockQColor(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setBorderQColor(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setFontQColor(*reinterpret_cast< int*>(_v)); break;
        case 3: _t->setFontBold(*reinterpret_cast< bool*>(_v)); break;
        case 4: _t->setFontSize(*reinterpret_cast< int*>(_v)); break;
        default: break;
        }
    } else if (_c == QMetaObject::ResetProperty) {
    }
#endif // QT_NO_PROPERTIES
    Q_UNUSED(_a);
}

const QMetaObject GDigitalClock::staticMetaObject = {
    { &QLabel::staticMetaObject, qt_meta_stringdata_GDigitalClock.data,
      qt_meta_data_GDigitalClock,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GDigitalClock::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GDigitalClock::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GDigitalClock.stringdata0))
        return static_cast<void*>(const_cast< GDigitalClock*>(this));
    return QLabel::qt_metacast(_clname);
}

int GDigitalClock::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QLabel::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 1)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 1;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 1)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 1;
    }
#ifndef QT_NO_PROPERTIES
   else if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 5;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 5;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 5;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 5;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 5;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 5;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
