/****************************************************************************
** Meta object code from reading C++ file 'gscrolllabel.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gscrolllabel.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gscrolllabel.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GScrollLabel_t {
    QByteArrayData data[7];
    char stringdata0[53];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GScrollLabel_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GScrollLabel_t qt_meta_stringdata_GScrollLabel = {
    {
QT_MOC_LITERAL(0, 0, 12), // "GScrollLabel"
QT_MOC_LITERAL(1, 13, 8), // "setSpeed"
QT_MOC_LITERAL(2, 22, 0), // ""
QT_MOC_LITERAL(3, 23, 1), // "s"
QT_MOC_LITERAL(4, 25, 12), // "setDirection"
QT_MOC_LITERAL(5, 38, 1), // "d"
QT_MOC_LITERAL(6, 40, 12) // "refreshLabel"

    },
    "GScrollLabel\0setSpeed\0\0s\0setDirection\0"
    "d\0refreshLabel"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GScrollLabel[] = {

 // content:
       7,       // revision
       0,       // classname
       0,    0, // classinfo
       3,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: name, argc, parameters, tag, flags
       1,    1,   29,    2, 0x0a /* Public */,
       4,    1,   32,    2, 0x0a /* Public */,
       6,    0,   35,    2, 0x08 /* Private */,

 // slots: parameters
    QMetaType::Void, QMetaType::Int,    3,
    QMetaType::Void, QMetaType::Int,    5,
    QMetaType::Void,

       0        // eod
};

void GScrollLabel::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        GScrollLabel *_t = static_cast<GScrollLabel *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->setSpeed((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 1: _t->setDirection((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 2: _t->refreshLabel(); break;
        default: ;
        }
    }
}

const QMetaObject GScrollLabel::staticMetaObject = {
    { &QLabel::staticMetaObject, qt_meta_stringdata_GScrollLabel.data,
      qt_meta_data_GScrollLabel,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GScrollLabel::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GScrollLabel::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GScrollLabel.stringdata0))
        return static_cast<void*>(const_cast< GScrollLabel*>(this));
    return QLabel::qt_metacast(_clname);
}

int GScrollLabel::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QLabel::qt_metacall(_c, _id, _a);
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
QT_END_MOC_NAMESPACE
