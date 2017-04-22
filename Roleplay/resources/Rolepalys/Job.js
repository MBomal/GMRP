var mark = null;
var blip = null;
API.onServerEventTrigger.connect(function (name, args) {
    if (name == "jobmarker") {

        var position = args[0];
        mark = API.createMarker(1, position, new Vector3(), new Vector3(), new Vector3(1, 1, 1), 255, 255, 0, 100);
        blip = API.createBlip(position);
    }
    if (name == "removeJobMarker") {
        if (API.doesEntityExist(mark)) API.deleteEntity(mark);
        if (API.doesEntityExist(blip)) API.deleteEntity(blip);
    }
});