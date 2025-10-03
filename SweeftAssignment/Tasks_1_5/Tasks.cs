namespace SweeftAssignment.Tasks_1_5;

public static class Tasks
{
    // Task 1
    public static bool IsPalindrome(string text)
    {
        if (string.IsNullOrEmpty(text))
            return false;
    
        if(text.Length == 1)
            return true;
    
        int left = 0;
        int right = text.Length - 1;
    
        while (left < right)
        {
            if (char.ToLowerInvariant(text[left]) != char.ToLowerInvariant(text[right]))
                return false;
            left++;
            right--;
        }
        return true;
    }

    // Task 2
    public static int MinSplit(int amount)
    {
        int[] coins = [50, 20, 10, 5, 1];
        int count = 0;

        foreach (int coin in coins)
        {
            count += amount / coin;
            amount %= coin;
        }
    
        return count;
    }

    // Task 3 
    public static int NotContains(int[] array)
    {
        HashSet<int> set = new HashSet<int>(array);
    
        int result = 1;
        while (set.Contains(result))
        {
            result++;
        }
    
        return result;
    }
    
    // Task 4
    public static bool IsProperly(string sequence)
    {
        int counter = 0;
    
        foreach (char c in sequence)
        {
            if (c == '(')
                counter++;
            else if (c == ')')
            {
                counter--;
            
                if (counter < 0)
                    return false;
            }
        }
    
        return counter == 0;
    }
    
    // Task 5
    public static int CountVariants(int stairCount)
    {
        switch (stairCount)
        {
            case <= 0:
                return 0;
            case 1:
                return 1;
            case 2:
                return 2;
        }

        int prev2 = 1;
        int prev1 = 2;
        int current = 0;
    
        for (int i = 3; i <= stairCount; i++)
        {
            current = prev1 + prev2;
            prev2 = prev1;
            prev1 = current;
        }
    
        return current;
    }
}