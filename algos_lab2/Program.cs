using System;

namespace algos_lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            graph.ADD_V(new Vertex("0", 0));
            graph.ADD_V(new Vertex("1", 1));
            graph.ADD_V(new Vertex("2", 2));
            graph.ADD_V(new Vertex("3", 3));
            graph.ADD_V(new Vertex("4", 4));
            graph.ADD_V(new Vertex("5", 5));

            graph.ADD_E(new Edge(graph.Vertexes[1], graph.Vertexes[0], 1));
            graph.ADD_E(new Edge(graph.Vertexes[2], graph.Vertexes[1], 1));
            graph.ADD_E(new Edge(graph.Vertexes[0], graph.Vertexes[2], 1));
            graph.ADD_E(new Edge(graph.Vertexes[3], graph.Vertexes[2], 1));
            graph.ADD_E(new Edge(graph.Vertexes[4], graph.Vertexes[3], 1));
            graph.ADD_E(new Edge(graph.Vertexes[5], graph.Vertexes[4], 1));
            graph.ADD_E(new Edge(graph.Vertexes[5], graph.Vertexes[3], 1));

            graph.Print();

            foreach (var item in graph.FindStronglyConnectedComponents())
            {
                Console.WriteLine(item.Name + " | " + item.Number);
            }

            Console.ReadLine();
        }
    }
}
