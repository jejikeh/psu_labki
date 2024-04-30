#include "window.hxx"
#include <raylib.h>
#include "../raygui.h"
#include "../raymath.h"

void Window::draw()
{
    if (!visible)
    {
        return;
    }

    GuiGroupBox({x, y, width, height}, title.c_str());
}