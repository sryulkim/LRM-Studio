/****************************************************************************
** Meta object code from reading C++ file 'qwtspeedmeter.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../qwtspeedmeter.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'qwtspeedmeter.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_QwtSpeedMeter_t {
    QByteArrayData data[19];
    char stringdata0[299];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_QwtSpeedMeter_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_QwtSpeedMeter_t qt_meta_stringdata_QwtSpeedMeter = {
    {
QT_MOC_LITERAL(0, 0, 13), // "QwtSpeedMeter"
QT_MOC_LITERAL(1, 14, 7), // "ClassID"
QT_MOC_LITERAL(2, 22, 38), // "{D5EDDD46-9DB4-4293-BA47-9963..."
QT_MOC_LITERAL(3, 61, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 73, 38), // "{53D83080-6734-45FF-9547-9552..."
QT_MOC_LITERAL(5, 112, 8), // "EventsID"
QT_MOC_LITERAL(6, 121, 38), // "{4597230C-DA27-400F-AFB5-7C2B..."
QT_MOC_LITERAL(7, 160, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 173, 11), // "StockEvents"
QT_MOC_LITERAL(9, 185, 3), // "yes"
QT_MOC_LITERAL(10, 189, 10), // "Insertable"
QT_MOC_LITERAL(11, 200, 23), // "background_color_number"
QT_MOC_LITERAL(12, 224, 19), // "number_color_number"
QT_MOC_LITERAL(13, 244, 18), // "label_color_number"
QT_MOC_LITERAL(14, 263, 7), // "d_label"
QT_MOC_LITERAL(15, 271, 3), // "min"
QT_MOC_LITERAL(16, 275, 3), // "max"
QT_MOC_LITERAL(17, 279, 9), // "max_minor"
QT_MOC_LITERAL(18, 289, 9) // "max_major"

    },
    "QwtSpeedMeter\0ClassID\0"
    "{D5EDDD46-9DB4-4293-BA47-99631F6CBA52}\0"
    "InterfaceID\0{53D83080-6734-45FF-9547-955291853829}\0"
    "EventsID\0{4597230C-DA27-400F-AFB5-7C2BA9642C08}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "background_color_number\0number_color_number\0"
    "label_color_number\0d_label\0min\0max\0"
    "max_minor\0max_major"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_QwtSpeedMeter[] = {

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
      14, QMetaType::QString, 0x00095003,
      15, QMetaType::Int, 0x00095103,
      16, QMetaType::Int, 0x00095103,
      17, QMetaType::Int, 0x00095003,
      18, QMetaType::Int, 0x00095003,

       0        // eod
};

void QwtSpeedMeter::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        QwtSpeedMeter *_t = static_cast<QwtSpeedMeter *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->backgroundColorNumber(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->numberColorNumber(); break;
        case 2: *reinterpret_cast< int*>(_v) = _t->labelColorNumber(); break;
        case 3: *reinterpret_cast< QString*>(_v) = _t->dLabel(); break;
        case 4: *reinterpret_cast< int*>(_v) = _t->Min(); break;
        case 5: *reinterpret_cast< int*>(_v) = _t->Max(); break;
        case 6: *reinterpret_cast< int*>(_v) = _t->maxMinor(); break;
        case 7: *reinterpret_cast< int*>(_v) = _t->maxMajor(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        QwtSpeedMeter *_t = static_cast<QwtSpeedMeter *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setBackgroundColorNumber(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setNumberColorNumber(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setLabelColorNumber(*reinterpret_cast< int*>(_v)); break;
        case 3: _t->setLabel(*reinterpret_cast< QString*>(_v)); break;
        case 4: _t->setMin(*reinterpret_cast< int*>(_v)); break;
        case 5: _t->setMax(*reinterpret_cast< int*>(_v)); break;
        case 6: _t->setMaxMinor(*reinterpret_cast< int*>(_v)); break;
        case 7: _t->setMaxMajor(*reinterpret_cast< int*>(_v)); break;
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

const QMetaObject QwtSpeedMeter::staticMetaObject = {
    { &QwtDial::staticMetaObject, qt_meta_stringdata_QwtSpeedMeter.data,
      qt_meta_data_QwtSpeedMeter,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *QwtSpeedMeter::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *QwtSpeedMeter::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_QwtSpeedMeter.stringdata0))
        return static_cast<void*>(const_cast< QwtSpeedMeter*>(this));
    return QwtDial::qt_metacast(_clname);
}

int QwtSpeedMeter::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QwtDial::qt_metacall(_c, _id, _a);
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
