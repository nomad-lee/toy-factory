import cv2
import socket
import pickle
import struct

cap = cv2.VideoCapture(0)

cap.set(cv2.CAP_PROP_FRAME_WIDTH, 320)
cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 320)
cap.set(cv2.CAP_PROP_FPS, 5)

s_address= ("10.10.10.104", 5000)
my_socket= socket.socket(socket.AF_INET, socket.SOCK_STREAM)
my_socket.connect(s_address)

while True:
    ret, frame = cap.read()

    ret, frame = cv2.imencode('.jpg', frame, [cv2.IMWRITE_JPEG_QUALITY, 100])
    frame = pickle.dumps(frame)

    my_socket.sendall(struct.pack(">L", len(frame)) + frame)

my_socket.close()
cap.release()
