using System;
using System.Collections.Generic;

namespace LeetCode111
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode testRoot0 = TreeGen(new int?[] { 1, 2, 3 });
            TreeNode testRoot1 = TreeGen(new int?[] { 1, 2, 3, 4, 5, null, 6, 7, null, null, null, null, 8 });
            TreeNode testRoot2 = TreeGen(new int?[] { 9, 9, 9, 9, 9, null, 9, 9, null, 9, null, null, 9, null, null, -5, -6 });
            TreeNode testRoot3 = TreeGen(new int?[] { 99 });

            List<int?> biglist = new List<int?>();
            for (int i = 0; i < 10000; i++)
            {
                biglist.Add(1);
            }

            TreeNode testRoot4 = TreeGen(biglist.ToArray());

            TreeNode testRoot5 = TreeGen(new int?[] { 1, 3, 2, 5 });
            TreeNode testRoot6 = TreeGen(new int?[] { 2, 1, 3, null, 4, null, 7 });
            TreeNode expectedTree0 = TreeGen(new int?[] { 3, 4, 5, 5, 4, null, 7 });

            TreeNode testBst1 = BstGen(new int[] { 10, 5, 15, 3, 7, 18 });
            TreeNode testBst2 = BstGen(new int[] { 10, 5, 15, 3, 7, 13, 18, 1, 6 });
            TreeNode testBst3 = BstGen(new int[] { -5, -6, -1, -7, -19, -9 });
            TreeNode testBst4 = BstGen(new int[] { -9, 18, 19, -10, 0, 1, 2, 4, 3 });

            List<int> biglist2 = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                if (i % 2 == 0)
                {
                    biglist2.Add(5000 - i);
                }
                else
                {
                    biglist2.Add(5000 + i);
                }
            }

            TreeNode testBst5 = BstGen(biglist2.ToArray());

            DeepestSum ds = new DeepestSum();

            RangeSum rs = new RangeSum();

            Console.WriteLine(ds.DeepestLeavesSum(testRoot0));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot1));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot2));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot3));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot4));

            //Console.WriteLine("\ntest bst 1: ");
            //PrintBstInOrder(testBst1);
            //Console.WriteLine("\ntest bst 2: ");
            //PrintBstInOrder(testBst2);
            //Console.WriteLine("\ntest bst 3: ");
            //PrintBstInOrder(testBst3);
            //Console.WriteLine("\ntest bst 4: ");
            //PrintBstInOrder(testBst4);
            //Console.WriteLine("\ntest bst 5: ");
            //PrintBstInOrder(testBst5);

            Console.WriteLine(rs.RangeSumBST(testBst1, 7, 15)); // Expected: 32
            Console.WriteLine(rs.RangeSumBST(testBst2, 6, 10)); // Expected: 23
            Console.WriteLine(rs.RangeSumBST(testBst3, -10, -4)); // Expected: -27
            Console.WriteLine(rs.RangeSumBST(testBst4, -10, 10)); // Expected: -9
            Console.WriteLine(rs.RangeSumBST(testBst5, 1000, 1100)); // Expected: 53550

            MergeBinaryTrees mbt = new MergeBinaryTrees();

            Console.WriteLine(TreesMatch(mbt.MergeTrees(testRoot5, testRoot6), expectedTree0));

            Console.ReadKey();
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
