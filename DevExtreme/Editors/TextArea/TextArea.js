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

   const instTextArea = $("#textArea").dxTextArea({
        placeholder: "share your idea",
       hint: "text-Area",
        value: "jeet",
       maxLength: 500
   }).dxTextArea("instance");

    instTextArea.on("enterKey", function () {
        console.log(instTextArea.option("text"));
        console.log(instTextArea.option("value"));
    });

    const instResizeArea = $("#resizeArea").dxTextArea({
        hint: "resize-Area",
        autoResizeEnabled: true
    }).dxTextArea("instance");

    instResizeArea.on("change", changeHandler);
    instResizeArea.on("contentReady", contentReadyHandler);
    instResizeArea.on("copy", copyHandler);
    instResizeArea.on("cut", cutHandler);
    instResizeArea.on("enterKey", enterKeyHandler);
    instResizeArea.on("focusIn", focusInHandler);
    instResizeArea.on("focusOut", focusOutHandler);
    instResizeArea.on("initialized", initializedHandler);
    instResizeArea.on("input", inputHandler);
    instResizeArea.on("keyDown", keyDownHandler);
    instResizeArea.on("keyUp", keyUpHandler);
    //instResizeArea.on("optionChanged", optionChangedHandler);
    instResizeArea.on("paste", pasteHandler);
    instResizeArea.on("valueChanged", valueChangedHandler);
});