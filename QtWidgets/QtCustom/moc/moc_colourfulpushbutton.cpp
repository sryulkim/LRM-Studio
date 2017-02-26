/****************************************************************************
** Meta object code from reading C++ file 'colourfulpushbutton.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../colourfulpushbutton.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'colourfulpushbutton.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_ColourfulQPushButton_t {
    QByteArrayData data[14];
    char stringdata0[263];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_ColourfulQPushButton_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_ColourfulQPushButton_t qt_meta_stringdata_ColourfulQPushButton = {
    {
QT_MOC_LITERAL(0, 0, 20), // "ColourfulQPushButton"
QT_MOC_LITERAL(1, 21, 7), // "ClassID"
QT_MOC_LITERAL(2, 29, 38), // "{EBCEB291-AF3B-40AB-ABCF-E789..."
QT_MOC_LITERAL(3, 68, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 80, 38), // "{88364BE2-A839-4384-A062-C7F6..."
QT_MOC_LITERAL(5, 119, 8), // "EventsID"
QT_MOC_LITERAL(6, 128, 38), // "{6B519C9A-B6A2-432D-BDEB-23D6..."
QT_MOC_LITERAL(7, 167, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 180, 11), // "StockEvents"
QT_MOC_LITERAL(9, 192, 3), // "yes"
QT_MOC_LITERAL(10, 196, 10), // "Insertable"
QT_MOC_LITERAL(11, 207, 19), // "button_color_number"
QT_MOC_LITERAL(12, 227, 23), // "background_color_number"
QT_MOC_LITERAL(13, 251, 11) // "button_text"

    },
    "ColourfulQPushButton\0ClassID\0"
    "{EBCEB291-AF3B-40AB-ABCF-E7893CD9967F}\0"
    "InterfaceID\0{88364BE2-A839-4384-A062-C7F61D466B11}\0"
    "EventsID\0{6B519C9A-B6A2-432D-BDEB-23D608491DFB}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "button_color_number\0background_color_number\0"
    "button_text"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_ColourfulQPushButton[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
       3,   26, // properties
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
      13, QMetaType::QString, 0x00095003,

       0        // eod
};

void ColourfulQPushButton::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        ColourfulQPushButton *_t = static_cast<ColourfulQPushButton *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->buttonColorNumber(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->backgroundColorNumber(); break;
        case 2: *reinterpret_cast< QString*>(_v) = _t->buttonText(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        ColourfulQPushButton *_t = static_cast<ColourfulQPushButton *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setButtonColorNumber(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setBackgroundColorNumber(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setButtonText(*reinterpret_cast< QString*>(_v)); break;
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

const QMetaObject ColourfulQPushButton::staticMetaObject = {
    { &QPushButton::staticMetaObject, qt_meta_stringdata_ColourfulQPushButton.data,
      qt_meta_data_ColourfulQPushButton,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *ColourfulQPushButton::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *ColourfulQPushButton::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_ColourfulQPushButton.stringdata0))
        return static_cast<void*>(const_cast< ColourfulQPushButton*>(this));
    return QPushButton::qt_metacast(_clname);
}

int ColourfulQPushButton::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QPushButton::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    
#ifndef QT_NO_PROPERTIES
   if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 3;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 3;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 3;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 3;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 3;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 3;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
