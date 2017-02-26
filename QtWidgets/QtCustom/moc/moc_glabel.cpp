/****************************************************************************
** Meta object code from reading C++ file 'glabel.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../glabel.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'glabel.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GLabel_t {
    QByteArrayData data[21];
    char stringdata0[303];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GLabel_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GLabel_t qt_meta_stringdata_GLabel = {
    {
QT_MOC_LITERAL(0, 0, 6), // "GLabel"
QT_MOC_LITERAL(1, 7, 7), // "ClassID"
QT_MOC_LITERAL(2, 15, 38), // "{AC1C9640-8226-4782-B484-D291..."
QT_MOC_LITERAL(3, 54, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 66, 38), // "{DDB206D3-6328-44CA-A446-FB41..."
QT_MOC_LITERAL(5, 105, 8), // "EventsID"
QT_MOC_LITERAL(6, 114, 38), // "{3C15A5B8-3A88-4327-BADF-3AB7..."
QT_MOC_LITERAL(7, 153, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 166, 11), // "StockEvents"
QT_MOC_LITERAL(9, 178, 3), // "yes"
QT_MOC_LITERAL(10, 182, 10), // "Insertable"
QT_MOC_LITERAL(11, 193, 11), // "label_color"
QT_MOC_LITERAL(12, 205, 12), // "border_color"
QT_MOC_LITERAL(13, 218, 10), // "font_color"
QT_MOC_LITERAL(14, 229, 9), // "font_bold"
QT_MOC_LITERAL(15, 239, 14), // "font_underline"
QT_MOC_LITERAL(16, 254, 9), // "thickness"
QT_MOC_LITERAL(17, 264, 9), // "font_size"
QT_MOC_LITERAL(18, 274, 5), // "angle"
QT_MOC_LITERAL(19, 280, 10), // "label_text"
QT_MOC_LITERAL(20, 291, 11) // "transparent"

    },
    "GLabel\0ClassID\0{AC1C9640-8226-4782-B484-D2911C8A3F76}\0"
    "InterfaceID\0{DDB206D3-6328-44CA-A446-FB413CA9303C}\0"
    "EventsID\0{3C15A5B8-3A88-4327-BADF-3AB73CB69ACC}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "label_color\0border_color\0font_color\0"
    "font_bold\0font_underline\0thickness\0"
    "font_size\0angle\0label_text\0transparent"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GLabel[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
      10,   26, // properties
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
      11, QMetaType::Int, 0x00095003,
      12, QMetaType::Int, 0x00095003,
      13, QMetaType::Int, 0x00095003,
      14, QMetaType::Bool, 0x00095003,
      15, QMetaType::Bool, 0x00095003,
      16, QMetaType::Float, 0x00095103,
      17, QMetaType::Int, 0x00095003,
      18, QMetaType::Int, 0x00095103,
      19, QMetaType::QString, 0x00095003,
      20, QMetaType::Bool, 0x00095103,

       0        // eod
};

void GLabel::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        GLabel *_t = static_cast<GLabel *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< int*>(_v) = _t->LabelColor(); break;
        case 1: *reinterpret_cast< int*>(_v) = _t->BorderColor(); break;
        case 2: *reinterpret_cast< int*>(_v) = _t->FontColor(); break;
        case 3: *reinterpret_cast< bool*>(_v) = _t->FontBold(); break;
        case 4: *reinterpret_cast< bool*>(_v) = _t->FontUnderline(); break;
        case 5: *reinterpret_cast< float*>(_v) = _t->Thickness(); break;
        case 6: *reinterpret_cast< int*>(_v) = _t->FontSize(); break;
        case 7: *reinterpret_cast< int*>(_v) = _t->Angle(); break;
        case 8: *reinterpret_cast< QString*>(_v) = _t->Text(); break;
        case 9: *reinterpret_cast< bool*>(_v) = _t->Transparent(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GLabel *_t = static_cast<GLabel *>(_o);
        Q_UNUSED(_t)
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setLabelQColor(*reinterpret_cast< int*>(_v)); break;
        case 1: _t->setBorderQColor(*reinterpret_cast< int*>(_v)); break;
        case 2: _t->setFontQColor(*reinterpret_cast< int*>(_v)); break;
        case 3: _t->setBold(*reinterpret_cast< bool*>(_v)); break;
        case 4: _t->setUnderline(*reinterpret_cast< bool*>(_v)); break;
        case 5: _t->setThickness(*reinterpret_cast< float*>(_v)); break;
        case 6: _t->setFontsize(*reinterpret_cast< int*>(_v)); break;
        case 7: _t->setAngle(*reinterpret_cast< int*>(_v)); break;
        case 8: _t->setTextWrapper(*reinterpret_cast< QString*>(_v)); break;
        case 9: _t->setTransparent(*reinterpret_cast< bool*>(_v)); break;
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

const QMetaObject GLabel::staticMetaObject = {
    { &QLabel::staticMetaObject, qt_meta_stringdata_GLabel.data,
      qt_meta_data_GLabel,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GLabel::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GLabel::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GLabel.stringdata0))
        return static_cast<void*>(const_cast< GLabel*>(this));
    return QLabel::qt_metacast(_clname);
}

int GLabel::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QLabel::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    
#ifndef QT_NO_PROPERTIES
   if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 10;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 10;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 10;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 10;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 10;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 10;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
