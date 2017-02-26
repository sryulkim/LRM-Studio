#ifndef GRAIL_H
#define GRAIL_H
#include <QList>
#include "grail.h"
#include "edge.h"
#include "gimage.h"

class GRail : public GImage
{
    Q_OBJECT
public:
    GRail(QWidget *parent=0):GImage(parent)
    {
        EdgeList = new QList<Edge*>();
        VertexList = new QList<Vertex*>();

        this->point = 0;
        this->totalLength = 0;
        this->setGeometry(this->geometry().x(), this->geometry().y(), 100, 100);
        xMax = 100;
        yMax = 100;

        bGrayscale = false;
        img = new QImage();
        tempImg = new QImage();
        reader = new QImageReader();
        imgFolder = "";
        objectScale = 1;
    }

    QList<Edge*> *EdgeList;
    QList<Vertex*> *VertexList;

    void AddVertex(int x, int y, double scale)
    {
        //qDebug() << "AddVertex x: "<<x<<" y: "<<y;
        if(this->xMax < x)
            xMax = x;
        if(this->yMax < y)
            yMax = y;
        this->setGeometry(this->geometry().x(), this->geometry().y(), this->width(), this->height());

        Vertex *vertex = new Vertex(x, y,scale);
        if(VertexList->count() != 0){
            Edge *edge = new Edge(VertexList->last(), vertex);
            totalLength += edge->Length();
            EdgeList->append(edge);
            this->setGeometry(VertexList->first()->X(), VertexList->first()->Y(), this->geometry().width(), this->geometry().height());
        }
        else
            this->setGeometry(vertex->X(), vertex->Y(), this->geometry().width(), this->geometry().height());
        VertexList->append(vertex);
        updateGeometry();
    }
    int Point()
    {
        return this->point;
    }
    int TotalLength()
    {
        return this->totalLength;
    }


public Q_SLOTS:
    void setPoint(int value){
        if(value < 0)
            value = 0;
        else if(value > 100)
            value = 100;
        point = value;
        Vertex* loc = this->PointToVertex();
        int afterX = (int)((double)loc->X() + ((double)originRect.width() - (double)originRect.width()*sqrt(loc->Scale()))/2);
        int afterY = (int)((double)loc->Y() + ((double)originRect.height() - (double)originRect.height()*sqrt(loc->Scale()))/2);
        int afterW = this->originRect.width()*sqrt(loc->Scale());
        int afterH = this->originRect.height()*sqrt(loc->Scale());
        //qDebug()<<loc->X()<<loc->Y()<<loc->Scale()<<"   "<<afterX<<afterY;
        this->setGeometry(afterX, afterY, afterW, afterH);
        *tempImg = img->copy(img->rect());
        *tempImg = tempImg->scaled(afterW,afterH);
        this->setPixmap(QPixmap::fromImage(*tempImg));
        //draw();
    }

private:
    int point;
    int totalLength;
    int xMax;
    int yMax;
    Vertex* PointToVertex()
    {
        Edge* findEdge = EdgeList->last();
        int findLength = 0; // 찾는 곳
        int findPoint = this->totalLength * this->point / 100; // 찾는 곳 까지의 길이

        QListIterator<Edge*> edgeListIter(*EdgeList);
        while(edgeListIter.hasNext())
        {
            Edge* edge = edgeListIter.next();

            if(findLength <= findPoint && findLength + edge->Length() >= findPoint)
            {
                findEdge = edge;
                break;
            }
            else
                findLength += edge->Length();
        }

        findLength = findPoint - findLength;
        int xVertex = findEdge->StartPoint()->X() + ((findEdge->EndPoint()->X() - findEdge->StartPoint()->X()) * findLength / findEdge->Length());
        int yVertex = findEdge->StartPoint()->Y() + ((findEdge->EndPoint()->Y() - findEdge->StartPoint()->Y()) * findLength / findEdge->Length());
        double sVertex = findEdge->StartPoint()->Scale() + (findEdge->EndPoint()->Scale() - findEdge->StartPoint()->Scale()) * findLength / findEdge->Length();
        //qDebug() << "PointToVertex xVertex: "<<xVertex<<" yVertex: "?<<Vertex? " point: "?point;
        Vertex* vertex = new Vertex(xVertex, yVertex,sVertex);
        return vertex;
    }

    QImage *tempImg;
};

#endif // GRAIL_H
