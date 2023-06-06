using System.Xml;

namespace Service.Helpers.Utils{
	public static class XmlUtils{

		public static XmlElement GetXmlElement(string xml){
			var doc = new XmlDocument();
			doc.PreserveWhitespace = true;
			doc.LoadXml(xml);
			return doc.DocumentElement;
		}

	}
}
