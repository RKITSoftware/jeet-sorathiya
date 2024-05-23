$(function () {
    // set defaultOptions
    DevExpress.ui.dxCheckBox.defaultOptions({
        device: { deviceType: "desktop" },
        options: {
            height: 30, // set height
            width: "100vw", // set width
        }
    });

    // Configuration demo section
    $("#checkBox").dxCheckBox(); // create checkbox
    const instCheckBox = $("#checkBox").dxCheckBox("instance"); // store instance
    const domElement = instCheckBox.element(); // get element
    domElement.addClass("customClass"); // addClass to element

    // register key
    instCheckBox.registerKeyHandler("j", function () { console.log("J key") });

    $("#checkBox").dxCheckBox({
        text: "checkBox",
        accessKey: "j", // access using alt + [key]
        name: "checkbox", // set name attr to "input" tag
        elementAttr: {
            id: "chId", // replace id if exist
            class: "chClass", // append class if exist
            Jeet: "Js"     // add custom attr     
        },
        activeStateEnabled: false, // off active effect       
        hint: "DevExtreme", // tooltip
        hoverStateEnabled: false, //  hover effect
        // call when any prop. change
        onOptionChanged: function (e) { console.log(e.value) }

    });

    const instChecked = $("#checked").dxCheckBox({
        text: "checked", // this will not show
        name: "checked", // set name attr to "input" tag
        value: true, // set value      
        disabled: true, // make it disable       
        hint: "DevExtreme", // not worked with disable
        onInitialized: function () { // this is always called before onContentReady
            console.log("Checkbox initialized");
        },
        // call when content is ready
        onContentReady: function () { console.log("CheckBox Is Ready"); },
        // call when any option change
        onOptionChanged: function (e) { console.log(e.value) },
        // write label
        text: "rtlCheckBox", // this is show
        // start at right side
        rtlEnabled: true
    }).dxCheckBox("instance");

    const instDelete = $("#delete").dxCheckBox({
        text: "delete",
        focusStateEnabled: false, // not focus using [TAB] key
        readOnly: true, // make it readOnly but hover,focus worked
        // call after value changed
        onValueChanged: function () { $("#delete").dxCheckBox("dispose") },
        // call before Disposing
        onDisposing: function () { console.log("This CheckBox is deleted") },
    }).dxCheckBox("instance");

    const instMyCheckBox = $("#myCheckBox").dxCheckBox({
        text: "myCheckBox",
        visible: false, // hide CheckBox
        elementAttr: {
            class: "InVisibleBox"
        }
    }).dxCheckBox("instance");

    // instance work after id changed
    console.log(`checkBox.option() :`, instCheckBox.option());

    // Methods demo section
    const instDisposeMeBox = $("#disposeMeBox").dxCheckBox({
        text: "I Will Dispose"
    }).dxCheckBox("instance");

   const instDisposeBox = $("#disposeBox").dxCheckBox({
        text: "I Can Dispose Other",
        onValueChanged: function () {
            // $("#disposeMeBox").dxCheckBox("dispose");          
            $("#disposeMeBox").remove();
        }
   }).dxCheckBox("instance");

    instCheckBox.focus(); // focus on checkbox
    const x = DevExpress.ui.dxCheckBox.getInstance(domElement);
    console.log("x", x);
    
    const insteventBox = $("#eventBox").dxCheckBox({
        text: "events",
        value: false
       /* onValueChanged: opChanged*/
    }).dxCheckBox("instance");

    insteventBox.beginUpdate()  //
    // Attaching a click event handler
    insteventBox.on("valueChanged", function () {
        alert("Someone Click Me - (from single on)");
    });
    function opChanged() {
        console.log("optionChanged");
    }
    // Attaching multiple event handlers at once
    insteventBox.on({
        "valueChanged": function () {
            alert("Someone Click Me - 1 (from multiple event)");
        },
        "valueChanged": function () {
            alert("Someone Click Me - 2 (from multiple event)");
        },
        "optionChanged": opChanged
    })

    // Detaches all event handlers
    insteventBox.off("valueChanged");

    // Detaches specific evenet handler
    insteventBox.off("optionChanged", opChanged);

   // this not work??
    // insteventBox.off("valueChanged", opChanged);
    // log all options
    console.log(insteventBox.option());
   // console.log($("#eventBox").dxCheckBox("option"));

   // log text option value
    console.log(insteventBox.option("text"));
  // console.log($("#eventBox").dxCheckBox("option","text"));

  // change value
    insteventBox.option("height", "40px");
    insteventBox.on("valueChanged", function () {
        console.log("reset");
        insteventBox.reset(); // reset value
        // not work with true case
    });
    insteventBox.endUpdate()  //



    
});