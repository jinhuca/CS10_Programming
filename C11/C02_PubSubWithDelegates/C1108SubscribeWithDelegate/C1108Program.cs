namespace C1108SubscribeWithDelegate;

public class C1108Program
{
  public static void Main()
  {
    var source = new KeyWatcher();
    source.Subscribe(value => Console.WriteLine("Received: " + value));
    source.Run();
  }
}