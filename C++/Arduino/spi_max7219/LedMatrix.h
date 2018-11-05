#ifndef LEDMATRIX
#define LEDMATRIX

#include <SPI.h>

class LedMatrix
{
private:
	byte clk;
	byte data;
	byte load;

public:
	//the opcodes for the MAX7221 and MAX7219
	const static byte NOOP = 0;
	const static byte DIGIT0 = 1;
	const static byte DIGIT1 = 2;
	const static byte DIGIT2 = 3;
	const static byte DIGIT3 = 4;
	const static byte DIGIT4 = 5;
	const static byte DIGIT5 = 6;
	const static byte DIGIT6 = 7;
	const static byte DIGIT7 = 8;
	const static byte DECODEMODE = 9;
	const static byte INTENSITY = 10;
	const static byte SCANLIMIT = 11;
	const static byte SHUTDOWN = 12;
	const static byte DISPLAYTEST = 15;
	const static byte OFFSET = 15;

	LedMatrix(byte clkPin, byte dataPin, byte loadPin);
	void init();
	void write(byte addr, byte data);
	void clearDisplay();
	byte getDataPin();
	byte getClockPin();
	byte getLoadPin();
};
#endif