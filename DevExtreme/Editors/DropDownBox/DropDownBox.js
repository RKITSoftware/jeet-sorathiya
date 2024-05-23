$(function () {
    const data = [
        {
            id: 1,
            name: "Jeet"
        },
        {
            id: 2,
            name: "Tony Stark"
        }
    ]
    const makeAsyncDataSource = function (jsonFile) {
        return new DevExpress.data.CustomStore({
            loadMode: 'raw',
            key: '_id',
            load() {
                return $.getJSON(`${jsonFile}`);
            },
        });
    };

    const instDropDown = $("#dropDown").dxDropDownBox({
        //  acceptCustomValue: true,
        //   value: "jeet", 
        // text: "jeet", ??
        dataSource: data,
        hint: "drop Down",
        displayExpr: "name",
        valueExpr: "id",
        placeholder: "Select Name",
        showClearButton: true,
        stylingMode: "filled",
        deferRendering: false, // data load immediately
        displayValueFormatter: function (value) {
            // console.log(value);
            if (value.length == 1)
                return "Name : " + value;
        },
        //fieldTemplate: function (value, fieldElement) {
        //    const result = $("<div class='custom-item'>");
        //    result
        //        .dxTextBox({
        //            value: value,
        //            readOnly: true
        //        });
        //    fieldElement.append(result);
        //},
        contentTemplate: (e) => {
            const $list = $("<div>").dxList({
                dataSource: e.component.getDataSource(),
                itemTemplate: function (item) {
                    return $("<div>").text(item.name);
                },
                onItemClick: (selected) => {
                    e.component.option("value", selected.itemData.id);
                    console.log("value : ", e.component.option("value"));
                    console.log("selected : ", selected);
                    e.component.close();
                }
            });
            return $list;
        }
    }).dxDropDownBox("instance");

    console.log("content", instDropDown.content());
    console.log("element", instDropDown.element());
    console.log("field", instDropDown.field());


    const instJsonBox = $("#jsonBox").dxDropDownBox({
        placeholder: "Select avenger",
        displayExpr: "name",
        valueExpr: "_id",
        dataSource: makeAsyncDataSource('Data.json'),
        contentTemplate: (e) => {
            selectionMode: 'multiple'
            const $list = $("<div>").dxList({
                dataSource: e.component.getDataSource(),
                itemTemplate: function (item) {
                    return $("<div>").text(item.name);
                },
                onItemClick: (selected) => {
                    e.component.option("value", selected.itemData._id);
                    //   e.component.option("value", selected.component.option('selectedItemKeys').join(', '));
                    console.log("value : ", e.component.option("value"));
                    console.log("selected : ", selected);
                    e.component.close();
                }
            });
            return $list;
        }
    }).dxDropDownBox("instance");

    function removeFocus() {
        instJsonBox.close();
        instJsonBox.blur();
    }
    instJsonBox.focus();
    instJsonBox.open();
    setTimeout(removeFocus, 5000);

    function changeHandler() {
        console.log("something is changed");
    }
    function closeHandler() {
        console.log("closed..");
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
    function openedHandler() {
        console.log("opened");
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

    const instEventBox = $("#eventBox").dxDropDownBox({
        dataSource: data,
        hint: "drop Down",
        displayExpr: "name",
        valueExpr: "id",
        placeholder: "Select Name",
        acceptCustomValue: true,
        showClearButton: true,
        onPaste: enterKeyHandler,
        contentTemplate: (e) => {
            const $list = $("<div>").dxList({
                dataSource: e.component.getDataSource(),
                itemTemplate: function (item) {
                    return $("<div>").text(item.name);
                },
                onItemClick: (selected) => {
                    e.component.option("value", selected.itemData.id);
                  //  console.log("value : ", e.component.option("value"));
                  //  console.log("selected : ", selected);
                    e.component.close();
                }
            });
            return $list;
        }
    }).dxDropDownBox("instance");

    instEventBox.on("change", changeHandler);
    instEventBox.on("closed", closeHandler);
    instEventBox.on("copy", copyHandler);
    instEventBox.on("cut", cutHandler);
    instEventBox.on("focusIn", focusInHandler);
    instEventBox.on("focusOut", focusOutHandler);
    instEventBox.on("initialized", initializedHandler);
    instEventBox.on("keyDown", keyDownHandler);
    instEventBox.on("keyUp", keyUpHandler);
    instEventBox.on("opened", openedHandler);
    instEventBox.on("paste", pasteHandler);
    instEventBox.on("valueChanged", valueChangedHandler);
    instEventBox.on("opened", openedHandler);
    instEventBox.on("enterKey", enterKeyHandler);
  
   
});