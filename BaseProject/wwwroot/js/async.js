var curProduct = "noName";
function sendRequest(productName, first, second) {
    var httpRequest = new XMLHttpRequest(first, second);
    httpRequest.onreadystatechange = function () {
        if (httpRequest.readyState == XMLHttpRequest.DONE && httpRequest.status == 200) {
            var res = JSON.parse(httpRequest.responseText)
            var currentTable = document.getElementById(first);
            var currenttestdiv = document.getElementById(second);
            // 새로운 상품 조회시 기존 상품 삭제 
            if (curProduct != productName) {

                currenttestdiv.removeChild(currentTable);
                var newTable = document.createElement("table");
                newTable.setAttribute("id", "table");
                currenttestdiv.appendChild(newTable);
                curProduct = productName;
            }

            for (var i = 0; i < res.length; i++) {
                if (document.getElementById(res[i]["name"] + String(i)) != null) {
                    document.getElementById(res[i]["name"] + String(i)).remove();
                }
                var newTr = document.createElement("tr");
                newTr.setAttribute("id", res[i]["name"] + String(i))

                var newTd1 = document.createElement("td");
                var newTd2 = document.createElement("td");
                var newName = document.createTextNode(res[i]["name"]);
                var newCreateTime = document.createTextNode(res[i]["CreateTime"]);
                newTd1.appendChild(newName);
                newTd2.appendChild(newCreateTime);

                newTr.appendChild(newTd1);
                newTr.appendChild(newTd2);
                currentTable.insertAdjacentElement("afterbegin", newTr);
            }

        }
    };
    httpRequest.open("GET", "/product/filter?name=" + productName, true);
    httpRequest.send();
}

function findProduct() {
    getData = setInterval(function () {
        var productName = document.getElementById("productselect").value
        sendRequest(productName);
    }, 1000);
}