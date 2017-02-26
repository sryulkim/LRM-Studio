/****************************************************************************
** Meta object code from reading C++ file 'colourfulslider.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../colourfulslider.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'colourfulslider.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_ColourfulQSlider_t {
    QByteArrayData data[13];
    char stringdata0[247];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_ColourfulQSlider_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_ColourfulQSlider_t qt_meta_stringdata_ColourfulQSlider = {
    {
QT_MOC_LITERAL(0, 0, 16), // "ColourfulQSlider"
QT_MOC_LITERAL(1, 17, 7), // "ClassID"
QT_MOC_LITERAL(2, 25, 38), // "{035A916A-310C-4185-8DEB-8B05..."
QT_MOC_LITERAL(3, 64, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 76, 38), // "{BC8D2451-96E7-4213-864D-7202..."
QT_MOC_LITERAL(5, 115, 8), // "EventsID"
QT_MOC_LITERAL(6, 124, 38), // "{AE5ED403-2D0C-46BF-A04C-0E9F..."
QT_MOC_LITERAL(7, 163, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 176, 11), // "StockEvents"
QT_MOC_LITERAL(9, 188, 3), // "yes"
QT_MOC_LITERAL(10, 192, 10), // "Insertable"
QT_MOC_LITERAL(11, 203, 19), // "button_color_number"
QT_MOC_LITERAL(12, 223, 23) // "background_color_number"

    },
    "ColourfulQSlider\0ClassID\0"
    "{035A916A-310C-4185-8DEB-8B05F285CAEA}\0"
    "InterfaceID\0{BC8D2451-96E7-4213-864D-72022978B286}\0"
    "EventsID\0{AE5ED403-2D0C-46BF-A04C-0E9F205FA688}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "button_color_number\0background_color_number"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_ColourfulQSlider[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
       2,   26, // properties
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

       0        // eod
};

void ColourfulQSlider::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        ColourfulQSlider *_t = static_cast<ColourfulQSlider *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->buttonColorNumber(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->backgroundColorNumber(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        ColourfulQSlider *_t = static_cast<ColourfulQSlider *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setButtonColorNumber(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setBackgroundColorNumber(*reinterpret_cast< int*>(_v)); break;
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

const QMetaObject ColourfulQSlider::staticMetaObject = {
    { &QSlider::staticMetaObject, qt_meta_stringdata_ColourfulQSlider.data,
      qt_meta_data_ColourfulQSlider,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *ColourfulQSlider::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *ColourfulQSlider::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_ColourfulQSlider.stringdata0))
        return static_cast<void*>(const_cast< ColourfulQSlider*>(this));
    return QSlider::qt_metacast(_clname);
}

int ColourfulQSlider::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QSlider::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    
#ifndef QT_NO_PROPERTIES
   if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 2;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 2;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 2;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 2;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 2;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 2;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
