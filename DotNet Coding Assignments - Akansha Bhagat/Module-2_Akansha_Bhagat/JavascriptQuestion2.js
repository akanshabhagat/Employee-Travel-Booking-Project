function displayEvenIndexesAndCount(arr) {
    let evenIndexes = [];
    let evenCount = 0;

    for (let i = 0; i < arr.length; i++) {
        if (arr[i] % 2 === 0) {
            evenIndexes.push(i);
            evenCount++;
        }
    }

    // Display the even index numbers
    console.log(`Index numbers of even numbers: ${evenIndexes.join(', ')}`);

    // Display the total count of even numbers
    console.log(`Total even numbers: ${evenCount}`);
}

// Sample array
const sampleArr = [9, 7, 3, 4, 2];

// Call the function
displayEvenIndexesAndCount(sampleArr);
