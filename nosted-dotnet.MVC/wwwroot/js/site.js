// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// checklist js
// Venter på at HTML dokumentet blir ferdig loada
document.addEventListener("DOMContentLoaded", function () {
    // får en referanse til "Alle ok" knappene 
    const selectAllOkButtonMekanisk = document.getElementById("selectAllOkButtonMekanisk");
    const selectAllOkButtonHydraulisk = document.getElementById("selectAllOkButtonHydraulisk");
    const selectAllOkButtonElektrisk = document.getElementById("selectAllOkButtonElektrisk");

    // legger til en click event listener til hver knapp 
    selectAllOkButtonMekanisk.addEventListener("click", function () {
        // her blir alle ok knappene i mekanisk kategori trykka
        const okRadioButtonsMekanisk = document.querySelectorAll('.mekanisk');
        okRadioButtonsMekanisk.forEach(function (radioButton) {
            radioButton.checked = true;
        });
    });

    selectAllOkButtonHydraulisk.addEventListener("click", function () {
        // her blir alle ok knappene i hydraulisk kategori trykka
        const okRadioButtonsHydraulisk = document.querySelectorAll('.hydraulisk');
        okRadioButtonsHydraulisk.forEach(function (radioButton) {
            radioButton.checked = true;
        });
    });

    selectAllOkButtonElektrisk.addEventListener("click", function () {
        // her blir alle ok knappene i elektrisk kategori trykka
        const okRadioButtonsElektrisk = document.querySelectorAll('.elektrisk');
        okRadioButtonsElektrisk.forEach(function (radioButton) {
            radioButton.checked = true;
        });
    });
});

//Ordre slett

    function cancelAction() {
        // Redirect to the "Ordre" page
        window.location.href = '/Ordre';
    }

    // Attach the cancelAction function to the "Avbryt" button's click event
    document.getElementById('DeleteButton').addEventListener('click', cancelAction);


function cancelAction() {
    // Redirect to the "Ordre" page
    window.location.href = '/Ordre';
}

// Attach the cancelAction function to the "Avbryt" button's click event
document.getElementById('tilbakeButton').addEventListener('click', cancelAction);
