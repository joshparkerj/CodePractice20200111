using System;
using System.Collections.Generic;

namespace LeetCode111
{
    class Program
    {
        static void Main(string[] args)
        {
            MinFlipsClass mf = new MinFlipsClass();
            Console.WriteLine(mf.MinFlips(2, 6, 5));
            Console.WriteLine(mf.MinFlips(4, 2, 7));
            Console.WriteLine(mf.MinFlips(1, 2, 3));
            Console.WriteLine(mf.MinFlips(8, 3, 5)); // Expected 3

            Console.ReadKey();
        }

        static void WriteInts(int[] ints)
        {
            foreach (int i in ints)
            {
                Console.Write(i + " ");
            }

            Console.Write("\n");
        }

        static TreeNode TreeGen(int?[] vals)
        {
            TreeNode root = new TreeNode((int)vals[0]);

            Queue<TreeNode> bfsQueue = new Queue<TreeNode>();

            bfsQueue.Enqueue(root);

            for (int i = 1; i < vals.Length; i += 2)
            {
                TreeNode node = bfsQueue.Dequeue();
                if (vals[i] != null)
                {
                    node.left = new TreeNode((int)vals[i]);
                    bfsQueue.Enqueue(node.left);
                }

                if (i + 1 < vals.Length && vals[i + 1] != null)
                {
                    node.right = new TreeNode((int)vals[i + 1]);
                    bfsQueue.Enqueue(node.right);
                }
            }

            return root;
        }

        static TreeNode BstGen(int[] vals)
        {
            TreeNode root = new TreeNode(vals[0]);

            for (int i = 1; i < vals.Length; i++)
            {
                InsertBstVal(root, vals[i]);
            }

            return root;
        }

        static void InsertBstVal(TreeNode node, int val)
        {
            if (val < node.val)
            {
                if (node.left == null)
                {
                    node.left = new TreeNode(val);
                }
                else
                {
                    InsertBstVal(node.left, val);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new TreeNode(val);
                }
                else
                {
                    InsertBstVal(node.right, val);
                }
            }
        }

        static void PrintBstInOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            PrintBstInOrder(node.left);
            Console.Write(node.val + " ");
            PrintBstInOrder(node.right);
        }

        static bool TreesMatch(TreeNode a, TreeNode b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null || (a.val != b.val))
            {
                return false;
            }

            return TreesMatch(a.left, b.left) && TreesMatch(a.right, b.right);
        }
    }
}
