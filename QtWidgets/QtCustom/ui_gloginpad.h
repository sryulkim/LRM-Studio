/********************************************************************************
** Form generated from reading UI file 'glogin.ui'
**
** Created by: Qt User Interface Compiler version 5.5.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_GLOGINPAD_H
#define UI_GLOGINPAD_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_GLoginpad
{
public:
    QGridLayout *gridLayout_2;
    QGridLayout *gridLayout;
    QHBoxLayout *horizontalLayout;
    QPushButton *btn1;
    QPushButton *btn2;
    QPushButton *btn3;
    QPushButton *btn4;
    QPushButton *btn5;
    QPushButton *btn6;
    QPushButton *btn7;
    QPushButton *btn8;
    QPushButton *btn9;
    QPushButton *mbtn;
    QPushButton *btn0;
    QPushButton *resetBtn;
    QPushButton *loginBtn;

    void setupUi(QWidget *GLogin)
    {
        if (GLogin->objectName().isEmpty())
            GLogin->setObjectName(QStringLiteral("GLogin"));
        GLogin->resize(400, 300);
        gridLayout_2 = new QGridLayout(GLogin);
        gridLayout_2->setSpacing(6);
        gridLayout_2->setContentsMargins(5, 5, 5, 5);
        gridLayout_2->setObjectName(QStringLiteral("gridLayout_2"));
        gridLayout = new QGridLayout();
        gridLayout->setSpacing(3);
        gridLayout->setObjectName(QStringLiteral("gridLayout"));
        horizontalLayout = new QHBoxLayout();
        horizontalLayout->setSpacing(6);
        horizontalLayout->setObjectName(QStringLiteral("horizontalLayout"));

        gridLayout->addLayout(horizontalLayout, 0, 0, 1, 3);

        btn1 = new QPushButton(GLogin);
        btn1->setObjectName(QStringLiteral("btn1"));
        QSizePolicy sizePolicy(QSizePolicy::Minimum, QSizePolicy::Expanding);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(btn1->sizePolicy().hasHeightForWidth());
        btn1->setSizePolicy(sizePolicy);

        gridLayout->addWidget(btn1, 1, 0, 1, 1);

        btn2 = new QPushButton(GLogin);
        btn2->setObjectName(QStringLiteral("btn2"));
        sizePolicy.setHeightForWidth(btn2->sizePolicy().hasHeightForWidth());
        btn2->setSizePolicy(sizePolicy);

        gridLayout->addWidget(btn2, 1, 1, 1, 1);

        btn3 = new QPushButton(GLogin);
        btn3->setObjectName(QStringLiteral("btn3"));
        sizePolicy.setHeightForWidth(btn3->sizePolicy().hasHeightForWidth());
        btn3->setSizePolicy(sizePolicy);

        gridLayout->addWidget(btn3, 1, 2, 1, 1);

        btn4 = new QPushButton(GLogin);
        btn4->setObjectName(QStringLiteral("btn4"));
        sizePolicy.setHeightForWidth(btn4->sizePolicy().hasHeightForWidth());
        btn4->setSizePolicy(sizePolicy);

        gridLayout->addWidget(btn4, 2, 0, 1, 1);

        btn5 = new QPushButton(GLogin);
        btn5->setObjectName(QStringLiteral("btn5"));
        sizePolicy.setHeightForWidth(btn5->sizePolicy().hasHeightForWidth());
        btn5->setSizePolicy(sizePolicy);

        gridLayout->addWidget(btn5, 2, 1, 1, 1);

        btn6 = new QPushButton(GLogin);
        btn6->setObjectName(QStringLiteral("btn6"));
        sizePolicy.setHeightForWidth(btn6->sizePolicy().hasHeightForWidth());
        btn6->setSizePolicy(sizePolicy);

        gridLayout->addWidget(btn6, 2, 2, 1, 1);

        btn7 = new QPushButton(GLogin);
        btn7->setObjectName(QStringLiteral("btn7"));
        sizePolicy.setHeightForWidth(btn7->sizePolicy().hasHeightForWidth());
        btn7->setSizePolicy(sizePolicy);

        gridLayout->addWidget(btn7, 3, 0, 1, 1);

        btn8 = new QPushButton(GLogin);
        btn8->setObjectName(QStringLiteral("btn8"));
        sizePolicy.setHeightForWidth(btn8->sizePolicy().hasHeightForWidth());
        btn8->setSizePolicy(sizePolicy);

        gridLayout->addWidget(btn8, 3, 1, 1, 1);

        btn9 = new QPushButton(GLogin);
        btn9->setObjectName(QStringLiteral("btn9"));
        sizePolicy.setHeightForWidth(btn9->sizePolicy().hasHeightForWidth());
        btn9->setSizePolicy(sizePolicy);

        gridLayout->addWidget(btn9, 3, 2, 1, 1);

        mbtn = new QPushButton(GLogin);
        mbtn->setObjectName(QStringLiteral("mbtn"));
        sizePolicy.setHeightForWidth(mbtn->sizePolicy().hasHeightForWidth());
        mbtn->setSizePolicy(sizePolicy);

        gridLayout->addWidget(mbtn, 4, 0, 1, 1);

        btn0 = new QPushButton(GLogin);
        btn0->setObjectName(QStringLiteral("btn0"));
        sizePolicy.setHeightForWidth(btn0->sizePolicy().hasHeightForWidth());
        btn0->setSizePolicy(sizePolicy);

        gridLayout->addWidget(btn0, 4, 1, 1, 1);

        resetBtn = new QPushButton(GLogin);
        resetBtn->setObjectName(QStringLiteral("resetBtn"));
        sizePolicy.setHeightForWidth(resetBtn->sizePolicy().hasHeightForWidth());
        resetBtn->setSizePolicy(sizePolicy);

        gridLayout->addWidget(resetBtn, 4, 2, 1, 1);

        loginBtn = new QPushButton(GLogin);
        loginBtn->setObjectName(QStringLiteral("loginBtn"));
        sizePolicy.setHeightForWidth(loginBtn->sizePolicy().hasHeightForWidth());
        loginBtn->setSizePolicy(sizePolicy);

        gridLayout->addWidget(loginBtn, 5, 0, 1, 3);


        gridLayout_2->addLayout(gridLayout, 0, 0, 1, 1);


        retranslateUi(GLogin);

        QMetaObject::connectSlotsByName(GLogin);
    } // setupUi

    void retranslateUi(QWidget *GLogin)
    {
        GLogin->setWindowTitle(QApplication::translate("GLogin", "GLogin", 0));
        btn1->setText(QApplication::translate("GLogin", "1", 0));
        btn2->setText(QApplication::translate("GLogin", "2", 0));
        btn3->setText(QApplication::translate("GLogin", "3", 0));
        btn4->setText(QApplication::translate("GLogin", "4", 0));
        btn5->setText(QApplication::translate("GLogin", "5", 0));
        btn6->setText(QApplication::translate("GLogin", "6", 0));
        btn7->setText(QApplication::translate("GLogin", "7", 0));
        btn8->setText(QApplication::translate("GLogin", "8", 0));
        btn9->setText(QApplication::translate("GLogin", "9", 0));
        mbtn->setText(QApplication::translate("GLogin", "M", 0));
        btn0->setText(QApplication::translate("GLogin", "0", 0));
        resetBtn->setText(QApplication::translate("GLogin", "RESET", 0));
        loginBtn->setText(QApplication::translate("GLogin", "LOGIN", 0));
    } // retranslateUi

};

namespace Ui {
    class GLoginpad: public Ui_GLoginpad {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_GLOGIN_H
