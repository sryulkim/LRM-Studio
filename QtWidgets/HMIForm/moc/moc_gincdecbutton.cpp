/****************************************************************************
** Meta object code from reading C++ file 'gincdecbutton.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gincdecbutton.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gincdecbutton.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GIncDecButton_t {
    QByteArrayData data[6];
    char stringdata0[60];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GIncDecButton_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GIncDecButton_t qt_meta_stringdata_GIncDecButton = {
    {
QT_MOC_LITERAL(0, 0, 13), // "GIncDecButton"
QT_MOC_LITERAL(1, 14, 11), // "getIntValue"
QT_MOC_LITERAL(2, 26, 0), // ""
QT_MOC_LITERAL(3, 27, 14), // "getDoubleValue"
QT_MOC_LITERAL(4, 42, 8), // "incValue"
QT_MOC_LITERAL(5, 51, 8) // "decValue"

    },
    "GIncDecButton\0getIntValue\0\0getDoubleValue\0"
    "incValue\0decValue"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GIncDecButton[] = {

 // content:
       7,       // revision
       0,       // classname
       0,    0, // classinfo
       4,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       2,       // signalCount

 // signals: name, argc, parameters, tag, flags
       1,    1,   34,    2, 0x06 /* Public */,
       3,    1,   37,    2, 0x06 /* Public */,

 // slots: name, argc, parameters, tag, flags
       4,    0,   40,    2, 0x0a /* Public */,
       5,    0,   41,    2, 0x0a /* Public */,

 // signals: parameters
    QMetaType::Void, QMetaType::Int,    2,
    QMetaType::Void, QMetaType::Double,    2,

 // slots: parameters
    QMetaType::Void,
    QMetaType::Void,

       0        // eod
};

void GIncDecButton::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        GIncDecButton *_t = static_cast<GIncDecButton *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->getIntValue((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 1: _t->getDoubleValue((*reinterpret_cast< double(*)>(_a[1]))); break;
        case 2: _t->incValue(); break;
        case 3: _t->decValue(); break;
        default: ;
        }
    } else if (_c == QMetaObject::IndexOfMethod) {
        int *result = reinterpret_cast<int *>(_a[0]);
        void **func = reinterpret_cast<void **>(_a[1]);
        {
            typedef void (GIncDecButton::*_t)(int );
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&GIncDecButton::getIntValue)) {
                *result = 0;
                return;
            }
        }
        {
            typedef void (GIncDecButton::*_t)(double );
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&GIncDecButton::getDoubleValue)) {
                *result = 1;
                return;
            }
        }
    }
}

const QMetaObject GIncDecButton::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_GIncDecButton.data,
      qt_meta_data_GIncDecButton,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GIncDecButton::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GIncDecButton::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GIncDecButton.stringdata0))
        return static_cast<void*>(const_cast< GIncDecButton*>(this));
    return QWidget::qt_metacast(_clname);
}

int GIncDecButton::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 4)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 4;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 4)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 4;
    }
    return _id;
}

// SIGNAL 0
void GIncDecButton::getIntValue(int _t1)
{
    void *_a[] = { Q_NULLPTR, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 0, _a);
}

// SIGNAL 1
void GIncDecButton::getDoubleValue(double _t1)
{
    void *_a[] = { Q_NULLPTR, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 1, _a);
}
QT_END_MOC_NAMESPACE
