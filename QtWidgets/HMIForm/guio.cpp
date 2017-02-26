#include "guio.h"

GUIO::GUIO(QString name, QString type, QWidget* guio, int layer=0)
{
    this->name = name;
    this->type = type;
    this->guio = guio;
    this->layer = layer;
}

QWidget *GUIO::getGuio() const
{
    return guio;
}

void GUIO::setGuio(QWidget *value)
{
    guio = value;
}

QString GUIO::getName() const
{
    return name;
}

void GUIO::setName(const QString &value)
{
    name = value;
}

QString GUIO::getType() const
{
    return type;
}

void GUIO::setType(const QString &value)
{
    type = value;
}

int GUIO::getLayer() const
{
    return layer;
}

void GUIO::setLayer(int value)
{
    layer = value;
}
