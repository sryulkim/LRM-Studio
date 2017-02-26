/****************************************************************************
** Meta object code from reading C++ file 'colourfullabel.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../colourfullabel.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'colourfullabel.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_ColourfulQLabel_t {
    QByteArrayData data[15];
    char stringdata0[266];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_ColourfulQLabel_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_ColourfulQLabel_t qt_meta_stringdata_ColourfulQLabel = {
    {
QT_MOC_LITERAL(0, 0, 15), // "ColourfulQLabel"
QT_MOC_LITERAL(1, 16, 7), // "ClassID"
QT_MOC_LITERAL(2, 24, 38), // "{50868389-3852-43C3-885F-A5A9..."
QT_MOC_LITERAL(3, 63, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 75, 38), // "{92C0F294-C3FC-463D-A61E-8BB2..."
QT_MOC_LITERAL(5, 114, 8), // "EventsID"
QT_MOC_LITERAL(6, 123, 38), // "{6216A786-78B2-4CEA-BC41-CECA..."
QT_MOC_LITERAL(7, 162, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 175, 11), // "StockEvents"
QT_MOC_LITERAL(9, 187, 3), // "yes"
QT_MOC_LITERAL(10, 191, 10), // "Insertable"
QT_MOC_LITERAL(11, 202, 18), // "label_color_number"
QT_MOC_LITERAL(12, 221, 23), // "background_color_number"
QT_MOC_LITERAL(13, 245, 10), // "label_text"
QT_MOC_LITERAL(14, 256, 9) // "font_size"

    },
    "ColourfulQLabel\0ClassID\0"
    "{50868389-3852-43C3-885F-A5A93FFEE35C}\0"
    "InterfaceID\0{92C0F294-C3FC-463D-A61E-8BB2CE6874EC}\0"
    "EventsID\0{6216A786-78B2-4CEA-BC41-CECAB2B4B1CE}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "label_color_number\0background_color_number\0"
    "label_text\0font_size"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_ColourfulQLabel[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
       4,   26, // properties
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
      14, QMetaType::Int, 0x00095003,

       0        // eod
};

void ColourfulQLabel::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        ColourfulQLabel *_t = static_cast<ColourfulQLabel *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->labelColorNumber(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->backgroundColorNumber(); break;
        case 2: *reinterpret_cast< QString*>(_v) = _t->labelText(); break;
        case 3: *reinterpret_cast< int*>(_v) = _t->fontSize(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        ColourfulQLabel *_t = static_cast<ColourfulQLabel *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setLabelColorNumber(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setBackgroundColorNumber(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setLabelText(*reinterpret_cast< QString*>(_v)); break;
        case 3: _t->setFontSize(*reinterpret_cast< int*>(_v)); break;
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

const QMetaObject ColourfulQLabel::staticMetaObject = {
    { &QLabel::staticMetaObject, qt_meta_stringdata_ColourfulQLabel.data,
      qt_meta_data_ColourfulQLabel,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *ColourfulQLabel::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *ColourfulQLabel::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_ColourfulQLabel.stringdata0))
        return static_cast<void*>(const_cast< ColourfulQLabel*>(this));
    return QLabel::qt_metacast(_clname);
}

int ColourfulQLabel::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QLabel::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    
#ifndef QT_NO_PROPERTIES
   if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 4;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 4;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 4;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 4;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 4;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 4;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
