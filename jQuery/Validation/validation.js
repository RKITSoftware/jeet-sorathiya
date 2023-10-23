$(document).ready(function () {
    $('#jobApplicationForm').validate({
        rules: {
            fullName: 'required',
            email: {
                required: true,
                email: true
            },
            phoneNumber: 'required',
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
                email: 'Please enter a valid email address'
            },
            phoneNumber: 'Please enter your phone number',
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
});
