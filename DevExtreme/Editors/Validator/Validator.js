$(function () {

    $("#name").dxTextBox({
         placeholder: "Enter Name"
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Enter Name"
        }, {
            type: "stringLength",
            min: 3,
            max: 20,
            message: "Enter Valid Name"
        }]
    });

    $("#number").dxTextBox({
        placeholder: "Enter Number"
    }).dxValidator({
        validationRules: [{
            type: "numeric",
            ignoreEmptyValue: false,
            message: "Enter Number"
        }, {
            type: "pattern",
            pattern: /^[6-9]\d{9}$/,
            message: "Enter Valid Number"
        }]
    });

    $("#exp").dxTextBox({
        placeholder: "Experience"
    }).dxValidator({
        validationRules: [{
            type: "range",
            min: 2,
            max: 10,
            reevaluate: false,
            message: "experience between 2 to 10 years required"
        }, {
            type: "numeric",
            ignoreEmptyValue: false,
            message: "Enter Experience"
        }]
    });

    $("#password").dxTextBox({
        placeholder: "Enter Password",
        onValueChanged: function () {
            let result = DevExpress.validationEngine.validateGroup("passwordGroup");
            console.log(result);
        }
    }).dxValidator({
        validationGroup: "passwordGroup",
        validationRules: [{
            type: "stringLength",
            min: 8,
            max: 16,
            message: "Password must be in between 8 to 16 char."
        }]
    });

    $("#confirm-Password").dxTextBox({
        placeholder: "ReEnter Password",
    }).dxValidator({
        validationGroup: "passwordGroup",
        validationRules: [{
            type: "compare",
            comparisonTarget: function () {
                const instPassword = $("#password").dxTextBox("instance")
                return instPassword.option("value");
            },
            message: "Not Match With Password"
        }]
    });

    $("#email").dxTextBox({
        placeholder: "Enter Email"
    }).dxValidator({
        validationRules: [{
            type: "email"
        }]
    });

    function checkUsernameAvailability(username) {
        // Simulate an async validation with a Promise
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                // Simulate a check with a list of existing usernames
                const existingUsernames = ["jeet", "tonystark"];
                if (existingUsernames.includes(username)) {
                    reject("Username already exists");
                } else {
                    resolve(true);
                }
            }, 1000); // Simulate a network delay
        });
    }

    $("#username").dxTextBox({
        placeholder: "Enter UserName"
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Username is required"
        }, {
            type: "async",
            message: "Username already exists",
            validationCallback: function (params) {
                return checkUsernameAvailability(params.value);
            }
        }]
    })

    var ageInput = $("#age").dxNumberBox({
        placeholder: "Enter your age",
        showSpinButtons: true,
    }).dxNumberBox("instance");

    // Initialize the Validator with an adapter
    ageInput.element().dxValidator({
        onValidated: function (e) {
            console.log("onValidated : ", e)
        },
        adapter: {
            getValue: function () {
                return ageInput.option("value");
                //  return -1;
            },
            applyValidationResults: function (result) {
                var messageElement = $("#age-validation-message");
                if (result.isValid) {
                    messageElement.hide();
                } else {
                    messageElement.text(result.brokenRule.message).show();
                }
            }
        },
        validationRules: [{
            type: "custom",
            message: "The age must be a number between 1 and 100",
            validationCallback: function (e) {
                var value = e.value;
                return value !== null && value >= 1 && value <= 100;
            }
        }]
    });

    // Trigger validation manually when the input loses focus
    ageInput.on("valueChanged", function () {
        ageInput.element().dxValidator("instance").validate();
    });
});

/* 
RangeRule : reevaluate

*/
