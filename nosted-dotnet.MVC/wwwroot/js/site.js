// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Creates new rows

document.addEventListener('DOMContentLoaded', function () {
    var addButton = document.getElementById('addRowButton');
    var tableBody = document.querySelector('table tbody');
    var isButtonEnabled = true;

    addButton.addEventListener('click', function () {
        if (isButtonEnabled) {
            isButtonEnabled = false;

                var newRow = document.createElement('tr');
                // Create a new row
                newRow.innerHTML = `
                    <td>123123</td>
                    <td>12.11.2020</td>
                    <td>Hvertfall ikke en vinsj</td >
                    <td><a href="@Url.Action("Index", "ServiceSkjema")" class="btn btn-primary">Lag Serviceskjema</a></td >
                    <td><a href="@Url.Action("Index", "Checklist")" class="btn btn-primary">Lag Sjekkliste</a></td >
                    <td>01/01/0001</td>
                    <td>In Progress</td>
                `;

                // Append the new row to the table's tbody
                tableBody.appendChild(newRow);

                setTimeout(function () {
                    isButtonEnabled = true;
                }, 1000); // 1000 milliseconds = 1 second
            }
    });
});


