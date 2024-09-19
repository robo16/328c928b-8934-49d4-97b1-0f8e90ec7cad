namespace LISMinimalApi;

public class LISFinder
{
    public List<int> FindLongestIncreasingSubsequence(List<int> sequence)
    {
        if (sequence == null || sequence.Count == 0)
        {
            return new List<int>();
        }

        List<int> tails = new List<int>();
        List<int> prevTails = new List<int>();

        for (int i = 0; i < sequence.Count; i++)
        {
            int num = sequence[i];
            int index = BinarySearch(tails, num);

            if (index >= tails.Count)
            {
                tails.Add(num);
            }
            else
            {
                if (prevTails.Count < tails.Count)
                {
                    prevTails.Clear();
                    prevTails.AddRange(tails);
                }
                tails.Clear();
                tails.Add(num);

            }
        }

        List<int> lis = (prevTails.Count >= tails.Count) ? prevTails : tails;
    
        return lis;
    }


    private int BinarySearch(List<int> tails, int target)
    {
        int left = 0, right = tails.Count;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (tails[mid] < target) left = mid + 1;
            else right = mid;
        }

        return left;
    }
    
}