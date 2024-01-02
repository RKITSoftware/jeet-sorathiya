// Function to handle form submission (login or sign up)
function HandleFormSubmission(event) {
    event.preventDefault();
    const username = document.getElementById("loginUsername").value;
    const password = document.getElementById("loginPassword").value;
    
    if (!username || !password) {
        alert("Please enter both username and password.");
        return;
    }
    // Check if the user exists in local storage
    const users = JSON.parse(localStorage.getItem("users"));

    const user = users.find((u) => u.username === username && u.password === password);

     // User exists, set session and redirect
    if (user) {
        sessionStorage.setItem("username", username);
        window.location.href = "dashboard.html";
    } 
    else {
        alert("Invalid username or password. Please sign up or try again.");
    }
}

// Function to handle user registration
function HandleRegistration(event) {
    event.preventDefault();
    const username = document.getElementById("signupUsername").value;
    const email = document.getElementById("signupEmail").value;
    const password = document.getElementById("signupPassword").value;

    if (!username || !email || !password) {
        alert("Please fill out all fields.");
        return;
    }

    // Check if the user exists in local storage
    const users = JSON.parse(localStorage.getItem("users"));

    const userExists = users.some((u) => u.username === username);

    if (userExists) {
        alert("Username already exists. Please choose a different one.");
    } 
     // User doesn't exist, add to local storage
    else {       
        users.push({ username, email, password });
        localStorage.setItem("users", JSON.stringify(users));

        // Set session and redirect to dashboard page
        sessionStorage.setItem("username", username);
        window.location.href = "dashboard.html";
    }
}

// form submit event listener for login form
const loginForm = document.getElementById("login-form");
loginForm.addEventListener("submit", HandleFormSubmission);

// form submit event listener for sign-up form
const signupForm = document.getElementById("signup-form");
signupForm.addEventListener("submit", HandleRegistration);
