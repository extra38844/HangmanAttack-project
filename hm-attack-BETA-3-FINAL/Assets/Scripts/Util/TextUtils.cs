using System;

namespace Util{
	
	public static class TextUtils {
		
		//is this character in the Uppercase alphabet?
		public static bool isUAlpha(char c){
			return c >= 'A' && c <= 'Z';
		}
		
		//.....................................................//
		
		//is this character in the Lowercase alphabet?
		public static bool isLAlpha(char c){
			return c >= 'a' && c <= 'z';
		}
		
		//.....................................................//
		
		////is this character in the Uppercase OR lowercase alphabet?
		public static bool isAlpha(char c){
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
		}
		
		//.....................................................//
	}
}