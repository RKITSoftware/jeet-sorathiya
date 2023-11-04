// Get the username from the session
const username = sessionStorage.getItem("username");
const welcomeUsername = document.getElementById("welcomeUsername");

if (username) {
    welcomeUsername.value = username;

    // Generate a unique cookie name based on the username
    const loginCountCookieName = `loginCount_${username}`;

    let loginCount = parseInt(getCookie(loginCountCookieName));
    loginCount++;

    // Set the login count cookie with the updated value
    setCookie(loginCountCookieName, loginCount, 30); // 30 is the number of days the cookie is valid
}
 else {
    window.location.href = "index.html";
}

// Redirect to login page if click logout
const logOut = document.getElementById("logout-btn");
logOut.addEventListener("click", function() {
    window.location.href = "index.html";
});

// Function to set a cookie
function setCookie(name, value, days) {
    const expires = new Date(Date.now() + days * 24 * 60 * 60 * 1000);
    document.cookie = `${name}=${value};expires=${expires.toUTCString()};path=/`;
}

// Function to get a cookie by name
function getCookie(name) {
    const cookieValue = document.cookie.split('; ').find(cookie => cookie.startsWith(name));
    console.log(cookieValue);

    return cookieValue.split('=')[1];
}

