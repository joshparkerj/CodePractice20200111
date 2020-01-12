using System;
using System.Linq;

namespace LeetCode111
{
    class ConnectNetwork
    {
        public int MakeConnected(int n, int[][] connections)
        {
            if (connections.Length < n - 1)
            {
                return -1;
            }

            int[] computers = new int[n];

            for (int i = 0; i < n; i++)
            {
                computers[i] = n;
            }

            foreach (int[] connection in connections)
            {
                int min = Math.Min(computers[connection[0]], computers[connection[1]]);
                computers[connection[0]] = min;
                computers[connection[1]] = min;
            }

            return computers.Distinct().Count() - 1;
        }
    }
}
