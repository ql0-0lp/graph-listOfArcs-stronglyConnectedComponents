namespace algos_lab2
{
    public class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public int Weight { get; set; }

        public Edge(Vertex to, Vertex from, int weight)
        {
            To = to;
            From = from;
            Weight = weight;
        }
    }
}
