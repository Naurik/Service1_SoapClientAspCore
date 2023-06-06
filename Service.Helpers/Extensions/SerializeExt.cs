using System.Text;
using System.Xml.Serialization;

namespace Service.Helpers.Extensions{

	public class Utf8StringWriter : StringWriter{
		public override Encoding Encoding{
			get { return Encoding.UTF8; }
		}
	}

	public static class SerializeExt{

		public static string SerializeObject<T>(this T toSerialize){
			XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
			StringWriter textWriter = new Utf8StringWriter();

			xmlSerializer.Serialize(textWriter, toSerialize);
			return textWriter.ToString();
		}

		public static string SerializeObject<T>(this T toSerialize, XmlSerializerNamespaces ns){
			XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
			StringWriter textWriter = new Utf8StringWriter();

			xmlSerializer.Serialize(textWriter, toSerialize, ns);
			return textWriter.ToString();
		}

		public static string SerializeObject<T>(this T toSerialize, Type[] types)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType(), types);
			StringWriter textWriter = new Utf8StringWriter();

			xmlSerializer.Serialize(textWriter, toSerialize);
			return textWriter.ToString();
		}

		public static T XmlDeserializeFromString<T>(this string objectData){
			return (T)XmlDeserializeFromString(objectData, typeof(T));
		}

		public static object XmlDeserializeFromString(this string objectData, Type type){
			var serializer = new XmlSerializer(type);
			object result;

			using (TextReader reader = new StringReader(objectData)){
				result = serializer.Deserialize(reader);
			}

			return result;
		}

		public static byte[] GetBytes(this string str){
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		public static string GetString(this byte[] bytes) {
			char[] chars = new char[bytes.Length/sizeof (char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}

	}
}
