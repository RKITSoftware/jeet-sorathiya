import { menuData } from './data.js';
import { plainData } from './data.js';

$(function () {

    $("#tree").dxTreeView({
        displayExpr: "name",
       // rootValue:"2",
        disabledExpr: "demo",
        dataStructure: "plain",
        animationEnabled: true,
        createChildren(parent) {
            let parentId = parent ? parent.itemData.id : null;

            return new Promise((resolve, reject) => {
                setTimeout(() => {
                    let array = plainData.filter(val => val.parentId == parentId);
                    resolve(array);
                }, 1000);
            });
        },
        virtualModeEnabled: false,
    });

    $("#trainingTree").dxTreeView({
        items: menuData,
       // width: 80,
        displayExpr: "name",
        disabledExpr: "demo",
        expandAllEnabled: true,
        expandNodesRecursive: true,
       // scrollDirection: "both",
        searchEnabled: true,
        searchExpr: ["name"],
        searchMode: 'contains',//'contains' | 'startswith' | 'equals'
        selectByClick: true,
        selectionMode: 'multiple',
        showCheckBoxesMode: 'selectAll',
        onContentReady(e) {
            console.log("onContentReady", e);
        },
        onInitialized(e) {
            console.log("onInitialized", e);
        },
        onItemClick(e) {
            console.log("onItemClick", e);
        },
        onItemCollapsed(e) {
            console.log("onItemCollapsed", e);
        },
        onItemContextMenu(e) {
            console.log("onItemContextMenu", e);
        },
        onItemExpanded(e) {
            console.log("onItemExpanded", e);
        },
        onItemHold(e) {
            console.log("onItemHold", e);
        },
        onItemRendered(e) {
            console.log("onItemRendered", e);
        },
        onItemSelectionChanged(e) {
            console.log("onItemSelectionChanged", e);
        },
        onOptionChanged(e) {
            console.log("onOptionChanged", e);
        },
        onSelectAllValueChanged(e) {
            console.log("onSelectAllValueChanged", e);
        },
        onSelectionChanged(e) {
            console.log("onSelectionChanged", e);
        }
    });
});