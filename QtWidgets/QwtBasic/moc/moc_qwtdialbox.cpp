/****************************************************************************
** Meta object code from reading C++ file 'qwtdialbox.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../qwtdialbox.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'qwtdialbox.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_QwtDialBox_t {
    QByteArrayData data[15];
    char stringdata0[212];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_QwtDialBox_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_QwtDialBox_t qt_meta_stringdata_QwtDialBox = {
    {
QT_MOC_LITERAL(0, 0, 10), // "QwtDialBox"
QT_MOC_LITERAL(1, 11, 7), // "ClassID"
QT_MOC_LITERAL(2, 19, 38), // "{D426AA45-DAF9-48A8-9180-B2E4..."
QT_MOC_LITERAL(3, 58, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 70, 38), // "{35575BD4-36F2-4A53-9588-DEE5..."
QT_MOC_LITERAL(5, 109, 8), // "EventsID"
QT_MOC_LITERAL(6, 118, 38), // "{7F2737D1-B922-4F11-ABCF-640C..."
QT_MOC_LITERAL(7, 157, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 170, 11), // "StockEvents"
QT_MOC_LITERAL(9, 182, 3), // "yes"
QT_MOC_LITERAL(10, 186, 10), // "Insertable"
QT_MOC_LITERAL(11, 197, 6), // "setNum"
QT_MOC_LITERAL(12, 204, 0), // ""
QT_MOC_LITERAL(13, 205, 1), // "v"
QT_MOC_LITERAL(14, 207, 4) // "type"

    },
    "QwtDialBox\0ClassID\0"
    "{D426AA45-DAF9-48A8-9180-B2E4E2CCDDF4}\0"
    "InterfaceID\0{35575BD4-36F2-4A53-9588-DEE57F683A0D}\0"
    "EventsID\0{7F2737D1-B922-4F11-ABCF-640C29CBAA78}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "setNum\0\0v\0type"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_QwtDialBox[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       1,   26, // methods
       1,   34, // properties
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

       0        // eod
};

void QwtDialBox::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        QwtDialBox *_t = static_cast<QwtDialBox *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->setNum((*reinterpret_cast< double(*)>(_a[1]))); break;
        default: ;
        }
    }
#ifndef QT_NO_PROPERTIES
    else if (_c == QMetaObject::ReadProperty) {
        QwtDialBox *_t = static_cast<QwtDialBox *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->getType(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        QwtDialBox *_t = static_cast<QwtDialBox *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setType(*reinterpret_cast< int*>(_v)); break;
        default: break;
        }
    } else if (_c == QMetaObject::ResetProperty) {
    }
#endif // QT_NO_PROPERTIES
}

const QMetaObject QwtDialBox::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_QwtDialBox.data,
      qt_meta_data_QwtDialBox,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *QwtDialBox::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *QwtDialBox::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_QwtDialBox.stringdata0))
        return static_cast<void*>(const_cast< QwtDialBox*>(this));
    return QWidget::qt_metacast(_clname);
}

int QwtDialBox::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
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
        _id -= 1;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 1;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 1;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 1;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 1;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 1;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
