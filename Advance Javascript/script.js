// script.js
/* 
    BankAccount Class 
    Member : accountName, balance
    Method : Deposit, CanWithdraw

*/
class BankAccount {
    constructor(accountName) {
        this.accountName = accountName;
        this.balance = 0;
    }

    Deposit(amount) {
        this.balance += amount;
    }

    CanWithdraw(amount) {
        if (amount <= this.balance) {
            this.balance -= amount;
            return true;
        } else {
            return false; // Insufficient balance
        }
    }
}

let accounts = []; // account array for store accounts

// create account if it not already exists
function CreateAccount() {
    const accountName = document.getElementById('accountName').value.trim(); // Trim leading/trailing whitespace
    const initialBalance = parseFloat(document.getElementById('balance').value);
    if (accountName && !isNaN(initialBalance)) {
        // Check if the account already exists
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

// add Money into existed account
function AddMoney() {
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
        document.getElementById('accountName').value = '';
        document.getElementById('depositAmount').value = '';
    }
}

// Withdraw Money into existed account
function WithdrawMoney() {
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

// List of All Accounts
function ListAccounts() {
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

// cheak if account is already exist
function FindAccount(accountName) {
    return accounts.find(account => account.accountName === accountName);
}

// delete only one account
function DeleteAccount(accountName) {
    const index = accounts.findIndex(account => account.accountName === accountName);
    if (index !== -1) {
        accounts.splice(index, 1);
        UpdateLocalStorage();
        ListAccounts();
    }
}


// delete all acounts
function DeleteAllAccounts() {
    accounts = [];
    UpdateLocalStorage();
    ListAccounts();
}

// this update localStorage when any new data add/edit
function UpdateLocalStorage() {
    localStorage.setItem('accounts', JSON.stringify(accounts));
}

// Load accounts from local storage on page load
const storedAccounts = JSON.parse(localStorage.getItem('accounts'));
if (Array.isArray(storedAccounts)) {
    accounts = storedAccounts;
    ListAccounts();
}

