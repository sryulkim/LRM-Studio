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
    QByteArrayData data[18];
    char stringdata0[254];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GPanel_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GPanel_t qt_meta_stringdata_GPanel = {
    {
QT_MOC_LITERAL(0, 0, 6), // "GPanel"
QT_MOC_LITERAL(1, 7, 7), // "ClassID"
QT_MOC_LITERAL(2, 15, 38), // "{E1710269-BC0A-4F63-94A4-C874..."
QT_MOC_LITERAL(3, 54, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 66, 38), // "{9A44D853-3410-4A6B-A5BF-E4E7..."
QT_MOC_LITERAL(5, 105, 8), // "EventsID"
QT_MOC_LITERAL(6, 114, 38), // "{F1F39717-232B-44C6-AFA8-3D33..."
QT_MOC_LITERAL(7, 153, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 166, 11), // "StockEvents"
QT_MOC_LITERAL(9, 178, 3), // "yes"
QT_MOC_LITERAL(10, 182, 10), // "Insertable"
QT_MOC_LITERAL(11, 193, 5), // "m_min"
QT_MOC_LITERAL(12, 199, 5), // "m_max"
QT_MOC_LITERAL(13, 205, 7), // "m_major"
QT_MOC_LITERAL(14, 213, 7), // "m_minor"
QT_MOC_LITERAL(15, 221, 11), // "needleColor"
QT_MOC_LITERAL(16, 233, 10), // "digitColor"
QT_MOC_LITERAL(17, 244, 9) // "bodyColor"

    },
    "GPanel\0ClassID\0{E1710269-BC0A-4F63-94A4-C87403276C85}\0"
    "InterfaceID\0{9A44D853-3410-4A6B-A5BF-E4E75B6C043D}\0"
    "EventsID\0{F1F39717-232B-44C6-AFA8-3D33C154ABE5}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "m_min\0m_max\0m_major\0m_minor\0needleColor\0"
    "digitColor\0bodyColor"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GPanel[] = {

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
      11, QMetaType::Double, 0x00095003,
      12, QMetaType::Double, 0x00095003,
      13, QMetaType::Int, 0x00095003,
      14, QMetaType::Int, 0x00095003,
      15, QMetaType::Int, 0x00095103,
      16, QMetaType::Int, 0x00095103,
      17, QMetaType::Int, 0x00095103,

       0        // eod
};

void GPanel::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        GPanel *_t = static_cast<GPanel *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< double*>(_v) = _t->Min(); break;
        case 1: *reinterpret_cast< double*>(_v) = _t->Max(); break;
        case 2: *reinterpret_cast< int*>(_v) = _t->Major(); break;
        case 3: *reinterpret_cast< int*>(_v) = _t->Minor(); break;
        case 4: *reinterpret_cast< int*>(_v) = _t->NeedleColor(); break;
        case 5: *reinterpret_cast< int*>(_v) = _t->DigitColor(); break;
        case 6: *reinterpret_cast< int*>(_v) = _t->BodyColor(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GPanel *_t = static_cast<GPanel *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setMinimum(*reinterpret_cast< double*>(_v)); break;
        case 1: _t->setMaximum(*reinterpret_cast< double*>(_v)); break;
        case 2: _t->setMajor(*reinterpret_cast< int*>(_v)); break;
        case 3: _t->setMinor(*reinterpret_cast< int*>(_v)); break;
        case 4: _t->setNeedleColor(*reinterpret_cast< int*>(_v)); break;
        case 5: _t->setDigitColor(*reinterpret_cast< int*>(_v)); break;
        case 6: _t->setBodyColor(*reinterpret_cast< int*>(_v)); break;
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
