/****************************************************************************
** Meta object code from reading C++ file 'gsetresetbutton.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gsetresetbutton.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gsetresetbutton.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GSetResetButton_t {
    QByteArrayData data[5];
    char stringdata0[49];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GSetResetButton_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GSetResetButton_t qt_meta_stringdata_GSetResetButton = {
    {
QT_MOC_LITERAL(0, 0, 15), // "GSetResetButton"
QT_MOC_LITERAL(1, 16, 11), // "changeValue"
QT_MOC_LITERAL(2, 28, 0), // ""
QT_MOC_LITERAL(3, 29, 8), // "setValue"
QT_MOC_LITERAL(4, 38, 10) // "resetValue"

    },
    "GSetResetButton\0changeValue\0\0setValue\0"
    "resetValue"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GSetResetButton[] = {

 // content:
       7,       // revision
       0,       // classname
       0,    0, // classinfo
       3,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       1,       // signalCount

 // signals: name, argc, parameters, tag, flags
       1,    1,   29,    2, 0x06 /* Public */,

 // slots: name, argc, parameters, tag, flags
       3,    0,   32,    2, 0x08 /* Private */,
       4,    0,   33,    2, 0x08 /* Private */,

 // signals: parameters
    QMetaType::Void, QMetaType::Bool,    2,

 // slots: parameters
    QMetaType::Void,
    QMetaType::Void,

       0        // eod
};

void GSetResetButton::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        GSetResetButton *_t = static_cast<GSetResetButton *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->changeValue((*reinterpret_cast< bool(*)>(_a[1]))); break;
        case 1: _t->setValue(); break;
        case 2: _t->resetValue(); break;
        default: ;
        }
    } else if (_c == QMetaObject::IndexOfMethod) {
        int *result = reinterpret_cast<int *>(_a[0]);
        void **func = reinterpret_cast<void **>(_a[1]);
        {
            typedef void (GSetResetButton::*_t)(bool );
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&GSetResetButton::changeValue)) {
                *result = 0;
                return;
            }
        }
    }
}

const QMetaObject GSetResetButton::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_GSetResetButton.data,
      qt_meta_data_GSetResetButton,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GSetResetButton::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GSetResetButton::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GSetResetButton.stringdata0))
        return static_cast<void*>(const_cast< GSetResetButton*>(this));
    return QWidget::qt_metacast(_clname);
}

int GSetResetButton::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 3)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 3;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 3)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 3;
    }
    return _id;
}

// SIGNAL 0
void GSetResetButton::changeValue(bool _t1)
{
    void *_a[] = { Q_NULLPTR, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 0, _a);
}
QT_END_MOC_NAMESPACE
