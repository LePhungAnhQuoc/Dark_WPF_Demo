using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class XmlProvider
{
    public static string PathData { get; set; }
    private static XmlDocument doc = null;
    public static XmlNode nodeRoot = null;

    public static void Open(string pathData)
    {
        PathData = pathData;
        if (doc == null)
            doc = new XmlDocument();
        doc.Load(PathData);
        nodeRoot = doc.DocumentElement;
    }
    public static void Close()
    {
        if (doc != null)
            doc.Save(PathData);
    }
    public static XmlNode getNode(string xpath)
    {
        return nodeRoot.SelectSingleNode(xpath);
    }
    public static XmlNode getNode(string xpath, int index)
    {
        XmlNode node = doc.SelectSingleNode(xpath);
        for (int i = 0; i < index; i++)
        {
            var next = node.NextSibling;
            if (next != null)
                node = next;
        }
        return node;
    }
    public static XmlNodeList getDsNode(string xpath) => nodeRoot.SelectNodes(xpath);
    public static XmlNode createNode(string tagName) => doc.CreateElement(tagName);
    public static XmlAttribute createAttr(string name) => doc.CreateAttribute(name);
}
