$(function () {
    // set defaultOptions
    DevExpress.ui.dxDateBox.defaultOptions({
        device: { deviceType: "desktop" },
        options: {
            // Here go the CheckBox properties
            //  height: 30, // set height
            //  width: "30%", // set width
        }
    });
    const instmyDateBox = $("#myDateBox").dxDateBox({
        text: "Enter DOB", // ?
        name: "nameAtr",
        readOnly: true,
        acceptCustomValue: false, // off custom typing,
        accessKey: ["j"],
        value: "2024-01-01",
        applyValueMode: "useButtons",
        openOnFieldClick: true,
        onContentReady: function () {
            console.log("content is ready");
        }
    }).dxDateBox("instance");

    instmyDateBox.on("copy", function () {
        console.log("Don't copy input");
    });
    instmyDateBox.on("cut", function () {
        console.log("Don't cut input");
    });
    instmyDateBox.on("focusIn", function () {
        console.log("focusIn");
    });
    instmyDateBox.on("enterKey", function () {
        console.log("Enter key");
    });
    instmyDateBox.on("focusOut", function () {
        console.log("focusout");
    });
    //instmyDateBox.on("blur", function () {
    //    console.log("blur");
    //});
    const instadaptivDateBox = $("#adaptivDateBox").dxDateBox({
        text: "Adaptive",
        disabled: true,
        openOnFieldClick: true
    }).dxDateBox("instance");
    // date
    const instnativeDateBox = $("#nativeDateBox").dxDateBox({
        pickerType: "native",
        openOnFieldClick: true,
        // opened: true, // ??
        onChange: function () { console.log("onChange"); },
        onClosed: function () { console.log("onClosed"); } // ??
    }).dxDateBox("instance");
    instnativeDateBox.on("input", function () {
        console.log("input is change");
    });
    instnativeDateBox.on("keyDown", function () {
        console.log("Key Is Down");
    });
    instnativeDateBox.on("keyUp", function () {
        console.log("Key Is Up");
    });
    //instnativeDateBox.on("optionChanged", function () { console.log("Option Changed"); })
    const instcalendarDateBox = $("#calendarDateBox").dxDateBox({
        pickerType: "calendar",
        spellcheck: true,
        text: "i am text", // ??
        showClearButton: true,
        openOnFieldClick: true,
        dateSerializationFormat: "yyyy-MM-ddTHH:mm:ss",
        disabledDates: [
            new Date("07/1/2024")
        ],
        min: new Date(2024, 0, 1),
        max: new Date(2024, 11, 31),
        dateOutOfRangeMessage: "Enter Date of this year only",
        //opened: true,
        onChange: function () { console.log("onChange"); },
        onClosed: function () { console.log("onClosed"); }


    }).dxDateBox("instance");
   // instcalendarDateBox.on("optionChanged", function (e) { console.log("Option Changed", e.name); })
    instcalendarDateBox.on("paste", function (e) {
        console.log("Paste", e);
        console.log("content", instcalendarDateBox.content());
        console.log("element", instcalendarDateBox.element());
    })
    instcalendarDateBox.focus();  
    
    setTimeout(function() {
        instcalendarDateBox.blur();
    } , 3000);
    const instrollersDateBox = $("#rollersDateBox").dxDateBox({
        pickerType: "rollers",
        placeholder: "Select Date",
        displayFormat: "EEEE, MMMM dd",
        useMaskBehavior: true,
        inputAttr: {
            class: "inputClass"
        },
        elementAttr: {
            class: "elementClass"
        },
        hint: "roller",
        applyButtonText: "Submit"


    }).dxDateBox("instance");

    const instlistDateBox = $("#listDateBox").dxDateBox({
        //pickerType: "list"

    }).dxDateBox("instance");
    // time
    const instnativeTimeBox = $("#nativeTimeBox").dxDateBox({
        // opened: true, ??
        pickerType: "native",
        type: "time"

    }).dxDateBox("instance");
    const instcalendarTimeBox = $("#calendarTimeBox").dxDateBox({
        //  pickerType: "calendar",
        type: "time"

    }).dxDateBox("instance");
    const instrollersTimeBox = $("#rollersTimeBox").dxDateBox({
        pickerType: "rollers",
        type: "time"

    }).dxDateBox("instance");
    const instlistTimeBox = $("#listTimeBox").dxDateBox({
        pickerType: "list",
        showClearButton: true,
        type: "time",
        interval: 1

    }).dxDateBox("instance");
    //
    const instnativeDateTimeBox = $("#nativeDateTimeBox").dxDateBox({
        pickerType: "native",
        // opened: true, ??
        type: "datetime"

    }).dxDateBox("instance");
    const instcalendarDateTimeBox = $("#calendarDateTimeBox").dxDateBox({
        pickerType: "calendar",
        showAnalogClock: false,
        showClearButton: true,
        type: "datetime"

    }).dxDateBox("instance");
    const instrollersDateTimeBox = $("#rollersDateTimeBox").dxDateBox({
        pickerType: "rollers",
        type: "datetime"

    }).dxDateBox("instance");
    const instlistDateTimeBox = $("#listDateTimeBox").dxDateBox({
        //  pickerType: "list",
        type: "datetime"

    }).dxDateBox("instance");

});