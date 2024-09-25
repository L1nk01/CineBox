// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(".read-more-text").each(function () {
        let hasOverflow = $(this)[0].scrollHeight > 68 || $(this).text().split(/\r\n|\r|\n/).length > 3;

        if (hasOverflow) $(this).next(".read-more").show();
    });

    $(".read-more").on('click', function () {
        $(this).prev(".read-more-text").toggleClass("show-content");

        var replaceText = $(this).prev(".read-more-text").hasClass("show-content") ? "Read Less" : "Read More";
        $(this).text(replaceText);
    });
});