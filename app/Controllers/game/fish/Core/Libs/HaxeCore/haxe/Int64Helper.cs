// Generated by Haxe 3.4.4

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe {
	public class Int64Helper : global::haxe.lang.HxObject {
		
		public Int64Helper(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Int64Helper() {
			global::haxe.Int64Helper.__hx_ctor_haxe_Int64Helper(this);
		}
		
		
		public static void __hx_ctor_haxe_Int64Helper(global::haxe.Int64Helper __hx_this) {
		}
		
		
		public static long parseString(string sParam) {
			unchecked {
				long @base = ((long) (10) );
				long current = ((long) (0) );
				long multiplier = ((long) (1) );
				bool sIsNegative = false;
				string s = sParam.Trim();
				if (string.Equals(global::haxe.lang.StringExt.charAt(s, 0), "-")) {
					sIsNegative = true;
					s = global::haxe.lang.StringExt.substring(s, 1, new global::haxe.lang.Null<int>(s.Length, true));
				}
				
				int len = s.Length;
				{
					int _g1 = 0;
					int _g = len;
					while (( _g1 < _g )) {
						int i = _g1++;
						int digitInt = ( (global::haxe.lang.StringExt.charCodeAt(s, ( ( len - 1 ) - i ))).@value - 48 );
						if (( ( digitInt < 0 ) || ( digitInt > 9 ) )) {
							throw global::haxe.lang.HaxeException.wrap("NumberFormatError");
						}
						
						long digit = ((long) (digitInt) );
						if (sIsNegative) {
							current = ((long) (( ((long) (current) ) - ((long) (( ((long) (multiplier) ) * ((long) (digit) ) )) ) )) );
							if ( ! ((((bool) (( ((long) (current) ) < 0 )) ))) ) {
								throw global::haxe.lang.HaxeException.wrap("NumberFormatError: Underflow");
							}
							
						}
						else {
							current = ((long) (( ((long) (current) ) + ((long) (( ((long) (multiplier) ) * ((long) (digit) ) )) ) )) );
							if (((bool) (( ((long) (current) ) < 0 )) )) {
								throw global::haxe.lang.HaxeException.wrap("NumberFormatError: Overflow");
							}
							
						}
						
						multiplier = ((long) (( ((long) (multiplier) ) * ((long) (@base) ) )) );
					}
					
				}
				
				return current;
			}
		}
		
		
		public static long fromFloat(double f) {
			unchecked {
				if (( global::System.Double.IsNaN(((double) (f) )) ||  ! (((  ! (global::System.Double.IsInfinity(((double) (f) )))  &&  ! (global::System.Double.IsNaN(((double) (f) )))  )))  )) {
					throw global::haxe.lang.HaxeException.wrap("Number is NaN or Infinite");
				}
				
				double noFractions = ( f - ( f % 1 ) );
				if (( noFractions > 9007199254740991 )) {
					throw global::haxe.lang.HaxeException.wrap("Conversion overflow");
				}
				
				if (( noFractions < -9007199254740991 )) {
					throw global::haxe.lang.HaxeException.wrap("Conversion underflow");
				}
				
				long result = ((long) (0) );
				bool neg = ( noFractions < 0 );
				double rest = ( (neg) ? ( - (noFractions) ) : (noFractions) );
				int i = 0;
				while (( rest >= 1 )) {
					double curr = ( rest % 2 );
					rest /= ((double) (2) );
					if (( curr >= 1 )) {
						result = ((long) (( ((long) (result) ) + (((long) (( ((long) (1) ) << i )) )) )) );
					}
					
					 ++ i;
				}
				
				if (neg) {
					result = global::haxe._Int64.Int64_Impl_.neg(result);
				}
				
				return result;
			}
		}
		
		
	}
}


