var assert = require("assert"),
basicSorting = require("../modules/basicsorting.js");


//Test Using Basic Mocha style
describe("basicSorting.UtilityFunction", function(){
	var sortedArray = [1,2,3,4,5,7];
	var unsortedArray = [8,6,2,7,8,9,1];
	it(sortedArray + " is sorted", function(){
		assert(true, basicSorting.isSorted(sortedArray));
	});
	it(unsortedArray + " is not sorted", function(){
		assert.equal(false, basicSorting.isSorted(unsortedArray));
	});
})

describe("basicSorting.SelectionSort", function(){
	var randomArray = basicSorting.getRandomArray(20,1,100);
	it("Selection Sort of Random Array: "+randomArray, function(){
		var sortResult = basicSorting.selectionSort(randomArray);
		assert.equal(true, basicSorting.isSorted(sortResult));
		console.log("Selection Sort Result is "+ sortResult);
	})
})

describe("basicSorting.InsertionSort", function(){
	var randomArray = basicSorting.getRandomArray(20,1,100);
	it("InsertionSort of Random Array "+ randomArray, function(){
		var sortResult = basicSorting.insertionSort(randomArray);
		assert.equal(true, basicSorting.isSorted(sortResult));
		console.log("Insertion Sort Result is "+ sortResult);	
	})
})

describe("basicSorting.ShellSort", function(){
	var randomArray = basicSorting.getRandomArray(20,1,100);
	var gaps = [13,4,1];		//3x+1 implementations 4=3*1+; 13=3*4+13
	it("ShellSort of Random Array "+ randomArray +" with gaps "+ gaps, function(){
		var sortResult = basicSorting.shellSort(randomArray,gaps);
		assert.equal(true, basicSorting.isSorted(sortResult));
		console.log("ShellSort Sort Result is "+ sortResult);	
	})

	gaps = [19,5,1]; //SedgeWick 
	it("ShellSort of Random Array "+ randomArray +" with gaps "+ gaps, function(){
		var sortResult = basicSorting.shellSort(randomArray,gaps);
		assert.equal(true, basicSorting.isSorted(sortResult));
		console.log("ShellSort Sort Result is "+ sortResult);	
	})
})