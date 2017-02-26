QWT_ROOT = C:\Qt\QWT-6.1.3

include(../shared.pri)
include( $${QWT_ROOT}/qwtconfig.pri )
include( $${QWT_ROOT}/qwtbuild.pri )
include( $${QWT_ROOT}/qwtfunctions.pri )

TEMPLATE = lib
TARGET   = hmiform

CONFIG += warn_off dll
QT += widgets axserver
INCLUDEPATH += $${QWT_ROOT}/src
DEPENDPATH  += $${QWT_ROOT}/src

SOURCES  = main.cpp edge.cpp guio.cpp hmiform.cpp vertex.cpp widgetwithbackground.cpp
HEADERS += edge.h gdial.h gdigitalclock.h gdrawing.h gimage.h gincdecbutton.h gipcamera.h glabel.h gled.h
HEADERS += gloginpad.h gnumpad.h gpanel.h gprogressbar.h gpushbutton.h grail.h gscrolllabel.h gsetresetbutton.h
HEADERS += gsliderbar.h guio.h gwebview.h hmiform.h ui_gloginpad.h ui_numpad.h vertex.h widgetwithbackground.h
RC_FILE  = hmiform.rc
DEF_FILE = hmiform.def

# install
INSTALLS += target

qwtAddLibrary($${QWT_ROOT}/lib, qwt)

greaterThan(QT_MAJOR_VERSION, 4) {

    QT += printsupport
    QT += concurrent
}

contains(QWT_CONFIG, QwtOpenGL ) {

    QT += opengl
}
else {

    DEFINES += QWT_NO_OPENGL
}

contains(QWT_CONFIG, QwtSvg) {

    QT += svg
}
else {

    DEFINES += QWT_NO_SVG
}


win32 {
    contains(QWT_CONFIG, QwtDll) {
        DEFINES    += QT_DLL QWT_DLL
    }
}