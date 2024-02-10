## Overview
---

This lab demonstrates SignalR

Create web project (mvc)

Add client library
```json
"provider": "unpkg",
"library": "@microsoft/signalr@latest",
"destination": "wwwroot/lib/microsoft/signalr/"
```
### Hub
* Create a new folder named *Hubs* in the root of the project
* Create a new class named *ChatHub* and interface shown below:
```C#
public interface IChatter
{
	void ReceiveText(string from, string text);
}

public class ChatHub : Hub<IChatter>
{
}
```

### Configure SignalR

Add SignalR to DI *Program.cs*
```c#
builder.Services.AddSignalR();
```

### HomeController

Inject the hub
Add another parameter to the constructor and store it in a private field (or use a primary constructor)

```c#
private readonly IHubContext<ChatHub, IChatter> _hub;

public HomeController(ILogger<HomeController> logger, IHubContext<ChatHub, IChatter> hub)
{
	_logger = logger;
	_hub = hub;
}
```

### Index.cshtml

Modify Index.cshtml as shown below.  The *chatter* div will be used to display messages.
The scripts are required to connect to the hub and send and receive messages.

```html
<div id="chatter"></div>
@section Scripts {
<script src="~/lib/microsoft/signalr/dist/browser/signalr.min.js"></script>
<script src="~/js/signalstuff.js"></script>
<script>
</script>
}
```

### Signalstuff.js

Create signalstuff.js in *wwwroot/js*
```javascript

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatter").build();


connection.on("GotMessage", function (user, message) {
    $("#chatter").html($("#chatter").html() +
        "<br/>" + user + ": -> " + message);

});

connection.start().then(function () {
    // alert("connection Started");
    connection.invoke("SendText", "Browser", "Hi you!");
}).catch(function (err) {
    return console.error(err.toString());
});
```

Run the application.  Open several browser windows.  The messages should appear in all windows.
