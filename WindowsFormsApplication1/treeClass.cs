using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class TreeClass
    {
        private treeNode leafNode;
        private Dictionary<byte, string> codesTable;
        //default constructor
        public TreeClass(treeNode node)
        {
            leafNode = node;
            codesTable = new Dictionary<byte, string>();
        }
        public static TreeClass createTree(Dictionary<byte, int> occurTable)
        {
            //need create something like list of treeNodes
            treeNodeParser nodeParser = new treeNodeParser();
            foreach(var occur in occurTable)
            {
                nodeParser.addNode(new treeNode(occur.Value, occur.Key));
            }
            //should return full tree node
            return new TreeClass(new treeNode());
        }
    }
}
