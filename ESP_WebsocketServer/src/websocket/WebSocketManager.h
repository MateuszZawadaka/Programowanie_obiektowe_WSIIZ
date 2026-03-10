#pragma once
#include<WebSocketsServer.h>
#include<ArduinoJson.h>

class WebSocketManager{
    public:
        WebSocketManager();
        void begin();
        void loop();
        void broadcast(const String& message);
        void sendJSON(uint8_t clientNum, const String& json);
        
        String jsonBuffer = "";

    private:
        WebSocketsServer webSocket;
        unsigned long ping = 0;
        static void onEventStatic(uint8_t num, WStype_t type, uint8_t* payload, size_t length);
        void onEvent(uint8_t num, WStype_t type, uint8_t* payload, size_t length);
        void handleJson(uint8_t num,  const String& json);


};

extern WebSocketManager* webSocketInstance;
