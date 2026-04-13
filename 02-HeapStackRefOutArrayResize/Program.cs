using System;

class Program
{
    
    static void Main()
    {
        int[] nums = { 14, 20, 35 };

        Console.WriteLine("Köhnə ölçü: " + nums.Length);

        nums = CustomArrResize(nums, 7);

        Console.WriteLine("Yeni ölçü: " + nums.Length);

        Console.WriteLine("Elementlər:");
        foreach (int item in nums)
        {
            Console.Write(item + " ");
        }
    }


    static int[] CustomArrResize(int[] oldArray, int newSize)
    {
        int[] newArray = new int[newSize];

        for (int i = 0; i < oldArray.Length; i++)
        {
            if (i < newSize) 
            {
                newArray[i] = oldArray[i];
            }
        }
        return newArray;
    }
}