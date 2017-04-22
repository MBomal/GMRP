API.onKeyDown.connect(function (sender, args) {

    if (args.KeyCode == Keys.F1) {
        API.triggerServerEvent("onKeyDown", 0);
    }
});