using System;
using System.Collections.Generic;

public class Grafo
{
    private Dictionary<string, List<(string, int)>> ady; // Lista de adyacencia

    public Grafo()
    {
        ady = new Dictionary<string, List<(string, int)>>();
    }

    public void AgregarArista(string u, string v, int peso)
    {
        if (!ady.ContainsKey(u))
            ady[u] = new List<(string, int)>();
        if (!ady.ContainsKey(v))
            ady[v] = new List<(string, int)>();

        ady[u].Add((v, peso));
        ady[v].Add((u, peso));
    }

    public Dictionary<string, (int distancia, string origen)> Dijkstra(string src)
    {
        Dictionary<string, (int distancia, string origen)> distancias = new Dictionary<string, (int distancia, string origen)>(); // Almacenará la distancia más corta desde src hasta i y el origen del camino
        HashSet<string> visitados = new HashSet<string>(); // Nodos ya visitados

        foreach (var nodo in ady.Keys)
            distancias[nodo] = (int.MaxValue, null);

        distancias[src] = (0, null);

        while (visitados.Count < ady.Count)
        {
            string u = null;
            foreach (var nodo in ady.Keys)
            {
                if (!visitados.Contains(nodo) && (u == null || distancias[nodo].distancia < distancias[u].distancia))
                    u = nodo;
            }

            visitados.Add(u);

            foreach (var item in ady[u])
            {
                string v = item.Item1;
                int peso = item.Item2;

                if (distancias[v].distancia > distancias[u].distancia + peso)
                    distancias[v] = (distancias[u].distancia + peso, u);
            }
        }

        return distancias;
    }

    public List<string> Recorrido(string ciudad, Dictionary<string, (int distancia, string origen)> distancias)
    {
        List<string> recorrido = new List<string>();
        recorrido.Add(ciudad);

        while (distancias[ciudad].origen != null)
        {
            ciudad = distancias[ciudad].origen;
            recorrido.Insert(0, ciudad);
        }

        return recorrido;
    }
}