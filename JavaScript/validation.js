function validateForm() {
    var fullName = document.getElementById("fullName").value;
    var email = document.getElementById("email").value;
    var phoneNumber = document.getElementById("phoneNumber").value;
    var address = document.getElementById("address").value;
    var role = document.getElementById("role").value;
    var skills = document.querySelectorAll('input[name="skills[]"]:checked');
    var resume = document.getElementById("resume").value;

    // Reset error messages
    document.getElementById("fullNameError").textContent = "";
    document.getElementById("emailError").textContent = "";
    document.getElementById("phoneError").textContent = "";
    document.getElementById("addressError").textContent = "";
    document.getElementById("roleError").textContent = "";
    document.getElementById("skillsError").textContent = "";
    document.getElementById("resumeError").textContent = "";

    // Validate full name
    if (fullName === "") {
        document.getElementById("fullNameError").textContent = "Full Name is Required.";
        return false;
    }

    // Validate email
    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    if (!email.match(emailPattern)) {
        document.getElementById("emailError").textContent = "Invalid Email.";
        return false;
    }

    // Validate phone number
    if (phoneNumber === "" || isNaN(phoneNumber)) {
        document.getElementById("phoneError").textContent = "Invalid Phone Number.";
        return false;
    }

    // Validate address
    if (address === "") {
        document.getElementById("addressError").textContent = "Address is .";
        return false;
    }

    // Validate role
    if (role === "Select") {
        document.getElementById("roleError").textContent = "Please select a Job Role.";
        return false;
    }

    // Validate skills
    if (skills.length === 0) {
        document.getElementById("skillsError").textContent = "Please select at least one skill.";
        return false;
    }

    // Validate resume
    if (resume === "") {
        document.getElementById("resumeError").textContent = "Please upload your resume.";
        return false;
    }

    return true; // Form is valid
}
