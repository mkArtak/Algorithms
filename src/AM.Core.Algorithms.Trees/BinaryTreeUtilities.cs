namespace AM.Core.Algorithms.Trees;

public static class BinaryTreeUtilities
{
    /// <summary>
    /// Given two integer arrays preorder and inorder, where preorder is the preorder traversal
    /// of a binary tree and inorder is the inorder traversal of the same tree,
    /// construct and return the binary tree.
    /// </summary>
    /// <param name="inorderTraversal"></param>
    /// <param name="preorderTraversal"></param>
    /// <returns>The root of the constructed tree</returns>
    public static BinaryTreeNode<int> RestoreFromArrays(int[] preorderTraversal, int[] inorderTraversal)
    {
        return RestoreFromArrays(preorderTraversal.AsSpan(), inorderTraversal.AsSpan());
    }

    private static BinaryTreeNode<int> RestoreFromArrays(Span<int> preorder, Span<int> inorder)
    {
        var rootValue = preorder[0];
        var root = new BinaryTreeNode<int>(rootValue);
        var separatorIndex = inorder.IndexOf(rootValue);
        var leftSubtreeElementCount = separatorIndex;
        if (leftSubtreeElementCount > 0)
            root.Left = RestoreFromArrays(preorder[1..(1 + separatorIndex)], inorder[0..separatorIndex]);

        var rightSubtreeElementCount = inorder.Length - separatorIndex - 1;
        if (rightSubtreeElementCount > 0)
            root.Right = RestoreFromArrays(preorder[^rightSubtreeElementCount..], inorder[^rightSubtreeElementCount..]);

        return root;
    }

    public static void FlattenBinaryTree<T>(BinaryTreeNode<T> root)
    {
        _ = FlattenAndTakeLast(root);
    }

    private static BinaryTreeNode<T> FlattenAndTakeLast<T>(BinaryTreeNode<T> node)
    {
        if (node is null)
            return null;

        if (node.Left is null && node.Right is null)
            return node;

        var rightRoot = node.Right;
        var leftRoot = node.Left;

        // Left subtree is empty
        if (leftRoot is null)
        {
            var result = FlattenAndTakeLast(rightRoot);
            return result;
        }

        // Right subtree is empty but left subtree is available
        if (rightRoot is null)
        {
            node.Right = leftRoot;
            node.Left = null;
            var result = FlattenAndTakeLast(leftRoot);
            return result;
        }

        // Both left and right subtrees are present
        node.Right = leftRoot;
        node.Left = null;
        var leftTail = FlattenAndTakeLast(leftRoot);
        leftTail.Right = rightRoot;
        var rightTail = FlattenAndTakeLast(rightRoot);

        return rightTail;
    }

    public static int SumNumbers(BinaryTreeNode<int> root)
    {
        return SumNumbersAtLevel(root, 0);
    }

    private static int SumNumbersAtLevel(BinaryTreeNode<int> root, int sum)
    {
        var currentTreeValue = sum * 10 + root.Value;
        var result = 0;
        if (root.Left is not null)
            result += SumNumbersAtLevel(root.Left, currentTreeValue);

        if (root.Right is not null)
            result += SumNumbersAtLevel(root.Right, currentTreeValue);

        // If this is a leaf node, then we should return the value of the full path.
        if (result == 0)
            result = currentTreeValue;

        return result;
    }
}
