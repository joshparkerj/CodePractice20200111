namespace LeetCode111
{
    class NoZero
    {
        public int[] GetNoZeroIntegers(int n)
        {
            int remainder = 1;

            while (true)
            {
                if (HasNoZero(remainder) && HasNoZero(n - remainder))
                {
                    break;
                }

                remainder++;
            }

            return new int[] { n - remainder, remainder };
        }

        private bool HasNoZero(int n)
        {
            while (n > 0)
            {
                if (n % 10 == 0)
                {
                    return false;
                }

                n /= 10;
            }

            return true;
        }
    }
}
