#include "hmiform.h"

GUIO *HMIForm::getSelectedGUIO() const
{
    return selectedGUIO;
}
void HMIForm::setSelectedGUIO(GUIO *value)
{
    selectedGUIO = value;
}

QString HMIForm::getSelectedGUIOName() const
{
    return selectedGUIOName;
}
void HMIForm::setSelectedGUIOName(const QString &value)
{
    QListIterator<GUIO*> iterator(*guioList);
    while(iterator.hasNext()){
        GUIO *guio = iterator.next();
        if(guio->getName() == value){
            this->setSelectedGUIO(guio);
            selectedGUIOName = value;
            return;
        }
    }
    this->setSelectedGUIO(NULL);
    selectedGUIOName =  "NULL";
}

QString HMIForm::getGUIOName() const
{
    return GUIOName;
}
void HMIForm::setGUIOName(const QString &value)
{
    setSelectedGUIOName("NULL");
    GUIOName = value;
}

QString HMIForm::getGUIOType() const
{
    return GUIOType;
}
void HMIForm::setGUIOType(const QString &value)
{
    GUIOType = value;
}

int HMIForm::getGUIOLayer() const
{
    return GUIOLayer;
}
void HMIForm::setGUIOLayer(const int &value)
{
    GUIOLayer = value;
}

bool HMIForm::getMakeGUIOCommand() const
{
    return MakeGUIOCommand;
}
void HMIForm::setMakeGUIOCommand(bool value)
{
    MakeGUIOCommand = value;
    if(GUIOType == "PushButton")
        makeGUIO(new GPushButton());
    else if(GUIOType == "Dial")
        makeGUIO(new GDial());
    else if(GUIOType == "ProgressBar")
        makeGUIO(new GProgressBar());
    else if(GUIOType == "SliderBar")
        makeGUIO(new GSliderbar());
    else if(GUIOType == "NumPad")
        makeGUIO(new GNumpad());
    else if(GUIOType == "LoginPad")
        makeGUIO(new GLoginpad());
    else if(GUIOType == "Label")
        makeGUIO(new GLabel());
    else if(GUIOType == "ScrollLabel")
        makeGUIO(new GScrollLabel());
    else if(GUIOType == "DigitalClock")
        makeGUIO(new GDigitalClock());
    else if(GUIOType == "Led")
        makeGUIO(new GLed());
    else if(GUIOType == "Panel")
        makeGUIO(new GPanel());
    else if(GUIOType == "IncDecButton")
        makeGUIO(new GIncDecButton());
    else if(GUIOType == "SetResetButton")
        makeGUIO(new GSetResetButton());
    else if(GUIOType == "Image")
        makeGUIO(new GImage());
    else if(GUIOType == "Rail")
        makeGUIO(new GRail());
    else if(GUIOType == "Circle")
        makeGUIO(new GDrawing(0, GDrawing::Ellipse));
    else if(GUIOType == "Rectangle")
        makeGUIO(new GDrawing(0, GDrawing::Rect));
    else if(GUIOType == "IPCamera")
        makeGUIO(new GIPCamera(0));
    else if(GUIOType == "WebView")
        makeGUIO(new GWebView(0));
}

bool HMIForm::getRemoveGUIOCommand() const
{
    return RemoveGUIOCommand;
}
void HMIForm::setRemoveGUIOCommand(bool value)
{
    RemoveGUIOCommand = value;
    if(selectedGUIO != NULL){
        removeBackground();
        guioList->removeOne(selectedGUIO);
        delete selectedGUIO;
        selectedGUIO = NULL;
        makeBackground();
    }
}

QString HMIForm::getEditPageBackgroundImageName() const
{
    return EditPageBackgroundImageName;
}
void HMIForm::setEditPageBackgroundImageName(const QString &value)
{
    EditPageBackgroundImageName = value;
    removeBackground();
    makeBackground();
}

int HMIForm::getEditPageBackgroundColor() const
{
    return EditPageBackgroundColor;
}
void HMIForm::setEditPageBackgroundColor(int value)
{
    EditPageBackgroundColor = value;
    removeBackground();
    makeBackground();
}

QString HMIForm::getEditPageName() const
{
    return EditPageName;
}
void HMIForm::setEditPageName(const QString &value)
{
    EditPageName = value;
    removeBackground();
    makeBackground();
}

void HMIForm::removeBackground()
{
    if(background != NULL){
        layout->removeWidget(background);
        QListIterator<GUIO*> iterator(*guioList);
        while(iterator.hasNext()){
            GUIO* guio = iterator.next();
            QWidget* widget = guio->getGuio();
            widget->setParent(0);
        }
        delete background;
        background = NULL;
    }
}

void HMIForm::makeBackground()
{
    if(background == NULL){
        background = new QWidget(this);
        background->setObjectName(EditPageName);
        QColor backgroundColor(EditPageBackgroundColor);
        QPalette pal(palette());
        pal.setColor(QPalette::Background, backgroundColor);
        background->setAutoFillBackground(true);
        background->setPalette(pal);

        background->setStyleSheet("QWidget#"+EditPageName+"{border-image: url("+ EditPageBackgroundImageName +");}");
        background->setGeometry(0, 0, this->width(), this->height());
        background->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);


        QListIterator<GUIO*> iterator(*guioList);
        while(iterator.hasNext()){
            GUIO* guio = iterator.next();
            QWidget* widget = guio->getGuio();
            widget->setParent(background);
        }

        layout->addWidget(background);
    }
}

bool layerLessThan(const GUIO* guio1, const GUIO* guio2)
{
    return guio1->getLayer() > guio2->getLayer();
}

void HMIForm::makeGUIO(QWidget* widget)
{
    removeBackground();
    GUIO* guio = new GUIO(GUIOName,GUIOType,widget,GUIOLayer);
    guioList->append(guio);
    qSort(guioList->begin(), guioList->end(), layerLessThan);
    setSelectedGUIOName(GUIOName);
    makeBackground();
    MakeGUIOCommand = true;
}


QString HMIForm::getEditGUIOPropertyName() const
{
        return EditGUIOPropertyName;
}
void HMIForm::setEditGUIOPropertyName(const QString &value)
{
    EditGUIOPropertyName = value;
    if(selectedGUIO != NULL){
        selectedGUIO->setName(value);
    }
}

int HMIForm::getEditGUIOPropertyLayer() const
{
        return EditGUIOPropertyLayer;
}

void HMIForm::setEditGUIOPropertyLayer(int value)
{
    EditGUIOPropertyLayer = value;
    if(selectedGUIO != NULL){
        selectedGUIO->setLayer(value);
        qSort(guioList->begin(), guioList->end(), layerLessThan);
    }
    removeBackground();
    makeBackground();
}

int HMIForm::getEditGUIOPropertyX() const
{
    return EditGUIOPropertyX;
}
void HMIForm::setEditGUIOPropertyX(int value)
{
    EditGUIOPropertyX = value;
    if(selectedGUIO != NULL){
        QWidget* guio = (selectedGUIO->getGuio());
        guio->setGeometry(value, guio->y(), guio->width(), guio->height());
    }
}

int HMIForm::getEditGUIOPropertyY() const
{
    return EditGUIOPropertyY;
}
void HMIForm::setEditGUIOPropertyY(int value)
{
    EditGUIOPropertyY = value;
    if(selectedGUIO != NULL){
        QWidget* guio = (selectedGUIO->getGuio());
        guio->setGeometry(guio->x(), value, guio->width(), guio->height());
    }
}

int HMIForm::getEditGUIOPropertyWidth() const
{
    return EditGUIOPropertyWidth;
}
void HMIForm::setEditGUIOPropertyWidth(int value)
{
    EditGUIOPropertyWidth = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Image")
        {
            GImage* guio = (GImage*)(selectedGUIO->getGuio());
            guio->setGeometry(guio->x(), guio->y(), value, guio->height());
        }
        else if(selectedGUIO->getType() == "Rail")
        {
            GRail* guio = (GRail*)(selectedGUIO->getGuio());
            guio->setGeometry(guio->x(), guio->y(), value, guio->height());
        }
        else if(selectedGUIO->getType() == "Circle" || selectedGUIO->getType() == "Rectangle")
        {
            GDrawing* guio = (GDrawing*)(selectedGUIO->getGuio());
            guio->setGeometry(guio->x(), guio->y(), value, guio->height());
        }
        else
        {
            QWidget* guio = (selectedGUIO->getGuio());
            guio->setGeometry(guio->x(), guio->y(), value, guio->height());
        }
    }
}

int HMIForm::getEditGUIOPropertyHeight() const
{
    return EditGUIOPropertyHeight;
}
void HMIForm::setEditGUIOPropertyHeight(int value)
{
    EditGUIOPropertyHeight = value;
    if(selectedGUIO != NULL){
            if(selectedGUIO->getType() == "Image")
            {
                GImage* guio = (GImage*)(selectedGUIO->getGuio());
                guio->setGeometry(guio->x(), guio->y(), guio->width(), value);
            }
            else if(selectedGUIO->getType() == "Rail")
            {
                GRail* guio = (GRail*)(selectedGUIO->getGuio());
                guio->setGeometry(guio->x(), guio->y(), guio->width(), value);
            }
            else if(selectedGUIO->getType() == "Circle" || selectedGUIO->getType() == "Rectangle")
            {
                GDrawing* guio = (GDrawing*)(selectedGUIO->getGuio());
                guio->setGeometry(guio->x(), guio->y(), guio->width(), value);
            }
            else
            {
                QWidget* guio = (selectedGUIO->getGuio());
                guio->setGeometry(guio->x(), guio->y(), guio->width(), value);
            }
    }
}


QString HMIForm::getEditPushButtonText() const
{
    return EditPushButtonText;
}
void HMIForm::setEditPushButtonText(const QString &value)
{
    EditPushButtonText = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "PushButton"){
            GPushButton* selectedButton = (GPushButton*)(selectedGUIO->getGuio());
            selectedButton->setButtonText(value);
        }
    }
}

int HMIForm::getEditPushButtonColor() const
{
    return EditPushButtonColor;
}
void HMIForm::setEditPushButtonColor(int value)
{
    EditPushButtonColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "PushButton"){
            GPushButton* selectedButton = (GPushButton*)(selectedGUIO->getGuio());
            selectedButton->setButtonColor(value);
        }
    }
}

int HMIForm::getEditPushButtonThickness() const
{
    return EditPushButtonThickness;
}
void HMIForm::setEditPushButtonThickness(int value)
{
    EditPushButtonThickness = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "PushButton"){
            GPushButton* selectedButton = (GPushButton*)(selectedGUIO->getGuio());
            selectedButton->setBorderThickness(value);
        }
    }
}

int HMIForm::getEditPushButtonBorderColor() const
{
    return EditPushButtonBorderColor;
}
void HMIForm::setEditPushButtonBorderColor(int value)
{
    EditPushButtonBorderColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "PushButton"){
            GPushButton* selectedButton = (GPushButton*)(selectedGUIO->getGuio());
            selectedButton->setBorderColor(value);
        }
    }
}

int HMIForm::getEditPushButtonFontColor() const
{
    return EditPushButtonFontColor;
}
void HMIForm::setEditPushButtonFontColor(int value)
{
    EditPushButtonFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "PushButton"){
            GPushButton* selectedButton = (GPushButton*)(selectedGUIO->getGuio());
            selectedButton->setFontColor(value);
        }
    }
}

int HMIForm::getEditPushButtonFontSize() const
{
    return EditPushButtonFontSize;
}
void HMIForm::setEditPushButtonFontSize(int value)
{
    EditPushButtonFontSize = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "PushButton"){
            GPushButton* selectedButton = (GPushButton*)(selectedGUIO->getGuio());
            selectedButton->setFontSize(value);
        }
    }
}

bool HMIForm::getEditPushButtonFontBold() const
{
    return EditPushButtonFontBold;
}
void HMIForm::setEditPushButtonFontBold(bool value)
{
    EditPushButtonFontBold = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "PushButton"){
            GPushButton* selectedButton = (GPushButton*)(selectedGUIO->getGuio());
            selectedButton->setFontBold(value);
        }
    }
}

bool HMIForm::getEditPushButtonFontUnderline() const
{
    return EditPushButtonFontUnderline;
}
void HMIForm::setEditPushButtonFontUnderline(bool value)
{
    EditPushButtonFontUnderline = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "PushButton"){
            GPushButton* selectedButton = (GPushButton*)(selectedGUIO->getGuio());
            selectedButton->setFontUnderline(value);
        }
    }
}

int HMIForm::getEditDialColor() const
{
    return EditDialColor;
}
void HMIForm::setEditDialColor(int value)
{
    EditDialColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Dial"){
            GDial* selectedDial = (GDial*)(selectedGUIO->getGuio());
            selectedDial->setDialColor(value);
        }
    }
}

int HMIForm::getEditDialFontColor() const
{
    return EditDialFontColor;
}
void HMIForm::setEditDialFontColor(int value)
{
    EditDialFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Dial"){
            GDial* selectedDial = (GDial*)(selectedGUIO->getGuio());
            selectedDial->setFontColor(value);
        }
    }
}

int HMIForm::getEditDialNeedleColor() const
{
    return EditDialNeedleColor;
}
void HMIForm::setEditDialNeedleColor(int value)
{
    EditDialNeedleColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Dial"){
            GDial* selectedDial = (GDial*)(selectedGUIO->getGuio());
            selectedDial->setNeedleColor(value);
        }
    }
}

int HMIForm::getEditDialMin() const
{
    return EditDialMin;
}
void HMIForm::setEditDialMin(int value)
{
    EditDialMin = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Dial"){
            GDial* selectedDial = (GDial*)(selectedGUIO->getGuio());
            selectedDial->setMin(value);
        }
    }
}

int HMIForm::getEditDialMax() const
{
    return EditDialMax;
}
void HMIForm::setEditDialMax(int value)
{
    EditDialMax = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Dial"){
            GDial* selectedDial = (GDial*)(selectedGUIO->getGuio());
            selectedDial->setMax(value);
        }
    }
}

int HMIForm::getEditDialMinor() const
{
    return EditDialMinor;
}
void HMIForm::setEditDialMinor(int value)
{
    EditDialMinor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Dial"){
            GDial* selectedDial = (GDial*)(selectedGUIO->getGuio());
            selectedDial->setMinor(value);
        }
    }
}

int HMIForm::getEditDialMajor() const
{
    return EditDialMajor;
}
void HMIForm::setEditDialMajor(int value)
{
    EditDialMajor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Dial"){
            GDial* selectedDial = (GDial*)(selectedGUIO->getGuio());
            selectedDial->setMajor(value);
        }
    }
}

int HMIForm::getEditProgressBarColor() const
{
    return EditProgressBarColor;
}
void HMIForm::setEditProgressBarColor(int value)
{
    EditProgressBarColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ProgressBar"){
            GProgressBar* selectedBar = (GProgressBar*)(selectedGUIO->getGuio());
            selectedBar->setProgressColor(value);
        }
    }
}

int HMIForm::getEditProgressBarOrient() const
{
    return EditProgressBarOrient;
}
void HMIForm::setEditProgressBarOrient(int value)
{
    EditProgressBarOrient = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ProgressBar"){
            GProgressBar* selectedBar = (GProgressBar*)(selectedGUIO->getGuio());
            selectedBar->setDirection(value);
        }
    }
}

int HMIForm::getEditProgressBarMin() const
{
    return EditProgressBarMin;
}
void HMIForm::setEditProgressBarMin(int value)
{
    EditProgressBarMin = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ProgressBar"){
            GProgressBar* selectedBar = (GProgressBar*)(selectedGUIO->getGuio());
            selectedBar->setMin(value);
        }
    }
}

int HMIForm::getEditProgressBarMax() const
{
    return EditProgressBarMax;
}
void HMIForm::setEditProgressBarMax(int value)
{
    EditProgressBarMax = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ProgressBar"){
            GProgressBar* selectedBar = (GProgressBar*)(selectedGUIO->getGuio());
            selectedBar->setMax(value);
        }
    }
}

int HMIForm::getEditProgressBarMinor() const
{
    return EditProgressBarMinor;
}
void HMIForm::setEditProgressBarMinor(int value)
{
    EditProgressBarMinor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ProgressBar"){
            GProgressBar* selectedBar = (GProgressBar*)(selectedGUIO->getGuio());
            selectedBar->setMaxminor(value);
        }
    }
}

int HMIForm::getEditProgressBarMajor() const
{
    return EditProgressBarMajor;
}
void HMIForm::setEditProgressBarMajor(int value)
{
    EditProgressBarMajor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ProgressBar"){
            GProgressBar* selectedBar = (GProgressBar*)(selectedGUIO->getGuio());
            selectedBar->setMaxmajor(value);
        }
    }
}

int HMIForm::getEditSliderBarColor() const
{
    return EditSliderBarColor;
}
void HMIForm::setEditSliderBarColor(int value)
{
    EditSliderBarColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "SliderBar"){
            GSliderbar* selectedBar = (GSliderbar*)(selectedGUIO->getGuio());
            selectedBar->setSliderColor(value);
        }
    }
}

int HMIForm::getEditSliderBarHandleColor() const
{
    return EditSliderBarHandleColor;
}
void HMIForm::setEditSliderBarHandleColor(int value)
{
    EditSliderBarHandleColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "SliderBar"){
            GSliderbar* selectedBar = (GSliderbar*)(selectedGUIO->getGuio());
            selectedBar->setHandleColor(value);
        }
    }
}

int HMIForm::getEditSliderBarOrient() const
{
    return EditSliderBarOrient;
}
void HMIForm::setEditSliderBarOrient(int value)
{
    EditSliderBarOrient = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "SliderBar"){
            GSliderbar* selectedBar = (GSliderbar*)(selectedGUIO->getGuio());
            selectedBar->setOrient(value);
        }
    }
}

int HMIForm::getEditSliderBarMin() const
{
    return EditSliderBarMin;
}
void HMIForm::setEditSliderBarMin(int value)
{
    EditSliderBarMin = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "SliderBar"){
            GSliderbar* selectedBar = (GSliderbar*)(selectedGUIO->getGuio());
            selectedBar->setMin(value);
        }
    }
}

int HMIForm::getEditSliderBarMax() const
{
    return EditSliderBarMax;
}
void HMIForm::setEditSliderBarMax(int value)
{
    EditSliderBarMax = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "SliderBar"){
            GSliderbar* selectedBar = (GSliderbar*)(selectedGUIO->getGuio());
            selectedBar->setMax(value);
        }
    }
}

int HMIForm::getEditSliderBarMinor() const
{
    return EditSliderBarMinor;
}
void HMIForm::setEditSliderBarMinor(int value)
{
    EditSliderBarMinor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "SliderBar"){
            GSliderbar* selectedBar = (GSliderbar*)(selectedGUIO->getGuio());
            selectedBar->setMinor(value);
        }
    }
}

int HMIForm::getEditSliderBarMajor() const
{
    return EditSliderBarMajor;
}
void HMIForm::setEditSliderBarMajor(int value)
{
    EditSliderBarMajor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "SliderBar"){
            GSliderbar* selectedBar = (GSliderbar*)(selectedGUIO->getGuio());
            selectedBar->setMajor(value);
        }
    }
}

int HMIForm::getEditNumPadNumberFontColor() const
{
    return EditNumPadNumberFontColor;
}
void HMIForm::setEditNumPadNumberFontColor(int value)
{
    EditNumPadNumberFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "NumPad"){
            GNumpad* selectedPad = (GNumpad*)(selectedGUIO->getGuio());
            selectedPad->setNumColor(value);
        }
    }
}

int HMIForm::getEditNumPadNumberButtonColor() const
{
    return EditNumPadNumberButtonColor;
}
void HMIForm::setEditNumPadNumberButtonColor(int value)
{
    EditNumPadNumberButtonColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "NumPad"){
            GNumpad* selectedPad = (GNumpad*)(selectedGUIO->getGuio());
            selectedPad->setNumButtonColor(value);
        }
    }
}

int HMIForm::getEditNumPadResetFontColor() const
{
    return EditNumPadResetFontColor;
}
void HMIForm::setEditNumPadResetFontColor(int value)
{
    EditNumPadResetFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "NumPad"){
            GNumpad* selectedPad = (GNumpad*)(selectedGUIO->getGuio());
            selectedPad->setResetColor(value);
        }
    }
}

int HMIForm::getEditNumPadResetButtonColor() const
{
    return EditNumPadResetButtonColor;
}
void HMIForm::setEditNumPadResetButtonColor(int value)
{
    EditNumPadResetButtonColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "NumPad"){
            GNumpad* selectedPad = (GNumpad*)(selectedGUIO->getGuio());
            selectedPad->setResetButtonColor(value);
        }
    }
}

int HMIForm::getEditNumPadOkFontColor() const
{
    return EditNumPadOkFontColor;
}
void HMIForm::setEditNumPadOkFontColor(int value)
{
    EditNumPadOkFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "NumPad"){
            GNumpad* selectedPad = (GNumpad*)(selectedGUIO->getGuio());
            selectedPad->setOkColor(value);
        }
    }
}

int HMIForm::getEditNumPadOkButtonColor() const
{
    return EditNumPadOkButtonColor;
}
void HMIForm::setEditNumPadOkButtonColor(int value)
{
    EditNumPadOkButtonColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "NumPad"){
            GNumpad* selectedPad = (GNumpad*)(selectedGUIO->getGuio());
            selectedPad->setOkButtonColor(value);
        }
    }
}

int HMIForm::getEditNumPadBorderColor() const
{
    return EditNumPadBorderColor;
}
void HMIForm::setEditNumPadBorderColor(int value)
{
    EditNumPadBorderColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "NumPad"){
            GNumpad* selectedPad = (GNumpad*)(selectedGUIO->getGuio());
            selectedPad->setBorderColor(value);
        }
    }
}

QString HMIForm::getEditLoginPadPassword() const
{
    return EditLoginPadPassword;
}
void HMIForm::setEditLoginPadPassword(const QString &value)
{
    EditLoginPadPassword = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "LoginPad"){
            GLoginpad* selectedPad = (GLoginpad*)(selectedGUIO->getGuio());
            selectedPad->setPassword(value);
        }
    }
}

int HMIForm::getEditLoginPadNumberFontColor() const
{
    return EditLoginPadNumberFontColor;
}
void HMIForm::setEditLoginPadNumberFontColor(int value)
{
    EditLoginPadNumberFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "LoginPad"){
            GLoginpad* selectedPad = (GLoginpad*)(selectedGUIO->getGuio());
            selectedPad->setNumColor(value);
        }
    }
}

int HMIForm::getEditLoginPadNumberButtonColor() const
{
    return EditLoginPadNumberButtonColor;
}
void HMIForm::setEditLoginPadNumberButtonColor(int value)
{
    EditLoginPadNumberButtonColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "LoginPad"){
            GLoginpad* selectedPad = (GLoginpad*)(selectedGUIO->getGuio());
            selectedPad->setNumberButtonColor(value);
        }
    }
}

int HMIForm::getEditLoginPadResetFontColor() const
{
    return EditLoginPadResetFontColor;
}
void HMIForm::setEditLoginPadResetFontColor(int value)
{
    EditLoginPadResetFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "LoginPad"){
            GLoginpad* selectedPad = (GLoginpad*)(selectedGUIO->getGuio());
            selectedPad->setResetColor(value);
        }
    }
}

int HMIForm::getEditLoginPadResetButtonColor() const
{
    return EditLoginPadResetButtonColor;
}
void HMIForm::setEditLoginPadResetButtonColor(int value)
{
    EditLoginPadResetButtonColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "LoginPad"){
            GLoginpad* selectedPad = (GLoginpad*)(selectedGUIO->getGuio());
            selectedPad->setResetButtonColor(value);
        }
    }
}

int HMIForm::getEditLoginPadLoginFontColor() const
{
    return EditLoginPadLoginFontColor;
}
void HMIForm::setEditLoginPadLoginFontColor(int value)
{
    EditLoginPadLoginFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "LoginPad"){
            GLoginpad* selectedPad = (GLoginpad*)(selectedGUIO->getGuio());
            selectedPad->setLoginColor(value);
        }
    }
}

int HMIForm::getEditLoginPadLoginButtonColor() const
{
    return EditLoginPadLoginButtonColor;
}
void HMIForm::setEditLoginPadLoginButtonColor(int value)
{
    EditLoginPadLoginButtonColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "LoginPad"){
            GLoginpad* selectedPad = (GLoginpad*)(selectedGUIO->getGuio());
            selectedPad->setLoginButtonColor(value);
        }
    }
}

int HMIForm::getEditLoginPadFuncFontColor() const
{
    return EditLoginPadFuncFontColor;
}
void HMIForm::setEditLoginPadFuncFontColor(int value)
{
    EditLoginPadFuncFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "LoginPad"){
            GLoginpad* selectedPad = (GLoginpad*)(selectedGUIO->getGuio());
            selectedPad->setFuncColor(value);
        }
    }
}

int HMIForm::getEditLoginPadFuncButtonColor() const
{
    return EditLoginPadFuncButtonColor;
}
void HMIForm::setEditLoginPadFuncButtonColor(int value)
{
    EditLoginPadFuncButtonColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "LoginPad"){
            GLoginpad* selectedPad = (GLoginpad*)(selectedGUIO->getGuio());
            selectedPad->setFuncButtonColor(value);
        }
    }
}

int HMIForm::getEditLoginPadBorderColor() const
{
    return EditLoginPadBorderColor;
}
void HMIForm::setEditLoginPadBorderColor(int value)
{
    EditLoginPadBorderColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "LoginPad"){
            GLoginpad* selectedPad = (GLoginpad*)(selectedGUIO->getGuio());
            selectedPad->setBorderColor(value);
        }
    }
}

int HMIForm::getEditLoginPadDigitNumber() const
{
    return EditLoginPadDigitNumber;
}
void HMIForm::setEditLoginPadDigitNumber(int value)
{
    EditLoginPadDigitNumber = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "LoginPad"){
            GLoginpad* selectedPad = (GLoginpad*)(selectedGUIO->getGuio());
            selectedPad->setDigitNumber(value);
        }
    }
}

int HMIForm::getEditLabelColor() const
{
    return EditLabelColor;
}
void HMIForm::setEditLabelColor(int value)
{
    EditLabelColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Label"){
            GLabel* selectedLabel = (GLabel*)(selectedGUIO->getGuio());
            selectedLabel->setLabelQColor(value);
        }
    }
}

int HMIForm::getEditLabelBorderColor() const
{
    return EditLabelBorderColor;
}
void HMIForm::setEditLabelBorderColor(int value)
{
    EditLabelBorderColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Label"){
            GLabel* selectedLabel = (GLabel*)(selectedGUIO->getGuio());
            selectedLabel->setBorderQColor(value);
        }
    }
}

int HMIForm::getEditLabelFontColor() const
{
    return EditLabelFontColor;
}
void HMIForm::setEditLabelFontColor(int value)
{
    EditLabelFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Label"){
            GLabel* selectedLabel = (GLabel*)(selectedGUIO->getGuio());
            selectedLabel->setFontQColor(value);
        }
    }
}

int HMIForm::getEditLabelFontSize() const
{
    return EditLabelFontSize;
}
void HMIForm::setEditLabelFontSize(int value)
{
    EditLabelFontSize = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Label"){
            GLabel* selectedLabel = (GLabel*)(selectedGUIO->getGuio());
            selectedLabel->setFontsize(value);
        }
    }
}

bool HMIForm::getEditLabelFontBold() const
{
    return EditLabelFontBold;
}
void HMIForm::setEditLabelFontBold(bool value)
{
    EditLabelFontBold = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Label"){
            GLabel* selectedLabel = (GLabel*)(selectedGUIO->getGuio());
            selectedLabel->setBold(value);
        }
    }
}

bool HMIForm::getEditLabelFontUnderline() const
{
    return EditLabelFontUnderline;
}
void HMIForm::setEditLabelFontUnderline(bool value)
{
    EditLabelFontUnderline = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Label"){
            GLabel* selectedLabel = (GLabel*)(selectedGUIO->getGuio());
            selectedLabel->setUnderline(value);
        }
    }
}

int HMIForm::getEditLabelThickness() const
{
    return EditLabelThickness;
}
void HMIForm::setEditLabelThickness(int value)
{
    EditLabelThickness = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Label"){
            GLabel* selectedLabel = (GLabel*)(selectedGUIO->getGuio());
            selectedLabel->setThickness(value);
        }
    }
}

int HMIForm::getEditLabelAngle() const
{
    return EditLabelAngle;
}
void HMIForm::setEditLabelAngle(int value)
{
    EditLabelAngle = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Label"){
            GLabel* selectedLabel = (GLabel*)(selectedGUIO->getGuio());
            selectedLabel->setAngle(value);
        }
    }
}

QString HMIForm::getEditLabelText() const
{
    return EditLabelText;
}
void HMIForm::setEditLabelText(const QString &value)
{
    EditLabelText = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Label"){
            GLabel* selectedLabel = (GLabel*)(selectedGUIO->getGuio());
            selectedLabel->setTextWrapper(value);
        }
    }
}

bool HMIForm::getEditLabelTransparent() const
{
    return EditLabelTransparent;
}
void HMIForm::setEditLabelTransparent(bool value)
{
    EditLabelTransparent = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Label"){
            GLabel* selectedLabel = (GLabel*)(selectedGUIO->getGuio());
            selectedLabel->setTransparent(value);
        }
    }
}

int HMIForm::getEditDigitalClockColor() const
{
    return EditDigitalClockColor;
}
void HMIForm::setEditDigitalClockColor(int value)
{
    EditDigitalClockColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "DigitalClock"){
            GDigitalClock* selectedClock = (GDigitalClock*)(selectedGUIO->getGuio());
            selectedClock->setClockQColor(value);
        }
    }
}

int HMIForm::getEditDigitalClockBorderColor() const
{
    return EditDigitalClockBorderColor;
}
void HMIForm::setEditDigitalClockBorderColor(int value)
{
    EditDigitalClockBorderColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "DigitalClock"){
            GDigitalClock* selectedClock = (GDigitalClock*)(selectedGUIO->getGuio());
            selectedClock->setBorderQColor(value);
        }
    }
}

int HMIForm::getEditDigitalClockFontColor() const
{
    return EditDigitalClockFontColor;
}
void HMIForm::setEditDigitalClockFontColor(int value)
{
    EditDigitalClockFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "DigitalClock"){
            GDigitalClock* selectedClock = (GDigitalClock*)(selectedGUIO->getGuio());
            selectedClock->setFontQColor(value);
        }
    }
}

bool HMIForm::getEditDigitalClockFontBold() const
{
    return EditDigitalClockFontBold;
}
void HMIForm::setEditDigitalClockFontBold(bool value)
{
    EditDigitalClockFontBold = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "DigitalClock"){
            GDigitalClock* selectedClock = (GDigitalClock*)(selectedGUIO->getGuio());
            selectedClock->setFontBold(value);
        }
    }
}

int HMIForm::getEditDigitalClockFontSize() const
{
    return EditDigitalClockFontSize;
}
void HMIForm::setEditDigitalClockFontSize(int value)
{
    EditDigitalClockFontSize = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "DigitalClock"){
            GDigitalClock* selectedClock = (GDigitalClock*)(selectedGUIO->getGuio());
            selectedClock->setFontSize(value);
        }
    }
}

int HMIForm::getEditDigitalClockTransparent() const
{
    return EditDigitalClockTransparent;
}
void HMIForm::setEditDigitalClockTransparent(int value)
{
    EditDigitalClockTransparent = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "DigitalClock"){
            GDigitalClock* selectedClock = (GDigitalClock*)(selectedGUIO->getGuio());
            selectedClock->setTransparent(value);
        }
    }
}

int HMIForm::getEditScrollLabelColor() const
{
    return EditScrollLabelColor;
}
void HMIForm::setEditScrollLabelColor(int value)
{
    EditScrollLabelColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ScrollLabel"){
            GScrollLabel* selectedLabel = (GScrollLabel*)(selectedGUIO->getGuio());
            selectedLabel->setBackgroundColor(value);
        }
    }
}

int HMIForm::getEditScrollLabelThickness() const
{
    return EditScrollLabelThickness;
}
void HMIForm::setEditScrollLabelThickness(int value)
{
    EditScrollLabelThickness = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ScrollLabel"){
            GScrollLabel* selectedLabel = (GScrollLabel*)(selectedGUIO->getGuio());
            selectedLabel->setThickness(value);
        }
    }
}

int HMIForm::getEditScrollLabelBorderColor() const
{
    return EditScrollLabelBorderColor;
}
void HMIForm::setEditScrollLabelBorderColor(int value)
{
    EditScrollLabelBorderColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ScrollLabel"){
            GScrollLabel* selectedLabel = (GScrollLabel*)(selectedGUIO->getGuio());
            selectedLabel->setBorderColor(value);
        }
    }
}

int HMIForm::getEditScrollLabelTransparent() const
{
    return EditScrollLabelTransparent;
}
void HMIForm::setEditScrollLabelTransparent(int value)
{
    EditScrollLabelTransparent = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ScrollLabel"){
            GScrollLabel* selectedLabel = (GScrollLabel*)(selectedGUIO->getGuio());
            selectedLabel->setTransparent(value);
        }
    }
}

int HMIForm::getEditScrollLabelFontColor() const
{
    return EditScrollLabelFontColor;
}
void HMIForm::setEditScrollLabelFontColor(int value)
{
    EditScrollLabelFontColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ScrollLabel"){
            GScrollLabel* selectedLabel = (GScrollLabel*)(selectedGUIO->getGuio());
            selectedLabel->setFontColor(value);
        }
    }
}

int HMIForm::getEditScrollLabelFontSize() const
{
    return EditScrollLabelFontSize;
}
void HMIForm::setEditScrollLabelFontSize(int value)
{
    EditScrollLabelFontSize = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ScrollLabel"){
            GScrollLabel* selectedLabel = (GScrollLabel*)(selectedGUIO->getGuio());
            selectedLabel->setFontSize(value);
        }
    }
}

int HMIForm::getEditScrollLabelFontBold() const
{
    return EditScrollLabelFontBold;
}
void HMIForm::setEditScrollLabelFontBold(int value)
{
    EditScrollLabelFontBold = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ScrollLabel"){
            GScrollLabel* selectedLabel = (GScrollLabel*)(selectedGUIO->getGuio());
            selectedLabel->setBold(value);
        }
    }
}

int HMIForm::getEditScrollLabelFontUnderline() const
{
    return EditScrollLabelFontUnderline;
}
void HMIForm::setEditScrollLabelFontUnderline(int value)
{
    EditScrollLabelFontUnderline = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ScrollLabel"){
            GScrollLabel* selectedLabel = (GScrollLabel*)(selectedGUIO->getGuio());
            selectedLabel->setUnderline(value);
        }
    }
}

int HMIForm::getEditScrollLabelDirection() const
{
    return EditScrollLabelDirection;
}
void HMIForm::setEditScrollLabelDirection(int value)
{
    EditScrollLabelDirection = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ScrollLabel"){
            GScrollLabel* selectedLabel = (GScrollLabel*)(selectedGUIO->getGuio());
            selectedLabel->setDirection(value);
        }
    }
}

int HMIForm::getEditScrollLabelSpeed() const
{
    return EditScrollLabelSpeed;
}
void HMIForm::setEditScrollLabelSpeed(int value)
{
    EditScrollLabelSpeed = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ScrollLabel"){
            GScrollLabel* selectedLabel = (GScrollLabel*)(selectedGUIO->getGuio());
            selectedLabel->setSpeed(value);
        }
    }
}

QString HMIForm::getEditScrollLabelText() const
{
    return EditScrollLabelText;
}
void HMIForm::setEditScrollLabelText(const QString &value)
{
    EditScrollLabelText = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "ScrollLabel"){
            GScrollLabel* selectedLabel = (GScrollLabel*)(selectedGUIO->getGuio());
            selectedLabel->setText(value);
        }
    }
}

int HMIForm::getEditLedColor() const
{
    return EditLedColor;
}
void HMIForm::setEditLedColor(int value)
{
    EditLedColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Led"){
            GLed* selectedLed = (GLed*)(selectedGUIO->getGuio());
            selectedLed->setLedColor(value);
        }
    }
}

int HMIForm::getEditPanelMax() const
{
    return EditPanelMax;
}
void HMIForm::setEditPanelMax(int value)
{
    EditPanelMax = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Panel"){
            GPanel* selectedPanel = (GPanel*)(selectedGUIO->getGuio());
            selectedPanel->setMaximum(value);
        }
    }
}

int HMIForm::getEditPanelMin() const
{
    return EditPanelMin;
}
void HMIForm::setEditPanelMin(int value)
{
    EditPanelMin = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Panel"){
            GPanel* selectedPanel = (GPanel*)(selectedGUIO->getGuio());
            selectedPanel->setMinimum(value);
        }
    }
}

int HMIForm::getEditPanelMajor() const
{
    return EditPanelMajor;
}
void HMIForm::setEditPanelMajor(int value)
{
    EditPanelMajor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Panel"){
            GPanel* selectedPanel = (GPanel*)(selectedGUIO->getGuio());
            selectedPanel->setMajor(value);
        }
    }
}

int HMIForm::getEditPanelMinor() const
{
    return EditPanelMinor;
}
void HMIForm::setEditPanelMinor(int value)
{
    EditPanelMinor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Panel"){
            GPanel* selectedPanel = (GPanel*)(selectedGUIO->getGuio());
            selectedPanel->setMinor(value);
        }
    }
}

int HMIForm::getEditPanelNeedleColor() const
{
    return EditPanelNeedleColor;
}
void HMIForm::setEditPanelNeedleColor(int value)
{
    EditPanelNeedleColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Panel"){
            GPanel* selectedPanel = (GPanel*)(selectedGUIO->getGuio());
            selectedPanel->setNeedleColor(value);
        }
    }
}

int HMIForm::getEditPanelDigitColor() const
{
    return EditPanelDigitColor;
}
void HMIForm::setEditPanelDigitColor(int value)
{
    EditPanelDigitColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Panel"){
            GPanel* selectedPanel = (GPanel*)(selectedGUIO->getGuio());
            selectedPanel->setDigitColor(value);
        }
    }
}

int HMIForm::getEditPanelBodyColor() const
{
    return EditPanelBodyColor;
}
void HMIForm::setEditPanelBodyColor(int value)
{
    EditPanelBodyColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Panel"){
            GPanel* selectedPanel = (GPanel*)(selectedGUIO->getGuio());
            selectedPanel->setBodyColor(value);
        }
    }
}

QString HMIForm::getEditImageName() const
{
    return EditImageName;
}
void HMIForm::setEditImageName(const QString &value)
{
    EditImageName = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Image"){
            GImage* selectedImage = (GImage*)(selectedGUIO->getGuio());
            selectedImage->setFileName(value);
        }
    }
}

bool HMIForm::getEditImageGrayScale() const
{
    return EditImageGrayScale;
}
void HMIForm::setEditImageGrayScale(bool value)
{
    EditImageGrayScale = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Image"){
            GImage* selectedImage = (GImage*)(selectedGUIO->getGuio());
            selectedImage->setGrayscale(value);
        }
    }
}

QString HMIForm::getEditRailImageName() const
{
    return EditRailImageName;
}
void HMIForm::setEditRailImageName(const QString &value)
{
    EditRailImageName = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Rail"){
            GRail* selectedRail = (GRail*)(selectedGUIO->getGuio());
            selectedRail->setFileName(value);
        }
    }
}

bool HMIForm::getEditRailGrayScale() const
{
    return EditRailGrayScale;
}
void HMIForm::setEditRailGrayScale(bool value)
{
    EditRailGrayScale = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Rail"){
            GRail* selectedRail = (GRail*)(selectedGUIO->getGuio());
            selectedRail->setGrayscale(value);
        }
    }
}

int HMIForm::getEditCircleFillColor() const
{
    return EditCircleFillColor;
}
void HMIForm::setEditCircleFillColor(int value)
{
    EditCircleFillColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Circle"){
            GDrawing* selectedDrawing = (GDrawing*)(selectedGUIO->getGuio());
            selectedDrawing->setfillColor(value);
        }
    }
}

int HMIForm::getEditCircleLineColor() const
{
    return EditCircleLineColor;
}
void HMIForm::setEditCircleLineColor(int value)
{
    EditCircleLineColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Circle"){
            GDrawing* selectedDrawing = (GDrawing*)(selectedGUIO->getGuio());
            selectedDrawing->setlineColor(value);
        }
    }
}

int HMIForm::getEditCircleLineThickness() const
{
    return EditCircleLineThickness;
}
void HMIForm::setEditCircleLineThickness(int value)
{
    EditCircleLineThickness = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Circle"){
            GDrawing* selectedDrawing = (GDrawing*)(selectedGUIO->getGuio());
            selectedDrawing->setlinewidth(value);
        }
    }
}

int HMIForm::getEditRectangleFillColor() const
{
    return EditRectangleFillColor;
}
void HMIForm::setEditRectangleFillColor(int value)
{
    EditRectangleFillColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Rectangle"){
            GDrawing* selectedDrawing = (GDrawing*)(selectedGUIO->getGuio());
            selectedDrawing->setfillColor(value);
        }
    }
}

int HMIForm::getEditRectangleLineColor() const
{
    return EditRectangleLineColor;
}
void HMIForm::setEditRectangleLineColor(int value)
{
    EditRectangleLineColor = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Rectangle"){
            GDrawing* selectedDrawing = (GDrawing*)(selectedGUIO->getGuio());
            selectedDrawing->setlineColor(value);
        }
    }
}

int HMIForm::getEditRectangleLineThickness() const
{
    return EditRectangleLineThickness;
}
void HMIForm::setEditRectangleLineThickness(int value)
{
    EditRectangleLineThickness = value;
    if(selectedGUIO != NULL){
        if(selectedGUIO->getType() == "Rectangle"){
            GDrawing* selectedDrawing = (GDrawing*)(selectedGUIO->getGuio());
            selectedDrawing->setlinewidth(value);
        }
    }
}
