/****************************************************************************
** Meta object code from reading C++ file 'colourfuldial.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../colourfuldial.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'colourfuldial.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_ColourfulQDial_t {
    QByteArrayData data[13];
    char stringdata0[245];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_ColourfulQDial_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_ColourfulQDial_t qt_meta_stringdata_ColourfulQDial = {
    {
QT_MOC_LITERAL(0, 0, 14), // "ColourfulQDial"
QT_MOC_LITERAL(1, 15, 7), // "ClassID"
QT_MOC_LITERAL(2, 23, 38), // "{877766E2-800E-48F0-83C1-F2C4..."
QT_MOC_LITERAL(3, 62, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 74, 38), // "{A023D60E-5C7A-4D55-A7C0-75DC..."
QT_MOC_LITERAL(5, 113, 8), // "EventsID"
QT_MOC_LITERAL(6, 122, 38), // "{CA6514DB-A922-42A6-8CA5-9B01..."
QT_MOC_LITERAL(7, 161, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 174, 11), // "StockEvents"
QT_MOC_LITERAL(9, 186, 3), // "yes"
QT_MOC_LITERAL(10, 190, 10), // "Insertable"
QT_MOC_LITERAL(11, 201, 19), // "button_color_number"
QT_MOC_LITERAL(12, 221, 23) // "background_color_number"

    },
    "ColourfulQDial\0ClassID\0"
    "{877766E2-800E-48F0-83C1-F2C4F8A2D820}\0"
    "InterfaceID\0{A023D60E-5C7A-4D55-A7C0-75DCAF7E421E}\0"
    "EventsID\0{CA6514DB-A922-42A6-8CA5-9B01F49FD9C3}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "button_color_number\0background_color_number"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_ColourfulQDial[] = {

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

void ColourfulQDial::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        ColourfulQDial *_t = static_cast<ColourfulQDial *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->buttonColorNumber(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->backgroundColorNumber(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        ColourfulQDial *_t = static_cast<ColourfulQDial *>(_o);
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

const QMetaObject ColourfulQDial::staticMetaObject = {
    { &QDial::staticMetaObject, qt_meta_stringdata_ColourfulQDial.data,
      qt_meta_data_ColourfulQDial,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *ColourfulQDial::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *ColourfulQDial::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_ColourfulQDial.stringdata0))
        return static_cast<void*>(const_cast< ColourfulQDial*>(this));
    return QDial::qt_metacast(_clname);
}

int ColourfulQDial::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QDial::qt_metacall(_c, _id, _a);
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
