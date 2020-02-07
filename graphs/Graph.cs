using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafs
{
    class Graph
    {
        GraphNode root;

        public Graph(int length, int[] items)
        {
            this.root = new GraphNode(length, items, "");
        }
        
        public void ShowGrid()
        {
            FindSolution(root);
        }
        public void Count()
        {
            int count;
            count = CountSolutions(root);
            Console.WriteLine("Amount of solution is {0}", count);
        }
        private int CountSolutions(GraphNode node)
        {
            int sum = 0;
            if (node.nodes.Count != 0)
            {
                foreach (GraphNode item in node.nodes)
                {
                    sum += CountSolutions(item);
                }
                return sum;
            }
            else
            { 
                return 1;
            }
        }
        
        void BuildGraph(GraphNode node)
        {
            for (int i = 0; i < node.lengthItems.Length; i++)
            {
                if (node.lengthItems[i] <= node.length)
                {
                    GraphNode nodeToAdd;
                    nodeToAdd = new GraphNode(node.length - node.lengthItems[i], node.lengthItems, node.line + i + " - ");
                    node.nodes.Add(nodeToAdd);
                    BuildGraph(nodeToAdd);
                }
            }
        }
        private void FindSolution(GraphNode node)
        {
            if(node.nodes.Count != 0)
            {
                foreach (GraphNode item in node.nodes)
                {
                    FindSolution(item);
                }
            }
            else
            {
                Console.WriteLine(node.line);
            }
        }
        public void Build()
        {
            BuildGraph(root);
        }
    }
}
