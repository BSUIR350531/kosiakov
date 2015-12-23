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
            //add each occurance to the ordered list of nodes
            foreach(var occur in occurTable)
            {
                nodeParser.addNode(new treeNode(occur.Value, occur.Key));
            }

            int amount = occurTable.Count;
            for (int i = 0; i < amount -1; ++i)
            {
                //get last to nodes, that have minimally weight
                treeNode leftNode = nodeParser.popMinNode();
                treeNode rightNode = nodeParser.popMinNode();
                //create from it a new node with a new weight and add new node to ordered list
                nodeParser.addNode(new treeNode(leftNode, rightNode, leftNode.weight + rightNode.weight));
            }
            //should return full tree node
            //after all cyrcles, when we get min node, it will have links to sub notes, the notes to itself subnotes and etc. :)
            return new TreeClass(nodeParser.popMinNode());
        }
        public Dictionary<byte, string> getByteCodeTable()
        {
            if (leafNode == null)
            {
                throw new Exception("Tree' leaf node shouldn't be empty");
            } else
            {
                //fill up for each original byte it new code
                createByteCodeTable(leafNode, "");
                //return calculated table
                return codesTable;
            }
        }
        private void createByteCodeTable(treeNode root, string startStr)
        {
            //if node doesn't have value
            if (root.value == null)
            {
                //and have left node
                if (root.left != null)
                {
                    //add to output string '0'
                    createByteCodeTable(root.left, startStr + "0");
                }
                //and have right node
                if (root.right != null)
                {
                    //add to output string '1'
                    createByteCodeTable(root.right, startStr + "1");
                }
            } else
            {
                //if node has value -> add for the key value output string calculated before
                codesTable[Convert.ToByte(root.value)] = startStr.ToString();
            }
        }
        public List<byte> getByteText(string text)
        {
            //we have string read form zipped file
            int i, len = text.Length;
            //create list of bytes
            List<byte> resultText = new List<byte>();
            for (i = 0; i < len; i++)
            {
                //set node leaf node of calculated tree
                treeNode node = leafNode;
                while (true)
                {
                    if (i >= len)
                    {
                        break;
                    }
                    //if value exists -> we find original byte, add it to list
                    if (node.value != null)
                    {
                        resultText.Add(Convert.ToByte(node.value));
                        i--;
                        break;
                    } else
                    {
                        //else if currant symbol equl to 0 -> go to left node, otherwise - to right node
                        node = (text[i] == '0') ? node.left : node.right;
                        i++;                                        
                    }                   
                }
            }
            //return list of original bytes
            return resultText;
        }
    }
}
