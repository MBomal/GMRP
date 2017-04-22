var menuPool = null;
var draw = false;


API.onResourceStart.connect(function () {

});

API.onServerEventTrigger.connect(function (name, args) {

    if (name == "create_menu") {
        var SocialClub = null;
        var montantAjout = 0;
        var banner = args[0];
        var subtitle = args[1];
        var rank = 0;

        var menu = null;
        if (banner == null)
            menu = API.createMenu(subtitle, 0, 0, 6);
        else menu = API.createMenu(banner, subtitle, 0, 0, 6);

        var Nomliste = args[2];
        var ListeItem = args[3];
        let menuListe = new Array(Nomliste.Count);
        //Listes
        for (var i = 0; i < Nomliste.Count; i++) {
            API.sendChatMessage("Creation de liste");
            var liste = new List(String);
            for (var j = 0; j < ListeItem[i].Count; j++) {
                API.sendChatMessage("Creation de liste");
                liste.Add(ListeItem[i][j]);
            }
            menuListe[i] = API.createListItem(Nomliste[i], "", liste, 0);
            menu.AddItem(menuListe[i]);
        }
        //Items
        var items = args[4]
        for (var i = 0; i < items.Count; i++) {
            var listItem = API.createMenuItem(items[i], "");
            menu.AddItem(listItem);
        }
        //CheckBox
        var checkbox = args[5];
        let GodMode = API.createCheckboxItem(checkbox[0], "", false);
        let Invisible = API.createCheckboxItem(checkbox[1], "", false);
        menu.AddItem(GodMode);
        menu.AddItem(Invisible);

        //GestionListe
        
        let Selection = new Array(Nomliste.Count);
        var taille = Nomliste.Count;
        if (taille > 0) {
            Selection[0] = ListeItem[0][0];
            menuListe[0].OnListChanged.connect(function (sender, new_index) {
            switch (new_index) {
                case new_index:
                    {
                        Selection[0] = ListeItem[0][new_index];
                        API.sendChatMessage("" + Selection[0]);
                        break;
                    }
            }
            });
        }
        if (taille > 1) {
            Selection[1] = ListeItem[1][0];
            menuListe[1].OnListChanged.connect(function (sender, new_index) {
                switch (new_index) {
                    case new_index:
                        {
                            Selection[1] = ListeItem[1][new_index];
                            API.sendChatMessage("" + Selection[1]);
                            break;
                        }
                }
            });
        }
        if (taille > 2) {
            Selection[2] = ListeItem[2][0];
            menuListe[2].OnListChanged.connect(function (sender, new_index) {
            switch (new_index) {
                case new_index:
                    {
                        Selection[2] = ListeItem[2][new_index];
                        API.sendChatMessage("" + Selection[2]);
                        break;
                    }
            }
            });
        }
        menu.RefreshIndex();
        menu.OnItemSelect.connect(function (sender, item, index) {
            if (item.Text == "Give") {
                API.triggerServerEvent("givemoney", Selection[0], Selection[1])
            }
            if (item.Text == "AdminRank") {
                API.triggerServerEvent("setrank", Selection[0], Selection[2])
            }
            if (item.Text == "TP vers Joueur") {
                API.triggerServerEvent("tptoplayer", Selection[0])
            }
            if (item.Text == "TP le joueur") {
                API.triggerServerEvent("tpplayer", Selection[0])
            }
            if (item.Text == "Kick") {
                API.triggerServerEvent("kickplayer", Selection[0])
            }

            API.sendChatMessage("Index : " + item.Text);
        });
        GodMode.CheckboxEvent.connect(function (sender) {
            API.triggerServerEvent("invincible");
        });
        Invisible.CheckboxEvent.connect(function (sender) {
            API.triggerServerEvent("invisible");
        });

        API.onUpdate.connect(function () {
            API.drawMenu(menu);
        });

        menu.Visible = true;

    }
});


API.onUpdate.connect(function (sender, args) {

    if (menuPool != null) menuPool.ProcessMenus();
});