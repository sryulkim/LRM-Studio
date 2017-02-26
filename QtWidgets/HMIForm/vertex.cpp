#include "vertex.h"

Vertex::Vertex(int xp, int yp,double s)
{
    this->x = xp;
    this->y = yp;
    this->scale = s;
}

int Vertex::X()
{
    return this->x;
}

int Vertex::Y()
{
    return this->y;
}

double Vertex::Scale()
{
    return this->scale;
}

void Vertex::setX(int p)
{
    this->x = p;
}

void Vertex::setY(int p)
{
    this->y = p;
}

void Vertex::setScale(double s)
{
    this->scale = s;
}
