/****************************************************************************
** Meta object code from reading C++ file 'gprogressbar.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gprogressbar.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gprogressbar.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GProgressBar_t {
    QByteArrayData data[17];
    char stringdata0[240];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GProgressBar_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GProgressBar_t qt_meta_stringdata_GProgressBar = {
    {
QT_MOC_LITERAL(0, 0, 12), // "GProgressBar"
QT_MOC_LITERAL(1, 13, 7), // "ClassID"
QT_MOC_LITERAL(2, 21, 38), // "{E584C326-F5E9-4664-8F38-5EFB..."
QT_MOC_LITERAL(3, 60, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 72, 38), // "{6F282EDF-F6E2-42B3-8060-E61D..."
QT_MOC_LITERAL(5, 111, 8), // "EventsID"
QT_MOC_LITERAL(6, 120, 38), // "{1CF2B28A-5448-4848-AADA-2DAA..."
QT_MOC_LITERAL(7, 159, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 172, 11), // "StockEvents"
QT_MOC_LITERAL(9, 184, 3), // "yes"
QT_MOC_LITERAL(10, 188, 10), // "Insertable"
QT_MOC_LITERAL(11, 199, 3), // "min"
QT_MOC_LITERAL(12, 203, 3), // "max"
QT_MOC_LITERAL(13, 207, 5), // "minor"
QT_MOC_LITERAL(14, 213, 5), // "major"
QT_MOC_LITERAL(15, 219, 6), // "orient"
QT_MOC_LITERAL(16, 226, 13) // "progressColor"

    },
    "GProgressBar\0ClassID\0"
    "{E584C326-F5E9-4664-8F38-5EFB5F5DE4D4}\0"
    "InterfaceID\0{6F282EDF-F6E2-42B3-8060-E61D7C26DDC8}\0"
    "EventsID\0{1CF2B28A-5448-4848-AADA-2DAAB08D736B}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "min\0max\0minor\0major\0orient\0progressColor"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GProgressBar[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
       6,   26, // properties
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
      11, QMetaType::Int, 0x00095103,
      12, QMetaType::Int, 0x00095103,
      13, QMetaType::Int, 0x00095003,
      14, QMetaType::Int, 0x00095003,
      15, QMetaType::Int, 0x00095003,
      16, QMetaType::Int, 0x00095103,

       0        // eod
};

void GProgressBar::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        GProgressBar *_t = static_cast<GProgressBar *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->Min(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->Max(); break;
        case 2: *reinterpret_cast< int*>(_v) = _t->Minor(); break;
        case 3: *reinterpret_cast< int*>(_v) = _t->Major(); break;
        case 4: *reinterpret_cast< int*>(_v) = _t->Orient(); break;
        case 5: *reinterpret_cast< int*>(_v) = _t->ProgressColor(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GProgressBar *_t = static_cast<GProgressBar *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setMin(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setMax(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setMaxminor(*reinterpret_cast< int*>(_v)); break;
        case 3: _t->setMaxmajor(*reinterpret_cast< int*>(_v)); break;
        case 4: _t->setDirection(*reinterpret_cast< int*>(_v)); break;
        case 5: _t->setProgressColor(*reinterpret_cast< int*>(_v)); break;
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

const QMetaObject GProgressBar::staticMetaObject = {
    { &QwtThermo::staticMetaObject, qt_meta_stringdata_GProgressBar.data,
      qt_meta_data_GProgressBar,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GProgressBar::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GProgressBar::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GProgressBar.stringdata0))
        return static_cast<void*>(const_cast< GProgressBar*>(this));
    return QwtThermo::qt_metacast(_clname);
}

int GProgressBar::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QwtThermo::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    
#ifndef QT_NO_PROPERTIES
   if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 6;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 6;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 6;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 6;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 6;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 6;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
