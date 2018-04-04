using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IISHelper
{
    public static class ExportManager
    {
        public static void ExportTreeViewToXmlFile(TreeView tv, string filename)
        {
            var rootElement = new XElement("IIS", CreateXmlElement(tv.Nodes));
            var document = new XDocument(rootElement);
            document.Save(filename);
        }

        private static List<XElement> CreateXmlElement(TreeNodeCollection treeViewNodes)
        {
            var elements = new List<XElement>();
            foreach (TreeNode treeViewNode in treeViewNodes)
            {
                var element = new XElement(treeViewNode.Text.Replace(" ", ""));
                if (treeViewNode.GetNodeCount(true) == 1)
                    element.Value = treeViewNode.Nodes[0].Text.Replace(" ", "");
                else
                    element.Add(CreateXmlElement(treeViewNode.Nodes));
                elements.Add(element);
            }
            return elements;
        }
    }
}
