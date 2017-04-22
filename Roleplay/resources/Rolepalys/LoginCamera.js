var mark = null;
var menus;
API.onServerEventTrigger.connect(function (name, args) {
    if (name == "createCamera") {
        var position = args[0];
        var rotation = args[1];
        var vinewoodCam = API.createCamera(position, rotation);
        
        API.setActiveCamera(vinewoodCam);
    }
    if (name == "exitCamera") {
        API.setActiveCamera(null);
    }
});