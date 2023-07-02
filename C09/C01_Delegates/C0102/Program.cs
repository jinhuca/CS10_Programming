namespace C0102
{
  public class Program
  {
    private static bool IsGreaterThanZero(int value) => value > 0;

    public static void CreateADelegate()
    {
      var p = IsGreaterThanZero;
      Console.WriteLine(p(42));
    }

    public static void Main(string[] args)
    {
      CreateADelegate();
    }
  }
}