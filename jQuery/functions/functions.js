$(document).ready(function() {
    // jQuery map() function example
    const numbers = [1, 2, 3, 4, 5];
    const squaredNumbers = $.map(numbers, function(num) {
        return num * num;
    });
    console.log("Squared Numbers (map function):", squaredNumbers);

    // jQuery grep() function example
    const filteredNumbers = $.grep(numbers, function(num) {
        return num % 2 === 0;
    });
    console.log("Filtered Numbers (grep function):", filteredNumbers);

    // jQuery extend() function example
    const obj1 = { name: "jeet" };
    const obj2 = { age: 20 };
    const mergedObject = $.extend({}, obj1, obj2);
    console.log("Merged Object (extend function):", mergedObject);

    // jQuery each() function example
    $('li').each(function(index) {
        console.log("Item (each function)" + (index + 1) + ": " + $(this).text());
    });

    // Callback function example
    function myCallback(data) {
        console.log("Callback executed with data:", data);
    }
    function performTask(callback) {
        setTimeout(function() {
            callback("Task completed!");
        }, 1000);
    }
    performTask(myCallback);

    // Deferred object example
    function asyncDeferredTask() {
        const deferred = $.Deferred();
        setTimeout(function() {
            deferred.resolve("Deferred task completed!");
        }, 2000);
        return deferred.promise();
    }
    const deferredPromise = asyncDeferredTask();
    deferredPromise.then(function(result) {
        console.log(result);
    });

    // Promise object example
    function asyncPromiseTask() {
        return new Promise(function(resolve, reject) {
            setTimeout(function() {
                resolve("Promise task completed!");
            }, 1500);
        });
    }
    const promise = asyncPromiseTask();
    promise.then(function(result) {
        console.log(result);
    });
});
