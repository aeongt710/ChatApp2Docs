
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});


//var user = document.getElementById("userInput").value;
//var message = document.getElementById("messageInput").value;
//connection.invoke("SendMessage", user, message).catch(function (err) {
//    return console.error(err.toString());
//});


document.getElementById("sendButton").addEventListener("click", function (event) {
    //var user = document.getElementById("userId").value;
    console.log($('#userId').val());
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    //var connection = document.getElementById("connectionInput2").value;
    //connection.invoke("SendSpecificMessage", user, connection, message).catch(function (err) {
    //    return console.error(err.toString());
    //});
    event.preventDefault();
});
document.getElementById("sendButton2").addEventListener("click", function (event) {

    //var user = document.getElementById("userInput2").value;
    var message = document.getElementById("messageInput2").value;
    //var con = document.getElementById("connectionInput2").value;
    connection.invoke("SendSpecificMessage", $('#userId').val(),  message).catch(function (err) {
        return console.error(err.toString());
    });


    //var user = document.getElementById("userInput2").value;
    //var message = document.getElementById("messageInput2").value;
    //var connection = document.getElementById("connectionInput2").value;
    //connection.invoke("SendSpecificMessage",  user,  connection,  message).catch(function (err) {
    //    return console.error(err.toString());
    //});
    event.preventDefault();
});
//document.getElementById("sendButton2").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput2").value;
//    var message = document.getElementById("messageInput2").value;
//    var connection = document.getElementById("connectionInput2").value;
//    connection.invoke("SendSpecificMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});