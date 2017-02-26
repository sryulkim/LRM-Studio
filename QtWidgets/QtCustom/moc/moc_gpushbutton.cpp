/****************************************************************************
** Meta object code from reading C++ file 'gpushbutton.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gpushbutton.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gpushbutton.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GPushButton_t {
    QByteArrayData data[19];
    char stringdata0[292];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GPushButton_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GPushButton_t qt_meta_stringdata_GPushButton = {
    {
QT_MOC_LITERAL(0, 0, 11), // "GPushButton"
QT_MOC_LITERAL(1, 12, 7), // "ClassID"
QT_MOC_LITERAL(2, 20, 38), // "{574AF946-CE02-4B60-92A8-879F..."
QT_MOC_LITERAL(3, 59, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 71, 38), // "{E496B5F2-FA7F-4880-85F3-BEDF..."
QT_MOC_LITERAL(5, 110, 8), // "EventsID"
QT_MOC_LITERAL(6, 119, 38), // "{37F10C34-A726-4A01-96E1-5C6E..."
QT_MOC_LITERAL(7, 158, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 171, 11), // "StockEvents"
QT_MOC_LITERAL(9, 183, 3), // "yes"
QT_MOC_LITERAL(10, 187, 10), // "Insertable"
QT_MOC_LITERAL(11, 198, 12), // "button_color"
QT_MOC_LITERAL(12, 211, 12), // "border_color"
QT_MOC_LITERAL(13, 224, 10), // "font_color"
QT_MOC_LITERAL(14, 235, 9), // "font_size"
QT_MOC_LITERAL(15, 245, 11), // "button_text"
QT_MOC_LITERAL(16, 257, 9), // "thickness"
QT_MOC_LITERAL(17, 267, 9), // "font_bold"
QT_MOC_LITERAL(18, 277, 14) // "font_underline"

    },
    "GPushButton\0ClassID\0"
    "{574AF946-CE02-4B60-92A8-879FD09855F4}\0"
    "InterfaceID\0{E496B5F2-FA7F-4880-85F3-BEDF8ECE8A6B}\0"
    "EventsID\0{37F10C34-A726-4A01-96E1-5C6E101F58AC}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "button_color\0border_color\0font_color\0"
    "font_size\0button_text\0thickness\0"
    "font_bold\0font_underline"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GPushButton[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
       8,   26, // properties
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
      14, QMetaType::Int, 0x00095003,
      15, QMetaType::QString, 0x00095003,
      16, QMetaType::Float, 0x00095003,
      17, QMetaType::Bool, 0x00095003,
      18, QMetaType::Bool, 0x00095003,

       0        // eod
};

void GPushButton::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        GPushButton *_t = static_cast<GPushButton *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->buttonColor(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->borderColor(); break;
        case 2: *reinterpret_cast< int*>(_v) = _t->fontColor(); break;
        case 3: *reinterpret_cast< int*>(_v) = _t->fontSize(); break;
        case 4: *reinterpret_cast< QString*>(_v) = _t->buttonText(); break;
        case 5: *reinterpret_cast< float*>(_v) = _t->borderThickness(); break;
        case 6: *reinterpret_cast< bool*>(_v) = _t->fontBold(); break;
        case 7: *reinterpret_cast< bool*>(_v) = _t->fontUnderline(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GPushButton *_t = static_cast<GPushButton *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setButtonColor(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setBorderColor(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setFontColor(*reinterpret_cast< int*>(_v)); break;
        case 3: _t->setFontSize(*reinterpret_cast< int*>(_v)); break;
        case 4: _t->setButtonText(*reinterpret_cast< QString*>(_v)); break;
        case 5: _t->setBorderThickness(*reinterpret_cast< float*>(_v)); break;
        case 6: _t->setFontBold(*reinterpret_cast< bool*>(_v)); break;
        case 7: _t->setFontUnderline(*reinterpret_cast< bool*>(_v)); break;
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

const QMetaObject GPushButton::staticMetaObject = {
    { &QPushButton::staticMetaObject, qt_meta_stringdata_GPushButton.data,
      qt_meta_data_GPushButton,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GPushButton::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GPushButton::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GPushButton.stringdata0))
        return static_cast<void*>(const_cast< GPushButton*>(this));
    return QPushButton::qt_metacast(_clname);
}

int GPushButton::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QPushButton::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    
#ifndef QT_NO_PROPERTIES
   if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 8;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 8;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 8;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 8;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 8;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 8;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
