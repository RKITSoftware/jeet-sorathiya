// Function to set a cookie
function SetCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}

// Function to get all cookies
function GetAllCookies() {
    var cookies = document.cookie.split(';');
    var cookieList = [];

    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i].trim();
        cookieList.push(cookie);
    }
console.log(cookieList.length);
    return cookieList;
}


// Function to display cookies
function DisplayCookies() {
    var cookieList = GetAllCookies();
    var cookieListElement = document.getElementById("cookieList");

    // Clear the list
    cookieListElement.innerHTML = "";

    // Display each cookie in a list item
    for (var i = 0; i < cookieList.length; i++) {
        var listItem = document.createElement("li");
        listItem.className = "list-group-item";
        listItem.textContent = cookieList[i];

        // Add Delete button for each cookie
        var deleteButton = document.createElement("button");
        deleteButton.className = "btn btn-danger btn-sm float-right";
        deleteButton.textContent = "Delete";
        deleteButton.onclick = function () {
            // Extract cookie name from the list item's text
            var cookieName = this.parentNode.textContent.split("=")[0].trim();
            DeleteCookie(cookieName);
        };

        listItem.appendChild(deleteButton);
        cookieListElement.appendChild(listItem);
    }

}

// Function to delete a cookie by name
function DeleteCookie(name) {
    document.cookie = name + "=; expires=Thu, 22 May 2003 00:00:00 UTC; path=/;";
    DisplayCookies(); // Refresh the displayed cookies
}

// Set a cookie when the "Create Cookie" button is clicked
document.getElementById("setCookieBtn").addEventListener("click", function () {
    var cookieName = document.getElementById("cookieName").value;
    var cookieValue = document.getElementById("cookieValue").value;

    if (cookieName && cookieValue) {
        SetCookie(cookieName, cookieValue, 7); // Cookie expires in 7 days
        DisplayCookies();
        document.getElementById("cookieName").value = '';
        document.getElementById("cookieValue").value = '';
    }
});

// Display cookies on page load
DisplayCookies();
