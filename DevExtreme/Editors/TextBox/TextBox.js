$(function () {

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
 

    $("#textBox").dxTextBox({
        hint: "text box",
        placeholder: "enter name",
        maxLength: 20,
        mode: "text"
    });
    $("#emailBox").dxTextBox({
        hint: "email box",
        placeholder: "enter email",
        maxLength: 20,
        mode: "email"
    });
    $("#passwordBox").dxTextBox({
        hint: "password box",
        placeholder: "enter password",
        maxLength: 20,
        mode: "password"
    });
    $("#searchBox").dxTextBox({
        hint: "search box",
        placeholder: "search password",
        maxLength: 20,
        mode: "search"
    });
    $("#telBox").dxTextBox({
        hint: "tel box",
        placeholder: "enter number",
        maxLength: 20,
        mode: "tel"
    });
    $("#urlBox").dxTextBox({
        hint: "url box",
        placeholder: "enter profile url",
        maxLength: 100,
        showClearButton: true,
        mode: "url"
    });
    function validation(input, index, string) {
        // console.log(input),
        // console.log(index),
        // console.log(string)
        const charAtA = string[0];
        if (charAtA === '1') {
            if (input == 0) {
                return true;
            }
            return false;
        }      
        return input >= 0 && input <= 9;
    }
    const instMaskBox = $("#maskBox").dxTextBox({
        hint: "SPI",
        placeholder: "enter SPI",
        mask: "AB.BB",
        useMaskedValue: true,
        showMaskMode: "onFocus",
        maskRules: {
            A: input => input <= 1,
            B: (input, index, string) => validation(input, index, string)
        },
        maskInvalidMessage: "enter valid SPI"
        //  maskChar: "-"
    }).dxTextBox("instance");

    instMaskBox.on("change", changeHandler);
    instMaskBox.on("contentReady", contentReadyHandler);
    instMaskBox.on("copy", copyHandler);
    instMaskBox.on("cut", cutHandler);
    instMaskBox.on("enterKey", enterKeyHandler);
    instMaskBox.on("focusIn", focusInHandler);
    instMaskBox.on("focusOut", focusOutHandler);
    instMaskBox.on("initialized", initializedHandler);
    instMaskBox.on("input", inputHandler);
    instMaskBox.on("keyDown", keyDownHandler);
    instMaskBox.on("keyUp", keyUpHandler);
    //instMaskBox.on("optionChanged", optionChangedHandler);
    instMaskBox.on("paste", pasteHandler);
    instMaskBox.on("valueChanged", valueChangedHandler);
   
});