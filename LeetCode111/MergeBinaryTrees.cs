namespace LeetCode111
{
    class MergeBinaryTrees
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
            {
                return null;
            }

            if (t1 == null)
            {
                return t2;
            }

            if (t2 == null)
            {
                return t1;
            }

            TreeNode t3 = new TreeNode(t1.val + t2.val);
            t3.left = MergeTrees(t1.left, t2.left);
            t3.right = MergeTrees(t1.right, t2.right);

            return t3;
        }
    }
}
