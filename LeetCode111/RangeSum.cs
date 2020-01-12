namespace LeetCode111
{
    class RangeSum
    {
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            int sum = 0;

            if (root.right != null && root.val <= R)
            {
                sum += RangeSumBST(root.right, L, R);
            }

            if (root.left != null && root.val >= L)
            {
                sum += RangeSumBST(root.left, L, R);
            }

            if (root.val >= L && root.val <= R)
            {
                sum += root.val;
            }

            return sum;
        }
    }
}
