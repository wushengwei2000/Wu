var assert = require("assert"),
unionfind = require('../modules/unionfind.js');


//Union Find Test;
describe.skip('unionfind', function(){
	it("unionfind should contain defintions of QuickFind, QuickUion and WeightedQuickUnion", function(){
		assert.equal(true, unionfind.hasOwnProperty("QuickFind"));
	})
});

//Running the following using mocha -u tdd -r spec 
suite('unionfind', function(){
	suite('quickFind', function(){
		var quickFind = new unionfind.QuickFind([0,1,2,3,4,5,6]);
		test('Index 0 , 3 and 6 are not connected', function(){
			assert.equal(false, quickFind.isConnected(0,6));
		});
		test('Connect 0 to 3 works fine', function(){
			quickFind.union(0,3);
			assert(true, quickFind.isConnected(0,3));
		});
		test('Connect 3 to 6 works fine', function(){
			quickFind.union(6,3);
			assert(true, quickFind.isConnected(6,3));
		});
		test('Connect 0vs3 and 3vs6 will connect 0 and 6', function(){
			assert(true, quickFind.isConnected(0,6));
		});
	});
});


