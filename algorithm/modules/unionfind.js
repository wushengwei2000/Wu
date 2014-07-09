

//QuickFind
//Data Strcture: Array[N]
//Logic: Array[i]==Array[j] if i and j are connected 

exports.QuickFind = function (arraydata){			//Javascript Class definition method 1: using functions 
	this.arraydata = arraydata;
}

exports.QuickFind.prototype.isConnected = function(i, j){
	return this.arraydata[i]==this.arraydata[j];
}

exports.QuickFind.prototype.union = function(i, j) {
	if(!this.isConnected(i,j)){
		var vi = this.arraydata[i];
		var vj = this.arraydata[j];
		for (var i = this.arraydata.length - 1; i >= 0; i--) {
			if(this.arraydata[i]==vi)
				this.arraydata[i] = vj;
		};
	}
};

//Quick Union 
//Data Structure: Array[N]
//Logic: each position value contains its parent pos index and it is root element if the value equals position index 

exports.QuickUnion = function (arraydata){			 
	this.arraydata = arraydata;
}

exports.QuickUnion.prototype = {
	root: function(i){
		if(arraydata[i]==i)
			return i;
		else
			return this.root(this.arraydata[i]);	//Recursive Implementation
	},
	isConnected: function(i,j) {
		return this.root(i)==this.root(j);
	},
	union: function(i,j) {
		if(!this.isConnected(i,j)){
			this.arraydata[this.root(i)] = root(j);
		}
	}
}

//Weighted Quick Union 
//Data Structure: Array[N] X2
//Logic: connect smaller "tree" to larger tree (The other array store the treesize)

exports.WeightedQuickUnion =  function (arraydata, sizearray){
	this.arraydata = arraydata;
	this.sizearray = sizearray;
	this.root = function(i){
		while(i!=this.arraydata[i]) i= this.arraydata[i];	//Using loop 
		return i;
	}
}

exports.WeightedQuickUnion.prototype.isConnected = function(i,j) {
	return this.root(i)== this.root(j);
};

exports.WeightedQuickUnion.prototype.union = function(i,j) {
	if(!this.isConnected(i,j)){
		var rooti = this.root(i);
		var rootj = this.root(j);

		if(this.sizearray[rooti]<this.sizearray[rootj]){
			this.arraydata[rooti] = j;
			this.sizearray[rootj]+=this.sizearray[rooti];
		}else{
			this.arraydata[rootj] = i;
			this.sizearray[rooti]+=this.sizearray[rootj];
		}
	}
};



