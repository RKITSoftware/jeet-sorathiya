$(function () {
    $("#popup").dxPopup({
        visible: false,
        closeOnOutsideClick: true,
        showTitle: true,
        title: "Alert",
        width: 300,
        height: 150,
        resizeEnabled: true,
        dragEnabled: false,
        position: "center",
        shading: true,
        shadingColor: "#ccc",
        showCloseButton: true,
        toolbarItems: [{
            widget: "dxButton",
            location: "after",
            options: {
                text: "Yes",
                onClick: function (e) { popup.toggle(false); }
            }
        }],
        contentTemplate: () => {
            const content = $("<div />");
            content.append(
                $(`<p>Are You Sure?</p>`)
            );
            return content;
        },
    });

    const popup = $("#popup").dxPopup("instance");

    $("#btn").dxButton({
        text: "Open popup",
        onClick: () => {
            popup.toggle(true);
        }
    });

});

