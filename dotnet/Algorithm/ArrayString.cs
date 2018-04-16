

public class ArrayStringAlgorithm{

//Implement an algorithm to determine if a string has all unique characters 
// What if you can not use additional data structures?
	public static bool StringAllUniqueCharacters(string input){
		if(string.IsNullOrEmpty(input))
			return false; //Consider empty non-unique 

		for(int i=0; i<input.Length(); i++)
			for(int j=i+1; j<input.Length; j++)
			{
				if(input[i]==input[j])
					return false;
			}
		return true;
	}

	public static bool StringContainsUnqiueCharsOnly(string input){
		bool[] flags = new bool[256];
		for(int i=0; i<input.Length; i++){
			if(flags[input[i]]) return false;
			flags[input[i]] = true;
		}
		return true;
	}

	public static bool StringContainsUnqiueCharsOnlyBit(string input){
		int checker =0;
		for(int i=0; i<input.Length; i++){
			int diff = input[i]- 'a';
			if((checker& 1<<diff)>0) return false;
			checker |= (1<<diff);
		}
		return true;
	}
//Write code to reverse a C-Style String 
//(C-String means that “abcd” is represented as five characters, including the null character )
	public static string ReverseString(string input){
		int midIndex = (input.Length+1)/2;
		int maxIndex = input.Length-1;
		for(int i=0; i<midIndex; i++){
			//Swap character 
			var tmp = input[i];
			input[i] = input[maxIndex-i];
			input[maxIndex-i] = tmp;
		}
		return input;
	}

//Design an algorithm and write code to remove the duplicate characters in a string without using any additional buffer
// NOTE: One or two additional variables are fine An extra copy of the array is not
//
	public static string RemoveDuplicate(string input){
		if(!string.IsNullOrEmpty(input)){
			int len = input.Length;
			for(int i=0; i<len; i++){
				for(int j=i+1; j<len; j++ ){
					if(input[j]==input[i]){

					}
				}

			}
		}
	}


	//Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, 
	//write a method to rotate the image by 90 degrees Can you do this in place?
	//

	public static int[][] RotateMatrix90Degree(int[][] matrix){
		
	}

}