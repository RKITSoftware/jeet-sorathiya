$(document).ready(function () {
    $('#jobApplicationForm').submit(function (e) {
        $('.error-message').empty(); 
        e.preventDefault(); 

        var fullName = $('input[name="fullName"]').val();
        var email = $('input[name="email"]').val();
        var phoneNumber = $('input[name="phoneNumber"]').val();
        var gender = $('input[name="gender"]:checked').val();
        var address = $('textarea[name="address"]').val();
        var role = $('select[name="role"]').val();
        var skills = $('input[name="skills[]"]:checked');
        var resume = $('input[name="resume"]').val();

        var errors = false;

        if (!fullName.trim()) {
            $('#fullNameError').text('Full Name is required.');
            errors = true;
        }

        if (!email.trim()) {
            $('#emailError').text('Email is required.');
            errors = true;
        } else if (!validateEmail(email)) {
            $('#emailError').text('Invalid email address.');
            errors = true;
        }

        if (!phoneNumber.trim()) {
            $('#phoneNumberError').text('Phone Number is required.');
            errors = true;
        }

        if (gender === undefined) {
            $('#genderError').text('Gender is required.');
            errors = true;
        }

        if (!address.trim()) {
            $('#addressError').text('Address is required.');
            errors = true;
        }

        if (role === '') {
            $('#roleError').text('Select a Job Role.');
            errors = true;
        }

        if (skills.length === 0) {
            $('#skillsError').text('Select at least one skill.');
            errors = true;
        }

        if (!resume.trim()) {
            $('#resumeError').text('Upload Your Resume is required.');
            errors = true;
        } 

        if (errors) {
            return false;
        } else {
            $('#jobApplicationForm').unbind('submit');
        }
    });
});

function validateEmail(email) {
    var emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    return emailRegex.test(email);
}

