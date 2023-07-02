namespace C0701;

public class C0701Program
{
  public static void Main()
  {
    var kw = new KeyWatcher();
    kw.Subscribe(Console.WriteLine);
    kw.Run();
  }
}