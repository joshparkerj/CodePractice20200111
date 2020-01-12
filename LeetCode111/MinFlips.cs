namespace LeetCode111
{
    class MinFlips
    {
        public int MinFlips(int a, int b, int c)
        {
            int flips = 0;

            while (c > 0)
            {
                if (c % 2 == 1 && a % 2 != 1 && b % 2 != 1)
                {
                    flips++;
                }

                if (c % 2 == 0)
                {
                    if (a%2 != 0)
                    {
                        flips++;
                    }

                    if (b%2 != 0)
                    {
                        flips++;
                    }
                }

                a /= 2;
                b /= 2;
                c /= 2;
            }

            return flips;
        }
    }
}
