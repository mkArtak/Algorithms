using System;

namespace AM.Core.DataStructures
{
    /// <summary>
    /// Represents a node in a binary search tree.
    /// </summary>
    /// <typeparam name="T">The type of the value each node of the tree will hold.</typeparam>
    public class BinarySearchTreeNode<T> where T : IComparable<T>
    {
        private BinarySearchTreeNode<T> leftChild;
        private BinarySearchTreeNode<T> rightChild;

        public BinarySearchTreeNode<T> Parent { get; private set; }

        public BinarySearchTreeNode<T> Root
        {
            get
            {
                BinarySearchTreeNode<T> parent = this;
                while (parent.Parent != null)
                {
                    parent = parent.Parent;
                }

                return parent;
            }
        }

        public BinarySearchTreeNode<T> LeftChild
        {
            get { return this.leftChild; }
            private set
            {
                this.leftChild = value;
                if (value != null)
                {
                    value.Parent = this;
                }
            }
        }

        public BinarySearchTreeNode<T> RightChild
        {
            get
            {
                return this.rightChild;
            }
            private set
            {
                this.rightChild = value;
                if (value != null)
                {
                    value.Parent = this;
                }
            }
        }

        public T Value { get; private set; }

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
        /// Inserts the specified node to the current subtree
        /// </summary>
        /// <param name="node">The node to insert to the subtree.</param>
        /// <remark>Call to this method on any node of a tree will cause the insertion to run from the root of the tree.</remarks>
        public BinarySearchTreeNode<T> Insert(T nodeValue)
        {
            BinarySearchTreeNode<T> node = new BinarySearchTreeNode<T>(nodeValue);

            // We shold always insert nodes from the root, to not break the BST properties.
            BinarySearchTreeNode<T> currentParentNode = this.Root;
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
            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this.Parent;
                this.LeftChild.RightChild = this.RightChild;
            }
            else if (this.RightChild != null)
            {
                this.RightChild.Parent = this.Parent;
            }
        }

        /// <summary>
        /// Searches the tree (starting from the root) for a node with the given value.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>The node with the specified value, if found. null - otherwise.</returns>
        /// <remarks>The search on any node of a tree runs a search from the root of it.</remarks>
        public BinarySearchTreeNode<T> Search(T value)
        {
            BinarySearchTreeNode<T> currentNode = this.Root;
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
        public void Traverse(Action<BinarySearchTreeNode<T>> visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            this.TraverseInternal(visitor);
        }

        private void TraverseInternal(Action<BinarySearchTreeNode<T>> visitor)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.TraverseInternal(visitor);
            }

            visitor(this);

            if (this.RightChild != null)
            {
                this.RightChild.TraverseInternal(visitor);
            }
        }
    }
}