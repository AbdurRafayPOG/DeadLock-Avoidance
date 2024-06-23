using System;
class GFG
{
    static int n = 5;
    static int m = 4;
    int[,] need;
    int[,] max;
    int[,] alloc;
    int[] avail;
    int[] safeSequence = new int[n];
    void initializeValues()
    {
        need = new int[,] { // Initialize need array here
            { 0, 1, 0, 0 },
            { 0, 4, 2, 1 },
            { 1, 0, 0, 1 },
            { 0, 0, 2, 0 },
            { 0, 6, 4, 2 }
        };
        max = new int[,] {
            { 7, 5, 3, 4 }, //P0
            { 3, 2, 2, 2 }, //P1
            { 9, 0, 2, 2 }, //P2
            { 2, 2, 2, 2 }, //P3 
            { 4, 3, 3, 3 }  //P4
        };
        alloc = new int[,] {
            { 7, 4, 3, 4 }, //P0 
            { 3, 0, 0, 1 }, //P1
            { 8, 0, 2, 1 }, //P2
            { 2, 2, 0, 2 }, //P3
            { 4, 0, 0, 1 }  //P4
        };
        avail = new int[] { 3, 3, 2, 2 };
    }
    void isSafe()
    {
        int count = 0;
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            visited[i] = false;
        }
        int[] work = new int[m];
        for (int i = 0; i < m; i++)
        {
            work[i] = avail[i];
        }
        while (count < n)
        {
            bool flag = false;
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    int j;
                    for (j = 0; j < m; j++)
                    {
                        if (need[i, j] > work[j])
                            break;
                    }
                    if (j == m)
                    {
                        safeSequence[count++] = i;
                        visited[i] = true;
                        flag = true;
                        Console.WriteLine($"Process P{i} is executing, updating resources.");
                        for (j = 0; j < m; j++)
                        {
                            work[j] += alloc[i, j];
                        }
                        Console.WriteLine("Available resources after process execution:");
                        for (int k = 0; k < m; k++)
                        {
                            Console.WriteLine($"Resource Type {(char)('A' + k)}: {work[k]}");
                        }
                        Console.WriteLine();
                    }
                }
            }
            if (!flag)
            {
                break;
            }
        }
        if (count < n)
        {
            Console.WriteLine("The System is UnSafe!");
        }
        else
        {
            Console.WriteLine("The System is Safe.");
            Console.WriteLine("Following is the SAFE Sequence:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("P" + safeSequence[i]);
                if (i != n - 1)
                    Console.Write(" -> ");
            }
            Console.WriteLine();
        }
    }
    void printNeedMatrix()
    {
        Console.WriteLine("Need Matrix:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("P" + i + ": ");
            for (int j = 0; j < m; j++)
            {
                Console.Write(need[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("// ABDUR RAFAY 032 //\n");
        GFG gfg = new GFG();
        gfg.initializeValues();
        gfg.printNeedMatrix();
        gfg.isSafe();
    }
}