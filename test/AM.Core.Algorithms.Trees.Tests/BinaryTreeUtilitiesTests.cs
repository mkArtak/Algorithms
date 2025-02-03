namespace AM.Core.Algorithms.Trees.Tests;

[TestClass]
public class BinaryTreeUtilitiesTests
{
    [TestMethod]
    public void RestoreFromArrays_Succeeds()
    {
        // Setup
        int[] preorder = [3, 9, 20, 15, 7];
        int[] inorder = [9, 3, 15, 20, 7];

        // Act
        BinaryTreeNode<int> result = BinaryTreeUtilities.RestoreFromArrays(preorder, inorder);

        // Validate

        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Value);

        Assert.IsNotNull(result.Left);
        Assert.AreEqual(9, result.Left.Value);

        Assert.IsNotNull(result.Right);
        Assert.AreEqual(20, result.Right.Value);

        Assert.IsNotNull(result.Right.Left);
        Assert.AreEqual(15, result.Right.Left.Value);

        Assert.IsNotNull(result.Right.Right);
        Assert.AreEqual(7, result.Right.Right.Value);
    }

    [TestMethod]
    public void FlattenBinaryTree_DoesNothingForSingleNodeTree()
    {
        var tree = new BinaryTreeNode<int>(5);

        BinaryTreeUtilities.FlattenBinaryTree(tree);

        Assert.IsNull(tree.Left);
        Assert.IsNull(tree.Right);

        Assert.Equals(5, tree.Value);
    }

    [TestMethod]
    public void FlattenBinaryTree_ReturnsFlattenedTree()
    {
        var root = new BinaryTreeNode<int>(1);

        root.Left = new BinaryTreeNode<int>(2);
        root.Left.Left = new BinaryTreeNode<int>(3);
        root.Left.Right = new BinaryTreeNode<int>(4);

        root.Right = new BinaryTreeNode<int>(5);
        root.Right.Right = new BinaryTreeNode<int>(6);

        BinaryTreeUtilities.FlattenBinaryTree(root);

        var currentNode = root;
        for (var i = 1; i <= 6; i++)
        {
            Assert.IsNull(currentNode.Left);
            Assert.AreEqual(i, currentNode.Value);
            currentNode = currentNode.Right;
        }
    }

    [TestMethod]
    public void FlattenBinaryTree_SucceedsForFlattenedTree()
    {
        var root = new BinaryTreeNode<int>(1);
        root.Right = new BinaryTreeNode<int>(2);

        BinaryTreeUtilities.FlattenBinaryTree(root);

        Assert.AreEqual(1, root.Value);
        Assert.AreEqual(2, root.Right.Value);
        Assert.IsNull(root.Left);
        Assert.IsNull(root.Right.Left);
        Assert.IsNull(root.Right.Right);
    }

    [TestMethod]
    public void SumNumbers_ReturnsNodeValueForASingleNodeTree()
    {
        var node = new BinaryTreeNode<int>(5);

        Assert.AreEqual(5, BinaryTreeUtilities.SumNumbers(node));
    }

    [TestMethod]
    public void SumNumbers_Succeeds()
    {
        var root = new BinaryTreeNode<int>(1);
        root.Left = new BinaryTreeNode<int>(2);
        root.Right = new BinaryTreeNode<int>(3);

        Assert.AreEqual(25, BinaryTreeUtilities.SumNumbers(root));
    }
}
