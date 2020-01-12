using System;
using System.Collections.Generic;
using System.Diagnostics;

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

            Program p = new Program();
            DeepestSum ds = new DeepestSum();

            //p.PrintGivenLevel(testRoot4, 12);

            //p.PrintGivenLevelRecursive(testRoot4, 12);

            //long iterativeTime = Time(() => p.PrintGivenLevel(testRoot4, 12),1000);
            //long recursiveTime = Time(() => p.PrintGivenLevelRecursive(testRoot4, 12), 1000);

            //Console.WriteLine($"Iterative time was: {iterativeTime}");
            //Console.WriteLine($"Recursive time was: {recursiveTime}");

            //p.PrintLevelOrder(testRoot2);

            Console.WriteLine(ds.DeepestLeavesSum(testRoot0));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot1));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot2));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot3));
            Console.WriteLine(ds.DeepestLeavesSum(testRoot4));

            Console.ReadKey();
        }

        static long Time(Action action, int iterations)
        {
            action();
            Stopwatch s = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }

            return s.ElapsedMilliseconds;
        }

        //public int DeepestLeavesSum(TreeNode root)
        //{
        //    Queue<Tuple<TreeNode, int>> bfsQueue = new Queue<Tuple<TreeNode, int>>();
        //    bfsQueue.Enqueue(new Tuple<TreeNode, int>(root, 0));

        //    int deepestDepth = 0;
        //    int sum = 0;

        //    while (bfsQueue.Count > 0)
        //    {
        //        Tuple<TreeNode, int> item = bfsQueue.Dequeue();
        //        TreeNode node = item.Item1;
        //        int depth = item.Item2;

        //        if (node.left != null)
        //        {
        //            bfsQueue.Enqueue(new Tuple<TreeNode, int>(node.left, depth + 1));
        //        }

        //        if (node.right != null)
        //        {
        //            bfsQueue.Enqueue(new Tuple<TreeNode, int>(node.right, depth + 1));
        //        }

        //        if (node.left == null && node.right == null)
        //        {
        //            if (depth > deepestDepth)
        //            {
        //                deepestDepth = depth;
        //                sum = 0;
        //            }

        //            sum += node.val;
        //        }
        //    }

        //    return sum;
        //}

        public int DeepestLeavesSum(TreeNode root, int level = 0, List<int> sums = null)
        {
            if (root == null)
            {
                return 0;
            }

            if (sums == null)
            {
                sums = new List<int>();
            }

            while (sums.Count < level + 1)
            {
                sums.Add(0);
            }

            sums[level] += root.val;

            DeepestLeavesSum(root.left, level + 1, sums);
            DeepestLeavesSum(root.right, level + 1, sums);

            return sums[sums.Count - 1];
        }



        public void PrintLevelOrder(TreeNode root)
        {
            Queue<TreeNode> bfsQueue = new Queue<TreeNode>();

            bfsQueue.Enqueue(root);

            while (bfsQueue.Count > 0)
            {
                TreeNode node = bfsQueue.Dequeue();
                Console.Write(node.val + " ");

                if (node.left != null)
                {
                    bfsQueue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    bfsQueue.Enqueue(node.right);
                }
            }

            Console.Write("\n");
        }

        public void PrintGivenLevel(TreeNode root, int level)
        {
            Queue<Tuple<TreeNode, int>> bfsQueue = new Queue<Tuple<TreeNode, int>>();
            bfsQueue.Enqueue(new Tuple<TreeNode, int>(root, 0));

            while (bfsQueue.Count > 0)
            {
                Tuple<TreeNode, int> item = bfsQueue.Dequeue();
                TreeNode node = item.Item1;
                int depth = item.Item2;

                if (depth == level)
                {
                    //Console.Write(node.val + " ");
                }

                if (depth > level)
                {
                    break;
                }

                if (node.left != null)
                {
                    bfsQueue.Enqueue(new Tuple<TreeNode, int>(node.left, depth + 1));
                }

                if (node.right != null)
                {
                    bfsQueue.Enqueue(new Tuple<TreeNode, int>(node.right, depth + 1));
                }
            }

            //Console.Write("\n");
        }

        /*
         *  ***Function to print all nodes at a given level***
            
            printGivenLevel(tree, level)
            if tree is NULL then return;
            if level is 1, then
                print(tree->data);
            else if level greater than 1, then
                printGivenLevel(tree->left, level-1);
                printGivenLevel(tree->right, level-1);
        */

        public void PrintGivenLevelRecursive(TreeNode tree, int level)
        {
            if (tree == null)
            {
                return;
            }

            if (level == 1)
            {
                //Console.Write(tree.val + " ");
            }
            else if (level > 1)
            {
                PrintGivenLevelRecursive(tree.left, level - 1);
                PrintGivenLevelRecursive(tree.right, level - 1);
            }
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
