$(function () {

    // create button
    $("#deletebtn").dxButton({
        text: "Delete Me",
        onClick: function () {
            // dispose all class and attribute etc from UI but present in DOM
            $("#deletebtn").dxButton("dispose");
            // remove from DOM
           // $("#deletebtn").dxButton().remove();
        }
    });

    // create & store button instance into variable
    const button = $("#btn").dxButton().dxButton("instance");
    console.log("button", button);
    button.focus(); 
   
    const x = $("#btn").dxButton();
    console.log("x", x);
    x.focus();

    // set multiple prop. of button
    button.option({
        text: "Submit",
        // set events
        onClick: function () {
            // store all options into variable
            let btnProp = button.option();
            console.log(btnProp);
            // remove event
            button.option("onClick", undefined);
            console.log("click event is Disabled");
        }
    })

    // get text prop. of button
    let btnText = button.option("text");
    console.log(btnText);

    // set text prop. of button
    $("#btn").dxButton("option", "text", "Cancel");

    // calling method at focus time
    // $("#btn").dxButton().focus(function () { console.log("This button is Focused") });
    // this is not working??
    // button.focus(function () { console.log("This button is Focused") });

    // focus on button
    button.focus();
    
});
