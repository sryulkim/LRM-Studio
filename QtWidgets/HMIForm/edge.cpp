#include "edge.h"
#include "math.h"

Edge::Edge(Vertex *sp, Vertex *ep)
{
    this->setStartPoint(sp);
    this->setEndPoint(ep);
    length =  (int)(sqrt(pow((double)sp->X() - (double)ep->X(), 2) +
                              pow((double)sp->Y() - (double)ep->Y(), 2)));
}

int Edge::Length(){
    return this->length;
}

Vertex* Edge::StartPoint(){
    return this->startPoint;
}

Vertex* Edge::EndPoint(){
    return this->endPoint;
}

void Edge::setStartPoint(Vertex *sp){
    this->startPoint = sp;
}

void Edge::setEndPoint(Vertex *ep){
    this->endPoint = ep;
}
