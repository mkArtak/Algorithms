using System;

namespace AM.Core.DataStructures
{
    /// <summary>
    /// Represents a node in a binary search tree.
    /// </summary>
    /// <typeparam name="T">The type of the value each node of the tree will hold.</typeparam>
    public abstract class BinarySearchTreeNode<T, V> where T : IComparable<T> where V : BinarySearchTreeNode<T, V>, new()
    {
        private V leftChild;
        private V rightChild;

        public V Parent { get; private set; }

        public V Root
        {
            get
            {
                V parent = (V)this;
                while (parent.Parent != null)
                {
                    parent = parent.Parent;
                }

                return parent;
            }
        }

        public V LeftChild
        {
            get { return this.leftChild; }
            protected set
            {
                this.leftChild = value;
                if (value != null)
                {
                    value.Parent = (V)this;
                }
            }
        }

        public V RightChild
        {
            get
            {
                return this.rightChild;
            }
            protected set
            {
                this.rightChild = value;
                if (value != null)
                {
                    value.Parent = (V)this;
                }
            }
        }

        public T Value { get; private set; }

        public BinarySearchTreeNode()
        {
        }

        public BinarySearchTreeNode(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets a boolean value indicating, whether current node is the root of the tree, or not.
        /// </summary>
        public bool IsRoot
        {
            get
            {
                return this.Parent == null;
            }
        }

        /// <summary>
        /// Gets a boolean value indicating, whether the current node is a leaf node or not.
        /// A leaf node is a node, which have no children.
        /// </summary>
        public bool IsLeaf { get { return this.LeftChild == null && this.RightChild == null; } }

        /// <summary>
        /// Inserts the specified node to the current subtree
        /// </summary>
        /// <param name="node">The node to insert to the subtree.</param>
        /// <returns>The node holding the just-inserted value.</returns>
        public V Insert(T nodeValue)
        {
            V node = new V();
            node.Value = nodeValue;

            // We should always insert nodes from the root, to not break the BST properties.
            V currentParentNode = (V)this;
            do
            {
                if (node.Value.CompareTo(currentParentNode.Value) <= 0)
                {
                    // The node should be inserted to the left subtree of the current node.
                    if (currentParentNode.LeftChild == null)
                    {
                        // This node has no left child. Add the node as such.
                        currentParentNode.LeftChild = node;
                        break;
                    }
                    else if (node.Value.CompareTo(currentParentNode.LeftChild.Value) <= 0)
                    {
                        // The node should be inserted further down in the left subtree
                        currentParentNode = currentParentNode.LeftChild;
                    }
                    else
                    {
                        // The node should be inserted in the leftChild location, and the left child should become a child of this node.
                        node.LeftChild = currentParentNode.LeftChild;
                        currentParentNode.LeftChild = node;
                        break;
                    }
                }
                else
                {
                    // The node should be inserted to the right subtree of the current node.
                    if (currentParentNode.RightChild == null)
                    {
                        // This node has no left child. Add the node as such.
                        currentParentNode.RightChild = node;
                        break;
                    }
                    else if (node.Value.CompareTo(currentParentNode.RightChild.Value) > 0)
                    {
                        currentParentNode = currentParentNode.RightChild;
                    }
                    else
                    {
                        // The node should be inserted in the rightChild location, and the right child should become a child of this node.
                        node.RightChild = currentParentNode.RightChild;
                        currentParentNode.RightChild = node;
                        break;
                    }
                }
            } while (true);

            return node;
        }

        /// <summary>
        /// Removes current node from the tree
        /// </summary>
        public void Remove()
        {
            /*
             * There are three possible cases:
             * 1. The node has no children (is leaf node)
             *    For this case - just set the parent's reference to null.
             * 2. The node has just one child (left or right subtree).
             *    Just remove the node and replace the paren't reference to point to the only child subtree
             * 3. The node has both left and right subtrees.
             *    
             * */
            if (this.IsLeaf)
            {
                // The node has no child subtrees.
                if (this.Parent != null)
                {
                    ReplaceParentNodesReferenceToNodeWith((V)this, null);
                }
            }
            else if (this.LeftChild != null && this.RightChild != null)
            {
                // The node has both child subtrees present.
                V successor = this.FindSuccessor();
                // Remove the predecessor from the tree (this should have no children)
                successor.Remove();

                ReplaceParentNodesReferenceToNodeWith((V)this, successor);
            }
            else
            {
                // The node has only one child subtree.
                if (this.Parent != null)
                {
                    V onlyChild = this.LeftChild ?? this.RightChild;
                    // Update the paren'ts reference to the child subtree.
                    ReplaceParentNodesReferenceToNodeWith((V)this, onlyChild);
                }
            }

            // Remove the node from tree completely.
            this.Parent = null;
        }

        public V FindMinimumNode()
        {
            V result = (V)this;
            while (result.LeftChild != null)
            {
                result = result.LeftChild;
            }

            return result;
        }

        public V FindMaximumNode()
        {
            V result = (V)this;
            while (result.RightChild != null)
            {
                result = result.RightChild;
            }

            return result;
        }

        /// <summary>
        /// Finds the successor of current node.
        /// </summary>
        /// <returns>The node, which is the successort to current.</returns>
        public V FindSuccessor()
        {
            V result;
            if (this.RightChild != null)
            {
                // If current node has right subtree, then the minimum element of that subtree would be the successor of current element.
                result = this.RightChild.FindMinimumNode();
            }
            else
            {
                result = null;

                // We should navigate up through the hierarchy as long as current node is in the right subtree.
                // As soon as we find a parent node, which for this node is in its left subtree, that'll be the successor of current node.
                V currentNode = (V)this;
                while (currentNode.Parent != null)
                {
                    if (currentNode.Parent.LeftChild == currentNode)
                    {
                        // Found a parent, which for the currentNode is the left child.
                        result = currentNode.Parent;
                        break;
                    }

                    currentNode = currentNode.Parent;
                };
            }

            return result;
        }

        /// <summary>
        /// Finds the predecessor of current node.
        /// </summary>
        /// <returns>The node, which is the predecessor to current.</returns>
        public V FindPredecessor()
        {
            V result;
            if (this.LeftChild != null)
            {
                result = this.LeftChild.FindMaximumNode();
            }
            else
            {
                result = null;
                V currentNode = (V)this;
                while (currentNode.Parent != null)
                {
                    if (currentNode.Parent.RightChild == currentNode)
                    {
                        result = currentNode.Parent;
                        break;
                    }

                    currentNode = currentNode.Parent;
                }
            }

            return result;
        }

        /// <summary>
        /// Searches the subtree (rooted at current node) for a node with the given value.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>The node with the specified value, if found. null - otherwise.</returns>
        public V Search(T value)
        {
            V currentNode = (V)this;
            do
            {
                if (value.CompareTo(this.Value) <= 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode = currentNode.RightChild;
                }

                if (currentNode.Value.CompareTo(value) == 0)
                {
                    break;
                }
            } while (currentNode != null);

            return currentNode;
        }

        /// <summary>
        /// Runs an in=order traversal over the elements of the tree.
        /// </summary>
        /// <param name="visitor">An action to call on every visited node.</param>
        public void Traverse(Action<V> visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            this.TraverseInternal(visitor);
        }

        private void TraverseInternal(Action<V> visitor)
        {
            this.LeftChild?.TraverseInternal(visitor);

            visitor((V)this);

            this.RightChild?.TraverseInternal(visitor);
        }

        private static void ReplaceParentNodesReferenceToNodeWith(V node, V nodeToReplaceWith)
        {
            if (node.Parent.LeftChild == node)
            {
                node.Parent.LeftChild = nodeToReplaceWith;
            }
            else if (node.Parent.RightChild == node)
            {
                node.Parent.RightChild = nodeToReplaceWith;
            }
        }
    }
}