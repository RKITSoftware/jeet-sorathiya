import { menuData } from './data.js';

$(function () {
    $('#sheet').dxMenu({
        dataSource: menuData,
        displayExpr: 'name',
        adaptivityEnabled: true,
       // width: 500,
        animation: { show: { type: 'fade', from: 0, to: 1, duration: 100 }, hide: { type: 'fade', from: 1, to: 0, duration: 100 } },
        disabledExpr: "demo",
        selectedItem: menuData[0].items[1], 
       // selectedExpr: "reconcile",
        selectionMode: "single",
        hideSubmenuOnMouseLeave: false,
        orientation: 'horizontal', // 'vertical ', 'horizontal'
       // rtlEnabled: true,
        selectByClick: true,
        showFirstSubmenuMode: 'onHover',
        showSubmenuMode: 'onClick',
        submenuDirection: 'leftOrTop',
        onContentReady1(e) {
            console.log("onContentReady", e);
        },
        onInitialized1(e) {
            console.log("onInitialized", e);
        },
        onItemClick1(e) {
            console.log("onItemClick", e);
        },
        onItemContextMenu1(e) {
            console.log("onItemContextMenu", e);
        },
        onItemRendered1(e) {
            console.log("onItemRendered", e.itemData);
        },
        //onOptionChanged(e) {
        //    console.log("onOptionChanged", e);
        //},
        onSelectionChanged(e) {
            console.log("onSelectionChanged",e);
        },
        onSubmenuHidden1(e) {
            console.log("onSubmenuHidden", e);
        },
        onSubmenuHiding1(e) {
            console.log("onSubmenuHiding", e);
        },
        onSubmenuShowing1(e) {
            console.log("onSubmenuShowing", e);
        },
        onSubmenuShown1(e) {
            console.log("onSubmenuShown", e);
        },

    });
});
