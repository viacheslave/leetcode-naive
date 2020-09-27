using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/throne-inheritance/
	///		Submission: https://leetcode.com/submissions/detail/401323779/
	/// </summary>
	internal class P1600
	{
    public class ThroneInheritance
    {
      private class TreeNode
      {
        public string Name { get; }
        public bool Alive { get; private set; } = true;

        public IList<TreeNode> Children { get; } = new List<TreeNode>();

        public void Die() => Alive = false;

        public TreeNode(string name) => Name = name;
      }

      private TreeNode _root;
      private Dictionary<string, TreeNode> _map = new Dictionary<string, TreeNode>();

      public ThroneInheritance(string kingName)
      {
        _root = new TreeNode(kingName);
        _map[kingName] = _root;
      }

      public void Birth(string parentName, string childName)
      {
        var child = new TreeNode(childName);

        _map[parentName].Children.Add(child);
        _map[childName] = child;
      }

      public void Death(string name)
      {
        _map[name].Die();
      }

      public IList<string> GetInheritanceOrder()
      {
        var order = new List<string>();
        Traverse(_root, order);

        return order;
      }

      private void Traverse(TreeNode node, List<string> order)
      {
        if (node.Alive)
          order.Add(node.Name);

        foreach (var child in node.Children)
        {
          Traverse(child, order);
        }
      }
    }

    /**
     * Your ThroneInheritance object will be instantiated and called as such:
     * ThroneInheritance obj = new ThroneInheritance(kingName);
     * obj.Birth(parentName,childName);
     * obj.Death(name);
     * IList<string> param_3 = obj.GetInheritanceOrder();
     */
  }
}
