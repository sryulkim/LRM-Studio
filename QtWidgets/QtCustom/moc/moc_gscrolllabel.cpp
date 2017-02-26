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
    QByteArrayData data[19];
    char stringdata0[291];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GScrollLabel_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GScrollLabel_t qt_meta_stringdata_GScrollLabel = {
    {
QT_MOC_LITERAL(0, 0, 12), // "GScrollLabel"
QT_MOC_LITERAL(1, 13, 7), // "ClassID"
QT_MOC_LITERAL(2, 21, 38), // "{96BE9AA1-A1AF-452F-AD86-E7BA..."
QT_MOC_LITERAL(3, 60, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 72, 38), // "{022B5EEE-32C9-40B9-82AA-0CE3..."
QT_MOC_LITERAL(5, 111, 8), // "EventsID"
QT_MOC_LITERAL(6, 120, 38), // "{90C847F2-B378-4A41-B5A1-F223..."
QT_MOC_LITERAL(7, 159, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 172, 11), // "StockEvents"
QT_MOC_LITERAL(9, 184, 3), // "yes"
QT_MOC_LITERAL(10, 188, 10), // "Insertable"
QT_MOC_LITERAL(11, 199, 11), // "label_color"
QT_MOC_LITERAL(12, 211, 12), // "border_color"
QT_MOC_LITERAL(13, 224, 10), // "font_color"
QT_MOC_LITERAL(14, 235, 9), // "font_bold"
QT_MOC_LITERAL(15, 245, 14), // "font_underline"
QT_MOC_LITERAL(16, 260, 9), // "thickness"
QT_MOC_LITERAL(17, 270, 9), // "font_size"
QT_MOC_LITERAL(18, 280, 10) // "label_text"

    },
    "GScrollLabel\0ClassID\0"
    "{96BE9AA1-A1AF-452F-AD86-E7BA70ABC119}\0"
    "InterfaceID\0{022B5EEE-32C9-40B9-82AA-0CE333E329F3}\0"
    "EventsID\0{90C847F2-B378-4A41-B5A1-F2239604D90E}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable\0"
    "label_color\0border_color\0font_color\0"
    "font_bold\0font_underline\0thickness\0"
    "font_size\0label_text"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GScrollLabel[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
       8,   26, // properties
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
      18, QMetaType::QString, 0x00095003,

       0        // eod
};

void GScrollLabel::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{

#ifndef QT_NO_PROPERTIES
    if (_c == QMetaObject::ReadProperty) {
        GScrollLabel *_t = static_cast<GScrollLabel *>(_o);
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
        case 7: *reinterpret_cast< QString*>(_v) = _t->Text(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        GScrollLabel *_t = static_cast<GScrollLabel *>(_o);
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
        case 7: _t->setTextWrapper(*reinterpret_cast< QString*>(_v)); break;
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
    
#ifndef QT_NO_PROPERTIES
   if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 8;
    } else if (_c == QMetaObject::QueryPropertyDesignable) {
        _id -= 8;
    } else if (_c == QMetaObject::QueryPropertyScriptable) {
        _id -= 8;
    } else if (_c == QMetaObject::QueryPropertyStored) {
        _id -= 8;
    } else if (_c == QMetaObject::QueryPropertyEditable) {
        _id -= 8;
    } else if (_c == QMetaObject::QueryPropertyUser) {
        _id -= 8;
    }
#endif // QT_NO_PROPERTIES
    return _id;
}
QT_END_MOC_NAMESPACE
