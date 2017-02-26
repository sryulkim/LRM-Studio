include(../shared.pri)

TEMPLATE = lib
TARGET   = basicax

CONFIG += warn_off dll
QT += widgets axserver

SOURCES  = main.cpp
RC_FILE  = basicax.rc
DEF_FILE = basicax.def

# install
target.path = $$[QT_INSTALL_EXAMPLES]/activeqt/wrapper
INSTALLS += target
