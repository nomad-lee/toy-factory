// 센서 상태값
var blockStatus = 0;
var beltStatus = 0;
var upBeltStatus = 0;
var downBeltStatus = 0;

// IoT Hub 연결
var connection = new signalR.HubConnectionBuilder().withUrl("/iotHub").build();
connection.start().then(function () { console.log("연결 성공"); })
    .catch(function (err) {
        console.log("연결 실패" + err.toString());
    });

function BlockClick() {
    console.log("BlockClick");
    // 이미지 객체 가져오기
    var block = document.getElementById("block");
        // 상태의 따른 변화
            if (blockStatus === 0) {
                block.src = "/img/iot/down.png";
                blockStatus = 1;
                connection.send("Block", blockStatus)
            }
            else if (blockStatus === 1) {
                block.src = "/img/iot/up.png";
                blockStatus = 0;
                connection.send("Block", blockStatus)
            }
    }
    function BeltClick() {
            console.log("beltClick");
            var belt = document.getElementById("belt");
        if (beltStatus === 0) {
            belt.src = "/img/iot/beltMove.png";
            beltStatus = 1;
            connection.send("Belt_0ne", blockStatus)
        }
        else if (beltStatus === 1) {
            belt.src = "/img/iot/beltStop.png";
            beltStatus = 0;
            connection.send("Belt_0ne", blockStatus)
        }
    }
    function UpBeltClick() {
        console.log("beltClick");
        var belt = document.getElementById("upbelt");
        if (upBeltStatus === 0) {
        belt.src = "/img/iot/upMove.png";
            upBeltStatus = 1;
            connection.send("Belt_tow", blockStatus)
        }
        else if (upBeltStatus === 1) {
            belt.src = "/img/iot/upStop.png";
            upBeltStatus = 0;
            connection.send("Belt_tow", blockStatus)
        }
    }
    function DownBeltClick() {
        console.log("beltClick");
        var belt = document.getElementById("downbelt");
        if (downBeltStatus === 0) {
        belt.src = "/img/iot/downMove.png";
            downBeltStatus = 1;
            connection.send("Belt_three", blockStatus)
        }
        else if (downBeltStatus === 1) {
        belt.src = "/img/iot/downStop.png";
            downBeltStatus = 0;
            connection.send("Belt_three", blockStatus)
        }
    }
