namespace InterviewPrep;

public static class ArrayMultiplier
{
    // [1, 2, 3, 4] => [2*3*4, 1*3*4, 1*2*4, 1*2*3] => [1 * (2*3*4), (1*1)*(3*4), (1*1*2)*4, (1*2*3)*4]
    public static int[] MultiplyByAllRecordsExceptSelf(int[] nums)
    {
        
        // Result array will be same length.
        var result = new int[nums.Length];
        
        // Start multiplier at 1.
        // Multiplier will represent the product of all previous records.
        // We update it by multiply it by the current record.
        // Ex: [1, 2, 3, 4] => [1, 1, 2, 6]
        var multiplier = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = multiplier;
            
            // multiply multiplier by current record.
            // Gives us product of all predecessors
            multiplier = multiplier * nums[i];
        }
        
        // Need to do the same, but for a records successors. Start from end of array.
        // [1, 1, 3, 6] => [24, 12, 8, 6]
        multiplier = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            // Use result now. It is populated from before and has predecessor multiplied records.
            result[i] = result[i] * multiplier;
            
            // Still use nums to update multiplier since it is original value.
            multiplier = multiplier * nums[i];
        }

        return result;
    }
}