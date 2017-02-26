#ifndef GUIO_H
#define GUIO_H
#include <QList>
#include <QWidget>
#include <QString>

class GUIO
{
public:
    GUIO(QString name, QString type, QWidget* guio, int layer);
    QWidget *getGuio() const;
    void setGuio(QWidget *value);

    QString getName() const;
    void setName(const QString &value);

    QString getType() const;
    void setType(const QString &value);

    int getLayer() const;
    void setLayer(int value);

private:
    QWidget* guio;
    QString name;
    QString type;
    int layer;
};

#endif // GUIO_H
