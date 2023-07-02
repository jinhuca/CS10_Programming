namespace C0101
{
  public class Program
  {
    public static void Main()
    {
      demo1_PassDelegate();
      ConstructADelegate();
      ImplicitDelegateCreation();
    }

    private static bool IsGreaterThanZero(int value) => value > 0;

    public static int GetIndexOfFirstNonEmptyBin(int[] bins) => Array.FindIndex(bins, IsGreaterThanZero);

    private static void demo1_PassDelegate()
    {
      int[] arr = { 0, 0, 3, 5, 7, 1, 0, 9, 4 };
      Console.WriteLine(GetIndexOfFirstNonEmptyBin(arr));
    }

    private static void ConstructADelegate()
    {
      var p = new Predicate<int>(IsGreaterThanZero);
      Console.WriteLine(p(42));
    }

    private static void ImplicitDelegateCreation()
    {
      Predicate<int> p = IsGreaterThanZero;
      Console.WriteLine(p(-41));
    }
  }
}