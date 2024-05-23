$(function () {
    const data = [{
        ID: 1,
        Name: 'Jeet',
        Role: 'Developer'
    }, {
        ID: 2,
        Name: 'Tony Stark',
        Role: 'Developer'
    }, {
        ID: 3,
        Name: 'Captain America',
        Role: 'Coordinator'
    }, {
        ID: 4,
        Name: 'Hulk',
        Role: 'Developer'
    }];

    const empData = [{
        ID: 1,
        Name: 'Jeet',
        Role: 'Developer'
    }, {
        ID: 2,
        Name: 'Tony Stark',
        Role: 'Developer'
    }, {
        ID: 3,
        Name: 'Captain America',
        Role: 'Coordinator'
    }, {
        ID: 4,
        Name: 'Hulk',
        Role: 'Developer'
    }];


    const groupData = [
        {
            key: "Developer",
            items: [
                {
                    ID: 1,
                    Name: 'Jeet',
                },
                {
                    ID: 2,
                    Name: 'Tony Stark'
                },
                {
                    ID: 4,
                    Name: 'Hulk'
                }]
        },
        {
            key: "Coordinators",
            items: [
                {
                    ID: 3,
                    Name: 'Captain America',
                    Role: 'Coordinator'
                }]
        }];

    const instBasicBox = $("#basicBox").dxSelectBox({
        dataSource: data,
        valueExpr: "ID",
        displayExpr: "Name",
        onValueChanged: function (e) {
            console.log("current value : ", e.value);
            console.log("previous Value", e.previousValue);
            console.log(instBasicBox.option("displayValue"));
        }
    }).dxSelectBox("instance");

    $("#groupBox").dxSelectBox({
        dataSource: groupData,
        hint: "grouped data",
        valueExpr: "ID",
        displayExpr: "Name",
        grouped: true,
        groupTemplate(data) {
            return $(`<div class='custom-icon'><span class='dx-icon-box icon'></span> ${data.key}</div>`);
        },
    });

    $("#itemsBox").dxSelectBox({
        items: data,
        hint: "items data",
        valueExpr: "ID",
        displayExpr: "Name",
        name: "employeeName"
    });

    $("#searchBox").dxSelectBox({
        dataSource: data,
        displayExpr: "Name",
        searchEnabled: true,
        // searchExpr: ["Role"]
        searchTimeout: 10,
        showClearButton: true,
        minSearchLength: 1,
        showDataBeforeSearch: false,
        // opened: true,
        showSelectionControls: true,
        spellcheck: true,
        wrapItemText: true
    });

    const productsDataSource = new DevExpress.data.DataSource({
        store: {
            data: empData,
            type: 'array',
            key: 'ID',
        },
    });

    $("#customBox").dxSelectBox({
        dataSource: productsDataSource,
        displayExpr: 'Name',
        valueExpr: 'ID',
        value: empData[0].ID,
        acceptCustomValue: true,
        onCustomItemCreating(data) {
            if (!data.text) {
                data.customItem = null;
                return;
            }
            const productIds = empData.map((item) => item.ID);
            const incrementedId = Math.max.apply(null, productIds) + 1;
            const newItem = {
                Role: "xyz",
                Name: data.text,
                ID: incrementedId,
            };
            data.customItem = productsDataSource.store().insert(newItem)
                .then(() => productsDataSource.load())
                .then(() => newItem)
                .catch((error) => {
                    throw error;
                });
        },
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
    function closedHandler() {
        console.log("box is closed");
    }
    function itemClickHandler() {
        console.log("item is click");
    }
    function openedHandler() {
        console.log("box is opened");
    }
    function selectionChangedHandler() {
        console.log("selection changed");
    }

    const instEventBox = $("#eventBox").dxSelectBox({
        items: data,
        valueExpr: "ID",
        displayExpr: "Name"
    }).dxSelectBox("instance");
    //customItemCreating

    instEventBox.on("change", changeHandler);
    instEventBox.on("contentReady", contentReadyHandler);
    instEventBox.on("closed", closedHandler);
    instEventBox.on("itemClick", itemClickHandler);
    instEventBox.on("opened", openedHandler);
    instEventBox.on("selectionChanged", selectionChangedHandler);
    instEventBox.on("copy", copyHandler);
    instEventBox.on("cut", cutHandler);
    instEventBox.on("enterKey", enterKeyHandler);
    instEventBox.on("focusIn", focusInHandler);
    instEventBox.on("focusOut", focusOutHandler);
    instEventBox.on("initialized", initializedHandler);
    instEventBox.on("input", inputHandler);
    instEventBox.on("keyDown", keyDownHandler);
    instEventBox.on("keyUp", keyUpHandler);
    //  instEventBox.on("optionChanged", optionChangedHandler);
    instEventBox.on("paste", pasteHandler);
    instEventBox.on("valueChanged", valueChangedHandler);
});