                 <script>
                     // 허브 연결
                     const Imgconnection = new signalR.HubConnectionBuilder()
                                .withUrl("/imghub")
                                .build();

                    // 허브 연결 시작
                    Imgconnection.start().then(function(){
                        console.log("연결 성공");
                    }).catch(function(err){
                        console.log("연결 실패" + err.toString());
                    });

                    // 전달받을 메시지 지정
                    connection.on("전달받을 변수 이름", function(message) {
                        console.log(message)
                        //document.getElementById('tartgetImg').src = "data:image/jpeg;base64," + message;
                        //var li = document.createElement("li");
                        //li.textContent = `${message}`;

                        // li 추가
                        //document.getElementById("messageList").appendChild(li);
                    });


                    var status = 1;
                    function sendMesage() {
                        if(status === 0)
                        {
                            // 메시지 전송("함수명", "메시지")
                            Imgconnection.send("SendControl", status);
                            status = 1;
                        }
                        else if(status === 1)
                        {
                            {
                            Imgconnection.send("SendControl", status);
                            status = 0;
                            }
                        }
                        
                    }
                            Imgconnection.on("img", function(message) {
                                console.log(message);
                                if(message === 0)
                                {
                                    document.getElementById("Img").src = "/img/iot/zero.png";
                                }
                                else if (message === 1){
                                    document.getElementById("Img").src = "/img/iot/one.png";
                                }
                                else if (message === 2){
                                    document.getElementById("Img").src = "/img/iot/two.png";
                                }
                            });

                            // 전송받은 이미지 데이터 변환
                            //document.getElementById('Img').src = "data:image/jpeg;base64," + img;
                            //});
                            //Imgconnection.on("AiImg", function(img, label, x) {
                            //    document.getElementById('AiImg').src = "data:image/jpeg;base64," + img;
                            //    //if(label === null)
                            //    //{
                            //    //    document.getElementById("gif").src = "/img/iot/a_stop.jpg";
                            //    //}
                            //    //else{
                            //    //    document.getElementById("gif").src = "/img/iot/a_move.gif";
                            //    //}
                            //});
                 </script>   