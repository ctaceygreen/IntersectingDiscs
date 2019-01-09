using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int[] discOpenPoints = new int[A.Length];
        int[] discClosePoints = new int[A.Length];

        for(int i = 0; i < A.Length; i++)
        {
            var disc = A[i];

            discOpenPoints[i] = i - disc;
            discClosePoints[i] = i + disc;
            
        }
        Array.Sort(discOpenPoints);
        Array.Sort(discClosePoints);

        int openIndex = 0;
        int closeIndex = 0;
        long currentlyOpen = 0;
        long totalIntersections = 0;

        while(openIndex < discOpenPoints.Length && closeIndex < discClosePoints.Length)
        {
            if(discOpenPoints[openIndex] <= discClosePoints[closeIndex])
            {
                //Then a disc has opened. 
                totalIntersections += currentlyOpen;
                currentlyOpen++;
                openIndex++;
            }
            else
            {
                currentlyOpen--;
                closeIndex++;
            }
            if(totalIntersections > 10000000)
            {
                return -1;
            }
        }
        //We shouldn't need to deal with the case of if close index finishes before open index because close should ALWAYS finish after open.

        return (int)totalIntersections;
    }
}