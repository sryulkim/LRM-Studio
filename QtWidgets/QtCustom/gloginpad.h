#ifndef GLOGINPAD_H
#define GLOGINPAD_H

#include <QWidget>
#include <QLabel>
#include "ui_gloginpad.h"
#include <QDebug>
namespace Ui {
class GLoginpad;
}

class GLoginpad : public QWidget
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{C8AC7D61-91F3-424F-8D77-D4875AC8FD29}")
    Q_CLASSINFO("InterfaceID", "{397CC88B-4166-42BF-9B8E-CA2923085E80}")
    Q_CLASSINFO("EventsID", "{A153ED60-E4D0-404B-B814-BF75C93DD0A5}")
    Q_CLASSINFO("ToSuperClass", "GNumpad")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")

    Q_PROPERTY(QString password READ Password WRITE setPassword)
    Q_PROPERTY(int numColor READ NumColor WRITE setNumColor)
    Q_PROPERTY(int numButtonColor READ NumButtonColor WRITE setNumberButtonColor)
    Q_PROPERTY(int resetColor READ ResetColor WRITE setResetColor)
    Q_PROPERTY(int resetButtonColor READ ResetButtonColor WRITE setResetButtonColor)
    Q_PROPERTY(int loginColor READ LoginColor WRITE setLoginColor)
    Q_PROPERTY(int loginButtonColor READ LoginButtonColor WRITE setLoginButtonColor)
    Q_PROPERTY(int funcColor READ FuncColor WRITE setFuncColor)
    Q_PROPERTY(int funcButtonColor READ FuncButtonColor WRITE setFuncButtonColor)
    Q_PROPERTY(int borderColor READ BorderColor WRITE setBorderColor)
    Q_PROPERTY(int digitNumber READ DigitNumber WRITE setDigitNumber)

public:
    GLoginpad(QWidget *parent = 0) : QWidget(parent), ui(new Ui::GLoginpad)
    {
        ui->setupUi(this);
        tempPassword = "";
        password = "";
        clickCount = 0;
        pageNum = 0;
    numberBtnQColor.setRgb(0x0000FF);
    numButtonColor = 0x0000FF;
    funcBtnQColor.setRgb(0x6424BD);
    funcButtonColor = 0x6424BD;
    resetBtnQColor.setRgb(0x0000B7);
    resetButtonColor = 0x0000B7;
    loginBtnQColor.setRgb(0x2F9D27);
    loginButtonColor = 0x2F9D27;
    borderQColor.setRgb(0xFFFFFF);
    borderColor = 0xFFFFFF;
    numQColor.setRgb(0xffffff);
    numColor = 0xFFFFFF;
    loginQColor.setRgb(0xffffff);
    loginColor = 0xffffff;
    funcQColor.setRgb(0xffffff);
    funcColor = 0xffffff;
    resetQColor.setRgb(0xffffff);
    resetColor = 0xffffff;
        setDigitNumber(6);
        colorUpdate();
    }
    ~GLoginpad()
    {
        delete ui;
    }

    QString Password(){
        return password;
    }

    int NumColor(){
        return numColor;
    }

    int NumButtonColor(){
        return numButtonColor;
    }

    int ResetColor(){
        return resetColor;
    }

    int ResetButtonColor(){
        return resetButtonColor;
    }

    int LoginColor(){
        return loginColor;
    }

    int LoginButtonColor(){
        return loginButtonColor;
    }

    int FuncColor(){
        return funcColor;
    }

    int FuncButtonColor(){
        return funcButtonColor;
    }

    int BorderColor(){
        return borderColor;
    }

    int DigitNumber(){
        return digitNumber;
    }

    void setDigitNumber(int n)
    {
        digitNumber = n;
        QSizePolicy sizePolicy(QSizePolicy::Preferred, QSizePolicy::Expanding);
        QFont *font = new QFont();
        font->setBold(true);
        font->setPixelSize(14);
        
        labelHash.clear();
        ui->horizontalLayout = new QHBoxLayout();
        ui->horizontalLayout->setSpacing(6);
        ui->horizontalLayout->setObjectName(QStringLiteral("horizontalLayout"));
        ui->gridLayout->addLayout(ui->horizontalLayout, 0, 0, 1, 3);
        for(int i=0;i<n;i++){
            passwordLabel = new QLabel(this);
            passwordLabel->setText("-");
            passwordLabel->setFont(*font);
            passwordLabel->setAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
            passwordLabel->setSizePolicy(sizePolicy);
            passwordLabel->setStyleSheet(QString("background-color: rgb(255,255,255);"));
            ui->horizontalLayout->addWidget(passwordLabel);
            labelHash.insert(i,passwordLabel);
        }
    //    this->repaint();
        this->update();
    }
    void setNumberButtonColor(int color){numberBtnQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
        numButtonColor = color;
        }
    void setNumColor(int color){numQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
        numColor = color;
        }

    void setLoginButtonColor(int color){loginBtnQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
        loginButtonColor = color;
        }
    void setLoginColor(int color){loginQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
        loginColor = color;
        }

    void setFuncButtonColor(int color){funcBtnQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
        funcButtonColor = color;
        }
    void setFuncColor(int color){funcQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
        funcColor = color;
        }

    void setResetButtonColor(int color){resetBtnQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
        resetButtonColor = color;
        }
    void setResetColor(int color){resetQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
        resetColor = color;
        }

    void setBorderColor(int color){borderQColor.setRgb(color & 0xFFFFFF);
        colorUpdate();
        borderColor = color;
        }

    void setPassword(QString pwd)
    {
        password = pwd;
    }
    void setChangePage(int page)
    {
        pageNum = page;
    }

    void colorUpdate(void)
    {
    //    this->setStyleSheet("QPushButton{background-color : rgb(255,255,255); color : rgb(255,0,0);}");
    this->setStyleSheet("QPushButton"+QString("{background-color : rgb(%1,%2,%3); color : rgb(%4,%5,%6); border: 0.5px solid rgb(%7,%8,%9);}")
                        .arg(numberBtnQColor.red()).arg(numberBtnQColor.green()).arg(numberBtnQColor.blue())
                        .arg(numQColor.red()).arg(numQColor.green()).arg(numQColor.blue())
                        .arg(borderQColor.red()).arg(borderQColor.green()).arg(borderQColor.blue()));
    ui->mbtn->setStyleSheet(QString("background-color : rgb(%1,%2,%3);").arg(funcBtnQColor.red()).arg(funcBtnQColor.green()).arg(funcBtnQColor.blue())
                            +QString("color : rgb(%1,%2,%3);").arg(funcQColor.red()).arg(funcQColor.green()).arg(funcQColor.blue()));
    ui->resetBtn->setStyleSheet(QString("background-color : rgb(%1,%2,%3);").arg(resetBtnQColor.red()).arg(resetBtnQColor.green()).arg(resetBtnQColor.blue())
                                +QString("color : rgb(%1,%2,%3);").arg(resetQColor.red()).arg(resetQColor.green()).arg(resetQColor.blue()));
    ui->loginBtn->setStyleSheet(QString("background-color : rgb(%1,%2,%3);").arg(loginBtnQColor.red()).arg(loginBtnQColor.green()).arg(loginBtnQColor.blue())
                                +QString("color : rgb(%1,%2,%3);").arg(loginQColor.red()).arg(loginQColor.green()).arg(loginQColor.blue()));
    }

private:
    Ui::GLoginpad *ui;
    QPalette *pal;
    QColor numberBtnQColor;
    QColor loginBtnQColor;
    QColor resetBtnQColor;
    QColor funcBtnQColor;
    QColor borderQColor;
    QColor numQColor;
    QColor loginQColor;
    QColor funcQColor;
    QColor resetQColor;

    int numColor;
    int numButtonColor;
    int resetColor;
    int resetButtonColor;
    int loginColor;
    int loginButtonColor;
    int funcColor;
    int funcButtonColor;
    int borderColor;

    int digitNumber;
    int clickCount;
    int pageNum;
    QLabel *passwordLabel;
    QString password,tempPassword;
    QHash <int, QLabel*> labelHash;
    void changeLabel(void);
};

#endif // GLOGIN_H
