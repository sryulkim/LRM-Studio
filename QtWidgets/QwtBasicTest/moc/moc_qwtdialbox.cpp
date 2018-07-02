/****************************************************************************
** Meta object code from reading C++ file 'qwtdialbox.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.6.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../qwtdialbox.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'qwtdialbox.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.6.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
struct qt_meta_stringdata_QwtTestDialBox_t {
    QByteArrayData data[11];
    char stringdata0[201];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_QwtTestDialBox_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_QwtTestDialBox_t qt_meta_stringdata_QwtTestDialBox = {
    {
QT_MOC_LITERAL(0, 0, 14), // "QwtTestDialBox"
QT_MOC_LITERAL(1, 15, 7), // "ClassID"
QT_MOC_LITERAL(2, 23, 38), // "{DEF66F5A-01FF-4DB8-8191-5678..."
QT_MOC_LITERAL(3, 62, 11), // "InterfaceID"
QT_MOC_LITERAL(4, 74, 38), // "{214592B1-CBA5-45D1-82F1-FDFF..."
QT_MOC_LITERAL(5, 113, 8), // "EventsID"
QT_MOC_LITERAL(6, 122, 38), // "{97D0D650-D089-40D8-ABB2-8B42..."
QT_MOC_LITERAL(7, 161, 12), // "ToSuperClass"
QT_MOC_LITERAL(8, 174, 11), // "StockEvents"
QT_MOC_LITERAL(9, 186, 3), // "yes"
QT_MOC_LITERAL(10, 190, 10) // "Insertable"

    },
    "QwtTestDialBox\0ClassID\0"
    "{DEF66F5A-01FF-4DB8-8191-5678EB6510DA}\0"
    "InterfaceID\0{214592B1-CBA5-45D1-82F1-FDFFCE955979}\0"
    "EventsID\0{97D0D650-D089-40D8-ABB2-8B42550B6818}\0"
    "ToSuperClass\0StockEvents\0yes\0Insertable"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_QwtTestDialBox[] = {

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

void QwtTestDialBox::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    Q_UNUSED(_o);
    Q_UNUSED(_id);
    Q_UNUSED(_c);
    Q_UNUSED(_a);
}

const QMetaObject QwtTestDialBox::staticMetaObject = {
    { &QWidget::staticMetaObject, qt_meta_stringdata_QwtTestDialBox.data,
      qt_meta_data_QwtTestDialBox,  qt_static_metacall, Q_NULLPTR, Q_NULLPTR}
};


const QMetaObject *QwtTestDialBox::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *QwtTestDialBox::qt_metacast(const char *_clname)
{
    if (!_clname) return Q_NULLPTR;
    if (!strcmp(_clname, qt_meta_stringdata_QwtTestDialBox.stringdata0))
        return static_cast<void*>(const_cast< QwtTestDialBox*>(this));
    return QWidget::qt_metacast(_clname);
}

int QwtTestDialBox::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    return _id;
}
QT_END_MOC_NAMESPACE
