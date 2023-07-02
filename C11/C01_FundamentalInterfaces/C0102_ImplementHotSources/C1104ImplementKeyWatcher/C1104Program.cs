namespace C1104ImplementKeyWatcher;

public class C1104Program
{
  public static void Main()
  {
    var source = new KeyWatcher();
    var subscriber = new MySubscriber<char>();
    source.Subscribe(subscriber);
    source.Run();
  }
}