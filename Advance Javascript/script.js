// script.js
/* 
    BankAccount Class 
    Member : accountName, balance
    Method : Deposit, CanWithdraw

*/
class BankAccount {

    // BankAccount Class Constructor
    constructor(accountName) {
        this.accountName = accountName;
        this.balance = 0;
    }

    // Deposit money into the account
    Deposit = (amount) => {
        this.balance += amount;
    }

    // Check if a withdrawal is possible
    CanWithdraw = (amount) => {
        if (amount <= this.balance) {
            this.balance -= amount;
            return true;
        } else {
            return false; // Insufficient balance
        }
    }
}

let accounts = []; // Array to store accounts

// Create a new account
const CreateAccount = () => {
    const accountName = document.getElementById('accountName').value.trim(); // Trim leading/trailing whitespace
    const initialBalance = parseFloat(document.getElementById('balance').value);
    if (accountName && !isNaN(initialBalance)) {
        if (!FindAccount(accountName)) {
            const account = new BankAccount(accountName);
            account.Deposit(initialBalance);
            accounts.push(account);
            UpdateLocalStorage();
            document.getElementById('accountName').value = '';
            document.getElementById('balance').value = '';
            ListAccounts();
        } else {
            alert('Account already exists.');
        }
    }
}

// Add money to an existing account
const AddMoney = () => {
    const accountName = document.getElementById('withdrawAccountName').value.trim(); // Trim leading/trailing whitespace
    const amount = parseFloat(document.getElementById('withdrawAmount').value);
    if (accountName && !isNaN(amount)) {
        const account = FindAccount(accountName);
        if (account) {
            account.Deposit(amount);
            UpdateLocalStorage();
            ListAccounts();
        } else {
            alert('Account not found');
        }
        document.getElementById('withdrawAccountName').value = '';
        document.getElementById('withdrawAmount').value = '';
    }
}

 // Withdraw money from an existing account
const WithdrawMoney = () => {
    const accountName = document.getElementById('withdrawAccountName').value.trim(); // Trim leading/trailing whitespace
    const amount = parseFloat(document.getElementById('withdrawAmount').value);
    if (accountName && !isNaN(amount)) {
        const account = FindAccount(accountName);
        if (account) {
            const success = account.CanWithdraw(amount);
            if (success) {
                UpdateLocalStorage();
                ListAccounts();
            } else {
                alert('Insufficient balance');
            }
        } else {
            alert('Account not found');
        }
        document.getElementById('withdrawAccountName').value = '';
        document.getElementById('withdrawAmount').value = '';
    }
}

// Display a list of all accounts
const ListAccounts = () => {
    const accountList = document.getElementById('accountList');
    accountList.innerHTML = '';
    for (const account of accounts) {
        accountList.innerHTML += `
            <div class="card mb-3">
                <div class="card-body">
                    <h5 class="card-title">${account.accountName}</h5>
                    <p class="card-text">Balance: $${account.balance}</p>
                    <button onclick="DeleteAccount('${account.accountName}')" class="btn btn-danger">Delete Account</button>
                </div>
            </div>
        `;
    }
}

// Check if an account with the given name already exists
const FindAccount = (accountName) => {
    return accounts.find(account => account.accountName === accountName); // return object
}

// Delete a single account
const DeleteAccount = (accountName) => {
    const index = accounts.findIndex(account => account.accountName === accountName); // return index
    if (index !== -1) {
        accounts.splice(index, 1);
        UpdateLocalStorage();
        ListAccounts();
    }
}

// Delete all accounts
const DeleteAllAccounts = () => {
    accounts = [];
    UpdateLocalStorage();
    ListAccounts();
}

 // Update local storage when any new data is added/edited
const UpdateLocalStorage = () => {
    localStorage.setItem('accounts', JSON.stringify(accounts));
}

// Load accounts from local storage on page load
const storedAccounts = JSON.parse(localStorage.getItem('accounts'));
if (Array.isArray(storedAccounts)) {
    accounts = storedAccounts;
    ListAccounts();
}
