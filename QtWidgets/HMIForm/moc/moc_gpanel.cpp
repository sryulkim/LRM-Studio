/****************************************************************************
** Meta object code from reading C++ file 'gpanel.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gpanel.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gpanel.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GPanel_t {
    QByteArrayData data[5];
    char stringdata0[34];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GPanel_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GPanel_t qt_meta_stringdata_GPanel = {
    {
QT_MOC_LITERAL(0, 0, 6), // "GPanel"
QT_MOC_LITERAL(1, 7, 12), // "valueChanged"
QT_MOC_LITERAL(2, 20, 0), // ""
QT_MOC_LITERAL(3, 21, 3), // "val"
QT_MOC_LITERAL(4, 25, 8) // "setValue"

    },
    "GPanel\0valueChanged\0\0val\0setValue"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GPanel[] = {

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
       1,    1,   37,    2, 0x06 /* Public */,

 // slots: name, argc, parameters, tag, flags
       4,    1,   40,    2, 0x0a /* Public */,
       4,    1,   43,    2, 0x0a /* Public */,

 // signals: parameters
    QMetaType::Void, QMetaType::Int,    3,
    QMetaType::Void, QMetaType::Double,    3,

 // slots: parameters
    QMetaType::Void, QMetaType::Int,    3,
    QMetaType::Void, QMetaType::Double,    3,

       0        // eod
};

void GPanel::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        GPanel *_t = static_cast<GPanel *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->valueChanged((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 1: _t->valueChanged((*reinterpret_cast< double(*)>(_a[1]))); break;
        case 2: _t->setValue((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 3: _t->setValue((*reinterpret_cast< double(*)>(_a[1]))); break;
        default: ;
        }
    } else if (_c == QMetaObject::IndexOfMethod) {
        int *result = reinterpret_cast<int *>(_a[0]);
        void **func = reinterpret_cast<void **>(_a[1]);
        {
            typedef void (GPanel::*_t)(int );
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&GPanel::valueChanged)) {
                *result = 0;
                return;
            }
        }
        {
            typedef void (GPanel::*_t)(double );
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&GPanel::valueChanged)) {
                *result = 1;
                return;
            }
        }
    }
}

const QMetaObject GPanel::staticMetaObject = {
    { &WidgetWithBackground::staticMetaObject, qt_meta_stringdata_GPanel.data,
      qt_meta_data_GPanel,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GPanel::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GPanel::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GPanel.stringdata0))
        return static_cast<void*>(const_cast< GPanel*>(this));
    return WidgetWithBackground::qt_metacast(_clname);
}

int GPanel::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = WidgetWithBackground::qt_metacall(_c, _id, _a);
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
void GPanel::valueChanged(int _t1)
{
    void *_a[] = { Q_NULLPTR, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 0, _a);
}

// SIGNAL 1
void GPanel::valueChanged(double _t1)
{
    void *_a[] = { Q_NULLPTR, const_cast<void*>(reinterpret_cast<const void*>(&_t1)) };
    QMetaObject::activate(this, &staticMetaObject, 1, _a);
}
QT_END_MOC_NAMESPACE
