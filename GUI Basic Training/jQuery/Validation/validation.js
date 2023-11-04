$(document).ready(function () {
    $('#jobApplicationForm').validate({
        rules: {
            fullName: 'required',
            email: {
                required: true,
                isEmail: true
            },
            phoneNumber: {
                required: true,
                digits: true,
                minlength: 10,
                maxlength: 10,                
            },
            gender: 'required',
            address: 'required',
            role: 'required',
            'skills[]': 'required',
            resume: 'required'
        },
        messages: {
            fullName: 'Please enter your full name',
            email: {
                required: 'Please enter your email address',
                isEmail: 'Please enter a valid email address'
            },
            phoneNumber: {
                required: 'Please enter your phone number',
                digits: 'Please enter only digits.',
                minlength: 'Please enter a valid phone number',
                maxlength: 'Please enter a valid phone number'
               
            },
            gender: 'Please select your gender',
            address: 'Please enter your address',
            role: 'Please select a job role',
            'skills[]': 'Please select at least one skill',
            resume: 'Please upload your resume'
        },
        errorPlacement: function (error, element) {
            if(element.attr('type') == 'radio' )
            {
                const errorElement = $('[for=gender]');
                error.insertAfter(errorElement).addClass("text-danger");
            }
            else if(element.attr('type') == 'checkbox')
            {
                const errorElement = $('[for=skill]');
                error.insertAfter(errorElement).addClass("text-danger");
            }
            else
            {
                 error.insertBefore(element).addClass("text-danger");                
            }
        },
    });

    // add custom validation
    $.validator.addMethod("isEmail",function(value, element)
    {
        //console.log("Custom Validation Work");
        return /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/.test(value);
    });
});
