var util = require("./util.js")

//********** Merge Sort *********
//	Data Structure: 	Array[N] x 2
//	Algorithm: 		Iterate two sorted list, compare value and put into a holding array
//	Cost: 				
//***********************************

function MergeSort(){

}

MergeSort.prototype.sort = function(array, aux, low, high) {
	console.log("sorting array "+array + "from " + low + " to "+high);
	if(low>=high)
		return;

	var midIndex = Math.floor((high-low)/2) + low;
	this.sort(array, aux, low, midIndex);
	this.sort(array, aux, midIndex+1, high);
	this.merge(array, aux, low, midIndex, high);
};

MergeSort.prototype.merge = function(array, aux, low, mid, high) {
	console.log("Merging "+ array + "from "+low + " to "+high);
	for (var i = low; i <= high; i++) {
		aux[i]= array[i];
	};

	var indexLow = low;
	var indexHigh = mid+1;
	for (var i = low; i <= high; i++) {
		if(indexLow>mid){
			array[i]= aux[indexHigh];
			indexHigh++;
		}
		else if (indexHigh>high){
			array[i]= aux[indexLow];
			indexLow++;
		}
		else if(aux[indexLow]<=aux[indexHigh]){
			array[i] = aux[indexLow];
			indexLow++;
		}
		else
		{
			array[i]= aux[indexHigh];
			indexHigh++;
		}
	};
	console.log("Merge result is "+ array);
};

MergeSort.prototype.mergeSort = function(array) {
	var size = array.length;
	var aux = [size];	//Temp array for holding data for comparing
	this.sort(array, aux, 0, size-1);
	return array;
};


MergeSort.prototype.mergeSortBottomUp = function(array){
	var size = array.length;
	var aux = [size];
	for (var sz = 1; sz < size; sz=sz*2) {
		for (var i = 0; i < size-sz; i+=sz+sz) {
			this.merge(array,aux,i, i+sz-1,Math.min(i+sz+sz-1, size-1));
		};
	};
	return array;
}


module.exports = new MergeSort();

