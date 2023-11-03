// Function to initialize form validation for the login and sign-up forms
function initFormValidation() {

    $("#login-form").validate({
        rules: {
            loginUsername: {
                required: true,
            },
            loginPassword: {
                required: true,
            },
        },
        messages: {
            loginUsername: "Please enter your username",
            loginPassword: "Please enter your password",
        },
        errorPlacement: function (error, element) {
            error.insertAfter(element).addClass("text-danger");
        },
    });

    $("#signup-form").validate({
        rules: {
            signupUsername: {
                required: true,
            },
            signupEmail: {
                required: true,
                isEmail: true,
            },
            signupPassword: {
                required: true,
            },
        },
        messages: {
            signupUsername: "Please choose a username",
            signupEmail: {
                required: "Please enter your email",
                isEmail: "Please enter a valid email address",
            },
            signupPassword: "Please create a password",
        },
        errorPlacement: function (error, element) {
            error.insertAfter(element).addClass("text-danger");
        },
    });

    // add custom validation
    $.validator.addMethod("isEmail", function (value, element) {
        //console.log("Custom Validation Work");
        return /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/.test(value);
    });
}

$(document).ready(function () {
    initFormValidation();
});
