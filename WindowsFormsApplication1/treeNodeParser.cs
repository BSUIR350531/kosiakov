﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class treeNodeParser
    {
        private treeNode[] nodes = new treeNode[2000];
        private int amount;
        public treeNodeParser()
        {
            nodes = new treeNode[2000];
            amount = 0;
        }
        //function for getting indexes
        private int getParentIndex(int index)
        {
            return index / 2;
        }
        //left node will be have index like current node index*2
        private int getLeftNodeIndex(int index)
        {
            return index * 2;
        }
        //right node will be have index like current node index*2 + 1, because (index*2) - it's left node
        private int getRightNodeIndex(int index)
        {
            return (index * 2) + 1;
        }
        private void swapElements(ref treeNode node1, ref treeNode node2)
        {
            treeNode temp = node1;
            node1 = node2;
            node2 = temp;
        }
        public void addNode(treeNode newNode)
        {
            amount++;
            int i = amount;
            nodes[i] = newNode;
            while( i > 1 && nodes[getParentIndex(i)].CompareTo(nodes[i]) > 0)
            {
                int parentIndex = getParentIndex(i);
                swapElements(ref nodes[i], ref nodes[parentIndex]);
                i = parentIndex;
            }
        }
        public treeNode popMinNode()
        {
            treeNode minNode = nodes[1];
            nodes[1] = nodes[amount];
            amount--;
            setChildPositionsFor(1);
            return minNode;
        }
        private void setChildPositionsFor(int index) {
            int leftIndex = getLeftNodeIndex(index),
                rightIndex = getRightNodeIndex(index),
                smallestIndex;
            if(leftIndex <= amount && nodes[leftIndex].CompareTo(nodes[index]) < 0) {
                smallestIndex = leftIndex;
            } else
            {
                smallestIndex = index;
            }
            if (rightIndex <= amount && nodes[rightIndex].CompareTo(nodes[smallestIndex]) < 0)
            {
                smallestIndex = rightIndex;
            }
            if (smallestIndex != index)
            {
                swapElements(ref nodes[index], ref nodes[smallestIndex]);
                setChildPositionsFor(smallestIndex);
            }
        }
    }
}
