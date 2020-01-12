namespace LeetCode111
{
    class DeepestSum
    {
        //public int DeepestLeavesSum(TreeNode root, int level = 0, List<int> sums = null)
        //{
        //    if (root == null)
        //    {
        //        return 0;
        //    }

        //    if (sums == null)
        //    {
        //        sums = new List<int>();
        //    }

        //    while (sums.Count < level + 1)
        //    {
        //        sums.Add(0);
        //    }

        //    sums[level] += root.val;

        //    DeepestLeavesSum(root.left, level + 1, sums);
        //    DeepestLeavesSum(root.right, level + 1, sums);

        //    return sums[sums.Count - 1];
        //}

        //public int DeepestLeavesSum(TreeNode root)
        //{
        //    return SumDepth(root, FindDepth(root));
        //}

        //private int FindDepth(TreeNode root, int level = 0)
        //{
        //    if (root == null)
        //    {
        //        return level - 1;
        //    }

        //    int leftDepth = FindDepth(root.left, level + 1);
        //    int rightDepth = FindDepth(root.right, level + 1);

        //    if (leftDepth > rightDepth)
        //    {
        //        return leftDepth;
        //    }
        //    else
        //    {
        //        return rightDepth;
        //    }
        //}

        //private int SumDepth(TreeNode root, int depth, int level = 0)
        //{
        //    int sum = 0;

        //    if (depth == level)
        //    {
        //        return root.val;
        //    }

        //    if (root.left != null)
        //    {
        //        sum += SumDepth(root.left, depth, level + 1);
        //    }

        //    if (root.right != null)
        //    {
        //        sum += SumDepth(root.right, depth, level + 1);
        //    }

        //    return sum;
        //}

        //public int DeepestLeavesSum(TreeNode root)
        //{
        //    int level = 0;
        //    return SumDepth(root, ref level);
        //}

        //private int SumDepth(TreeNode root, ref int level)
        //{
        //    if (root == null)
        //    {
        //        return 0;
        //    }

        //    level++;

        //    int myLevel = level;

        //    int leftSum = SumDepth(root.left, ref level);

        //    int leftLevel = level;

        //    level = myLevel;

        //    int rightSum = SumDepth(root.right, ref level);

        //    if (myLevel == leftLevel && myLevel == level)
        //    {
        //        return root.val;
        //    }

        //    if (level > leftLevel)
        //    {
        //        return rightSum;
        //    }

        //    if (level == leftLevel)
        //    {
        //        return leftSum + rightSum;
        //    }

        //    level = leftLevel;
        //    return leftSum;
        //}

        public int DeepestLeavesSum(TreeNode root)
        {
            int level = 0;
            return SumDepth(root, ref level);
        }

        private int SumDepth(TreeNode root, ref int level)
        {
            level++;

            if (root.left == null)
            {
                if (root.right == null)
                {
                    return root.val;
                }

                return SumDepth(root.right, ref level);
            }

            if (root.right == null)
            {
                return SumDepth(root.left, ref level);
            }

            int myLevel = level;

            int leftSum = SumDepth(root.left, ref level);

            int leftLevel = level;

            level = myLevel;

            int rightSum = SumDepth(root.right, ref level);

            if (level > leftLevel)
            {
                return rightSum;
            }

            if (level == leftLevel)
            {
                return leftSum + rightSum;
            }

            level = leftLevel;
            return leftSum;
        }

    }
}
