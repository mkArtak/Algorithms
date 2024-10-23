namespace AM.Core.Algorithms.Trees.Tests;

[TestClass]
public class BinaryTreeTests
{
    [TestMethod]
    public void FindTree_ThrowsForNullTree()
    {
        Assert.ThrowsException<NullReferenceException>(() => BinaryTree<int>.FindTreeWidth(null));
    }

    [TestMethod]
    public void FindTree_ReturnsZeroForSingleNodeTree()
    {
        var sut = new BinaryTreeNode<int>(0);
        Assert.AreEqual(0, BinaryTree<int>.FindTreeWidth(sut));
    }

    [TestMethod]
    public void FindTree_Succeeds()
    {
        var root = new BinaryTreeNode<int>(1);
        root.Left = new BinaryTreeNode<int>(2);
        root.Right = new BinaryTreeNode<int>(3);
        root.Left.Left = new BinaryTreeNode<int>(4);
        root.Left.Right = new BinaryTreeNode<int>(5);

        Assert.AreEqual(3, BinaryTree<int>.FindTreeWidth(root));
    }

    [TestMethod]
    public void FindTree_WithSingleRightChild()
    {
        var root = new BinaryTreeNode<int>(1);
        root.Right = new BinaryTreeNode<int>(2);

        Assert.AreEqual(1, BinaryTree<int>.FindTreeWidth(root));
    }


    [TestMethod]
    public void FindTree_LinearTreeReturnsLength()
    {
        var root = new BinaryTreeNode<int>(1);
        root.Right = new BinaryTreeNode<int>(2);
        root.Right.Right = new BinaryTreeNode<int>(3);
        root.Right.Right.Right = new BinaryTreeNode<int>(4);

        Assert.AreEqual(3, BinaryTree<int>.FindTreeWidth(root));

    }
}