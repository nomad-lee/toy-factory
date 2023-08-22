import RPi.GPIO as GPIO
from signalrcore.hub_connection_builder import HubConnectionBuilder
import time
from time import sleep

servoPin = 17
SERVO_MAX_DUTY = 12
SERVO_MIN_DUTY = 3

hub_connection = HubConnectionBuilder() \
    .with_url('http://10.10.10.104:5297/iothub', options={"verify_ssl": False}) \
    .with_automatic_reconnect({
    "type": "interval",
    "keep_alive_interval": 10,
    "intervals": [1, 3, 5, 6, 7, 87, 3]
}) \
    .build()


def moveServo(kind):
    print(kind[0])
    if kind[0] == 2:
        print("dodo")
        sleep(2)
        setServoPos(180)
        sleep(1)
        setServoPos(0)


hub_connection.on("moveservo", moveServo)

hub_connection.start()

GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)

TRIG = 23
ECHO = 24
print("start")

GPIO.setup(TRIG, GPIO.OUT)
GPIO.setup(ECHO, GPIO.IN)
GPIO.setup(servoPin, GPIO.OUT)

servo = GPIO.PWM(servoPin, 50)
servo.start(0)


def setServoPos(degree):
    if degree > 180:
        degree = 180

    duty = SERVO_MIN_DUTY + (degree * (SERVO_MAX_DUTY - SERVO_MIN_DUTY) / 180.0)
    print("Degree: {} to {}(Duty)".format(degree, duty))

    servo.ChangeDutyCycle(duty)


GPIO.output(TRIG, False)
print("init")
time.sleep(2)

try:
    while True:
        GPIO.output(TRIG, True)
        time.sleep(0.00001)
        GPIO.output(TRIG, False)

        while GPIO.input(ECHO) == 0:
            start = time.time()

        while GPIO.input(ECHO) == 1:
            stop = time.time()

        check_time = stop - start
        distance = check_time * 34300 / 2
        print("Distance : %.1f cm" % distance)
        hub_connection.send("SendStatus", [distance])
        time.sleep(0.4)

except KeyboardInterrupt:
    print("quit")
    GPIO.cleanup()
