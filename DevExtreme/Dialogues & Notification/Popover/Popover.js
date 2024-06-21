$(function () {
  const popover =  $("#popover").dxPopover({
        target: '#target',
        showTitle: true,
        title: 'Details:',
        showEvent: 'mouseenter',
        hideEvent: 'mouseleave',
        position: 'bottom',
        width: 300,
       // showCloseButton: true,
        //toolbarItems: [{
        //    widget: "dxButton",
        //    location: "after",
        //    options: {
        //        text: "Close",
        //        onClick: function (e) {  popover.toggle(false); }
        //    }
        //}],
    }).dxPopover("instance");
});