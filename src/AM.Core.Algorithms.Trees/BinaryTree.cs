using System.Diagnostics;

namespace AM.Core.Algorithms.Trees;

public static class BinaryTree<T>
{
    public static int FindTreeWidth(BinaryTreeNode<T> root)
    {
        if (root == null)
            throw new NullReferenceException();


        return FindMaxForNode(root, out var maxDepth);
    }

    private static int FindMaxForNode(BinaryTreeNode<T> node, out int maxDepth)
    {
        if (node.Left == null && node.Right == null)
        {
            maxDepth = 0;
            return 0;
        }

        var maxLeftDepth = 0;
        var maxRightDepth = 0;

        var maxLeft = 0;
        var maxRight = 0;


        if (node.Left != null)
        {
            maxLeft = FindMaxForNode(node.Left, out maxLeftDepth);
            maxLeftDepth++;
        }

        if (node.Right != null)
        {
            maxRight = FindMaxForNode(node.Right, out maxRightDepth);
            maxRightDepth++;
        }

        var maxWithinChildren = Math.Max(maxLeft, maxRight);

        maxDepth = Math.Max(maxLeftDepth, maxRightDepth);

        var combinedMax = maxLeftDepth + maxRightDepth;
        return Math.Max(combinedMax, maxWithinChildren);
    }
}

[DebuggerDisplay("Value = {Value}")]
public class BinaryTreeNode<T>
{
    public BinaryTreeNode<T>? Left { get; set; }

    public BinaryTreeNode<T>? Right { get; set; }

    public T Value { get; set; }

    public BinaryTreeNode(T value)
    {
        Value = value;
    }
}
