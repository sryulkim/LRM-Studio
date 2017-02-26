#ifndef EDGE_H
#define EDGE_H
#include "vertex.h"

class Edge
{
public:
    Edge(Vertex *sp, Vertex *ep);
    int Length();
    Vertex* StartPoint();
    Vertex* EndPoint();
    void setStartPoint(Vertex *sp);
    void setEndPoint(Vertex *ep);

private:
    int length;
    Vertex *startPoint;
    Vertex *endPoint;
};

#endif // EDGE_H
