#include "LedMatrix.h"

LedMatrix::LedMatrix(byte clkPin, byte dataPin, byte loadPin)
{
	clk = clkPin;
	data = dataPin;
	load = loadPin;
}

void LedMatrix::init()
{
	pinMode(clk, OUTPUT);
	pinMode(data, OUTPUT);
	pinMode(load, OUTPUT);
	SPI.begin();
	SPI.setBitOrder(MSBFIRST);
	write(SCANLIMIT, 0x07);      
	write(DECODEMODE, 0x00);  // using an led matrix (not digits)
	write(SHUTDOWN, 0x01);    // not in shutdown mode
	write(DISPLAYTEST, 0x00); // no display test
	clearDisplay();
}

void LedMatrix::clearDisplay()
{
	for (int i = 1; i <= 8; i++) 
    {
		write(i,0);
	}

	delay(100);
}

void LedMatrix::write(byte addr, byte data)
{
  digitalWrite(load, LOW);
  SPI.transfer(addr);
  SPI.transfer(data);
  digitalWrite(load, HIGH);
}

byte LedMatrix::getClockPin()
{
	return clk;
}

byte LedMatrix::getDataPin()
{
	return data;
}

byte LedMatrix::getLoadPin()
{
	return load;
}
