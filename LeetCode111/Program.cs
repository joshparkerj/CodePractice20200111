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

            DeepestSum ds = new DeepestSum();

            Console.WriteLine(ds.DeepestLeavesSum(testRoot0));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot1));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot2));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot3));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot4));

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
    }
}
