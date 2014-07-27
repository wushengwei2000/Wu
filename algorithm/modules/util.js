
function Util(){
}

Util.prototype.isArraySorted = function(array) {
		for (var i = array.length - 1; i >0; i--) {
		if(array[i]<array[i-1])
			return false;
	};
	return true;
};

Util.prototype.getRandomArray = function(size, min, max) {
	var randomArray = [size];
	for(var i=0; i<size; i++)
		randomArray[i]= Math.floor(Math.random()*(max-min)+min);
	return randomArray;
};

Util.prototype.swapIndex = function(array, i, j) {
	var tmp = array[i];
	array[i] = array[j];
	array[j] = tmp;
};



module.exports = new Util();		//Export a single instance of Utility object.