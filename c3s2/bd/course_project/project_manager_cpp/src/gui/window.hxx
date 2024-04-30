#pragma once

#include <cstdint>
#include <string>

class Window
{
public:
    float x;
    float y;
    float width;
    float height;
    std::string title = "Window";
    bool visible = false;

    Window() : x(0), y(0), width(0), height(0){};

    Window(float x, float y, float width, float height, std::string title)
        : x(x), y(y), width(width), height(height), title(std::move(title))
    {
    }

    virtual void update() = 0;
    virtual void draw() = 0;
};