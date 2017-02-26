#ifndef VERTEX_H
#define VERTEX_H


class Vertex
{
public:
    Vertex(int xp, int yp,double s);
    int X();
    int Y();
    double Scale();
    void setX(int p);
    void setY(int p);
    void setScale(double s);
private:
    int x;
    int y;
    double scale;
};

#endif //
