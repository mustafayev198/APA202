function handleDuplicates(arr) {
  const uniqueArray = [...new Set(arr)];
  
  const duplicateCount = arr.length - uniqueArray.length;
  
  return {
    uniqueArray: uniqueArray,
    duplicateCount: duplicateCount
  };
}

console.log(handleDuplicates([1, 2, 2, 3, 4, 4, 4, 5])); 


function isPalindrome(word) {
  const lowerCaseWord = word.toString().toLowerCase();
  
  const reversedWord = lowerCaseWord.split('').reverse().join('');
  
  return lowerCaseWord === reversedWord;
}

console.log(isPalindrome("Ana")); 
console.log(isPalindrome("salam")); 


function countSmallerThanArrayElements(arr, num) {
  const largerElements = arr.filter(element => element > num);
  
  return largerElements.length;
}

console.log(countSmallerThanArrayElements([10, 20, 30, 40, 50], 25)); 



function checkAbundantOrDeficient(num) {
  if (num <= 0) return "Müsbət tam ədəd daxil edin";
  
  let sum = 0;
  
  for (let i = 1; i <= num / 2; i++) {
    if (num % i === 0) {
      sum += i;
    }
  }
  
  if (sum > num) {
    return "Abundant";
  } else {
    return "Deficient";
  }
}

console.log(checkAbundantOrDeficient(12)); 
console.log(checkAbundantOrDeficient(13)); 


function squareArrayElements(arr) {
  return arr.map(element => element * element);
  
}

console.log(squareArrayElements([2, 3, 4, 5])); 