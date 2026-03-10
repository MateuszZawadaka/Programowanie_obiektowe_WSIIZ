#include <Arduino.h>
#include <WiFi.h>
#include "websocket/WebSocketManager.h"

// ======================
// GLOBALNE OBIEKTY
// ======================
WebSocketManager ws;

// ======================
// TASKI FreeRTOS
// ======================
void WebSocketTask(void* pvParameters) {
    for (;;) {
        ws.loop();       // obsługa WebSocket
        vTaskDelay(1);   // oddanie czasu CPU
    }
}

// ======================
// SETUP
// ======================
void setup() {
    Serial.begin(115200);
    delay(1000);

    Serial.println("ESP32 Starting...");

    // ======================
    // ACCESS POINT
    // ======================
    WiFi.mode(WIFI_AP_STA);
    if (WiFi.softAP("ESP32_Server", "12345678")) {
        Serial.println("Access Point started");
        Serial.print("AP IP: ");
        Serial.println(WiFi.softAPIP());
    } else {
        Serial.println("Failed to start Access Point");
    }

    // ======================
    // INICJALIZACJA WEBSOCKET
    // ======================
    ws.begin();

    // ======================
    // TASK FreeRTOS dla WebSocket
    // ======================
    xTaskCreatePinnedToCore(
        WebSocketTask,   // funkcja taska
        "WebSocketTask", // nazwa
        8192,            // stos
        NULL,            // argument
        1,               // priorytet
        NULL,            // uchwyt
        1                // core 1
    );

    Serial.println("System ready!");
}

// ======================
// LOOP
// ======================
void loop() {
    // Wszystko obsługuje task FreeRTOS
    vTaskDelay(10);
}
