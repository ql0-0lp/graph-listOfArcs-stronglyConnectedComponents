using System;
using System.Collections.Generic;

namespace algos_lab2
{
    public class Graph
    {
        public int Compomemt = 1;
        public List<Vertex> Vertexes = new List<Vertex>();
        public List<Edge> Edges = new List<Edge>();

        public int FIRST(Vertex vertex)
        {
            foreach(Edge e in Edges)
                if(e.From == vertex)
                    return e.To.Number;

            return 0;
        }

        public int NEXT(Vertex vertex, int i)
        {
            bool check = false;
            foreach (Edge e in Edges)
            {
                if (e.From == vertex && check)
                    return e.To.Number;
                if (e.From == vertex && i == e.To.Number)
                    check = true;
            }
            return 0;
        }

        public List<Vertex> VERTEX(Vertex vertex)
        {
            List<Vertex> vert = new List<Vertex>();
            foreach (var edge in Edges)
                if (edge.From == vertex)
                    vert.Add(edge.To);
            return vert;
        }

        public void ADD_V(Vertex vertex) { Vertexes.Add(vertex); }

        public void ADD_E(Edge edge) { Edges.Add(edge); }

        public void DEL_V(string name)
        {
            for (int i = 0; i < Vertexes.Count; i++)
            {
                if (Vertexes[i].Name == name)
                {
                    for (int j = 0; j < Edges.Count; j++)
                        if (Vertexes[i] == Edges[j].To && Vertexes[i] == Edges[j].From)
                            Edges.RemoveAt(j);
                    Vertexes.RemoveAt(i);
                }
            }

        }

        public void DEL_E(Vertex to, Vertex from)
        {
            for (int i = 0; i < Edges.Count; i++)
                if (to == Edges[i].To && from == Edges[i].From)
                    Edges.RemoveAt(i);
        }

        public void EDIT_V(string name, int number)
        {
            for (int i = 0; i < Vertexes.Count; i++)
                if (Vertexes[i].Name == name)
                    Vertexes[i].Number = number;
        }

        public void EDIT_E(Vertex to, Vertex from, int weight)
        {
            for (int i = 0; i < Edges.Count; i++)
                if (to == Edges[i].To && from == Edges[i].From)
                    Edges[i].Weight = weight;
        }

        public List<Vertex> BFS(Vertex start)
        {
            List<Vertex> list = BFS2(start);
            foreach (var item in Vertexes)
            {
                if (!list.Contains(item))
                {
                    list.AddRange(BFS2(item));
                    Compomemt++;
                }
            }
            return list;
        }

        public List<Vertex> BFS2(Vertex start)
        {
            List<Vertex> list = new List<Vertex>();
            var vertex = start;
            list.Add(vertex);
            for (int i = 0; i < list.Count; i++)
            {
                vertex = list[i];
                foreach (var item in VERTEX(vertex))
                    if (!list.Contains(item))
                        list.Add(item);
            }
            return list;
        }

        public List<Vertex> FindStronglyConnectedComponents()
        {
            List<Vertex> components = new List<Vertex>();
            int[] vertexSteps = new int[Vertexes.Count];

            for (int i = 0; i < Vertexes.Count; i++)
                foreach (var item in BFS(Vertexes[i]))
                    vertexSteps[item.Number]++;

            List<int> indexes = new List<int>();
            for (int i = 0; i < vertexSteps.Length - 1; i++)
                if (vertexSteps[i] == vertexSteps[i + 1])
                    indexes.Add(i);
                else if (vertexSteps[i] == vertexSteps[i - 1])
                    indexes.Add(i);

            foreach (var item in indexes)
            {
                components.Add(Vertexes[item]);
            }

            return components;
        }

        public void Print()
        {
            Console.WriteLine("Список дуг:");
            foreach (var item in Edges)
            {
                Console.WriteLine(item.From.Name + " -> " + item.To.Name);
            }
        }
    }
}
