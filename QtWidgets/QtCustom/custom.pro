QWT_ROOT = C:\Qt\QWT-6.1.3

include(../shared.pri)
include( $${QWT_ROOT}/qwtconfig.pri )
include( $${QWT_ROOT}/qwtbuild.pri )
include( $${QWT_ROOT}/qwtfunctions.pri )

TEMPLATE = lib
TARGET   = customax

CONFIG += warn_off dll
QT += widgets axserver
INCLUDEPATH += $${QWT_ROOT}/src
DEPENDPATH  += $${QWT_ROOT}/src

SOURCES  = main.cpp widgetwithbackground.cpp
HEADERS  = colourfuldial.h colourfullabel.h colourfulpushbutton.h colourfulslider.h 
HEADERS += gpushbutton.h gdial.h widgetwithbackground.h gpanel.h gsliderbar.h gnumpad.h ui_numpad.h gloginpad.h ui_gloginpad.h 
HEADERS += glabel.h gdigitalclock.h gprogressbar.h gincdecbutton.h gsetresetbutton.h gradiobutton.h gled.h gfixpanel.h
HEADERS += gscrolllabel.h
RC_FILE  = customax.rc
DEF_FILE = customax.def

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