function countOccurrences(arr, num) {
    let count = 0;

    for (let i = 0; i < arr.length; i++) {
        if (arr[i] === num) {
            count++;
        }
    }

    return count;
}

// Sample array
const sampleArr = [9, 2, 3, 2, 1, 2];

// Number to count occurrences
const numberToCount = 2;

// Call the function
const occurrences = countOccurrences(sampleArr, numberToCount);

// Display the result
console.log(`Total occurrences of ${numberToCount} is: ${occurrences}`);
