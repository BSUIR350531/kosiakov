﻿using System;
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

            int amount = occurTable.Count;
            for (int i = 0; i < amount -1; ++i)
            {
                treeNode leftNode = nodeParser.popMinNode();
                treeNode rightNode = nodeParser.popMinNode();
                nodeParser.addNode(new treeNode(leftNode, rightNode, leftNode.weight + rightNode.weight));
            }
            //should return full tree node
            return new TreeClass(nodeParser.popMinNode());
        }
        public Dictionary<byte, string> getByteCodeTable()
        {
            if (leafNode == null)
            {
                throw new Exception("Tree' leaf node shouldn't be empty");
            } else
            {
                createByteCodeTable(leafNode, "");
                return codesTable;
            }
        }
        private void createByteCodeTable(treeNode root, string startStr)
        {
            if (root.value == null)
            {
                if (root.left != null)
                {
                    createByteCodeTable(root.left, startStr + "0");
                }
                if (root.right != null)
                {
                    createByteCodeTable(root.right, startStr + "1");
                }
            } else
            {
                codesTable[Convert.ToByte(root.value)] = startStr.ToString();
            }
        }
    }
}
