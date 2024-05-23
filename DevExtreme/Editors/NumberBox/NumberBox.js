$(function () {
    $("#numberBox").dxNumberBox({
        placeholder: "Enter Number",
        focusStateEnabled: false,
        hint: "number",
        max: 100,
        min: 1,
        mode: "tel",
        showClearButton: true,
        showSpinButtons: true,
        useLargeSpinButtons: true,
        step: 10,
        stylingMode: "filled",
        onEnterKey: function () { console.log("option change"); },
        onValueChanged: function () { console.log("Value change"); },
        // validationStatus: "invalid"

    });

    $("#textBox").dxNumberBox({
        placeholder: "enter text",
        hint: "text",
        // max: 3,
        mode: "text",
        validationStatus: "pending"
    });

    $("#integerBox").dxNumberBox({
        format: '#'
    });

    $("#decimalBox").dxNumberBox({
        format: '#0.###'
    });

    $("#CurrencyBox").dxNumberBox({
        format: '₹#,##,##0.##'
    });

    $("#AccountingBox").dxNumberBox({
        format: '#,##0.#;(#,##0.##)'
    });

    $("#PercentBox").dxNumberBox({
        value: 0.15,
        format: '#.##%'
    });

    function changeHandler() {
        console.log("something is changed");
    }
    function contentReadyHandler() {
        console.log("content is ready");
    }
    function copyHandler() {
        console.log("don't copy");
    }
    function cutHandler() {
        console.log("don't cut");
    }
    function enterKeyHandler() {
        console.log("enterKey is press");
    }
    function focusInHandler() {
        console.log("getting focus");
    }
    function focusOutHandler() {
        console.log("losing focus");
    }
    function initializedHandler() {
        console.log("initialization done");
    }
    function inputHandler() {
        console.log("input");
    }
    function keyDownHandler() {
        console.log("keyDown");
    }
    function keyUpHandler() {
        console.log("keyUp");
    }
    function optionChangedHandler() {
        console.log("optionChanged");
    }
    function pasteHandler() {
        console.log("verified before paste");
    }
    function valueChangedHandler() {
        console.log("value is changed");
    }


    const instEventBox = $("#EventBox").dxNumberBox({

    }).dxNumberBox("instance");

    instEventBox.on("change", changeHandler);
    instEventBox.on("contentReady", contentReadyHandler);
    instEventBox.on("copy", copyHandler);
    instEventBox.on("cut", cutHandler);
    instEventBox.on("enterKey", enterKeyHandler);
    instEventBox.on("focusIn", focusInHandler);
    instEventBox.on("focusOut", focusOutHandler);
    instEventBox.on("initialized", initializedHandler);
    instEventBox.on("input", inputHandler);
    instEventBox.on("keyDown", keyDownHandler);
    instEventBox.on("keyUp", keyUpHandler);
    instEventBox.on("optionChanged", optionChangedHandler);
    instEventBox.on("paste", pasteHandler);
    instEventBox.on("valueChanged", valueChangedHandler);
});