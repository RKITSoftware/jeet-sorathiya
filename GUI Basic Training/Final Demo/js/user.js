// Display a list of all user
function displayData() {
    const storedUsers = JSON.parse(localStorage.getItem('users'));
    userList.innerHTML = '';
    for (const user of storedUsers) {
        userList.innerHTML += `
            <div class="card mb-3">
                <div class="card-body">
                    <h5 class="card-title">${user.username}</h5>
                    <p class="card-text">Email Id: ${user.email}</p>
                    <p class="card-text">Password: ${user.password}</p>
                    <button onclick="DeleteAccount('${user.username}')" class="btn btn-danger">Delete Account</button>
                </div>
            </div>
        `;
    }  
}

// Delete user
function DeleteAccount(username) {
    const storedUsers = JSON.parse(localStorage.getItem('users'));
    if(username === sessionStorage.getItem("username"))
    {
        window.location.href = "index.html";
    }
    // Find the index of the user with the matching username
    const userIndex = storedUsers.findIndex(user => user.username === username);

    if (userIndex !== -1) {
        // Remove the user from the array
        storedUsers.splice(userIndex, 1);

        // Update the data in local storage
        localStorage.setItem('users', JSON.stringify(storedUsers));

        // Refresh the displayed data
        displayData();       
        
    }
}

const userList = document.getElementById("data-container");
displayData();