package vzh;

import com.sun.source.tree.Tree;
import org.w3c.dom.ranges.RangeException;

import java.awt.dnd.DropTargetDragEvent;
import java.lang.reflect.Array;
import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Main {

  public static void main(String[] arg) {
    PriorityQueue<Integer> d = new PriorityQueue<>();
    TreeMap<Integer> f = new TreeMap();


  }

  static class Solution {
    class Edge implements Comparable<Edge> {
      public int node;
      public double prob;

      public Edge(int node, double prob) {
        this.node = node;
        this.prob = prob;
      }


      @Override
      public int compareTo(Edge o) {
        if (o.prob > this.prob)
          return 1;
        else if (o.prob < this.prob)
          return -1;
        return 0;
      }
    }

    public double maxProbability(int n, int[][] edges, double[] succProb, int start, int end) {
      var e = new HashMap<Integer, ArrayList<Edge>>();
      var pq = new PriorityQueue<Edge>();

      for (var i = 0; i < edges.length; i++) {
        if (!e.containsKey(edges[i][0])) e.put(edges[i][0], new ArrayList<>());
        if (!e.containsKey(edges[i][1])) e.put(edges[i][1], new ArrayList<>());

        e.get(edges[i][0]).add(new Edge(edges[i][1], Math.log(succProb[i])));
        e.get(edges[i][1]).add(new Edge(edges[i][0], Math.log(succProb[i])));
      }

      var p = new HashMap<Integer, Double>();

      for (var key : e.keySet())
        p.put(key, Double.MAX_VALUE);

      p.put(start, 0d);

      var visited = new boolean[n];
      pq.add(new Edge(start, 0));

      while (!pq.isEmpty()) {
        var edge = pq.poll();
        var node = edge.node;
        var prob = edge.prob;

        if (visited[edge.node])
          continue;

        visited[edge.node] = true;

        for (Edge child : e.get(node)) {
          if (p.get(child.node) > p.get(node) - child.prob) {
            p.put(child.node, p.get(node) - child.prob);
            pq.add(new Edge(child.node, p.get(child.node)));
          }
        }
      }

      if (p.get(end) == Integer.MIN_VALUE)
        return 0;

      return Math.exp(-p.get(end));
    }
  }
}
