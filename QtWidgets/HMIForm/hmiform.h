#ifndef HMIFORM_H
#define HMIFORM_H

#include <QWidget>
#include <QString>
#include <QVBoxLayout>
#include <guio.h>
#include <algorithm>
#include "gpushbutton.h"
#include "gdial.h"
#include "gprogressbar.h"
#include "gsliderbar.h"
#include "gnumpad.h"
#include "gloginpad.h"
#include "glabel.h"
#include "gscrolllabel.h"
#include "gdigitalclock.h"
#include "gled.h"
#include "gpanel.h"
#include "gincdecbutton.h"
#include "gsetresetbutton.h"
#include "gimage.h"
#include "grail.h"
#include "gdrawing.h"
#include "gipcamera.h"
#include "gwebview.h"

class HMIForm : public QWidget
{
    Q_OBJECT
    Q_CLASSINFO("ClassID", "{4B46A2D5-65A9-40DD-9EC2-5D7D11072B93}")
    Q_CLASSINFO("InterfaceID", "{0779FBA0-96AB-4A31-8A58-7C0DB7A832E9}")
    Q_CLASSINFO("EventsID", "{36115845-A13F-47E5-9D73-056841C82847}")
    Q_CLASSINFO("ToSuperClass", "HMIForm")
    Q_CLASSINFO("StockEvents", "yes")
    Q_CLASSINFO("Insertable", "yes")
    Q_PROPERTY(QString selectedGUIOName READ getSelectedGUIOName WRITE setSelectedGUIOName)

    Q_PROPERTY(QString GUIOName READ getGUIOName WRITE setGUIOName)
    Q_PROPERTY(QString GUIOType READ getGUIOType WRITE setGUIOType)
    Q_PROPERTY(int GUIOLayer READ getGUIOLayer WRITE setGUIOLayer)
    Q_PROPERTY(bool MakeGUIOCommand READ getMakeGUIOCommand WRITE setMakeGUIOCommand)
    Q_PROPERTY(bool RemoveGUIOCommand READ getRemoveGUIOCommand WRITE setRemoveGUIOCommand)

    Q_PROPERTY(QString EditPageName READ getEditPageName WRITE setEditPageName)
    Q_PROPERTY(QString EditPageBackgroundImageName READ getEditPageBackgroundImageName WRITE setEditPageBackgroundImageName)
    Q_PROPERTY(int EditPageBackgroundColor READ getEditPageBackgroundColor WRITE setEditPageBackgroundColor)

    Q_PROPERTY(QString EditGUIOPropertyName READ getEditGUIOPropertyName WRITE setEditGUIOPropertyName)
    Q_PROPERTY(int EditGUIOPropertyLayer READ getEditGUIOPropertyLayer WRITE setEditGUIOPropertyLayer)

    Q_PROPERTY(int EditGUIOPropertyX READ getEditGUIOPropertyX WRITE setEditGUIOPropertyX)
    Q_PROPERTY(int EditGUIOPropertyY READ getEditGUIOPropertyY WRITE setEditGUIOPropertyY)

    Q_PROPERTY(int EditGUIOPropertyWidth READ getEditGUIOPropertyWidth WRITE setEditGUIOPropertyWidth)
    Q_PROPERTY(int EditGUIOPropertyHeight READ getEditGUIOPropertyHeight WRITE setEditGUIOPropertyHeight)

    Q_PROPERTY(QString EditPushButtonText READ getEditPushButtonText WRITE setEditPushButtonText)
    Q_PROPERTY(int EditPushButtonColor READ getEditPushButtonColor WRITE setEditPushButtonColor)
    Q_PROPERTY(int EditPushButtonThickness READ getEditPushButtonThickness WRITE setEditPushButtonThickness)
    Q_PROPERTY(int EditPushButtonBorderColor READ getEditPushButtonBorderColor WRITE setEditPushButtonBorderColor)
    Q_PROPERTY(int EditPushButtonFontColor READ getEditPushButtonFontColor WRITE setEditPushButtonFontColor)
    Q_PROPERTY(int EditPushButtonFontSize READ getEditPushButtonFontColor WRITE setEditPushButtonFontSize)
    Q_PROPERTY(bool EditPushButtonFontBold READ getEditPushButtonFontBold WRITE setEditPushButtonFontBold)
    Q_PROPERTY(bool EditPushButtonFontUnderline READ getEditPushButtonFontUnderline WRITE setEditPushButtonFontUnderline)

    Q_PROPERTY(int EditDialColor READ getEditDialColor WRITE setEditDialColor)
    Q_PROPERTY(int EditDialNeedleColor READ getEditDialNeedleColor WRITE setEditDialNeedleColor)
    Q_PROPERTY(int EditDialFontColor READ getEditDialFontColor WRITE setEditDialFontColor)
    Q_PROPERTY(int EditDialMin READ getEditDialMin WRITE setEditDialMin)
    Q_PROPERTY(int EditDialMax READ getEditDialMax WRITE setEditDialMax)
    Q_PROPERTY(int EditDialMinor READ getEditDialMinor WRITE setEditDialMinor)
    Q_PROPERTY(int EditDialMajor READ getEditDialMajor WRITE setEditDialMajor)

    Q_PROPERTY(int EditProgressBarColor READ getEditProgressBarColor WRITE setEditProgressBarColor)
    Q_PROPERTY(int EditProgressBarOrient READ getEditProgressBarOrient WRITE setEditProgressBarOrient)    
    Q_PROPERTY(int EditProgressBarMin READ getEditProgressBarMin WRITE setEditProgressBarMin)
    Q_PROPERTY(int EditProgressBarMax READ getEditProgressBarMax WRITE setEditProgressBarMax)
    Q_PROPERTY(int EditProgressBarMinor READ getEditProgressBarMinor WRITE setEditProgressBarMinor)
    Q_PROPERTY(int EditProgressBarMajor READ getEditProgressBarMajor WRITE setEditProgressBarMajor)

    Q_PROPERTY(int EditSliderBarColor READ getEditSliderBarColor WRITE setEditSliderBarColor)
    Q_PROPERTY(int EditSliderBarHandleColor READ getEditSliderBarHandleColor WRITE setEditSliderBarHandleColor)
    Q_PROPERTY(int EditSliderBarOrient READ getEditSliderBarOrient WRITE setEditSliderBarOrient)
    Q_PROPERTY(int EditSliderBarMin READ getEditSliderBarMin WRITE setEditSliderBarMin)
    Q_PROPERTY(int EditSliderBarMax READ getEditSliderBarMax WRITE setEditSliderBarMax)
    Q_PROPERTY(int EditSliderBarMinor READ getEditSliderBarMinor WRITE setEditSliderBarMinor)
    Q_PROPERTY(int EditSliderBarMajor READ getEditSliderBarMajor WRITE setEditSliderBarMajor)

    Q_PROPERTY(int EditNumPadNumberFontColor READ getEditNumPadNumberFontColor WRITE setEditNumPadNumberFontColor)
    Q_PROPERTY(int EditNumPadNumberButtonColor READ getEditNumPadNumberButtonColor WRITE setEditNumPadNumberButtonColor)
    Q_PROPERTY(int EditNumPadResetFontColor READ getEditNumPadResetFontColor WRITE setEditNumPadResetFontColor)
    Q_PROPERTY(int EditNumPadResetButtonColor READ getEditNumPadResetButtonColor WRITE setEditNumPadResetButtonColor)
    Q_PROPERTY(int EditNumPadOkFontColor READ getEditNumPadOkFontColor WRITE setEditNumPadOkFontColor)
    Q_PROPERTY(int EditNumPadOkButtonColor READ getEditNumPadOkButtonColor WRITE setEditNumPadOkButtonColor)
    Q_PROPERTY(int EditNumPadBorderColor READ getEditNumPadBorderColor WRITE setEditNumPadBorderColor)

    Q_PROPERTY(QString EditLoginPadPassword READ getEditLoginPadPassword WRITE setEditLoginPadPassword)
    Q_PROPERTY(int EditLoginPadNumberFontColor READ getEditLoginPadNumberFontColor WRITE setEditLoginPadNumberFontColor)
    Q_PROPERTY(int EditLoginPadNumberButtonColor READ getEditLoginPadNumberButtonColor WRITE setEditLoginPadNumberButtonColor)
    Q_PROPERTY(int EditLoginPadResetFontColor READ getEditLoginPadResetFontColor WRITE setEditLoginPadResetFontColor)
    Q_PROPERTY(int EditLoginPadResetButtonColor READ getEditLoginPadResetButtonColor WRITE setEditLoginPadResetButtonColor)
    Q_PROPERTY(int EditLoginPadLoginFontColor READ getEditLoginPadLoginFontColor WRITE setEditLoginPadLoginFontColor)
    Q_PROPERTY(int EditLoginPadLoginButtonColor READ getEditLoginPadLoginButtonColor WRITE setEditLoginPadLoginButtonColor)
    Q_PROPERTY(int EditLoginPadFuncFontColor READ getEditLoginPadFuncFontColor WRITE setEditLoginPadFuncFontColor)
    Q_PROPERTY(int EditLoginPadFuncButtonColor READ getEditLoginPadFuncButtonColor WRITE setEditLoginPadFuncFontColor)
    Q_PROPERTY(int EditLoginPadBorderColor READ getEditLoginPadBorderColor WRITE setEditLoginPadBorderColor)
    Q_PROPERTY(int EditLoginPadDigitNumber READ getEditLoginPadDigitNumber WRITE setEditLoginPadDigitNumber)

    Q_PROPERTY(int EditLabelColor READ getEditLabelColor WRITE setEditLabelColor)
    Q_PROPERTY(int EditLabelBorderColor READ getEditLabelBorderColor WRITE setEditLabelBorderColor)
    Q_PROPERTY(int EditLabelFontColor READ getEditLabelFontColor WRITE setEditLabelFontColor)
    Q_PROPERTY(int EditLabelFontSize READ getEditLabelFontSize WRITE setEditLabelFontSize)
    Q_PROPERTY(bool EditLabelFontBold READ getEditLabelFontBold WRITE setEditLabelFontBold)
    Q_PROPERTY(bool EditLabelFontUnderline READ getEditLabelFontUnderline WRITE setEditLabelFontUnderline)
    Q_PROPERTY(int EditLabelThickness READ getEditLabelThickness WRITE setEditLabelThickness)
    Q_PROPERTY(int EditLabelAngle READ getEditLabelAngle WRITE setEditLabelAngle)
    Q_PROPERTY(QString EditLabelText READ getEditLabelText WRITE setEditLabelText)
    Q_PROPERTY(bool EditLabelTransparent READ getEditLabelTransparent WRITE setEditLabelTransparent)

    Q_PROPERTY(int EditScrollLabelColor READ getEditScrollLabelColor WRITE setEditScrollLabelColor)
    Q_PROPERTY(int EditScrollLabelBorderColor READ getEditScrollLabelBorderColor WRITE setEditScrollLabelBorderColor)
    Q_PROPERTY(int EditScrollLabelFontColor READ getEditScrollLabelFontColor WRITE setEditScrollLabelFontColor)
    Q_PROPERTY(int EditScrollLabelFontSize READ getEditScrollLabelFontSize WRITE setEditScrollLabelFontSize)
    Q_PROPERTY(bool EditScrollLabelFontBold READ getEditScrollLabelFontBold WRITE setEditScrollLabelFontBold)
    Q_PROPERTY(bool EditScrollLabelFontUnderline READ getEditScrollLabelFontUnderline WRITE setEditScrollLabelFontUnderline)
    Q_PROPERTY(int EditScrollLabelThickness READ getEditScrollLabelThickness WRITE setEditScrollLabelThickness)
    Q_PROPERTY(QString EditScrollLabelText READ getEditScrollLabelText WRITE setEditScrollLabelText)
    Q_PROPERTY(bool EditScrollLabelTransparent READ getEditScrollLabelTransparent WRITE setEditScrollLabelTransparent)
    Q_PROPERTY(int EditScrollLabelDirection READ getEditScrollLabelDirection WRITE setEditScrollLabelDirection)
    Q_PROPERTY(int EditScrollLabelSpeed READ getEditScrollLabelSpeed WRITE setEditScrollLabelSpeed)

    Q_PROPERTY(int EditDigitalClockColor READ getEditDigitalClockColor WRITE setEditDigitalClockColor)
    Q_PROPERTY(int EditDigitalClockBorderColor READ getEditDigitalClockBorderColor WRITE setEditDigitalClockBorderColor)
    Q_PROPERTY(int EditDigitalClockFontColor READ getEditDigitalClockFontColor WRITE setEditDigitalClockFontColor)
    Q_PROPERTY(int EditDigitalClockFontBold READ getEditDigitalClockFontBold WRITE setEditDigitalClockFontBold)
    Q_PROPERTY(int EditDigitalClockFontSize READ getEditDigitalClockFontSize WRITE setEditDigitalClockFontSize)
    Q_PROPERTY(int EditDigitalClockTransparent READ getEditDigitalClockTransparent WRITE setEditDigitalClockTransparent)

    Q_PROPERTY(int EditLedColor READ getEditLedColor WRITE setEditLedColor)

    Q_PROPERTY(int EditPanelMax READ getEditPanelMax WRITE setEditPanelMax)
    Q_PROPERTY(int EditPanelMin READ getEditPanelMin WRITE setEditPanelMin)
    Q_PROPERTY(int EditPanelMajor READ getEditPanelMajor WRITE setEditPanelMajor)
    Q_PROPERTY(int EditPanelMinor READ getEditPanelMinor WRITE setEditPanelMinor)
    Q_PROPERTY(int EditPanelNeedleColor READ getEditPanelNeedleColor WRITE setEditPanelNeedleColor)
    Q_PROPERTY(int EditPanelDigitColor READ getEditPanelDigitColor WRITE setEditPanelDigitColor)
    Q_PROPERTY(int EditPanelBodyColor READ getEditPanelBodyColor WRITE setEditPanelBodyColor)

    Q_PROPERTY(QString EditImageName READ getEditImageName WRITE setEditImageName)
    Q_PROPERTY(bool EditImageGrayScale READ getEditImageGrayScale WRITE setEditImageGrayScale)

    Q_PROPERTY(QString EditRailImageName READ getEditRailImageName WRITE setEditRailImageName)
    Q_PROPERTY(bool EditRailGrayScale READ getEditRailGrayScale WRITE setEditRailGrayScale)

    Q_PROPERTY(int EditCircleFillColor READ getEditCircleFillColor WRITE setEditCircleFillColor)
    Q_PROPERTY(int EditCircleLineColor READ getEditCircleLineColor WRITE setEditCircleLineColor)
    Q_PROPERTY(int EditCircleLineThickness READ getEditCircleLineThickness WRITE setEditCircleLineThickness)

    Q_PROPERTY(int EditRectangleFillColor READ getEditRectangleFillColor WRITE setEditRectangleFillColor)
    Q_PROPERTY(int EditRectangleLineColor READ getEditRectangleLineColor WRITE setEditRectangleLineColor)
    Q_PROPERTY(int EditRectangleLineThickness READ getEditRectangleLineThickness WRITE setEditRectangleLineThickness)
public:
    HMIForm(QWidget *parent = 0):QWidget(parent)
    {
        layout = new QVBoxLayout(this);
        layout->setMargin(0);
        EditPageName = "page";
        EditPageBackgroundColor = 0xFFFFFF;
        EditPageBackgroundImageName = "";
        background = NULL;
        guioList = new QList<GUIO*>();
    }

    // Instance for selected GUIO
    GUIO *getSelectedGUIO() const;
    void setSelectedGUIO(GUIO *value);
    // Name of selected GUIO
    QString getSelectedGUIOName() const;
    void setSelectedGUIOName(const QString &value);

    QString getGUIOName() const;
    void setGUIOName(const QString &value);

    QString getGUIOType() const;
    void setGUIOType(const QString &value);

    int getGUIOLayer() const;
    void setGUIOLayer(const int &value);

    bool getMakeGUIOCommand() const;
    void setMakeGUIOCommand(bool value);
    bool getRemoveGUIOCommand() const;
    void setRemoveGUIOCommand(bool value);

    QString getEditPageBackgroundImageName() const;
    void setEditPageBackgroundImageName(const QString &value);
    int getEditPageBackgroundColor() const;
    void setEditPageBackgroundColor(int value);
    QString getEditPageName() const;
    void setEditPageName(const QString &value);

    QString getEditGUIOPropertyName() const;
    void setEditGUIOPropertyName(const QString &value);
    int getEditGUIOPropertyLayer() const;
    void setEditGUIOPropertyLayer(int value);

    int getEditGUIOPropertyX() const;
    void setEditGUIOPropertyX(int value);
    int getEditGUIOPropertyY() const;
    void setEditGUIOPropertyY(int value);

    int getEditGUIOPropertyWidth() const;
    void setEditGUIOPropertyWidth(int value);
    int getEditGUIOPropertyHeight() const;
    void setEditGUIOPropertyHeight(int value);

    QString getEditPushButtonText() const;
    void setEditPushButtonText(const QString &value);
    int getEditPushButtonColor() const;
    void setEditPushButtonColor(int value);
    void setEditPushButtonThickness(int value);
    int getEditPushButtonThickness() const;
    void setEditPushButtonBorderColor(int value);
    int getEditPushButtonBorderColor() const;
    void setEditPushButtonFontColor(int value);
    int getEditPushButtonFontColor() const;
    void setEditPushButtonFontSize(int value);
    int getEditPushButtonFontSize() const;
    void setEditPushButtonFontBold(bool value);
    bool getEditPushButtonFontBold() const;
    void setEditPushButtonFontUnderline(bool value);
    bool getEditPushButtonFontUnderline() const;

    int getEditDialColor() const;
    void setEditDialColor(int value);
    int getEditDialFontColor() const;
    void setEditDialFontColor(int value);
    int getEditDialNeedleColor() const;
    void setEditDialNeedleColor(int value);
    int getEditDialMin() const;
    void setEditDialMin(int value);
    int getEditDialMax() const;
    void setEditDialMax(int value);
    int getEditDialMinor() const;
    void setEditDialMinor(int value);
    int getEditDialMajor() const;
    void setEditDialMajor(int value);

    int getEditProgressBarColor() const;
    void setEditProgressBarColor(int value);
    int getEditProgressBarOrient() const;
    void setEditProgressBarOrient(int value);
    int getEditProgressBarMin() const;
    void setEditProgressBarMin(int value);
    int getEditProgressBarMax() const;
    void setEditProgressBarMax(int value);
    int getEditProgressBarMinor() const;
    void setEditProgressBarMinor(int value);
    int getEditProgressBarMajor() const;
    void setEditProgressBarMajor(int value);

    int getEditSliderBarColor() const;
    void setEditSliderBarColor(int value);
    int getEditSliderBarHandleColor() const;
    void setEditSliderBarHandleColor(int value);
    int getEditSliderBarOrient() const;
    void setEditSliderBarOrient(int value);
    int getEditSliderBarMin() const;
    void setEditSliderBarMin(int value);
    int getEditSliderBarMax() const;
    void setEditSliderBarMax(int value);
    int getEditSliderBarMinor() const;
    void setEditSliderBarMinor(int value);
    int getEditSliderBarMajor() const;
    void setEditSliderBarMajor(int value);

    int getEditNumPadNumberFontColor() const;
    void setEditNumPadNumberFontColor(int value);
    int getEditNumPadNumberButtonColor() const;
    void setEditNumPadNumberButtonColor(int value);
    int getEditNumPadResetFontColor() const;
    void setEditNumPadResetFontColor(int value);
    int getEditNumPadResetButtonColor() const;
    void setEditNumPadResetButtonColor(int value);
    int getEditNumPadOkFontColor() const;
    void setEditNumPadOkFontColor(int value);
    int getEditNumPadOkButtonColor() const;
    void setEditNumPadOkButtonColor(int value);
    int getEditNumPadBorderColor() const;
    void setEditNumPadBorderColor(int value);

    QString getEditLoginPadPassword() const;
    void setEditLoginPadPassword(const QString &value);
    int getEditLoginPadNumberFontColor() const;
    void setEditLoginPadNumberFontColor(int value);
    int getEditLoginPadNumberButtonColor() const;
    void setEditLoginPadNumberButtonColor(int value);
    int getEditLoginPadResetFontColor() const;
    void setEditLoginPadResetFontColor(int value);
    int getEditLoginPadResetButtonColor() const;
    void setEditLoginPadResetButtonColor(int value);
    int getEditLoginPadLoginFontColor() const;
    void setEditLoginPadLoginFontColor(int value);
    int getEditLoginPadLoginButtonColor() const;
    void setEditLoginPadLoginButtonColor(int value);
    int getEditLoginPadFuncFontColor() const;
    void setEditLoginPadFuncFontColor(int value);
    int getEditLoginPadFuncButtonColor() const;
    void setEditLoginPadFuncButtonColor(int value);
    int getEditLoginPadBorderColor() const;
    void setEditLoginPadBorderColor(int value);
    int getEditLoginPadDigitNumber() const;
    void setEditLoginPadDigitNumber(int value);

    int getEditLabelColor() const;
    void setEditLabelColor(int value);
    int getEditLabelBorderColor() const;
    void setEditLabelBorderColor(int value);
    int getEditLabelFontColor() const;
    void setEditLabelFontColor(int value);
    int getEditLabelFontSize() const;
    void setEditLabelFontSize(int value);
    bool getEditLabelFontBold() const;
    void setEditLabelFontBold(bool value);
    bool getEditLabelFontUnderline() const;
    void setEditLabelFontUnderline(bool value);
    int getEditLabelThickness() const;
    void setEditLabelThickness(int value);
    int getEditLabelAngle() const;
    void setEditLabelAngle(int value);
    QString getEditLabelText() const;
    void setEditLabelText(const QString &value);
    bool getEditLabelTransparent() const;
    void setEditLabelTransparent(bool value);

    int getEditDigitalClockColor() const;
    void setEditDigitalClockColor(int value);
    int getEditDigitalClockBorderColor() const;
    void setEditDigitalClockBorderColor(int value);
    int getEditDigitalClockFontColor() const;
    void setEditDigitalClockFontColor(int value);
    bool getEditDigitalClockFontBold() const;
    void setEditDigitalClockFontBold(bool value);
    int getEditDigitalClockFontSize() const;
    void setEditDigitalClockFontSize(int value);
    int getEditDigitalClockTransparent() const;
    void setEditDigitalClockTransparent(int value);

    int getEditScrollLabelColor() const;
    void setEditScrollLabelColor(int value);
    int getEditScrollLabelThickness() const;
    void setEditScrollLabelThickness(int value);
    int getEditScrollLabelBorderColor() const;
    void setEditScrollLabelBorderColor(int value);
    int getEditScrollLabelTransparent() const;
    void setEditScrollLabelTransparent(int value);
    int getEditScrollLabelFontColor() const;
    void setEditScrollLabelFontColor(int value);
    int getEditScrollLabelFontSize() const;
    void setEditScrollLabelFontSize(int value);
    int getEditScrollLabelFontBold() const;
    void setEditScrollLabelFontBold(int value);
    int getEditScrollLabelFontUnderline() const;
    void setEditScrollLabelFontUnderline(int value);
    int getEditScrollLabelDirection() const;
    void setEditScrollLabelDirection(int value);
    int getEditScrollLabelSpeed() const;
    void setEditScrollLabelSpeed(int value);
    QString getEditScrollLabelText() const;
    void setEditScrollLabelText(const QString &value);

    int getEditLedColor() const;
    void setEditLedColor(int value);

    int getEditPanelMax() const;
    void setEditPanelMax(int value);
    int getEditPanelMin() const;
    void setEditPanelMin(int value);
    int getEditPanelMajor() const;
    void setEditPanelMajor(int value);
    int getEditPanelMinor() const;
    void setEditPanelMinor(int value);
    int getEditPanelNeedleColor() const;
    void setEditPanelNeedleColor(int value);
    int getEditPanelDigitColor() const;
    void setEditPanelDigitColor(int value);
    int getEditPanelBodyColor() const;
    void setEditPanelBodyColor(int value);

    QString getEditImageName() const;
    void setEditImageName(const QString &value);
    bool getEditImageGrayScale() const;
    void setEditImageGrayScale(bool value);

    QString getEditRailImageName() const;
    void setEditRailImageName(const QString &value);
    bool getEditRailGrayScale() const;
    void setEditRailGrayScale(bool value);

    int getEditCircleFillColor() const;
    void setEditCircleFillColor(int value);
    int getEditCircleLineColor() const;
    void setEditCircleLineColor(int value);
    int getEditCircleLineThickness() const;
    void setEditCircleLineThickness(int value);

    int getEditRectangleFillColor() const;
    void setEditRectangleFillColor(int value);
    int getEditRectangleLineColor() const;
    void setEditRectangleLineColor(int value);
    int getEditRectangleLineThickness() const;
    void setEditRectangleLineThickness(int value);

private:
    QVBoxLayout* layout;
    QWidget* background;
    QList<GUIO*>* guioList;

    GUIO* selectedGUIO;
    QString selectedGUIOName;

    QString GUIOName;
    QString GUIOType;
    int GUIOLayer;
    bool MakeGUIOCommand;
    bool RemoveGUIOCommand;

    QString EditPageName;
    int EditPageBackgroundColor;
    QString EditPageBackgroundImageName;

    QString EditGUIOPropertyName;
    int EditGUIOPropertyLayer;

    int EditGUIOPropertyX;
    int EditGUIOPropertyY;

    int EditGUIOPropertyWidth;
    int EditGUIOPropertyHeight;

    QString EditPushButtonText;
    int EditPushButtonColor;
    int EditPushButtonThickness;
    int EditPushButtonBorderColor;
    int EditPushButtonFontColor;
    int EditPushButtonFontSize;
    bool EditPushButtonFontBold;
    bool EditPushButtonFontUnderline;

    int EditDialColor;
    int EditDialFontColor;
    int EditDialNeedleColor;
    int EditDialMin;
    int EditDialMax;
    int EditDialMinor;
    int EditDialMajor;

    int EditProgressBarColor;
    int EditProgressBarOrient;
    int EditProgressBarMin;
    int EditProgressBarMax;
    int EditProgressBarMinor;
    int EditProgressBarMajor;

    int EditSliderBarColor;
    int EditSliderBarHandleColor;
    int EditSliderBarOrient;
    int EditSliderBarMin;
    int EditSliderBarMax;
    int EditSliderBarMinor;
    int EditSliderBarMajor;

    int EditNumPadNumberFontColor;
    int EditNumPadNumberButtonColor;
    int EditNumPadResetFontColor;
    int EditNumPadResetButtonColor;
    int EditNumPadOkFontColor;
    int EditNumPadOkButtonColor;
    int EditNumPadBorderColor;

    QString EditLoginPadPassword;
    int EditLoginPadNumberFontColor;
    int EditLoginPadNumberButtonColor;
    int EditLoginPadResetFontColor;
    int EditLoginPadResetButtonColor;
    int EditLoginPadLoginFontColor;
    int EditLoginPadLoginButtonColor;
    int EditLoginPadFuncFontColor;
    int EditLoginPadFuncButtonColor;
    int EditLoginPadBorderColor;
    int EditLoginPadDigitNumber;

    int EditLabelColor;
    int EditLabelBorderColor;
    int EditLabelFontColor;
    int EditLabelFontSize;
    bool EditLabelFontBold;
    bool EditLabelFontUnderline;
    int EditLabelThickness;
    int EditLabelAngle;
    QString EditLabelText;
    bool EditLabelTransparent;

    int EditDigitalClockColor;
    int EditDigitalClockBorderColor;
    int EditDigitalClockFontColor;
    bool EditDigitalClockFontBold;
    int EditDigitalClockFontSize;
    int EditDigitalClockTransparent;

    int EditScrollLabelColor;
    int EditScrollLabelThickness;
    int EditScrollLabelBorderColor;
    bool EditScrollLabelTransparent;
    int EditScrollLabelFontColor;
    int EditScrollLabelFontSize;
    bool EditScrollLabelFontBold;
    bool EditScrollLabelFontUnderline;
    int EditScrollLabelDirection;
    int EditScrollLabelSpeed;
    QString EditScrollLabelText;

    int EditLedColor;

    int EditPanelMax;
    int EditPanelMin;
    int EditPanelMajor;
    int EditPanelMinor;
    int EditPanelNeedleColor;
    int EditPanelDigitColor;
    int EditPanelBodyColor;

    QString EditImageName;
    bool EditImageGrayScale;

    QString EditRailImageName;
    bool EditRailGrayScale;

    int EditCircleFillColor;
    int EditCircleLineColor;
    int EditCircleLineThickness;

    int EditRectangleFillColor;
    int EditRectangleLineColor;
    int EditRectangleLineThickness;

    void removeBackground();
    void makeBackground();
    void makeGUIO(QWidget* widget);
};

#endif // HMIFORM_H
