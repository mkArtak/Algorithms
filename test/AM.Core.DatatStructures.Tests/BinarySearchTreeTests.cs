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
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(10);
            root.Insert(1);
            root.Insert(5);
            root.Insert(16);
            BinarySearchTreeNode<int> searchNode = root.Insert(4);
            root.Insert(3);
            root.Insert(34);

            Assert.Equal(searchNode, root.Search(4));
        }

        [Fact]
        public void Root_ReturnsTheRealRoot()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(10);
            root.Insert(1);
            root.Insert(5);
            root.Insert(16);
            BinarySearchTreeNode<int> insertedNode = root.Insert(4);

            Assert.Equal(root, insertedNode.Root);
        }
    }
}
