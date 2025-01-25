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
}
