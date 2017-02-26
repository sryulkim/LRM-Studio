/****************************************************************************
** Meta object code from reading C++ file 'gdial.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gdial.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gdial.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GDial_t {
    QByteArrayData data[18];
    char stringdata0[247];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GDial_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GDial_t qt_meta_stringdata_GDial = {
    {
QT_MOC_LITERAL(0, 0, 5), // "GDial"
QT_MOC_LITERAL(1, 6, 7), // "ClassID"
QT_MOC_LITERAL(2, 14, 38), // "{9B1B494C-7696-443B-ADDF-55BB..."
QT_MOC_LITERAL(3, 53, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 65, 38), // "{2A219270-88CA-4DC0-8214-A5C2..."
QT_MOC_LITERAL(5, 104, 8), // "EventsID"
QT_MOC_LITERAL(6, 113, 38), // "{DCD003B1-1BEF-4A41-92BF-0407..."
QT_MOC_LITERAL(7, 152, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 165, 11), // "StockEvents"
QT_MOC_LITERAL(9, 177, 3), // "yes"
QT_MOC_LITERAL(10, 181, 10), // "Insertable"
QT_MOC_LITERAL(11, 192, 10), // "dial_color"
QT_MOC_LITERAL(12, 203, 10), // "font_color"
QT_MOC_LITERAL(13, 214, 12), // "needle_color"
QT_MOC_LITERAL(14, 227, 3), // "min"
QT_MOC_LITERAL(15, 231, 3), // "max"
QT_MOC_LITERAL(16, 235, 5), // "minor"
QT_MOC_LITERAL(17, 241, 5) // "major"

    },
    "GDial\0ClassID\0{9B1B494C-7696-443B-ADDF-55BB09B55CB8}\0"
    "InterfaceID\0{2A219270-88CA-4DC0-8214-A5C2408BB7C4}\0"
    "EventsID\0{DCD003B1-1BEF-4A41-92BF-0407F4D45CC1}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "dial_color\0font_color\0needle_color\0"
    "min\0max\0minor\0major"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GDial[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
       7,   26, // properties
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
      11, QMetaType::Int, 0x00095003,
      12, QMetaType::Int, 0x00095003,
      13, QMetaType::Int, 0x00095003,
      14, QMetaType::Int, 0x00095103,
      15, QMetaType::Int, 0x00095103,
      16, QMetaType::Int, 0x00095103,
      17, QMetaType::Int, 0x00095103,

       0        // eod
};

void GDial::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        GDial *_t = static_cast<GDial *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->dialColor(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->fontColor(); break;
        case 2: *reinterpret_cast< int*>(_v) = _t->needleColor(); break;
        case 3: *reinterpret_cast< int*>(_v) = _t->Min(); break;
        case 4: *reinterpret_cast< int*>(_v) = _t->Max(); break;
        case 5: *reinterpret_cast< int*>(_v) = _t->Minor(); break;
        case 6: *reinterpret_cast< int*>(_v) = _t->Major(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GDial *_t = static_cast<GDial *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setDialColor(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setFontColor(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setNeedleColor(*reinterpret_cast< int*>(_v)); break;
        case 3: _t->setMin(*reinterpret_cast< int*>(_v)); break;
        case 4: _t->setMax(*reinterpret_cast< int*>(_v)); break;
        case 5: _t->setMinor(*reinterpret_cast< int*>(_v)); break;
        case 6: _t->setMajor(*reinterpret_cast< int*>(_v)); break;
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

const QMetaObject GDial::staticMetaObject = {
    { &QwtDial::staticMetaObject, qt_meta_stringdata_GDial.data,
      qt_meta_data_GDial,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GDial::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GDial::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GDial.stringdata0))
        return static_cast<void*>(const_cast< GDial*>(this));
    return QwtDial::qt_metacast(_clname);
}

int GDial::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QwtDial::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    
#ifndef QT_NO_PROPERTIES
   if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 7;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 7;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 7;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 7;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 7;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 7;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
