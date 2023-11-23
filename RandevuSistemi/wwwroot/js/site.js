// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $(".silButon").on("click", function (e) {
        if (!confirm("Silmek İstiyormusunuz!")) {
            return false;
        }
    })
})