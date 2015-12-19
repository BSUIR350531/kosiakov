using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class treeNode
    {
        public byte? value { get; set; }
        public int weight { get; set; }
        public treeNode right { get; set; }
        public treeNode left { get; set; }
        //def constructor
        public treeNode() {
            value = null;
            weight = 0;
        }
        public treeNode(int nodeWeight, byte nodeValue)
        {
            weight = nodeWeight;
            value = nodeValue;
        }
    }
}
