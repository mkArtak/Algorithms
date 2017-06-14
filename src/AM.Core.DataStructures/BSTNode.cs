using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Core.DataStructures
{
    public class BSTNode<T> : BinarySearchTreeNode<T, BSTNode<T>> where T : IComparable<T>
    {
        public BSTNode() : base()
        {
        }

        public BSTNode(T value) : base(value)
        {
        }
    }
}
