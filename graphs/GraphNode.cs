using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafs
{
    public class GraphNode
    {
        public int length;
        public int[] lengthItems;
        public string line;
        public List<GraphNode> nodes;

        public GraphNode(int length, int[] items, string line)
        {
            this.length = length;
            this.lengthItems = items;
            this.line = line;
            nodes = new List<GraphNode>();
        }
    }
}
