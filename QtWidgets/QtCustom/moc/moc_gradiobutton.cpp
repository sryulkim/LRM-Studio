/****************************************************************************
** Meta object code from reading C++ file 'gradiobutton.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gradiobutton.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gradiobutton.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GRadioButton_t {
    QByteArrayData data[17];
    char stringdata0[268];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GRadioButton_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GRadioButton_t qt_meta_stringdata_GRadioButton = {
    {
QT_MOC_LITERAL(0, 0, 12), // "GRadioButton"
QT_MOC_LITERAL(1, 13, 7), // "ClassID"
QT_MOC_LITERAL(2, 21, 38), // "{09D4E40E-61AE-4BA3-814F-5DE0..."
QT_MOC_LITERAL(3, 60, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 72, 38), // "{D3B7CED6-76AC-4FA1-BC01-D0C1..."
QT_MOC_LITERAL(5, 111, 8), // "EventsID"
QT_MOC_LITERAL(6, 120, 38), // "{A7968A2B-AC48-43E3-9FC5-2481..."
QT_MOC_LITERAL(7, 159, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 172, 11), // "StockEvents"
QT_MOC_LITERAL(9, 184, 3), // "yes"
QT_MOC_LITERAL(10, 188, 10), // "Insertable"
QT_MOC_LITERAL(11, 199, 5), // "count"
QT_MOC_LITERAL(12, 205, 16), // "background_color"
QT_MOC_LITERAL(13, 222, 10), // "font_color"
QT_MOC_LITERAL(14, 233, 9), // "font_size"
QT_MOC_LITERAL(15, 243, 9), // "font_bold"
QT_MOC_LITERAL(16, 253, 14) // "font_underline"

    },
    "GRadioButton\0ClassID\0"
    "{09D4E40E-61AE-4BA3-814F-5DE01A42FF5A}\0"
    "InterfaceID\0{D3B7CED6-76AC-4FA1-BC01-D0C1DAECD6A6}\0"
    "EventsID\0{A7968A2B-AC48-43E3-9FC5-2481065601A2}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "count\0background_color\0font_color\0"
    "font_size\0font_bold\0font_underline"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GRadioButton[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
       6,   26, // properties
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
      12, QMetaType::Int, 0x00095003,
      13, QMetaType::Int, 0x00095003,
      14, QMetaType::Int, 0x00095003,
      15, QMetaType::Bool, 0x00095003,
      16, QMetaType::Bool, 0x00095003,

       0        // eod
};

void GRadioButton::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        GRadioButton *_t = static_cast<GRadioButton *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->Count(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->BackgroundColor(); break;
        case 2: *reinterpret_cast< int*>(_v) = _t->FontColor(); break;
        case 3: *reinterpret_cast< int*>(_v) = _t->FontSize(); break;
        case 4: *reinterpret_cast< bool*>(_v) = _t->FontBold(); break;
        case 5: *reinterpret_cast< bool*>(_v) = _t->FontUnderline(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GRadioButton *_t = static_cast<GRadioButton *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setCount(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setBackgroundColor(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setFontColor(*reinterpret_cast< int*>(_v)); break;
        case 3: _t->setFontSize(*reinterpret_cast< int*>(_v)); break;
        case 4: _t->setFontBold(*reinterpret_cast< bool*>(_v)); break;
        case 5: _t->setFontUnderline(*reinterpret_cast< bool*>(_v)); break;
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

const QMetaObject GRadioButton::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_GRadioButton.data,
      qt_meta_data_GRadioButton,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GRadioButton::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GRadioButton::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GRadioButton.stringdata0))
        return static_cast<void*>(const_cast< GRadioButton*>(this));
    return QWidget::qt_metacast(_clname);
}

int GRadioButton::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    
#ifndef QT_NO_PROPERTIES
   if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 6;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 6;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 6;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 6;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 6;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 6;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
