// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// checklist js
// Venter på at HTML dokumentet blir ferdig loada
document.addEventListener("DOMContentLoaded", function () {
    // får en referanse til "Alle ok" knappen 
    const selectAllOkButton = document.getElementById("selectAllOkButton");
    // legger til en click event listener til knappen 
    selectAllOkButton.addEventListener("click", function () {
      //her blir alle ok knappene trykka
        const okRadioButtons = document.querySelectorAll('input[type="radio"][value="1"]');
        // for løkke som går gjennom alle ok knappene 
        okRadioButtons.forEach(function (radioButton) {
            // sjekker at alle er selecta 
            radioButton.checked = true;
        });
    });
});
