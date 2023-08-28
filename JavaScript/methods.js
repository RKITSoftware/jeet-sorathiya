// methods.js

// Initialize an empty array
const array = [];

// Array Methods

// push into Array
document.getElementById("pushButton").addEventListener("click", function() {
  let valueToPush = prompt("Enter a value to push to the array:");
  valueToPush = +valueToPush;
  if (!isNaN(valueToPush)) {
    array.push(valueToPush);
    document.getElementById("arrayResult").textContent = "Array: " + array.join(", ");
  }
});

// pop into Array
document.getElementById("popButton").addEventListener("click", function() {
  if (array.length > 0) {
    const poppedValue = array.pop();
    document.getElementById("arrayResult").textContent = "Array: " + array.join(", ");
    document.getElementById("popResult").textContent = "Popped Element: " + poppedValue;
  } else {
    document.getElementById("arrayResult").textContent = "Array is empty, cannot pop.";
    document.getElementById("popResult").textContent = "";
  }
});

// slice into Array
document.getElementById("sliceButton").addEventListener("click", function() {
  if (array.length > 0) {
    const startIdx = parseInt(prompt("Enter the start index for slicing:"));
    const endIdx = parseInt(prompt("Enter the end index for slicing:"));
    
    if (!isNaN(startIdx) && !isNaN(endIdx)) {
      const slicedArray = array.slice(startIdx, endIdx);
      document.getElementById("arrayResult").textContent = "Array: " + array.join(", ");
      document.getElementById("popResult").textContent = "Sliced Array: " + slicedArray.join(", ");
    } else {
      document.getElementById("arrayResult").textContent = "Invalid input for slicing.";
      document.getElementById("popResult").textContent = "";
    }
  } else {
    document.getElementById("arrayResult").textContent = "Array is empty, cannot slice.";
    document.getElementById("popResult").textContent = "";
  }
});

// String Methods

// String Length
document.getElementById("lengthButton").addEventListener("click", function() {
  const inputString = document.getElementById("inputString").value;
  const stringLength = inputString.length;
  document.getElementById("stringResult").textContent = "String Length: " + stringLength;
});


// String UpparCase
document.getElementById("upperCaseButton").addEventListener("click", function() {
  const inputString = document.getElementById("inputString").value;
  const upperCaseString = inputString.toUpperCase();
  document.getElementById("stringResult").textContent = "String to Uppercase: " + upperCaseString;
});

// String LowerCase
document.getElementById("lowerCaseButton").addEventListener("click", function() {
  const inputString = document.getElementById("inputString").value;
  const lowerCaseString = inputString.toLowerCase();
  document.getElementById("stringResult").textContent = "String to Lowercase: " + lowerCaseString;
});
