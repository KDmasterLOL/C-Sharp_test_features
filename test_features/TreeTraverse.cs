using System;
using DataStructure;

namespace test_features;

public static class TreeTraverse
{
    public static void InOrder<T>(Tree<T> tree) where T : IComparable, IFormattable
    {
        if (tree is null)
            return;
        InOrder(tree.Left);
        WriteLine(tree.Value);
        InOrder(tree.Right);
    }
    public static void PreOrder<T>(Tree<T> tree) where T : IComparable, IFormattable
    {
        if (tree is null)
            return;
        WriteLine(tree.Value);
        PreOrder(tree.Left);
        PreOrder(tree.Right);
    }
    public static void PostOrder<T>(Tree<T> tree) where T : IComparable, IFormattable
    {
        if (tree is null)
            return;
        PostOrder(tree.Left);
        PostOrder(tree.Right);
        WriteLine(tree.Value);
    }
}

