// Add an event listener to the form's submit event
document.getElementById("jobApplicationForm").addEventListener("submit", function (event) {

    // Prevent the form from submitting by default
    event.preventDefault();

    // Define validation rules for each field
    const validationRules = {
      fullName: {
        element: "fullName",
        errorElement: "fullNameError",
        required: true,
        message: "Full Name is Required.",
      },
      email: {
        element: "email",
        errorElement: "emailError",
        required: true,
        pattern: /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/,
        message: "Invalid Email.",
      },
      phoneNumber: {
        element: "phoneNumber",
        errorElement: "phoneError",
        required: true,
        pattern: /^\d+$/,
        message: "Invalid Phone Number.",
      },
      address: {
        element: "address",
        errorElement: "addressError",
        required: true,
        message: "Address is Required.",
      },
      role: {
        element: "role",
        errorElement: "roleError",
        required: true,
        isDefault: true, // Check if the default option is selected
        message: "Please select a Job Role.",
      },
      skills: {
        element: "role", 
        errorElement: "skillsError",
        required: true,
        minChecked: 1, // atleast 1 cheackBox is ticked
        message: "Please select at least one skill.",
      },
      resume: {
        element: "resume",
        errorElement: "resumeError",
        required: true,
        message: "Please upload your resume.",
      },
    };

    let hasErrors = false; // Flag to track validation errors

    // Reset error messages
    for (const field in validationRules) {
      document.getElementById(validationRules[field].errorElement).textContent = "";
    }

    // Validate each field
    for (const field in validationRules) {
      const rule = validationRules[field];
      const value = document.getElementById(rule.element).value.trim();

      // prevent user to pass empty value or select option Select in required field
      if (rule.required && (value === "" || (rule.isDefault && value === "Select"))) 
      {
        document.getElementById(rule.errorElement).textContent = rule.message;
        hasErrors = true;
      }
      // if pattern is set then cheak it
       else if (rule.pattern && !rule.pattern.test(value)) 
       {
        document.getElementById(rule.errorElement).textContent = rule.message;
        hasErrors = true;
      }
      // user checked aleast minimum required cheakBox
      else if (rule.minChecked && rule.element === "role") 
      {
        const checkedSkills = document.querySelectorAll('input[name="skills[]"]:checked').length;
        if (checkedSkills < rule.minChecked) {
          document.getElementById(rule.errorElement).textContent = rule.message;
          hasErrors = true;
        }
      }
    }

    // If there are errors, don't allow the form to submit
    if (hasErrors) {
      return;
    }

    // If there are no errors, allow the form to submit
    this.submit();
  });
