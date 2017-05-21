﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AM.Core.DataStructures.Tests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void BinarySearchTree_NewHasNoParent()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(10);

            Assert.Null(root.Parent);
        }

        [Fact]
        public void BinarySearchTree_NewHasNoChildren()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(10);

            Assert.Null(root.LeftChild);
            Assert.Null(root.RightChild);
        }

        [Fact]
        public void Insert_ReturnsNodeWithSpecifiedValue()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(10);
            BinarySearchTreeNode<int> node = root.Insert(1);

            Assert.Equal(1, node.Value);
        }

        [Fact]
        public void Insert_AddsTheValueToExpectedNode()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(10);
            BinarySearchTreeNode<int> leftNode = root.Insert(1);

            Assert.Equal(leftNode, root.LeftChild);
            Assert.Null(root.RightChild);

            BinarySearchTreeNode<int> rightNode = root.Insert(11);
            Assert.Equal(rightNode, root.RightChild);
        }

        [Fact]
        public void Search_FindsDesiredNode()
        {
            BinarySearchTreeNode<int> root = CreateTestTree(10, 1, 5, 16);
            BinarySearchTreeNode<int> searchNode = root.Insert(4);
            InsertValuesToTree(root, 3, 34);

            Assert.Equal(searchNode, root.Search(4));
        }

        [Fact]
        public void Root_ReturnsTheRealRoot()
        {
            BinarySearchTreeNode<int> root = CreateTestTree(10, 1, 5, 16);
            BinarySearchTreeNode<int> insertedNode = root.Insert(4);

            Assert.Equal(root, insertedNode.Root);
        }

        [Fact]
        public void Traverse_TraversesAllNodesInLeftSelfRightOrder()
        {
            int[] items = new[] { 4, 60, 4, 87, 54, 12, 45, 78, 4, 45, 65 };
            BinarySearchTreeNode<int> root = CreateTestTree(50, items);

            IList<int> visitedItems = new List<int>();
            Action<BinarySearchTreeNode<int>> visitor = node =>
            {
                visitedItems.Add(node.Value);
            };

            root.Traverse(visitor);

            int[] sortedItems = items.Concat(new[] { root.Value }).OrderBy(item => item).ToArray();
            Assert.Equal(sortedItems.Length, visitedItems.Count);
            for (int i = 0; i < visitedItems.Count; i++)
            {
                Assert.Equal(sortedItems[i], visitedItems[i]);
            }
        }

        [Fact]
        public void FindSuccessor_ReturnsNullForMaximumNode()
        {
            BinarySearchTreeNode<int> testTree = CreateTestTree(10, 15, 13, 5, 8, 3);
            BinarySearchTreeNode<int> nodeToFindSuccessorFor = testTree.Insert(18);

            Assert.Null(nodeToFindSuccessorFor.FindSuccessor());
        }

        [Fact]
        public void FindSuccessor_SucceedsForNodeInLeftSubtree()
        {
            BinarySearchTreeNode<int> testTree = CreateTestTree(10, 15, 13, 18);
            BinarySearchTreeNode<int> expectedSuccessor = testTree.Insert(5);
            expectedSuccessor.Insert(8);
            BinarySearchTreeNode<int> nodeToFindSuccessorFor = testTree.Insert(3);

            Assert.Equal(expectedSuccessor, nodeToFindSuccessorFor.FindSuccessor());
        }

        [Fact]
        public void FindSuccessor_SucceedsForNodeInRightSubtree()
        {
            BinarySearchTreeNode<int> testTree = CreateTestTree(10, 5, 3, 8);
            BinarySearchTreeNode<int> nodeToFindSuccessorFor = testTree.Insert(15);
            testTree.Insert(13);
            BinarySearchTreeNode<int> expectedSuccessor = testTree.Insert(18);

            Assert.Equal(expectedSuccessor, nodeToFindSuccessorFor.FindSuccessor());
        }

        [Fact]
        public void FindPredecessor_ReturnsNullForMinimumNode()
        {
            BinarySearchTreeNode<int> testTree = CreateTestTree(10, 15, 13, 18, 5, 8);
            BinarySearchTreeNode<int> nodeToFindSuccessorFor = testTree.Insert(3);

            Assert.Null(nodeToFindSuccessorFor.FindPredecessor());
        }

        [Fact]
        public void FindPredecessor_SucceedsForNodeInLeftSubtree()
        {
            BinarySearchTreeNode<int> testTree = CreateTestTree(10, 15, 13, 18);
            BinarySearchTreeNode<int> nodeToFindSuccessorFor = testTree.Insert(5);
            testTree.Insert(8);
            BinarySearchTreeNode<int> expectedSuccessor = testTree.Insert(3);

            Assert.Equal(expectedSuccessor, nodeToFindSuccessorFor.FindPredecessor());
        }

        [Fact]
        public void FindPredecessor_SucceedsForNodeInRightSubtree()
        {
            BinarySearchTreeNode<int> testTree = CreateTestTree(10, 5, 3, 8);
            BinarySearchTreeNode<int> nodeToFindSuccessorFor = testTree.Insert(15);
            BinarySearchTreeNode<int> expectedSuccessor = testTree.Insert(13);
            testTree.Insert(18);

            Assert.Equal(expectedSuccessor, nodeToFindSuccessorFor.FindPredecessor());
        }

        /// <summary>
        /// Creates a new binary search tree, given it's root and items to be added to it.
        /// </summary>
        /// <param name="rootValue">The value of the root node.</param>
        /// <param name="items">A list of values to be added to the tree.</param>
        /// <returns>A new binary search tree, build from the requested values.</returns>
        private static BinarySearchTreeNode<int> CreateTestTree(int rootValue, params int[] items)
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(rootValue);
            if (items != null)
            {
                InsertValuesToTree(root, items);
            }

            return root;
        }

        private static void InsertValuesToTree(BinarySearchTreeNode<int> root, params int[] items)
        {
            foreach (int item in items)
            {
                root.Insert(item);
            }
        }

        private static string GetDebugTreeStructure(BinarySearchTreeNode<int> tree)
        {
            StringBuilder result = new StringBuilder();

            tree.Traverse(node =>
            {
                result.Append(node.Value + " ");
            });

            return result.ToString();
        }
    }
}
