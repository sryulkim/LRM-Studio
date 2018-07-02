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
HEADERS  = qwtdialbox.h
RC_FILE  = qwtbasicax.rc
DEF_FILE = qwtbasicax.def

# install
INSTALLS += target

qwtAddLibrary($${QWT_ROOT}/lib, qwt)



win32 {
    contains(QWT_CONFIG, QwtDll) {
        DEFINES    += QT_DLL QWT_DLL
    }
}