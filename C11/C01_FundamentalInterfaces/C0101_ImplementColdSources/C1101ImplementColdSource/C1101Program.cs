namespace C1101ImplementColdSource;

public class C1101Program
{
  public static void Main()
  {
    var source = new SimpleColdSource();
    var subscriber = new MySubscriber<string>();
    source.Subscribe(subscriber);
    Console.ReadLine();
  }
}