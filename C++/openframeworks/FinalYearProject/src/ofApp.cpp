#include "ofApp.h"

//--------------------------------------------------------------
void ofApp::setup(){
	w = 320;  // try to grab at this size.
	h = 240;
	FONT_SIZE = 12;
	findHue = 30;
	font.load("futura_book.otf", FONT_SIZE);

	if (!settings.loadFile("settings.xml")) {
		ofLogError() << "Couldn't load file";
	}

	string ip = settings.getValue("SETTINGS:IP", "127.0.0.1");
	int port = settings.getValue("SETTINGS:PORT", 12324);

	ofxTCPSettings setup(ip, port);
	client.setup(setup);
	client.setMessageDelimiter("\n");

	//get back a list of devices.
	vector<ofVideoDevice> devices = vidGrabber.listDevices();

	for (size_t i = 0; i < devices.size(); i++) {
		if (devices[i].bAvailable) {
			//log the device
			ofLogNotice() << devices[i].id << ": " << devices[i].deviceName;
		}
		else {
			//log the device and note it as unavailable
			ofLogNotice() << devices[i].id << ": " << devices[i].deviceName << " - unavailable ";
		}
	}

	vidGrabber.setDeviceID(0);
	vidGrabber.setDesiredFrameRate(60);
	vidGrabber.initGrabber(w, h, true);

	rgb.allocate(w, h);
	hsb.allocate(w, h);
	hue.allocate(w, h);
	sat.allocate(w, h);
	bri.allocate(w, h);
	filtered.allocate(w, h);
}

//--------------------------------------------------------------
void ofApp::update(){
	ofBackground(100, 100, 100);
	vidGrabber.update();

	if (vidGrabber.isFrameNew()) {

		rgb.setFromPixels(vidGrabber.getPixels());
		rgb.mirror(false, true);
		hsb = rgb;
		hsb.convertRgbToHsv();
		hsb.convertToGrayscalePlanarImages(hue, sat, bri);

		for (int i = 0; i < w * h; i++) {
			filtered.getPixels()[i] = ofInRange(hue.getPixels()[i], findHue, findHue) ? 255:0;
		}

		filtered.flagImageChanged();
		filtered.blurGaussian(3);
		filtered.dilate();
		filtered.erode();
		contours.findContours(filtered, 50, w * h / 2, 1, false);
	}
}

//--------------------------------------------------------------
void ofApp::draw(){
	const int W = 320, H = 240, MARGIN = 10, SQUARE_WIDTH = 40;
	string action = "";
	rgb.draw(0, 0);
	hsb.draw(W, 0);
	bri.draw(0, H);
	hue.draw(W, H);
	sat.draw(0, 2 * H);
	filtered.draw(W, 2 * H);
	contours.draw(2 * W, 2 * H);

	ofSetColor(255, 0, 0);
	ofFill();
	float maxArea = 0;
	int index = 0;

	if(contours.nBlobs > 0) {
		for (int i = 0; i < contours.nBlobs; i++) {
			if (contours.blobs[i].area > maxArea) {
				index = i;
				maxArea = contours.blobs[i].area;
			}
		}

		// reverse
		if (contours.blobs[index].centroid.y < H / 4 && action.length() < 3) {
			action += "1";
		}

		//  forward
		if (contours.blobs[index].centroid.y > H * 0.5 - 20 && action.length() < 3) {
			action += "2";
		}

		// right
		if (contours.blobs[index].centroid.x > W / 2 + 0.5 * SQUARE_WIDTH && action.length() < 3) {
			action += "3";
		}

		// left
		if (contours.blobs[index].centroid.x < W / 2 - 0.5 * SQUARE_WIDTH && action.length() < 3) {
			action += "4";
		}

		// idle
		if (action == "") {
			action = "0";
		}

		ofSetColor(0, 255, 255);
		font.drawString("POSITION: " + ofToString(contours.blobs[index].centroid.x) + ", "
			+ ofToString(contours.blobs[index].centroid.y), 2 * W + MARGIN, 2 * FONT_SIZE);
		font.drawString(action, 2 * W + MARGIN, 3 * FONT_SIZE + 10);
		ofSetColor(255, 0, 0);

		ofCircle(contours.blobs[index].centroid.x, contours.blobs[index].centroid.y, 5);
		ofLine(MARGIN, H / 4, W - MARGIN, H / 4);
		ofLine(MARGIN, H * 0.5 - 20, W - MARGIN, H * 0.5 - 20);
		ofLine(W / 2 - 0.5 * SQUARE_WIDTH, MARGIN, W / 2 - 0.5 * SQUARE_WIDTH, H - MARGIN);
		ofLine(W / 2 + 0.5 * SQUARE_WIDTH, MARGIN, W / 2 + 0.5 * SQUARE_WIDTH, H - MARGIN);
		/*
		if (client.isConnected()) {
			client.sendRaw(std::to_string(contours.blobs[index].centroid.x) + " " +
				std::to_string(contours.blobs[index].centroid.y) + "\n");
		}*/

		if (client.isConnected() && start) {
			client.sendRaw(action + "\n");
		}

		action = "";
	}

	ofSetColor(255, 255, 255);
}

//--------------------------------------------------------------
void ofApp::keyPressed(int key){

}

//--------------------------------------------------------------
void ofApp::keyReleased(int key){

}

//--------------------------------------------------------------
void ofApp::mouseMoved(int x, int y ){

}

//--------------------------------------------------------------
void ofApp::mouseDragged(int x, int y, int button){

}

//--------------------------------------------------------------
void ofApp::mousePressed(int x, int y, int button){
	int mX = x % w;
	int mY = y % h;

	findHue = hue.getPixels()[mY * w + mX];
	printf("%d", findHue);
	start = true;
}

//--------------------------------------------------------------
void ofApp::mouseReleased(int x, int y, int button){

}

//--------------------------------------------------------------
void ofApp::mouseEntered(int x, int y){

}

//--------------------------------------------------------------
void ofApp::mouseExited(int x, int y){

}

//--------------------------------------------------------------
void ofApp::windowResized(int w, int h){

}

//--------------------------------------------------------------
void ofApp::gotMessage(ofMessage msg){

}

//--------------------------------------------------------------
void ofApp::dragEvent(ofDragInfo dragInfo){ 

}
