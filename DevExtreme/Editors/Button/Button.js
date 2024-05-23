$(function () {

    function clickHandler() {
        console.log("clicked");
    }

    $("#textBtn").dxButton({
        text: 'info',
        icon: 'check',
        hint: "text",
        onClick: clickHandler,
        stylingMode: "text",
        type: "default"

        // disabled: true
    });

    $("#outlinedBtn").dxButton({
        text: 'delete',
        hint: "outlined",
        onClick: clickHandler,
        stylingMode: "outlined",
        type: "danger"

        // disabled: true
    });

    $("#containedBtn").dxButton({
        text: 'submit',
        hint: "contained",
        onClick: clickHandler,
        stylingMode: "contained",
        type: "success"
        // disabled: true
    })

    $("#normalBtn").dxButton({
        text: "click",
        type: "normal"
    })

    const instbackBtn = $("#backBtn").dxButton({
        type: "back"
    }).dxButton("instance");

    function clickHandler() {
        alert("Bye🙋🏻‍♂️");
    }

    function optionChangedHandler() {
        console.log("optionChanged");
    }

    instbackBtn.on("click", clickHandler)
   // instbackBtn.on("optionChanged", optionChangedHandler)
});