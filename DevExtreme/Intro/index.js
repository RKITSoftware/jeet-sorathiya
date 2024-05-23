$(function () {
    $("#buttonContainer").dxButton({
        text: "Click me!",
        onClick: function () {
            alert("Hello world!");
        }
    });
});