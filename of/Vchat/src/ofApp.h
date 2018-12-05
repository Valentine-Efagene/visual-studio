#pragma once

#include "ofMain.h"
#include "ofxGui.h"
#include "ofxNetwork.h"

class ofApp : public ofBaseApp{

	public:
		void setup();
		void update();
		void draw();

		void keyPressed(ofKeyEventArgs & key);
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

		void startButtonPressed();

		void roleButtonPressed();
		
		ofxPanel gui;
		ofxButton b_role;
		ofParameter<bool> p_isServer;
		ofParameter<string> p_addr;
		ofParameter<string> p_port;
		ofxInputField<string> if_addr;
		ofxInputField<string> if_port;
		ofxButton b_start;

		bool role;
};
