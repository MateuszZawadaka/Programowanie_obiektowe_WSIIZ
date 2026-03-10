#include"WebSocketManager.h"
#include<Arduino.h>

WebSocketManager* webSocketInstance = nullptr;

WebSocketManager::WebSocketManager()
    : webSocket(81)
    {
        webSocketInstance = this;
    }


void WebSocketManager::begin(){
    webSocket.begin();
    webSocket.onEvent(onEventStatic);

    webSocket.enableHeartbeat(2, 4, 10);
    pinMode(26, OUTPUT);

}

void WebSocketManager::loop(){
    webSocket.loop();

    if (millis() - ping > 30000)
    {
        ping = millis();
        webSocket.broadcastPing();
    }
    
}

void WebSocketManager::broadcast(const String& message){
    webSocket.broadcastTXT(message.c_str());
}


void WebSocketManager::onEventStatic(uint8_t num, WStype_t type, uint8_t* payload, size_t length){
    if (webSocketInstance != nullptr)
    {
        webSocketInstance->onEvent(num, type, payload, length);
    }
    
}

void WebSocketManager::onEvent(uint8_t num, WStype_t type, uint8_t* payload, size_t length){

    switch (type)
    {
    case WStype_CONNECTED:
        Serial.printf("[%u] Connected\n", num);
        webSocket.sendTXT(num, "Connected");
        break;
    case WStype_DISCONNECTED:
        Serial.printf("[%u] Disconnected\n", num);
        jsonBuffer = "";

    case WStype_TEXT:{
        String msg = (char*)payload;
        Serial.printf("[%u] Received text: %s\n", num, msg.c_str());
        
        if (msg == "START")
        {
            digitalWrite(26, HIGH);
            webSocket.sendTXT(num, "Wlaczono port 32");

        }else if(msg == "STOP"){
            digitalWrite(26, LOW);
            webSocket.sendTXT(num, "Wylaczono port 32");
        }
        
    }
    default:
        break;
    }
}