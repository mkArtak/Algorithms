using System;
using System.Collections.Generic;

namespace AM.Core.DataStructures
{
    /// <summary>
    /// Represents a graph stracture, where no nodes are isolated.
    /// </summary>
    /// <typeparam name="T">The type of value each node in the graph holds.</typeparam>
    public class GraphNode<T>
    {
        private IList<GraphNode<T>> neighbors = new List<GraphNode<T>>();

        /// <summary>
        /// This value is used to track the traversal session, to allow traversal of the graph multiple times.
        /// </summary>
        /// <remarks>To understand the purpose of this value, think about how in a cyclic graph visited nodes are detected. A boolean is usually used. However, if the boolean is marked as "visited", the traversal logic can't be repeated again. That's the problem the int solves here.</remarks>
        private int traversalSession = 0;

        public T Value { get; set; }

        public IList<GraphNode<T>> Neighbors { get => this.neighbors; protected set => this.neighbors = value; }

        public GraphNode(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Adds the specified graph node as a neighbor to the current node.
        /// </summary>
        /// <param name="neighbor">The node to add to current node as neighbor.</param>
        /// <returns>The newly added neighbor node.</returns>
        public GraphNode<T> AddNeighbor(GraphNode<T> neighbor)
        {
            if (neighbor == null)
            {
                throw new ArgumentNullException(nameof(neighbor));
            }

            this.Neighbors.Add(neighbor);

            return neighbor;
        }

        /// <summary>
        /// Traverses the graph in a breadth-first way, visiting each node.
        /// </summary>
        /// <param name="visitor">A delegate, called for each visited node. If the delegate returns true, the traversal will be terminated.</param>
        public void BreadthFirstTraverse(Func<T, bool> visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            this.BreadthFirstTraverse(visitor, this.traversalSession + 1);
        }

        private void BreadthFirstTraverse(Func<T, bool> visitor, int traversalSession)
        {
            if (this.TrackTraversalSession(traversalSession))
            {
                return;
            }

            Queue<GraphNode<T>> traversalQueue = new Queue<GraphNode<T>>();
            traversalQueue.Enqueue(this);
            while (traversalQueue.Count > 0)
            {
                GraphNode<T> node = traversalQueue.Dequeue();
                if (visitor(node.Value))
                {
                    break;
                }

                foreach (GraphNode<T> neighbor in node.Neighbors)
                {
                    if (neighbor.TrackTraversalSession(traversalSession))
                    {
                        continue;
                    }

                    traversalQueue.Enqueue(neighbor);
                }
            }
        }

        /// <summary>
        /// Tracks the current traversal session and updates cureent node's traversal state.
        /// </summary>
        /// <param name="traversalSession">The new session number for current traversal.</param>
        /// <returns>True, if the node has already been visited within this session. false - otherwise.</returns>
        private bool TrackTraversalSession(int traversalSession)
        {
            int traversalDiff = traversalSession - this.traversalSession;
            if (traversalDiff == 0)
            {
                // This node has already been visited. Move on.
                return true;
            }

            if (traversalDiff == 1)
            {
                // The node is being visited the first time as part of this session. Update the session.
                this.traversalSession++;
            }
            else
            {
                // The graph is in non-traversable state. It should be rebuild.
                throw new Exception("The graph is in unknown state, so traversal is not possible");
            }

            return false;
        }
    }
}