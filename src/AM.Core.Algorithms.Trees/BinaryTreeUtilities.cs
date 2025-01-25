using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        BinaryTreeNode<int> root = new BinaryTreeNode<int>(rootValue);
        var separatorIndex = inorder.IndexOf(rootValue);
        var leftSubtreeElementCount = separatorIndex;
        if (leftSubtreeElementCount > 0)
            root.Left = RestoreFromArrays(preorder[1..(1 + separatorIndex)], inorder[0..separatorIndex]);

        var rightSubtreeElementCount = inorder.Length - separatorIndex - 1;
        if (rightSubtreeElementCount > 0)
            root.Right = RestoreFromArrays(preorder[^rightSubtreeElementCount..], inorder[^rightSubtreeElementCount..]);

        return root;
    }
}
