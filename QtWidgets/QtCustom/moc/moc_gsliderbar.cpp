/****************************************************************************
** Meta object code from reading C++ file 'gsliderbar.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gsliderbar.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gsliderbar.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GSliderbar_t {
    QByteArrayData data[18];
    char stringdata0[250];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GSliderbar_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GSliderbar_t qt_meta_stringdata_GSliderbar = {
    {
QT_MOC_LITERAL(0, 0, 10), // "GSliderbar"
QT_MOC_LITERAL(1, 11, 7), // "ClassID"
QT_MOC_LITERAL(2, 19, 38), // "{343BE7E7-6F64-4AF0-B897-E6B2..."
QT_MOC_LITERAL(3, 58, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 70, 38), // "{5F113DFA-7B7C-4C28-86F7-744A..."
QT_MOC_LITERAL(5, 109, 8), // "EventsID"
QT_MOC_LITERAL(6, 118, 38), // "{41069664-CC17-42C2-B034-45C4..."
QT_MOC_LITERAL(7, 157, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 170, 11), // "StockEvents"
QT_MOC_LITERAL(9, 182, 3), // "yes"
QT_MOC_LITERAL(10, 186, 10), // "Insertable"
QT_MOC_LITERAL(11, 197, 12), // "slider_color"
QT_MOC_LITERAL(12, 210, 12), // "handle_color"
QT_MOC_LITERAL(13, 223, 3), // "min"
QT_MOC_LITERAL(14, 227, 3), // "max"
QT_MOC_LITERAL(15, 231, 5), // "minor"
QT_MOC_LITERAL(16, 237, 5), // "major"
QT_MOC_LITERAL(17, 243, 6) // "orient"

    },
    "GSliderbar\0ClassID\0"
    "{343BE7E7-6F64-4AF0-B897-E6B289822E6A}\0"
    "InterfaceID\0{5F113DFA-7B7C-4C28-86F7-744A9A43E78A}\0"
    "EventsID\0{41069664-CC17-42C2-B034-45C4615E358D}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "slider_color\0handle_color\0min\0max\0"
    "minor\0major\0orient"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GSliderbar[] = {

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
      13, QMetaType::Int, 0x00095103,
      14, QMetaType::Int, 0x00095103,
      15, QMetaType::Int, 0x00095103,
      16, QMetaType::Int, 0x00095103,
      17, QMetaType::Int, 0x00095103,

       0        // eod
};

void GSliderbar::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        GSliderbar *_t = static_cast<GSliderbar *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->sliderColor(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->handleColor(); break;
        case 2: *reinterpret_cast< int*>(_v) = _t->Min(); break;
        case 3: *reinterpret_cast< int*>(_v) = _t->Max(); break;
        case 4: *reinterpret_cast< int*>(_v) = _t->Minor(); break;
        case 5: *reinterpret_cast< int*>(_v) = _t->Major(); break;
        case 6: *reinterpret_cast< int*>(_v) = _t->Orientation(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GSliderbar *_t = static_cast<GSliderbar *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setSliderColor(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setHandleColor(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setMin(*reinterpret_cast< int*>(_v)); break;
        case 3: _t->setMax(*reinterpret_cast< int*>(_v)); break;
        case 4: _t->setMinor(*reinterpret_cast< int*>(_v)); break;
        case 5: _t->setMajor(*reinterpret_cast< int*>(_v)); break;
        case 6: _t->setOrient(*reinterpret_cast< int*>(_v)); break;
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

const QMetaObject GSliderbar::staticMetaObject = {
    { &QwtSlider::staticMetaObject, qt_meta_stringdata_GSliderbar.data,
      qt_meta_data_GSliderbar,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GSliderbar::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GSliderbar::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GSliderbar.stringdata0))
        return static_cast<void*>(const_cast< GSliderbar*>(this));
    return QwtSlider::qt_metacast(_clname);
}

int GSliderbar::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QwtSlider::qt_metacall(_c, _id, _a);
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
