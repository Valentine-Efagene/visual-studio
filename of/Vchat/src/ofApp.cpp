#include "ofApp.h"

//--------------------------------------------------------------
void ofApp::setup(){
	role = true;
	b_start.addListener(this, &ofApp::startButtonPressed);
	b_role.addListener(this, &ofApp::roleButtonPressed);
	gui.setup();
	gui.add(b_role.setup("SERVER"));
}

void ofApp::startButtonPressed() {
	if (p_isServer) {
		gui.add(if_addr.setup(p_addr, 200, 30));
	}
	else {
		gui.add(if_addr.setup(p_addr, 200, 30));
		gui.add(if_port.setup(p_port, 100, 30));
	}
	
	gui.add(b_start.setup("START"));
}

void ofApp::roleButtonPressed() {
	if (p_isServer) {
		gui.add(if_addr.setup(p_addr, 200, 30));
	}
	else {
		gui.add(if_addr.setup(p_addr, 200, 30));
		gui.add(if_port.setup(p_port, 100, 30));
	}

	gui.add(b_start.setup("START"));
}

//--------------------------------------------------------------
void ofApp::update(){
	if (p_isServer) {
		t_role.setName("SERVER");
	}
	else {
		t_role.setName("CLIENT");
	}
}

//--------------------------------------------------------------
void ofApp::draw(){
	gui.draw();
	b_role.
}

//--------------------------------------------------------------
void ofApp::keyPressed(ofKeyEventArgs & key){
	if (key.key == OF_KEY_RETURN) {
		cout << p_addr.get();
	}
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
