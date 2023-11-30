function replaceOddWithOdd(arr) {
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] % 2 !== 0) {
            arr[i] = 'odd';
        }
    }
}

// Sample array
const sampleArr = [9, 7, 3, 4, 2];

// Call the function
replaceOddWithOdd(sampleArr);

// Display the modified array
console.log(sampleArr);
