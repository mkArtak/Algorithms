using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AM.Core.DataStructures.Tests
{
    public class GraphNodeTests
    {
        [Fact]
        public void BreadthFirstTraverse_Succeeds()
        {
            GraphNode<int> node = new GraphNode<int>(10);
            node.AddNeighbor(new GraphNode<int>(1));
            node.AddNeighbor(new GraphNode<int>(2));
            node.AddNeighbor(new GraphNode<int>(10))
                .AddNeighbor(new GraphNode<int>(20));

            IList<int> visitedNodes = new List<int>();
            node.BreadthFirstTraverse(val =>
            {
                visitedNodes.Add(val);
                return false;
            });

            int[] expectedNodes = new[] { 10, 1, 2, 10, 20 };

            Assert.Equal(expectedNodes.Length, visitedNodes.Count);
            for (int i = 0; i < expectedNodes.Length; i++)
            {
                Assert.Equal(expectedNodes[i], visitedNodes[i]);
            }
        }

        [Fact]
        public void BreadthFirstTraverse_VisitsNodesOnlyOnce()
        {
            GraphNode<int> node = new GraphNode<int>(10);
            node.AddNeighbor(new GraphNode<int>(1));

            // Creating a cycle in the graph
            node.AddNeighbor(new GraphNode<int>(2)).AddNeighbor(node);

            IList<int> visitedNodes = new List<int>();
            node.BreadthFirstTraverse(val =>
            {
                visitedNodes.Add(val);
                return false;
            });

            int[] expectedNodes = new[] { 10, 1, 2 };

            Assert.Equal(expectedNodes.Length, visitedNodes.Count);
            for (int i = 0; i < expectedNodes.Length; i++)
            {
                Assert.Equal(expectedNodes[i], visitedNodes[i]);
            }
        }
    }
}
