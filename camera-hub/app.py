import socket
import struct
import pickle
from signalrcore.hub_connection_builder import HubConnectionBuilder
import cv2
from av import VideoFrame
import torch
import base64
import myai

ip1 = 'http://10.10.10.104:5297/AiHub'
ip2 = 'http://10.10.10.104:5297/ImageHub'

hub_connection = HubConnectionBuilder() \
    .with_url(ip2, options={"verify_ssl": False}) \
    .with_automatic_reconnect({
    'http://10.10.10.104:5297/ImageHub'    "type": "interval",
    "keep_alive_interval": 10,
    "intervals": [1, 3, 5, 6, 7, 87, 3]
}) \
    .build()
hub_connection.start()

hub_connection1 = HubConnectionBuilder() \
    .with_url(ip1, options={"verify_ssl": False}) \
    .with_automatic_reconnect({
    'http://10.10.10.104:5297/AiHub'    "type": "interval",
    "keep_alive_interval": 10,
    "intervals": [1, 3, 5, 6, 7, 87, 3]
}) \
    .build()
hub_connection1.start()

model = torch.hub.load('ultralytics/yolov5', 'custom', 'best.pt')

data_buffer = b''
data_size = struct.calcsize('L')

s_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s_address = ('', 5000)
s_socket.bind(s_address)
s_socket.listen(1)
client, c_address = s_socket.accept()

print('connected by', c_address)

while True:
    while len(data_buffer) < data_size:
        data_buffer += client.recv(4096)

    packed_data_size = data_buffer[:data_size]
    data_buffer = data_buffer[data_size:]

    frame_size = struct.unpack(">L", packed_data_size)[0]

    while len(data_buffer) < frame_size:
        data_buffer += client.recv(4096)

    frame_data = data_buffer[:frame_size]
    data_buffer = data_buffer[frame_size:]

    frame = pickle.loads(frame_data)
    frame = cv2.imdecode(frame, cv2.IMREAD_COLOR)


    ret, send_frame = cv2.imencode('.jpg', frame, [cv2.IMWRITE_JPEG_QUALITY, 100])
    base64_encoded = base64.b64encode(send_frame).decode('utf-8')
    hub_connection.send("SendMessage", [base64_encoded])


    result, label, x, y = myai.run(model=model, origin_img=frame)
    new_frame = VideoFrame.from_ndarray(result, format="bgr24")

    new_frame = new_frame.to_ndarray()

    cv2.imshow("frame", new_frame)
    ret, send_frame1 = cv2.imencode('.jpg', new_frame, [cv2.IMWRITE_JPEG_QUALITY, 100])
    bytes = base64.b64encode(send_frame1).decode('utf-8')

    hub_connection1.send("SendMessage1", [bytes])





    if label is not None:
        score = int(float(label.split(' ')[1]) * 100)
        x = int(x)
        if 'NinjaStar' in label:
            hub_connection1.send("SendAi", [2, x, score])
            print("Label : NinjaStar" , "score : " , score)
        elif 'Boomerang' in label:
            hub_connection1.send("SendAi", [3, x, score])
            print("Label : Boomerang\n" + "score : " + str(score))


    key = cv2.waitKey(1) & 0xff
    if key == ord("q"):
        break

client.close()
s_socket.close()

cv2.destroyAllWindows()