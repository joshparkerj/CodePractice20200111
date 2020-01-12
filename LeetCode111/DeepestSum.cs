namespace LeetCode111
{
    class DeepestSum
    {
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
