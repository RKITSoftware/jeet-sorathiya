import { menuData } from './data.js';
let nextId = 10;
$(function () {

    function setPopupCustomOptions(item) {
        popup.option("title", "Add New Menu-Item");
        popup.option("menuType", item.isAdd);
        if (item.isAdd === "subMenu") {
            popup.option("title", "Add New SubMenu-Item");
            popup.option("subMenuId", item.id.split('_')[0]);
        }
        popup.toggle(true);
    }
    ///////////
    const menuInst = $("#menu").dxMenu({
        dataSource: menuData,
        displayExpr: 'name',
        onItemClick(e) {
            let item = e.itemData?.isAdd ? e.itemData : null;
            if (item) {
                setPopupCustomOptions(item);
            }
        }
    }).dxMenu("instance");

    let nameInst;
    $("#popup").dxPopup({
        visible: false,
        closeOnOutsideClick: true,
        showTitle: true,
      //  title: "Add New Menu-Item",
        width: 400,
        height: 150,
        position: "center",
        shading: true,
        shadingColor: "#ccc",
        showCloseButton: true,
        toolbarItems: [{
            widget: "dxButton",
            location: "after",
            options: {
                text: "Save",
                onClick: function () {
                    let menuType = popup.option("menuType");
                    const newName = nameInst.option("value");
                    nameInst.option("value", undefined);
                    if (newName) {                       
                        if (menuType === "firstMenu") {
                           
                            let index = menuData.length - 1;
                            let data = {
                                id: nextId, name: newName,
                                items: [{
                                    id: `${nextId++}_0`,
                                    name: 'Add New',
                                    icon: 'plus',
                                    isAdd: 'subMenu'
                                }]
                            };
                            menuData.splice(index, 0, data);
                            menuInst.option("dataSource", menuData);
                        }
                        else if (menuType === "subMenu") {
                           
                            let id = popup.option("subMenuId");
                            let data = menuData.find(val => val.id == id).items;
                            let newData = {
                                id: `${id}_${data.length + 2}`,
                                name: newName,
                            }
                            data.push(newData);
                            menuInst.option("dataSource", menuData);
                        }
                    }
                    loadPanel.show();                   
                }
            }
        }],
        contentTemplate: (container) => {
            container.append(`<div id="name"></div>`);
            nameInst = $("#name").dxTextBox({
                placeholder: "Enter menu item name",
            }).dxTextBox("instance");
        },
    });
    const popup = $("#popup").dxPopup("instance");

    const popover = $("#popover").dxPopover({
        target: '#target',
        showEvent: 'mouseenter',
        hideEvent: 'mouseleave',
        position: 'right',
        height: 150,
    }).dxPopover("instance");

    const loadPanel = $("#loadPanel").dxLoadPanel({
        position: { of: '#popup' },
        position: 'center',
        visible: false,
        showIndicator: true,
        indicatorSrc: "../image/Pendulum.gif",
        showPane: true,
        shading: true,
        shadingColor: 'rgba(0,0,0,0.4)',
        onShown() {
            setTimeout(() => {
                loadPanel.hide();
            }, 3000);
        },
        onHidden() {
            popup.toggle(false);
            toast.show();
        }
    }).dxLoadPanel('instance');

    const toast = $("#toast").dxToast({
        message: "New Training Topic Added",
        animation: { hide: { type: 'fade', duration: 3000, from: 1, to: 0 } },
        type: "success",
        width: 200,
        displayTime: 200,
        position: 'top right'
    }).dxToast('instance');

});

