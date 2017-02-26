/********************************************************************************
** Form generated from reading UI file 'numpad.ui'
**
** Created by: Qt User Interface Compiler version 5.5.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_NUMPAD_H
#define UI_NUMPAD_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_numpad
{
public:
    QGridLayout *gridLayout;
    QPushButton *QPB_7;
    QPushButton *QPB_8;
    QPushButton *QPB_9;
    QPushButton *QPB_4;
    QPushButton *QPB_5;
    QPushButton *QPB_6;
    QPushButton *QPB_1;
    QPushButton *QPB_2;
    QPushButton *QPB_3;
    QPushButton *RST_BTN;
    QPushButton *QPB_0;
    QPushButton *OK_BTN;
    void setupUi(QWidget *GNumpad)
    {
        if (GNumpad->objectName().isEmpty())
            GNumpad->setObjectName(QStringLiteral("GNumpad"));
        GNumpad->resize(400, 300);
        gridLayout = new QGridLayout(GNumpad);
        gridLayout->setSpacing(2);
        gridLayout->setObjectName(QStringLiteral("gridLayout"));

        QPB_7 = new QPushButton(GNumpad);
        QPB_7->setObjectName(QStringLiteral("QPB_7"));
        QSizePolicy sizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(QPB_7->sizePolicy().hasHeightForWidth());
        QPB_7->setSizePolicy(sizePolicy);

        gridLayout->addWidget(QPB_7, 0, 0, 1, 1);

        QPB_8 = new QPushButton(GNumpad);
        QPB_8->setObjectName(QStringLiteral("QPB_8"));
        sizePolicy.setHeightForWidth(QPB_8->sizePolicy().hasHeightForWidth());
        QPB_8->setSizePolicy(sizePolicy);
        gridLayout->addWidget(QPB_8, 0, 1, 1, 1);

        QPB_9 = new QPushButton(GNumpad);
        QPB_9->setObjectName(QStringLiteral("QPB_9"));
        sizePolicy.setHeightForWidth(QPB_9->sizePolicy().hasHeightForWidth());
        QPB_9->setSizePolicy(sizePolicy);
        gridLayout->addWidget(QPB_9, 0, 2, 1, 1);

        QPB_4 = new QPushButton(GNumpad);
        QPB_4->setObjectName(QStringLiteral("QPB_4"));
        sizePolicy.setHeightForWidth(QPB_4->sizePolicy().hasHeightForWidth());
        QPB_4->setSizePolicy(sizePolicy);


        gridLayout->addWidget(QPB_4, 1, 0, 1, 1);

        QPB_5 = new QPushButton(GNumpad);
        QPB_5->setObjectName(QStringLiteral("QPB_5"));
        sizePolicy.setHeightForWidth(QPB_5->sizePolicy().hasHeightForWidth());
        QPB_5->setSizePolicy(sizePolicy);


        gridLayout->addWidget(QPB_5, 1, 1, 1, 1);

        QPB_6 = new QPushButton(GNumpad);
        QPB_6->setObjectName(QStringLiteral("QPB_6"));
        sizePolicy.setHeightForWidth(QPB_6->sizePolicy().hasHeightForWidth());
        QPB_6->setSizePolicy(sizePolicy);


        gridLayout->addWidget(QPB_6, 1, 2, 1, 1);

        QPB_1 = new QPushButton(GNumpad);
        QPB_1->setObjectName(QStringLiteral("QPB_1"));
        sizePolicy.setHeightForWidth(QPB_1->sizePolicy().hasHeightForWidth());
        QPB_1->setSizePolicy(sizePolicy);


        gridLayout->addWidget(QPB_1, 2, 0, 1, 1);

        QPB_2 = new QPushButton(GNumpad);
        QPB_2->setObjectName(QStringLiteral("QPB_2"));
        sizePolicy.setHeightForWidth(QPB_2->sizePolicy().hasHeightForWidth());
        QPB_2->setSizePolicy(sizePolicy);


        gridLayout->addWidget(QPB_2, 2, 1, 1, 1);

        QPB_3 = new QPushButton(GNumpad);
        QPB_3->setObjectName(QStringLiteral("QPB_3"));
        sizePolicy.setHeightForWidth(QPB_3->sizePolicy().hasHeightForWidth());
        QPB_3->setSizePolicy(sizePolicy);


        gridLayout->addWidget(QPB_3, 2, 2, 1, 1);

        RST_BTN = new QPushButton(GNumpad);
        RST_BTN->setObjectName(QStringLiteral("RST_BTN"));
        sizePolicy.setHeightForWidth(RST_BTN->sizePolicy().hasHeightForWidth());
        RST_BTN->setSizePolicy(sizePolicy);

        gridLayout->addWidget(RST_BTN, 3, 0, 1, 1);

        QPB_0 = new QPushButton(GNumpad);
        QPB_0->setObjectName(QStringLiteral("QPB_0"));
        sizePolicy.setHeightForWidth(QPB_0->sizePolicy().hasHeightForWidth());
        QPB_0->setSizePolicy(sizePolicy);


        gridLayout->addWidget(QPB_0, 3, 1, 1, 1);

        OK_BTN = new QPushButton(GNumpad);
        OK_BTN->setObjectName(QStringLiteral("OK_BTN"));
        sizePolicy.setHeightForWidth(OK_BTN->sizePolicy().hasHeightForWidth());
        OK_BTN->setSizePolicy(sizePolicy);

        gridLayout->addWidget(OK_BTN, 3, 2, 1, 1);

        retranslateUi(GNumpad);

        QMetaObject::connectSlotsByName(GNumpad);
    } // setupUi

    void retranslateUi(QWidget *GNumpad)
    {
        GNumpad->setWindowTitle(QApplication::translate("GNumpad", "GNumpad", 0));
//        GNumpad->setProperty("current_value", QVariant(QString()));
        QPB_7->setText(QApplication::translate("numpad", "7", 0));
        QPB_8->setText(QApplication::translate("numpad", "8", 0));
        QPB_9->setText(QApplication::translate("numpad", "9", 0));
        QPB_4->setText(QApplication::translate("numpad", "4", 0));
        QPB_5->setText(QApplication::translate("numpad", "5", 0));
        QPB_6->setText(QApplication::translate("numpad", "6", 0));
        QPB_1->setText(QApplication::translate("numpad", "1", 0));
        QPB_2->setText(QApplication::translate("numpad", "2", 0));
        QPB_3->setText(QApplication::translate("numpad", "3", 0));
        RST_BTN->setText(QApplication::translate("numpad", "RST", 0));
        QPB_0->setText(QApplication::translate("numpad", "0", 0));
        OK_BTN->setText(QApplication::translate("numpad", "OK", 0));
    } // retranslateUi

};

namespace Ui {
    class GNumpad: public Ui_numpad {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_NUMPAD_H
