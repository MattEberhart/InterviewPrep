using Accord.Math;

namespace InterviewPrep;

public class DivisibleByDigitNumber
{
    private int[] digits = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private int[] combinations;

    public DivisibleByDigitNumber()
    {
        var combos = digits.Combinations(false);
        
        
        
    }

    
    private int GetNumber()
    {
        var permuations = Enumerable.Range(123456789, 987654321);
        var stringPerms = permuations.Select(_ => _.ToString());
        stringPerms = stringPerms.Where((_) => _.Distinct().Count() == 9);

        foreach (var item in stringPerms)
        {

            for (int x = 9; x > 0; x--)
            {
                int value = int.Parse(item[0..(x-1)]);

                if (value % x != 0)
                {
                    break;
                }

                if (x == 1)
                {
                    return value;
                }
            }
        }

        return 0;

    }

    private bool IsDivisibleBy(int num, int divisor)
    {
        return num % divisor == 0;
    }
}