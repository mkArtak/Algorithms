using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AM.Core.DataStructures.Tests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void IsRoot_ReturnsTrueForRootNode()
        {
            BSTNode<int> tree = CreateTestTree(10, 1);

            Assert.True(tree.IsRoot);
        }

        [Fact]
        public void IsRoot_ReturnsFalseForNonRootNode()
        {
            BSTNode<int> tree = CreateTestTree(10);
            Assert.False(tree.Insert(1).IsRoot);
        }

        [Fact]
        public void IsLeaf_ReturnsTrueForLeafNode()
        {
            BSTNode<int> testTree = CreateTestTree(10);

            BSTNode<int> leafNode = testTree.Insert(4);

            Assert.True(leafNode.IsLeaf);
        }

        [Fact]
        public void IsLeaf_ReturnsFalseForNonLeafNode()
        {
            BSTNode<int> testTree = CreateTestTree(10);

            BSTNode<int> leafNode = testTree.Insert(4);
            testTree.Insert(3);

            Assert.False(leafNode.IsLeaf);
        }

        [Fact]
        public void Ctor_NewNodeHasNoParent()
        {
            BSTNode<int> root = new BSTNode<int>(10);

            Assert.Null(root.Parent);
        }

        [Fact]
        public void Ctor_NewNodeHasNoChildren()
        {
            BSTNode<int> root = new BSTNode<int>(10);

            Assert.Null(root.LeftChild);
            Assert.Null(root.RightChild);
        }

        [Fact]
        public void Insert_ReturnsNodeWithSpecifiedValue()
        {
            BSTNode<int> root = new BSTNode<int>(10);
            BSTNode<int> node = root.Insert(1);

            Assert.Equal(1, node.Value);
        }

        [Fact]
        public void Insert_AddsTheValueToExpectedNode()
        {
            BSTNode<int> root = new BSTNode<int>(10);
            BSTNode<int> leftNode = root.Insert(1);

            Assert.Equal(leftNode, root.LeftChild);
            Assert.Null(root.RightChild);

            BSTNode<int> rightNode = root.Insert(11);
            Assert.Equal(rightNode, root.RightChild);
        }

        [Fact]
        public void Remove_SucceedsWhenRemovingLeafNode()
        {
            BSTNode<int> testTree = CreateTestTree(10, 5, 15, 8, 13);
            BSTNode<int> nodeToRemove = testTree.Insert(3);
            nodeToRemove.Remove();

            AssertTreeHasOnlyElements(testTree, new[] { 10, 5, 15, 8, 13 });
        }

        [Fact]
        public void Remove_SucceedsWhenRemovingNodeWithSingleChild()
        {
            BSTNode<int> testTree = CreateTestTree(10, 5, 15, 8, 13);
            BSTNode<int> nodeToRemove = testTree.Insert(3);
            testTree.Insert(1);

            nodeToRemove.Remove();

            AssertTreeHasOnlyElements(testTree, new[] { 1, 10, 5, 15, 8, 13 });
        }

        [Fact]
        public void Remove_SucceedsForNodeWithTwoChildren()
        {
            BSTNode<int> testTree = CreateTestTree(10, 5, 15, 8, 13);
            BSTNode<int> nodeToRemove = testTree.Insert(3);
            testTree.Insert(1);
            testTree.Insert(4);

            nodeToRemove.Remove();

            AssertTreeHasOnlyElements(testTree, new[] { 1, 4, 10, 5, 15, 8, 13 });
        }

        [Fact]
        public void Search_FindsDesiredNode()
        {
            BSTNode<int> root = CreateTestTree(10, 1, 5, 16);
            BSTNode<int> searchNode = root.Insert(4);
            InsertValuesToTree(root, 3, 34);

            Assert.Equal(searchNode, root.Search(4));
        }

        [Fact]
        public void Root_ReturnsTheRealRoot()
        {
            BSTNode<int> root = CreateTestTree(10, 1, 5, 16);
            BSTNode<int> insertedNode = root.Insert(4);

            Assert.Equal(root, insertedNode.Root);
        }

        [Fact]
        public void Traverse_TraversesAllNodesInLeftSelfRightOrder()
        {
            int[] items = new[] { 4, 60, 4, 87, 54, 12, 45, 78, 4, 45, 65 };
            BSTNode<int> root = CreateTestTree(50, items);

            IList<int> visitedItems = new List<int>();
            Action<BSTNode<int>> visitor = node =>
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
        public void FindMinimumNode_ReturnsMinimumNode()
        {
            BSTNode<int> tree = CreateTestTree(10, 5, 15, 8, 13, 18);
            BSTNode<int> expectedNode = tree.Insert(3);

            Assert.Equal(expectedNode, tree.FindMinimumNode());
        }

        [Fact]
        public void FindMaximumNode_ReturnsMaximumNode()
        {
            BSTNode<int> tree = CreateTestTree(10, 5, 15, 3, 8, 13);
            BSTNode<int> expectedNode = tree.Insert(18);

            Assert.Equal(expectedNode, tree.FindMaximumNode());
        }

        [Fact]
        public void FindSuccessor_ReturnsNullForMaximumNode()
        {
            BSTNode<int> testTree = CreateTestTree(10, 15, 13, 5, 8, 3);
            BSTNode<int> nodeToFindSuccessorFor = testTree.Insert(18);

            Assert.Null(nodeToFindSuccessorFor.FindSuccessor());
        }

        [Fact]
        public void FindSuccessor_SucceedsForNodeInLeftSubtree()
        {
            BSTNode<int> testTree = CreateTestTree(10, 15, 13, 18);
            BSTNode<int> expectedSuccessor = testTree.Insert(5);
            expectedSuccessor.Insert(8);
            BSTNode<int> nodeToFindSuccessorFor = testTree.Insert(3);

            Assert.Equal(expectedSuccessor, nodeToFindSuccessorFor.FindSuccessor());
        }

        [Fact]
        public void FindSuccessor_SucceedsForNodeInRightSubtree()
        {
            BSTNode<int> testTree = CreateTestTree(10, 5, 3, 8);
            BSTNode<int> nodeToFindSuccessorFor = testTree.Insert(15);
            testTree.Insert(13);
            BSTNode<int> expectedSuccessor = testTree.Insert(18);

            Assert.Equal(expectedSuccessor, nodeToFindSuccessorFor.FindSuccessor());
        }

        [Fact]
        public void FindPredecessor_ReturnsNullForMinimumNode()
        {
            BSTNode<int> testTree = CreateTestTree(10, 15, 13, 18, 5, 8);
            BSTNode<int> nodeToFindSuccessorFor = testTree.Insert(3);

            Assert.Null(nodeToFindSuccessorFor.FindPredecessor());
        }

        [Fact]
        public void FindPredecessor_SucceedsForNodeInLeftSubtree()
        {
            BSTNode<int> testTree = CreateTestTree(10, 15, 13, 18);
            BSTNode<int> nodeToFindSuccessorFor = testTree.Insert(5);
            testTree.Insert(8);
            BSTNode<int> expectedSuccessor = testTree.Insert(3);

            Assert.Equal(expectedSuccessor, nodeToFindSuccessorFor.FindPredecessor());
        }

        [Fact]
        public void FindPredecessor_SucceedsForNodeInRightSubtree()
        {
            BSTNode<int> testTree = CreateTestTree(10, 5, 3, 8);
            BSTNode<int> nodeToFindSuccessorFor = testTree.Insert(15);
            BSTNode<int> expectedSuccessor = testTree.Insert(13);
            testTree.Insert(18);

            Assert.Equal(expectedSuccessor, nodeToFindSuccessorFor.FindPredecessor());
        }

        /// <summary>
        /// Creates a new binary search tree, given it's root and items to be added to it.
        /// </summary>
        /// <param name="rootValue">The value of the root node.</param>
        /// <param name="items">A list of values to be added to the tree.</param>
        /// <returns>A new binary search tree, build from the requested values.</returns>
        private static BSTNode<int> CreateTestTree(int rootValue, params int[] items)
        {
            BSTNode<int> root = new BSTNode<int>(rootValue);
            if (items != null)
            {
                InsertValuesToTree(root, items);
            }

            return root;
        }

        private static void InsertValuesToTree(BSTNode<int> root, params int[] items)
        {
            foreach (int item in items)
            {
                root.Insert(item);
            }
        }

        private static string GetDebugTreeStructure(BSTNode<int> tree)
        {
            StringBuilder result = new StringBuilder();

            tree.Traverse(node =>
                {
                    result.Append(node.Value + " ");
                });

            return result.ToString();
        }

        /// <summary>
        /// Ensures that the specified arrays have the same elements in the same order.
        /// </summary>
        private static void AssertEqualArrays(int[] sourceArray, int[] actualArray)
        {
            Assert.Equal(sourceArray.Length, actualArray.Length);

            for (int i = 0; i < sourceArray.Length; i++)
            {
                Assert.Equal(sourceArray[i], actualArray[i]);
            }
        }

        private static void AssertTreeHasOnlyElements(BSTNode<int> root, int[] elements)
        {
            IList<int> nodes = new List<int>();
            root.Traverse(node => nodes.Add(node.Value));
            AssertEqualArrays(elements.OrderBy(item => item).ToArray(), nodes.ToArray());
        }
    }
}
