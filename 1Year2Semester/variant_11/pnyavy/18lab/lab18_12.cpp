// #include "stdafx.h"
#include <iostream>
using namespace std;

class LONG
{
	float value;
	LONG *next;

public:
	LONG(long _value);
	LONG();

	void add(float n);
	friend LONG operator --(LONG queue1);
	LONG operator++(int queue1);
	void print();
};

//----------------
LONG::LONG(long _value)
{
	value = _value;
}

void LONG::add(float n){
	value += n;
}

void LONG::print(){
	std::cout << value;
}


void operator++(LONG &LONG)
{
	float t = 1;
	LONG.add(t);
}

void operator--(LONG &LONG)
{
	float t = -1;
	LONG.add(t);
}

class DOUBLE {
	double value;
	LONG *next;

public:
	DOUBLE(double _value);
	DOUBLE();

	void add(double n);
	friend LONG operator -(LONG queue1);
	LONG operator+(int queue1);
	void print();
};

DOUBLE::DOUBLE(double d){
	value = d;
}

void DOUBLE::add(double n){
	value += n;
}
void operator+(DOUBLE &DOUBLE)
{
	DOUBLE.add(1);
}


void operator-(DOUBLE &DOUBLE)
{
	DOUBLE.add(-1);
}


void DOUBLE::print(){
	std::cout << value;
}


//---------------
int main()
{
	float n = 3;
	LONG *L1 = new LONG(n); 
	LONG *L2 = new LONG(++n); 
	LONG *L3 = new LONG(--n); 
	
	--L1;
	L1->print(); 
	++L2;
	std::cout << "\n";
	L2->print(); 
	std::cout << "\n";
	L3->print();


	std::cout << "\n";
	std::cout << "\n";

	double d = 3.4;

	DOUBLE *D1 = new DOUBLE(d);
	DOUBLE *D2 = new DOUBLE(++d);
	DOUBLE *D3 = new DOUBLE(--d);


	+D1;
	D1->print(); 
	std::cout << "\n";
	D2->print(); 
	std::cout << "\n";
	D3->print();

}