/****************************************************************************
** Meta object code from reading C++ file 'qwtwheelbox.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../qwtwheelbox.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'qwtwheelbox.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_QwtWheelBox_t {
    QByteArrayData data[16];
    char stringdata0[225];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_QwtWheelBox_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_QwtWheelBox_t qt_meta_stringdata_QwtWheelBox = {
    {
QT_MOC_LITERAL(0, 0, 11), // "QwtWheelBox"
QT_MOC_LITERAL(1, 12, 7), // "ClassID"
QT_MOC_LITERAL(2, 20, 38), // "{DA0A3A80-F4A2-4088-8E28-34D6..."
QT_MOC_LITERAL(3, 59, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 71, 38), // "{BA9EA385-0956-46EE-ACA9-053B..."
QT_MOC_LITERAL(5, 110, 8), // "EventsID"
QT_MOC_LITERAL(6, 119, 38), // "{36CF7C41-FB09-4888-B972-F35F..."
QT_MOC_LITERAL(7, 158, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 171, 11), // "StockEvents"
QT_MOC_LITERAL(9, 183, 3), // "yes"
QT_MOC_LITERAL(10, 187, 10), // "Insertable"
QT_MOC_LITERAL(11, 198, 6), // "setNum"
QT_MOC_LITERAL(12, 205, 0), // ""
QT_MOC_LITERAL(13, 206, 1), // "v"
QT_MOC_LITERAL(14, 208, 4), // "type"
QT_MOC_LITERAL(15, 213, 11) // "orientation"

    },
    "QwtWheelBox\0ClassID\0"
    "{DA0A3A80-F4A2-4088-8E28-34D6D9413867}\0"
    "InterfaceID\0{BA9EA385-0956-46EE-ACA9-053B406E2DE6}\0"
    "EventsID\0{36CF7C41-FB09-4888-B972-F35F525B6511}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "setNum\0\0v\0type\0orientation"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_QwtWheelBox[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       1,   26, // methods
       2,   34, // properties
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

 // slots: name, argc, parameters, tag, flags
      11,    1,   31,   12, 0x08 /* Private */,

 // slots: parameters
    QMetaType::Void, QMetaType::Double,   13,

 // properties: name, type, flags
      14, QMetaType::Int, 0x00095103,
      15, QMetaType::Int, 0x00095103,

       0        // eod
};

void QwtWheelBox::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        QwtWheelBox *_t = static_cast<QwtWheelBox *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->setNum((*reinterpret_cast< double(*)>(_a[1]))); break;
        default: ;
        }
    }
#ifndef QT_NO_PROPERTIES
    else if (_c == QMetaObject::ReadProperty) {
        QwtWheelBox *_t = static_cast<QwtWheelBox *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->getType(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->getOrientation(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        QwtWheelBox *_t = static_cast<QwtWheelBox *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setType(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setOrientation(*reinterpret_cast< int*>(_v)); break;
        default: break;
        }
    } else if (_c == QMetaObject::ResetProperty) {
    }
#endif // QT_NO_PROPERTIES
}

const QMetaObject QwtWheelBox::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_QwtWheelBox.data,
      qt_meta_data_QwtWheelBox,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *QwtWheelBox::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *QwtWheelBox::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_QwtWheelBox.stringdata0))
        return static_cast<void*>(const_cast< QwtWheelBox*>(this));
    return QWidget::qt_metacast(_clname);
}

int QwtWheelBox::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 1)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 1;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 1)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 1;
    }
#ifndef QT_NO_PROPERTIES
   else if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
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
