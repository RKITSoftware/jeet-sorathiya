$(function () {

    $("#btnLoad").dxButton({
        text: "load",
        onClick: () => { $("#data").text(""); loadPanel.show() }
    });
    const loadPanel = $("#loadPanel").dxLoadPanel({
        position: { of: '.container' },
       // position: // : 'bottom' | 'center' | 'left' | 'left bottom' | 'left top' | 'right' | 'right bottom' | 'right top' | 'top'
        hint: "wait",
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
            $("#data").text("Jeet Sorathiya");
        },
    }).dxLoadPanel('instance');
});