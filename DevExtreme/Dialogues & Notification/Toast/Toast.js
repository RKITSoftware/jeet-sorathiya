$(function () {

    const toast =  $("#toast").dxToast({
        message: "Hello",
        type: "success",
        displayTime: 6000,
        position: 'top center'
       // closeOnClick: true,
       // closeOnOutsideClick: true,
    }).dxToast('instance');

   

    $("#btnShow").dxButton({
        text: "show Toast",
        onClick() {
            toast.toggle(true);
        }
    })

    $("#btnHide").dxButton({
        text: "hide Toast",
        onClick() {
            toast.toggle(false);
        }
    })
});