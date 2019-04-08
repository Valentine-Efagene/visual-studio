#pragma once

#include "ofMain.h"
#include "ofxOpencv.h"
#include "ofxNetwork.h"
#include "ofxXmlSettings.h"

class ofApp : public ofBaseApp{

	public:
		void setup();
		void update();
		void draw();

		void keyPressed(int key);
		void keyReleased(int key);
		void mouseMoved(int x, int y );
		void mouseDragged(int x, int y, int button);
		void mousePressed(int x, int y, int button);
		void mouseReleased(int x, int y, int button);
		void mouseEntered(int x, int y);
		void mouseExited(int x, int y);
		void windowResized(int w, int h);
		void dragEvent(ofDragInfo dragInfo);
		void gotMessage(ofMessage msg);
		
		ofxXmlSettings settings;
		ofVideoGrabber vidGrabber;
		int w, h, rangeLow, rangeHigh;
		int findHue;
		ofxCvColorImage rgb, hsb;
		ofxCvGrayscaleImage hue, sat, bri, filtered;
		ofxCvContourFinder contours;

		ofxTCPClient client;
};
