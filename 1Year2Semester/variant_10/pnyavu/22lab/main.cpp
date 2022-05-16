#include <iostream>
#include <tuple>
#include <math.h>

std::tuple <double, double> c(double x) {
    return {
            ((2 / (x - pow(2 * x,0.5)) + ((x + 2) / pow(2 * x,0.5)) - (x / (pow(2 * x,0.5) + 2))) * (pow(x,0.5) - pow(2,0.5)) / (x + 2)),
            1 / (pow(x,0.5) + pow(2,0.5))
    };
}

std::tuple <double, double> calc(double x) {
    std::tuple <double, double> t = c(x);
    double z1 = std::get<0>(t);
    double z2 = std::get<1>(t);
    if (std::isinf(z1) || std::isnan(z1) || std::isnan(z2) || std::isinf(z2)) {
        throw;
    }
    else {
        return c(x);
    }
}


int main() {
    while (true) {
        std::cout << "Input a number : ";
        try {
            double in;
            std::cin >> in;
            std::cout << " Z1 = " << std::get<0>(calc(in)) << "\n Z2 = " << std::get<1>(calc(in)) << "\n";
        }
        catch (const std::exception& e) {
            std::cout << e.what() << '\n';
        }
    }
}



