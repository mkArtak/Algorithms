using System;

namespace AM.Core.DataStructures
{
    public class SelfBalancingBSTNode<T> : BinarySearchTreeNode<T, SelfBalancingBSTNode<T>> where T : IComparable<T>
    {
        public SelfBalancingBSTNode() : base()
        {
        }

        public SelfBalancingBSTNode(T value) : base(value)
        {
        }

        /// <summary>
        /// Executes right-rotation operation on current node.
        /// </summary>
        public void RotateRight()
        {
            SelfBalancingBSTNode<T> leftChild = this.LeftChild;
            this.LeftChild = leftChild.RightChild;
            leftChild.RightChild = this;
        }

        /// <summary>
        /// Executes left-rotation operation on current node.
        /// </summary>
        public void LeftRotation()
        {
            SelfBalancingBSTNode<T> rightChild = this.RightChild;
            this.RightChild = rightChild.LeftChild;
            rightChild.LeftChild = this;
        }
    }
}
