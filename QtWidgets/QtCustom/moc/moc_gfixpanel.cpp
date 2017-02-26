/****************************************************************************
** Meta object code from reading C++ file 'gfixpanel.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../gfixpanel.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gfixpanel.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_GFixPanel_t {
    QByteArrayData data[11];
    char stringdata0[196];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GFixPanel_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GFixPanel_t qt_meta_stringdata_GFixPanel = {
    {
QT_MOC_LITERAL(0, 0, 9), // "GFixPanel"
QT_MOC_LITERAL(1, 10, 7), // "ClassID"
QT_MOC_LITERAL(2, 18, 38), // "{BC97D5C5-D71C-414D-89FE-AB95..."
QT_MOC_LITERAL(3, 57, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 69, 38), // "{C9704444-DCFB-42EE-A5A8-322D..."
QT_MOC_LITERAL(5, 108, 8), // "EventsID"
QT_MOC_LITERAL(6, 117, 38), // "{96BB162D-3E65-4EFB-B673-904B..."
QT_MOC_LITERAL(7, 156, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 169, 11), // "StockEvents"
QT_MOC_LITERAL(9, 181, 3), // "yes"
QT_MOC_LITERAL(10, 185, 10) // "Insertable"

    },
    "GFixPanel\0ClassID\0"
    "{BC97D5C5-D71C-414D-89FE-AB953372E0EC}\0"
    "InterfaceID\0{C9704444-DCFB-42EE-A5A8-322D588048D1}\0"
    "EventsID\0{96BB162D-3E65-4EFB-B673-904B532A1957}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GFixPanel[] = {

 // content:
       7,       // revision
       0,       // classname
       6,   14, // classinfo
       0,    0, // methods
       0,    0, // properties
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

       0        // eod
};

void GFixPanel::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    Q_UNUSED(_o);
    Q_UNUSED(_id);
    Q_UNUSED(_c);
    Q_UNUSED(_a);
}

const QMetaObject GFixPanel::staticMetaObject = {
    { &WidgetWithBackground::staticMetaObject, qt_meta_stringdata_GFixPanel.data,
      qt_meta_data_GFixPanel,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *GFixPanel::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GFixPanel::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_GFixPanel.stringdata0))
        return static_cast<void*>(const_cast< GFixPanel*>(this));
    return WidgetWithBackground::qt_metacast(_clname);
}

int GFixPanel::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = WidgetWithBackground::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    return _id;
}
QT_END_MOC_NAMESPACE
