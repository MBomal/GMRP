// DECLARATION
// Variables

let visageArray = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45];
let visageHom = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 24, 26, 30, 41, 42, 43, 44];
let visageFem = [21, 22, 23, 24, 25, 26, 27, 28, 29, 31, 33, 34, 35, 36, 37, 38, 39, 40, 45];
let hairArray = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36];
let hairColorArray = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63];
let eyeBrowArray = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32];
let colorArray = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24];
var checked = false;

// TO TRANSMIT AND SAVE IN DB

var visageMere = 0;
var visagePere = 0;
var visageColor = 0;
var cheveuxChar = 0;
var sexeChar = 0; // 1 = Homme, 2 = Femme
var colCheveux = 0;
var colYeux = 0;
var eyeBrow = 0;
var eyeBrowColor = 0;
var heritage = 0;
var charFirstName = "";
var charLastName = "";

//402.9543 -997.5 -98.15

var camZoom = API.createCamera(new Vector3(402.9543, -997.5, -98.15), new Vector3(-10, 0, 0));
API.setCameraFov(camZoom, 60);
var camFace = API.createCamera(new Vector3(402.9543, -998, -98.35), new Vector3(-10, 0, 0));
API.setCameraFov(camFace, 60)

// MENU

// Creation Menu

menuSexe = API.createMenu("Personnage", 3, 0, 6);
let accept = API.createMenuItem("ACCEPTER", "");

// Liste Choix du sexe

var sexeList = new List(String);
sexeList.Add("Homme");
sexeList.Add("Femme");
let listSexe = API.createListItem("Sexe", "Choix du Sexe", sexeList, 0);

// Choix Pere Mere ou Pas

let mix = API.createCheckboxItem("Heritage", "Choix de l'heritage", false);

// Liste Choix visage ( Heritage == False )

var visageList = new List(String);
for (var i = 0; i < visageArray.length; i++) {
    visageList.Add("Visage " + i);
};
let listVisage = API.createListItem("Visage", "Choix du visage", visageList, 0);

// Liste Choix visage Pere

var visage1List = new List(String);
for (var i = 0; i < visageHom.length; i++) {
    visage1List.Add("Visage " + i);
};
let listVisagePere = API.createListItem("Visage Pere", "Choix du visage du pere", visage1List, 0);

// Liste Choix couleur Visage

var visageColorList = new List(String);
for (var i = 0; i < visageArray.length; i++) {
    visageColorList.Add("Couleur " + i);
};
let listVisageColor = API.createListItem("Couleur Peau", "Choix de la couleur de peau", visageColorList, 0);

// Liste Choix visage Mere

var visage2List = new List(String);
for (var i = 0; i < visageFem.length; i++) {
    visage2List.Add("Visage " + i);
};
let listVisageMere = API.createListItem("Visage Mere", "Choix du visage de la mere", visage2List, 0);

// Liste Choix Cheveux

var hairList = new List(String);
for (var i = 0; i < hairArray.length; i++) {
    hairList.Add("Cheveux " + i);
};
let listHair = API.createListItem("Cheveux", "Choix des cheveux", hairList, 0);

// Liste Choix Couleur Cheveux

var hairColorList = new List(String);
for (var i = 0; i < hairColorArray.length; i++) {
    hairColorList.Add("Couleur  " + i);
};
let listColorHair = API.createListItem("Couleur Cheveux", "Choix Couleur Cheveux", hairColorList, 0);

// Liste Choix Couleur Yeux

var eyeColorList = new List(String);
for (var i = 0; i < colorArray.length; i++) {
    eyeColorList.Add("Couleur  " + i);
};
let listEyeColor = API.createListItem("Couleur Yeux", "Choix Couleur Yeux", eyeColorList, 0);

// Liste Sourcils

var eyeBrowList = new List(String);
for (var i = 0; i < eyeBrowArray.length; i++) {
    eyeBrowList.Add("Sourcils  " + i);
};
let listEyeBrow = API.createListItem("Sourcils", "Choix Sourcils", eyeBrowList, 0);

// Liste Couleurs Sourcils

var eyeBrowColorList = new List(String);
for (var i = 0; i < colorArray.length; i++) {
    eyeBrowColorList.Add("Couleur Sourcils  " + i);
};
let listEyeBrowColor = API.createListItem("Couleur Sourcils", "Choix Couleur Sourcils", eyeBrowList, 0);

// FONCTION
// Sexe

listSexe.OnListChanged.connect(function (sender, new_index) {
    switch (new_index) {
        case 0:
            {
                API.setPlayerSkin(1885233650);
                API.callNative("SET_PED_HEAD_BLEND_DATA", API.getLocalPlayer(), visagePere, visageMere, 0, visageColor, visageColor, 0, 0.5, 0.5, 0, true);
                API.setPlayerClothes(API.getLocalPlayer(), 6, 1, 0);
                API.setPlayerClothes(API.getLocalPlayer(), 2, cheveuxChar, 0);
                API.callNative("_SET_PED_HAIR_COLOR", API.getLocalPlayer(), colCheveux, colCheveux);
                API.callNative("_SET_PED_EYE_COLOR", API.getLocalPlayer(), colYeux);
                sexeChar = 1;
                API.setActiveCamera(camFace);
                break;


            }
        case 1:
            {
                API.setPlayerSkin(-1667301416);
                API.callNative("SET_PED_HEAD_BLEND_DATA", API.getLocalPlayer(), visagePere, visageMere, 0, visageColor, visageColor, 0, 0.5, 0.5, 0, true);
                API.setPlayerClothes(API.getLocalPlayer(), 2, cheveuxChar, 0);
                API.callNative("_SET_PED_HAIR_COLOR", API.getLocalPlayer(), colCheveux, colCheveux);
                API.callNative("_SET_PED_EYE_COLOR", API.getLocalPlayer(), colYeux);
                sexeChar = 2;
                API.setActiveCamera(camFace);
                break;
            }
    }
});

// Inherit

mix.CheckboxEvent.connect(function (sender, new_index) {
    switch (new_index) {
        case new_index:
            {
                if (checked == false) {
                    menuSexe.Clear();
                    menuSexe.AddItem(listSexe);
                    menuSexe.AddItem(mix);
                    menuSexe.AddItem(listVisagePere);
                    menuSexe.AddItem(listVisageMere);
                    menuSexe.AddItem(listVisageColor);
                    menuSexe.AddItem(listHair);
                    menuSexe.AddItem(listColorHair);
                    menuSexe.AddItem(listEyeColor);
                    menuSexe.AddItem(listEyeBrow);
                    menuSexe.AddItem(listEyeBrowColor);
                    menuSexe.AddItem(accept);
                    checked = true;
                }
                else if (checked == true) {
                    menuSexe.Clear();
                    menuSexe.AddItem(listSexe);
                    menuSexe.AddItem(mix);
                    menuSexe.AddItem(listVisage);
                    menuSexe.AddItem(listVisageColor);
                    menuSexe.AddItem(listHair);
                    menuSexe.AddItem(listColorHair);
                    menuSexe.AddItem(listEyeColor);
                    menuSexe.AddItem(listEyeBrow);
                    menuSexe.AddItem(listEyeBrowColor);
                    menuSexe.AddItem(accept);
                    checked = false;
                }
            }
    }
});


// Visage 

listVisage.OnListChanged.connect(function (sender, new_index) {
    switch (new_index) {
        case new_index:
            {
                visagePere = new_index;
                visageMere = new_index;
                API.callNative("SET_PED_HEAD_BLEND_DATA", API.getLocalPlayer(), visagePere, visageMere, 0, visageColor, visageColor, 0, 0.5, 0.5, 0, true);
                API.setActiveCamera(camFace);
                break;
            }
    }
});

// Visage Pere

listVisagePere.OnListChanged.connect(function (sender, new_index) {
    switch (new_index) {
        case new_index:
            {
                visagePere = visageHom[new_index];
                API.callNative("SET_PED_HEAD_BLEND_DATA", API.getLocalPlayer(), visagePere, visageMere, 0, visageColor, visageColor, 0, 0.5, 0.5, 0, true);
                API.setActiveCamera(camFace);
                break;
            }
    }
});

// Visage Mere

listVisageMere.OnListChanged.connect(function (sender, new_index) {
    switch (new_index) {
        case new_index:
            {
                visageMere = visageFem[new_index];
                API.callNative("SET_PED_HEAD_BLEND_DATA", API.getLocalPlayer(), visagePere, visageMere, 0, visageColor, visageColor, 0, 0.5, 0.5, 0, true);
                API.setActiveCamera(camFace);
                break;
            }
    }
});

// Visage Color

listVisageColor.OnListChanged.connect(function (sender, new_index) {
    switch (new_index) {
        case new_index:
            {
                visageColor = new_index;
                API.callNative("SET_PED_HEAD_BLEND_DATA", API.getLocalPlayer(), visagePere, visageMere, 0, visageColor, visageColor, 0, 0.5, 1, 0, true);
                API.setActiveCamera(camFace);
                break;
            }
    }
});

// Cheveux

listHair.OnListChanged.connect(function (sender, new_index) {
    switch (new_index) {
        case new_index:
            {
                cheveuxChar = hairArray[new_index];
                API.setPlayerClothes(API.getLocalPlayer(), 2, cheveuxChar, 0);
                API.setActiveCamera(camFace);
                break;
            }
    }
});

// Couleur Cheveux

listColorHair.OnListChanged.connect(function (sender, new_index) {
    switch (new_index) {
        case new_index:
            {
                colCheveux = new_index;
                API.callNative("_SET_PED_HAIR_COLOR", API.getLocalPlayer(), colCheveux, colCheveux);
                API.setActiveCamera(camFace);
                break;
            }
    }
});

// Couleur Yeux

listEyeColor.OnListChanged.connect(function (sender, new_index) {
    switch (new_index) {
        case new_index:
            {
                colYeux = new_index;
                API.callNative("_SET_PED_EYE_COLOR", API.getLocalPlayer(), colYeux);
                API.setActiveCamera(camZoom);
                break;
            }
    }
});

// Sourcils

listEyeBrow.OnListChanged.connect(function (sender, new_index) {
    switch (new_index) {
        case new_index:
            {
                eyeBrow = new_index;
                API.callNative("SET_PED_HEAD_OVERLAY", API.getLocalPlayer(), 2, eyeBrow, API.f(1));
                API.setActiveCamera(camZoom);
                break;
            }
    }
});

// Couleurs Sourcils

listEyeBrowColor.OnListChanged.connect(function (sender, new_index) {
    switch (new_index) {
        case new_index:
            {
                eyeBrowColor = new_index;
                API.callNative("_SET_PED_HEAD_OVERLAY_COLOR", API.getLocalPlayer(), 2, 1, eyeBrowColor, eyeBrowColor);
                API.setActiveCamera(camZoom);
                break;
            }
    }
});

// Apply

accept.Activated.connect(function (menu, item) {
    menuSexe.Visible = false;
    API.triggerServerEvent("CHARFINISHED", sexeChar, visageMere, visagePere, cheveuxChar, colCheveux, colYeux, visageColor, eyeBrow, eyeBrowColor, charLastName, charFirstName);
    menuSexe.Clear();
    API.setActiveCamera(null);

});

// AJOUTS





API.onServerEventTrigger.connect(function (eventName, args) {
    switch (eventName) {

        case 'StarCharacterCustomizationTrigger':
            // MISE EN PLACE

            /*API.triggerServerEvent("CHARSTARTCREATION");*/


            API.setActiveCamera(camFace);
            API.setPlayerSkin(1885233650);
            visageMere = 0;
            visagePere = 0;
            visageColor = 0;
            cheveuxChar = 0;
            sexeChar = 1; // 1 = Homme, 2 = Femme
            colCheveux = 0;
            colYeux = 0;
            eyeBrow = 0;
            eyeBrowColor = 2;
            API.setPlayerClothes(API.getLocalPlayer(), 6, 1, 0);
            API.callNative("SET_PED_HEAD_BLEND_DATA", API.getLocalPlayer(), 0, 0, 0, 0, 0, 0, 0.5, 0.5, 0, true);
            API.callNative("_SET_PED_HEAD_OVERLAY_COLOR", API.getLocalPlayer(), 2, 1, eyeBrowColor, eyeBrowColor);

            charLastName = API.getUserInput("Nom", 10);
            charFirstName = API.getUserInput("Prenom", 10);
            menuSexe.AddItem(listSexe);
            menuSexe.AddItem(mix);
            menuSexe.AddItem(listVisage);
            menuSexe.AddItem(listVisageColor);
            menuSexe.AddItem(listHair);
            menuSexe.AddItem(listColorHair);
            menuSexe.AddItem(listEyeColor);
            menuSexe.AddItem(listEyeBrow);
            menuSexe.AddItem(listEyeBrowColor);
            menuSexe.AddItem(accept);
            API.setMenuTitle(menuSexe, "Creation de Perso")

            menuSexe.Visible = true;
            break;
        case 'setplayerskin':
            //          0                       1                           2                       3                       4                           5                       6
            //characterdata.SexeChar, characterdata.VisageMere, characterdata.VisagePere, characterdata.CheveuxChar, characterdata.ColCheveux, characterdata.ColYeux, characterdata.VisageColor, 
            //          7                       8                           
            // characterdata.EyeBrown, characterdata.EyeBrownColor);

            if (args[0] == 1) {
                API.setPlayerSkin(1885233650);
            } else {
                API.setPlayerSkin(-1667301416);
            }
            API.callNative("SET_PED_HEAD_BLEND_DATA", API.getLocalPlayer(), args[2], args[1], 0, args[6], args[6], 0, 0.5, 0.5, 0, true);
            API.setPlayerClothes(API.getLocalPlayer(), 2, args[3], 0);
            API.callNative("_SET_PED_HAIR_COLOR", API.getLocalPlayer(), args[4], args[4]);
            API.callNative("_SET_PED_EYE_COLOR", API.getLocalPlayer(), args[5]);
            API.callNative("SET_PED_HEAD_OVERLAY", API.getLocalPlayer(), 2, args[7], API.f(1));
            API.callNative("_SET_PED_HEAD_OVERLAY_COLOR", API.getLocalPlayer(), 2, 1, args[8], args[8]);
    }
});

// SYNC DATA

API.onUpdate.connect(function () {

    API.drawMenu(menuSexe);

});


