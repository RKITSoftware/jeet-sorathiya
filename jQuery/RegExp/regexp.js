// Creating RegExp objects using constructor and literals
const pattern1 = new RegExp("S JeEt");

let pattern2 = /S\sJEET/i;

// Using the test() method
var str = "abc bca ABC jeetS JeEt";
console.log(pattern1.test(str)); // true
console.log(pattern2.test(str)); // true

// Using the match() method
console.log(str.match(pattern2)); // ['S JeEt', index: 16, input: 'abc bca ABC jeetS JeEt', groups: undefined]

// Using the search() method
console.log(str.search(pattern2)); // 16

// Using the replace() method
let regexp1 = /morning/;
let regexp2 = /morning/g;

const strToReplace = "hello good morning jeet, your morning work in pending";
let replaced = strToReplace.replace(regexp1, "afternoon");
console.log(replaced); // hello good afternoon jeet, your morning work in pending
replaced = strToReplace.replace(regexp2, "afternoon");
console.log(replaced); // hello good afternoon jeet, your afternoon work in pending


// Using the split() method
const regexpSplit = /[,]/;
const strToSplit = "c++,c#,js,.netCore";
const parts = strToSplit.split(regexpSplit);
console.log(parts); // ['c++', 'c#', 'js', '.netCore']


const regexDigits1 = /\d+/g;
const strWithDigits = "1 abc  123 xydvoehoehgoigih 45iufeiuf6 fuiiuf";
console.log(strWithDigits.match(regexDigits1)); // ['1', '123', '45', '6']

