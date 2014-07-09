var unionfind = require('./modules/unionfind.js');

var data = [0,1,2,3,4,5,6,7,8,9];
var size = [1,1,1,1,1,1,1,1,1,1];
var quickfind = new unionfind.QuickFind(data);
var quickunion = new unionfind.QuickUnion(data);
var weightedquickunion = new unionfind.WeightedQuickUnion(data,size);

// console.log("union 3,4 ");
// quickfind.union(3,4);
// console.log("union 4,5 ");
// quickfind.union(4,5); 
// console.log("Is 3 and 5 connected? : "+quickfind.isConnected(3,5));

// console.log("union 3,4 ");
// quickunion.union(3,4);
// console.log("union 4,5 ");
// quickunion.union(4,5); 
// console.log("Is 3 and 8 connected? : "+quickunion.isConnected(3,8));

console.log("union 3,4 ");
weightedquickunion.union(3,4);
console.log("union 4,5 ");
weightedquickunion.union(4,5); 
console.log("Is 3 and 5 connected? : "+weightedquickunion.isConnected(3,5));
console.log("Treesize is "+size);