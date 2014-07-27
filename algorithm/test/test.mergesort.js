var util = require("../modules/util");
var mergeSort = require("../modules/mergesort.js");

var assert = require("assert");


describe("MergeSort Algorithm", function(){
	var randomInputArray = util.getRandomArray(50, 0, 100);

	it.skip("Array "+randomInputArray +" should be correctly sorted!", function(){
		var sortedArray = mergeSort.mergeSort(randomInputArray);
		assert.equal(true, util.isArraySorted(sortedArray));

		console.log("Merge Sort result is "+ sortedArray);
	});


	it("Array "+randomInputArray +" should be correctly sorted using Bottom up Mergesort!", function(){
		var sortedArray = mergeSort.mergeSortBottomUp(randomInputArray);
		assert.equal(true, util.isArraySorted(sortedArray));

		console.log("Merge Sort result is "+ sortedArray);
	});
})