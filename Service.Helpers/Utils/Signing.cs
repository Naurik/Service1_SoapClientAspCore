using KalkanCryptCOMLib;
using Service.Helpers.Models;

namespace Service.Helpers.Utils{

	public static class Signing{

		public static string XorString(string source, int key){
			string resultString = "";
			for (int i = 0; i < source.Length; i++){
				int charValue = Convert.ToInt32(source[i]);
				charValue ^= key;
				resultString += char.ConvertFromUtf32(charValue);
			}
			return resultString;
		}
		
		public static byte[] StreamToByteArray(Stream input){
			byte[] buffer = new byte[16 * 1024];
			using (MemoryStream ms = new MemoryStream()){
				int read;
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0){
					ms.Write(buffer, 0, read);
				}
				return ms.ToArray();
			}
		}

		public static byte[] GetBytes(string str){
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		public static string GetString(byte[] bytes){
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}

		public static string SignWSSE(RequestModel model)
		{
			var filePath = "";
			if (!File.Exists(filePath))
				throw new FileNotFoundException("File not found");
			var pin = "";
			var kalkanCOM = new KalkanCryptCOM();
			kalkanCOM.Init();
			kalkanCOM.LoadKeyStore((int)KALKANCRYPTCOM_STORETYPE.KCST_PKCS12, pin, filePath, "");
			kalkanCOM.SignWSSE(model.Attr, 0, model.Xml, model.Attr, out string outSign);
			kalkanCOM.GetLastErrorString(out string err_str, out uint err);
			kalkanCOM.XMLFinalize();
			return outSign == null ? err_str : outSign;
		}

	}
}
