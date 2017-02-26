/****************************************************************************
** Meta object code from reading C++ file 'gloginpad.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gloginpad.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gloginpad.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GLoginpad_t {
    QByteArrayData data[23];
    char stringdata0[343];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GLoginpad_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GLoginpad_t qt_meta_stringdata_GLoginpad = {
    {
QT_MOC_LITERAL(0, 0, 9), // "GLoginpad"
QT_MOC_LITERAL(1, 10, 7), // "ClassID"
QT_MOC_LITERAL(2, 18, 38), // "{C8AC7D61-91F3-424F-8D77-D487..."
QT_MOC_LITERAL(3, 57, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 69, 38), // "{397CC88B-4166-42BF-9B8E-CA29..."
QT_MOC_LITERAL(5, 108, 8), // "EventsID"
QT_MOC_LITERAL(6, 117, 38), // "{A153ED60-E4D0-404B-B814-BF75..."
QT_MOC_LITERAL(7, 156, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 169, 7), // "GNumpad"
QT_MOC_LITERAL(9, 177, 11), // "StockEvents"
QT_MOC_LITERAL(10, 189, 3), // "yes"
QT_MOC_LITERAL(11, 193, 10), // "Insertable"
QT_MOC_LITERAL(12, 204, 8), // "password"
QT_MOC_LITERAL(13, 213, 8), // "numColor"
QT_MOC_LITERAL(14, 222, 14), // "numButtonColor"
QT_MOC_LITERAL(15, 237, 10), // "resetColor"
QT_MOC_LITERAL(16, 248, 16), // "resetButtonColor"
QT_MOC_LITERAL(17, 265, 10), // "loginColor"
QT_MOC_LITERAL(18, 276, 16), // "loginButtonColor"
QT_MOC_LITERAL(19, 293, 9), // "funcColor"
QT_MOC_LITERAL(20, 303, 15), // "funcButtonColor"
QT_MOC_LITERAL(21, 319, 11), // "borderColor"
QT_MOC_LITERAL(22, 331, 11) // "digitNumber"

    },
    "GLoginpad\0ClassID\0"
    "{C8AC7D61-91F3-424F-8D77-D4875AC8FD29}\0"
    "InterfaceID\0{397CC88B-4166-42BF-9B8E-CA2923085E80}\0"
    "EventsID\0{A153ED60-E4D0-404B-B814-BF75C93DD0A5}\0"
    "ToSuperClass\0GNumpad\0StockEvents\0yes\0"
    "Insertable\0password\0numColor\0"
    "numButtonColor\0resetColor\0resetButtonColor\0"
    "loginColor\0loginButtonColor\0funcColor\0"
    "funcButtonColor\0borderColor\0digitNumber"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GLoginpad[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
      11,   26, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // classinfo: key, value
       1,    2,
       3,    4,
       5,    6,
       7,    8,
       9,   10,
      11,   10,

 // properties: name, type, flags
      12, QMetaType::QString, 0x00095103,
      13, QMetaType::Int, 0x00095103,
      14, QMetaType::Int, 0x00095003,
      15, QMetaType::Int, 0x00095103,
      16, QMetaType::Int, 0x00095103,
      17, QMetaType::Int, 0x00095103,
      18, QMetaType::Int, 0x00095103,
      19, QMetaType::Int, 0x00095103,
      20, QMetaType::Int, 0x00095103,
      21, QMetaType::Int, 0x00095103,
      22, QMetaType::Int, 0x00095103,

       0        // eod
};

void GLoginpad::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        GLoginpad *_t = static_cast<GLoginpad *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< QString*>(_v) = _t->Password(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->NumColor(); break;
        case 2: *reinterpret_cast< int*>(_v) = _t->NumButtonColor(); break;
        case 3: *reinterpret_cast< int*>(_v) = _t->ResetColor(); break;
        case 4: *reinterpret_cast< int*>(_v) = _t->ResetButtonColor(); break;
        case 5: *reinterpret_cast< int*>(_v) = _t->LoginColor(); break;
        case 6: *reinterpret_cast< int*>(_v) = _t->LoginButtonColor(); break;
        case 7: *reinterpret_cast< int*>(_v) = _t->FuncColor(); break;
        case 8: *reinterpret_cast< int*>(_v) = _t->FuncButtonColor(); break;
        case 9: *reinterpret_cast< int*>(_v) = _t->BorderColor(); break;
        case 10: *reinterpret_cast< int*>(_v) = _t->DigitNumber(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GLoginpad *_t = static_cast<GLoginpad *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setPassword(*reinterpret_cast< QString*>(_v)); break;
        case 1: _t->setNumColor(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setNumberButtonColor(*reinterpret_cast< int*>(_v)); break;
        case 3: _t->setResetColor(*reinterpret_cast< int*>(_v)); break;
        case 4: _t->setResetButtonColor(*reinterpret_cast< int*>(_v)); break;
        case 5: _t->setLoginColor(*reinterpret_cast< int*>(_v)); break;
        case 6: _t->setLoginButtonColor(*reinterpret_cast< int*>(_v)); break;
        case 7: _t->setFuncColor(*reinterpret_cast< int*>(_v)); break;
        case 8: _t->setFuncButtonColor(*reinterpret_cast< int*>(_v)); break;
        case 9: _t->setBorderColor(*reinterpret_cast< int*>(_v)); break;
        case 10: _t->setDigitNumber(*reinterpret_cast< int*>(_v)); break;
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

const QMetaObject GLoginpad::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_GLoginpad.data,
      qt_meta_data_GLoginpad,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GLoginpad::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GLoginpad::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GLoginpad.stringdata0))
        return static_cast<void*>(const_cast< GLoginpad*>(this));
    return QWidget::qt_metacast(_clname);
}

int GLoginpad::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    
#ifndef QT_NO_PROPERTIES
   if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 11;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 11;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 11;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 11;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 11;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 11;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
