
var routeURL = location.protocol + "//" + location.host;

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

//document.getElementById("sendButton").disabled = true;

connection.on("ReceivePublicMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `(Public) ${user} says ${message}`;
});

connection.on("ReceivePrivateMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `(Private) ${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});



//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});

//document.getElementById("sendButton2").addEventListener("click", function (event) {
//    var message = document.getElementById("messageInput2").value;
//    connection.invoke("SendSpecificMessage", $('#userId').val(),  message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});

function sendPrivateMessage() {

    var requestData = {
        Text: $('#messageInput2').val(),
        ReceiverName: $('#userId').val()
    };

    $.ajax({
        url: routeURL + '/api/hubcontext/sendPrivateMessage',
        type: 'POST',
        data: JSON.stringify(requestData),

        contentType: 'application/json',
        success: function (response) {
            console.log("respnse is ", response);
        },
        error: function (xhr) {
            console.log("Error Occured", xhr);
        }
    });
}

function sendGloablMessage() {
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();


    //var requestData = {
    //    Text: $('#messageInput').val(),
    //};

    //$.ajax({
    //    url: routeURL + '/api/hubcontext/sendGlobalMessage',
    //    type: 'POST',
    //    data: JSON.stringify(requestData),

    //    contentType: 'application/json',
    //    success: function (response) {
    //        console.log("respnse is ",response);
    //    },
    //    error: function (xhr) {
    //        console.log("Error Occured",xhr);
    //    }
    //});
}
//const text = document.querySelectorAll(".text");
//let delay = 0;
//text.forEach(el => {
//    el.style.animation = "fade-in 1s ease forwards";
//    el.style.animationDelay = delay + "s";
//    delay += 0.33;
//});