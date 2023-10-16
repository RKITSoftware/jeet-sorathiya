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
            resume: {
                required: true,
                extension: 'pdf'
            }
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
            resume: {
                required: 'Please upload your resume',
                extension: 'Only PDF files are allowed'
            }
        },
        errorPlacement: function (error, element) {
            error.insertBefore(element).addClass("text-danger");
        },
        submitHandler: function () {
            alert('Form submitted successfully');
        }
    });
});
