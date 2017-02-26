/****************************************************************************
** Meta object code from reading C++ file 'gnumpad.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gnumpad.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gnumpad.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GNumpad_t {
    QByteArrayData data[18];
    char stringdata0[290];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GNumpad_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GNumpad_t qt_meta_stringdata_GNumpad = {
    {
QT_MOC_LITERAL(0, 0, 7), // "GNumpad"
QT_MOC_LITERAL(1, 8, 7), // "ClassID"
QT_MOC_LITERAL(2, 16, 38), // "{DC27EB90-5309-452B-9F3D-B98B..."
QT_MOC_LITERAL(3, 55, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 67, 38), // "{7C16C63D-5227-48BA-8A8E-DF95..."
QT_MOC_LITERAL(5, 106, 8), // "EventsID"
QT_MOC_LITERAL(6, 115, 38), // "{AC4DDC98-235D-4DBA-90DB-E3BD..."
QT_MOC_LITERAL(7, 154, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 167, 11), // "StockEvents"
QT_MOC_LITERAL(9, 179, 3), // "yes"
QT_MOC_LITERAL(10, 183, 10), // "Insertable"
QT_MOC_LITERAL(11, 194, 9), // "num_color"
QT_MOC_LITERAL(12, 204, 16), // "num_button_color"
QT_MOC_LITERAL(13, 221, 11), // "reset_color"
QT_MOC_LITERAL(14, 233, 18), // "reset_button_color"
QT_MOC_LITERAL(15, 252, 8), // "ok_color"
QT_MOC_LITERAL(16, 261, 15), // "ok_button_color"
QT_MOC_LITERAL(17, 277, 12) // "border_color"

    },
    "GNumpad\0ClassID\0{DC27EB90-5309-452B-9F3D-B98B887EAECC}\0"
    "InterfaceID\0{7C16C63D-5227-48BA-8A8E-DF9561BFB14A}\0"
    "EventsID\0{AC4DDC98-235D-4DBA-90DB-E3BD94C6595B}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "num_color\0num_button_color\0reset_color\0"
    "reset_button_color\0ok_color\0ok_button_color\0"
    "border_color"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GNumpad[] = {

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
      14, QMetaType::Int, 0x00095003,
      15, QMetaType::Int, 0x00095003,
      16, QMetaType::Int, 0x00095003,
      17, QMetaType::Int, 0x00095003,

       0        // eod
};

void GNumpad::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        GNumpad *_t = static_cast<GNumpad *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->numColor(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->numButtonColor(); break;
        case 2: *reinterpret_cast< int*>(_v) = _t->resetColor(); break;
        case 3: *reinterpret_cast< int*>(_v) = _t->resetButtonColor(); break;
        case 4: *reinterpret_cast< int*>(_v) = _t->okColor(); break;
        case 5: *reinterpret_cast< int*>(_v) = _t->okButtonColor(); break;
        case 6: *reinterpret_cast< int*>(_v) = _t->borderColor(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GNumpad *_t = static_cast<GNumpad *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setNumColor(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setNumButtonColor(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setResetColor(*reinterpret_cast< int*>(_v)); break;
        case 3: _t->setResetButtonColor(*reinterpret_cast< int*>(_v)); break;
        case 4: _t->setOkColor(*reinterpret_cast< int*>(_v)); break;
        case 5: _t->setOkButtonColor(*reinterpret_cast< int*>(_v)); break;
        case 6: _t->setBorderColor(*reinterpret_cast< int*>(_v)); break;
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

const QMetaObject GNumpad::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_GNumpad.data,
      qt_meta_data_GNumpad,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GNumpad::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GNumpad::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GNumpad.stringdata0))
        return static_cast<void*>(const_cast< GNumpad*>(this));
    return QWidget::qt_metacast(_clname);
}

int GNumpad::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
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
