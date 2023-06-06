using System.Text;

namespace Service.Helpers.Extensions{

	public static class StringExt{

		public static bool IsNullOrEmpty(this string str){
			return string.IsNullOrEmpty(str);
		}

		public static string ToNullString(this string str){
			return str.IsNullOrEmpty() ? "" : str;
		}

		public static void Add(this string str, string addStr){
			str += addStr;
		}

		public static string Trunc(this string str, int len){
			if(str == null) return null;
			return str.Length > len ? str.Substring(0,len) : str;
		}

		public static byte[] StringToByteArray(this string str){
			return Encoding.UTF8.GetBytes(str);
		}

		public static string StringToBase64String(this string str){
			byte[] data = Encoding.UTF8.GetBytes(str);
			return Convert.ToBase64String(data);
		}

	}
}
