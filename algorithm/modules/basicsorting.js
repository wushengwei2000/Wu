

function BasicSorting(){
}

BasicSorting.prototype.getRandomArray = function(size, min, max) {
	var randomArray = [size];
	for(var i=0; i<size; i++)
		randomArray[i]= Math.floor(Math.random()*(max-min)+min);
	return randomArray;
};

BasicSorting.prototype.isSorted = function(array) {
	for (var i = array.length - 1; i >0; i--) {
		if(array[i]<array[i-1])
			return false;
	};
	return true;
};

//********** Selection Sort *********
//	Data Structure: 	Array[N]
//	Algorithm: 		Interate Array to locate Array[min], swap with beginning of the interator 
//	Cost: 				
//***********************************
BasicSorting.prototype.selectionSort = function(data) {
	this.findMinIndex = function(array, startIndex){
		var minIndex = startIndex;
		for(var i=startIndex+1; i<array.length; i++){
			if(array[minIndex]>array[i])
				minIndex = i;
		}
		return minIndex;
	};

	var lenth = data.length;
	for(var i=0; i<lenth; i++){
		var currentVal = data[i];
		var minIndex = this.findMinIndex(data, i);
		data[i]= data[minIndex];
		data[minIndex]= currentVal;
	}
	return data;
};

//********** Insertion Sort *********
//	Data Structure: 	Array[N]
//	Algorithm: 		Interate the array and compare current pos val vs pos<current pos, swap value if current val is smaller
//	Cost: 				
//***********************************
BasicSorting.prototype.insertionSort = function(data) {
	var size = data.length;
	for (var i = 1; i < size; i++) {
		for(var j=i; j>0; j--){
			if(data[j]<data[j-1])
			{
				var tmp = data[j];
				data[j]=data[j-1];
				data[j-1] = tmp;
			}
			else 
				break;
		}
	};
	return data;
};

//********** Shell Sort *********
//	Data Structure: 	Array[N] with Step f(h)
//	Algorithm: 		Similar to Insertion Sort except instead of comparing vs pos before, it compares/swap with val[i-h]
//	Cost: 				
//***********************************
BasicSorting.prototype.shellSort = function(data,h) {
	var size = data.length;
	h.forEach(function(step){
		for(var i=step; i<data.length; i++){
			for(var j=i; j>=0; j-=step){
				if(data[j]<data[j-step]){
					var tmp = data[j];
					data[j] = data[j-step];
					data[j-step] = tmp;
				}
			}
		}
	})
	return data;
};


module.exports = new BasicSorting();









