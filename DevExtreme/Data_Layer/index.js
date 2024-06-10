$(function () {

    var store = new DevExpress.data.ArrayStore({
        data: [
            { id: 1, name: "Jeet" },
            { id: 2, name: "Tony Stark" },
        ]
    });

    $("#div1").dxSelectBox({
        dataSource: store,
        valueExpr: "id",
        displayExpr: "name",
    });

});