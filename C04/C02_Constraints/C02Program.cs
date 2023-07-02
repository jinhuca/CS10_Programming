namespace C02_Constraints
{
  internal class C02Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello, World!");
    }
  }

  public static class Deferred<T> where T : new()
  {
    private static T? _instance;

    public static T Instance
    {
      get
      {
        if(_instance == null)
        {
          _instance = new T();
        }
        return _instance;
      }
    }
  }
}