/***************************************************************************
 *   Copyright (C) 2006-2008 by Tomasz Ziobrowski                          *
 *   http://www.3electrons.com                                             *
 *   e-mail: t.ziobrowski@3electrons.com                                   *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
/**
 * @file widgetwithbackground.cpp
 * @brief 3rd party library
 * @details 외부 라이브러리 사용\n
 * 기본 라이센스는 GPL이며 제작자에게 사용처와 목적에 대한 메일을 보내면
 * LGPL로 사용 가능
 * AbstractMeter에서 상속받아 사용함
 *
 */
#include <QtGui>
#include "widgetwithbackground.h"

WidgetWithBackground::WidgetWithBackground(QWidget * parent) : QWidget(parent)
{
  m_pixmap = new QPixmap(size());
  m_modified = false;
}

WidgetWithBackground::~WidgetWithBackground()
{
   if (m_pixmap)
     {
    delete m_pixmap;
    m_pixmap = NULL;
     }
}

void WidgetWithBackground::drawBackground()
{
  if (m_pixmap->size() != size() || m_modified )
    {
    delete m_pixmap;
    m_pixmap = new QPixmap(size());
    m_modified=true;
    repaintBackground();
    m_modified=false;
    }
    QPainter painter(this);
    painter.drawPixmap(0,0,*m_pixmap);
}//

void WidgetWithBackground::updateWithBackground()
{
  m_modified=true;
  update();
}

bool WidgetWithBackground::doRepaintBackground()
{
  return m_modified;
}

void WidgetWithBackground::repaintBackground()
{
  m_pixmap->fill(QColor(0,0,0,0));
  QPainter painter(m_pixmap);
  paintBackground(painter);
}
