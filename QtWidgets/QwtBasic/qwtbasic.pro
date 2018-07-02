QWT_ROOT = C:\Qt\QWT-6.1.3

include(../shared.pri)
include( $${QWT_ROOT}/qwtconfig.pri )
include( $${QWT_ROOT}/qwtbuild.pri )
include( $${QWT_ROOT}/qwtfunctions.pri )

TEMPLATE = lib
TARGET   = qwtbasicax

CONFIG += warn_off dll
QT += widgets axserver
INCLUDEPATH += $${QWT_ROOT}/src
DEPENDPATH  += $${QWT_ROOT}/src

SOURCES  = main.cpp
HEADERS  = qwtdialbox.h qwtknobbox.h qwtsliderbox.h qwtwheelbox.h qwtspeedmeter.h
RC_FILE  = qwtbasicax.rc
DEF_FILE = qwtbasicax.def

# install

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