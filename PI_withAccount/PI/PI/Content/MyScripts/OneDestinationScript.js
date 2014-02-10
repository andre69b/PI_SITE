function loadClick(image) {
    imageAlter = image;
    document.getElementById("imageAlter").setAttribute("src", image);
}
function loadOver(image) {
    document.getElementById("imageAlter").setAttribute("src", image);
}
function loadOut() {
    document.getElementById("imageAlter").setAttribute("src", imageAlter);
}

function click(array, dest, type) {
    var In = false;
    for (var i = 0; i < array.length; ++i) {
        var element = document.getElementById(array[i] + type);
        document.getElementById(array[i] + type).onclick = function (idx, e) {
            return function () {
                var long;
                var validate = false;
                if (type === "O")
                    long = document.getElementById("CheckIn").value;
                else
                    long = document.getElementById("CheckOut").value;
                if (long === "") {
                    validate = true;
                }
                else {
                    long = parseInt(long.substring(0, long.length - 1));
                    if (type === "I") {
                        var s = document.getElementById(array[idx] + type).id;
                        var actual = parseInt(s.substring(0, s.length - 1));
                        if (long >= actual)
                            validate = true;
                    }
                    else {
                        var s = document.getElementById(array[idx] + type).id;
                        var actual = parseInt(s.substring(0, s.length - 1));
                        if (long <= actual)
                            validate = true;
                    }
                }
                if (e.style.backgroundColor === "rgb(0, 255, 0)" && !In && validate) {
                    In = true;

                    console.log(In + "+" + type)
                    document.getElementById(dest).value = array[idx] + type;
                    e.style.backgroundColor = "#00FFFF";
                }
                else if (e.style.backgroundColor === "rgb(0, 255, 255)" && In) {
                    In = false;

                    document.getElementById(dest).value = "";
                    e.style.backgroundColor = "#00FF00";
                }
                else {
                    e.style.backgroundColor = "#00FF00";
                }

            }
        }(i, element);
    }
}
function updateobjectCallBack(element, objectCallBack, objectCallBack2) {
    console.log(element)
    if (element.id == "previousI") {
        objectCallBack.button = objectCallBack2.button;
        objectCallBack.type = objectCallBack2.type;
        objectCallBack.dest = objectCallBack2.dest;
    }
    if (element.id == "previousO") {
        objectCallBack.button = objectCallBack2.button;
        objectCallBack.type = objectCallBack2.type;
        objectCallBack.dest = objectCallBack2.dest;
    }
}

function registerObject(o, button, type, dest) {
    o["button"] = button;
    o["type"] = type;
    o["dest"] = dest;
}

function changeMonth(button, type, dest) {
    var objectCallBack = {};
    var objectCallBack2 = {};
    registerObject(objectCallBack, button, type, dest);
    registerObject(objectCallBack2, button, type, dest);
    document.getElementById(objectCallBack.button + objectCallBack.type).onclick =
        function callbackchangemonth() {
            updateobjectCallBack(this, objectCallBack, objectCallBack2);

            var request = new XMLHttpRequest();
            var id = document.URL.substring(document.URL.lastIndexOf('/') + 1, document.URL.length);
            var uri = "/Destination/ChangeMonth/" + id;
            var method = "GET";
            var year = document.getElementById("Year" + objectCallBack.type).textContent;
            var month = document.getElementById("Month" + objectCallBack.type).textContent;
            var params = "?Year=" + year + "&Month=" + month + "&Move=" + objectCallBack.button + "&Type=" + objectCallBack.type;
            request.onreadystatechange = (function () {
                if (this.readyState == 4) {
                    if (this.status == 200) {
                        document.getElementById(objectCallBack.dest).innerHTML = request.responseText;
                        if (type === "I") {
                            var type1 = "I";
                            var buttonnextI1 = "next";
                            var dest1 = "CalendarIn";
                            document.getElementById("nextI").onclick = function (b, t, d) {
                                registerObject(objectCallBack, b, t, d);
                                return callbackchangemonth;

                            }(buttonnextI1, type1, dest1);

                            var buttonpreviousO = "previous";
                            document.getElementById("previousI").onclick = function (b, t, d) {
                                registerObject(objectCallBack2, b, t, d);
                                return callbackchangemonth;
                            }(buttonpreviousO, type1, dest1);
                            var array1 = JSON.parse(document.getElementById("arrayI").textContent)
                            click(array1, "CheckIn", "I");
                            document.getElementById("CheckIn").value = "";
                        }
                        else {
                            var type2 = "O";
                            var buttonnextI2 = "next";
                            var dest2 = "CalendarOut";

                            document.getElementById("nextO").onclick = function (b, t, d) {
                                registerObject(objectCallBack, b, t, d);
                                return callbackchangemonth;

                            }(buttonnextI2, type2, dest2);

                            var buttonpreviousO2 = "previous";
                            document.getElementById("previousO").onclick = function (b, t, d) {
                                registerObject(objectCallBack2, b, t, d);
                                return callbackchangemonth;
                            }(buttonpreviousO2, type2, dest2);
                            var array2 = JSON.parse(document.getElementById("arrayO").textContent)
                            click(array2, "CheckOut", "O");
                            document.getElementById("CheckOut").value = "";
                        }
                    }
                }
            });

            request.open(method, uri + params);
            request.send();
        };
}

window.onload = function () {
    var array = JSON.parse(document.getElementById("CENA").textContent);

    for (var i = 0; i < array.length; i++) {
        var val = "../../Images/" + array[i];
        document.getElementById(array[i]).onclick = function (idx) {
            return function() {
                loadClick(idx);
            };
        }(val);
        document.getElementById(array[i]).onmouseover = function (idx) {
            return function() {
                loadOver(idx);
            };
        }(val);
        document.getElementById(array[i]).onmouseout = loadOut;
    }

    var s = JSON.parse(document.getElementById("arrayI").textContent)
    click(s, "CheckIn", "I");
    var s1 = JSON.parse(document.getElementById("arrayO").textContent)
    click(s1, "CheckOut", "O");

    changeMonth("next", "I", "CalendarIn");
    changeMonth("previous", "I", "CalendarIn");
    changeMonth("next", "O", "CalendarOut");
    changeMonth("previous", "O", "CalendarOut");

    document.getElementById("submitCalendar").onclick =
        function (event) {
            if (document.getElementById("CheckIn").value === "" || document.getElementById("CheckOut").value === "")
                return false;
        };

    document.getElementById("submitAppre").onclick =
        function (event) {
            var request = new XMLHttpRequest();
            var id = document.URL.substring(document.URL.lastIndexOf('/') + 1, document.URL.length);
            var uri = "/Destination/Appreciation/" + id;
            var method = "POST";
            var form = document.getElementById("AprreciationForm");
            var array = form.getElementsByTagName("input");
            var params = "";
            for (var i = 0; i < array.length; ++i) {
                if (i === array.length - 1)
                    params += array[i].name + "=" + array[i].value;
                else
                    params += array[i].name + "=" + array[i].value + "&";
            }
            params.replace(' ', '+');
            request.onreadystatechange = (function () {
                if (this.readyState == 4) {
                    if (this.status == 200) {
                        console.log(document.getElementById("AccountUserName"))
                        if (document.getElementById("AccountUserName") != null) {
                            document.getElementById("Apprecation").innerHTML += request.responseText;
                        }
                        else {
                            document.getElementById("erroLogin").innerHTML = "É necessário fazer login";
                        }
                    }
                }
            });

            request.open(method, uri);
            request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            request.send(params);
            return false;
        };
};