/****************************************************************************
** Meta object code from reading C++ file 'qwtknobbox.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../qwtknobbox.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'qwtknobbox.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_QwtKnobBox_t {
    QByteArrayData data[15];
    char stringdata0[212];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_QwtKnobBox_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_QwtKnobBox_t qt_meta_stringdata_QwtKnobBox = {
    {
QT_MOC_LITERAL(0, 0, 10), // "QwtKnobBox"
QT_MOC_LITERAL(1, 11, 7), // "ClassID"
QT_MOC_LITERAL(2, 19, 38), // "{031CE66B-A9DD-4C2A-B6C5-5816..."
QT_MOC_LITERAL(3, 58, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 70, 38), // "{EC9ECB46-6DD7-4475-9A45-77CF..."
QT_MOC_LITERAL(5, 109, 8), // "EventsID"
QT_MOC_LITERAL(6, 118, 38), // "{DDC64792-5439-4F5C-A8D5-7831..."
QT_MOC_LITERAL(7, 157, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 170, 11), // "StockEvents"
QT_MOC_LITERAL(9, 182, 3), // "yes"
QT_MOC_LITERAL(10, 186, 10), // "Insertable"
QT_MOC_LITERAL(11, 197, 6), // "setNum"
QT_MOC_LITERAL(12, 204, 0), // ""
QT_MOC_LITERAL(13, 205, 1), // "v"
QT_MOC_LITERAL(14, 207, 4) // "type"

    },
    "QwtKnobBox\0ClassID\0"
    "{031CE66B-A9DD-4C2A-B6C5-5816A775B300}\0"
    "InterfaceID\0{EC9ECB46-6DD7-4475-9A45-77CF8FFADF0F}\0"
    "EventsID\0{DDC64792-5439-4F5C-A8D5-7831361BF0F1}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "setNum\0\0v\0type"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_QwtKnobBox[] = {

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

void QwtKnobBox::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        QwtKnobBox *_t = static_cast<QwtKnobBox *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->setNum((*reinterpret_cast< double(*)>(_a[1]))); break;
        default: ;
        }
    }
#ifndef QT_NO_PROPERTIES
    else if (_c == QMetaObject::ReadProperty) {
        QwtKnobBox *_t = static_cast<QwtKnobBox *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->getType(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        QwtKnobBox *_t = static_cast<QwtKnobBox *>(_o);
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

const QMetaObject QwtKnobBox::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_QwtKnobBox.data,
      qt_meta_data_QwtKnobBox,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *QwtKnobBox::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *QwtKnobBox::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_QwtKnobBox.stringdata0))
        return static_cast<void*>(const_cast< QwtKnobBox*>(this));
    return QWidget::qt_metacast(_clname);
}

int QwtKnobBox::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
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
