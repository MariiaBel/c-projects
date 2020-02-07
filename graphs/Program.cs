using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(10, new int[] { 3, 5, 8});
            graph.Build();
            graph.ShowGrid();
            graph.Count();
            Console.ReadKey();
        }
    }
}
