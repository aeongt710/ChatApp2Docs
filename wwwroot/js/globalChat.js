
var routeURL = location.protocol + "//" + location.host;

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();


connection.on("ReceivePublicMessage", function (message) {
    console.log(message);
    //var li = document.createElement("li");

    //document.getElementById("allMessages").appendChild('<div class="single-text sent"> < div class= "profile-pic" ><img src="~/img/vectors/person.png" alt=""></div>    <div class="text-content"><h5>Laurie</h5>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Voluptates, saepe?<span class="timestamp">12:00hrs</span></div>    </div > ');
    //li.textContent = `(Public) ${user} says ${message}`;
    //$('#allMessages').slideToggle();
    //$('#allMessages ').animate({ scrollTop: $('#allMessages')[0].scrollHeight }, 'slow');
    //$('html, body').animate({ scrollTop: $(document).height() }, 'slow');

    //$("#allMessages").append(`<div class="single-text sent"> <div class= "profile-pic" ><img src="/img/vectors/person.png" alt=""></div>    <div class="text-content"><h5>${user}</h5>${message}<span class="timestamp">12:00hrs</span></div>    </div > `);
    console.log(message);
});



connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});




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

    var requestData = {
        Text: $('#messageInput').val(),
    };

    $.ajax({
        url: routeURL + '/api/hubcontext/sendGlobalMessage',
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
const text = document.querySelectorAll(".text");
let delay = 0;
text.forEach(el => {
    el.style.animation = "fade-in 1s ease forwards";
    el.style.animationDelay = delay + "s";
    delay += 0.33;
});