namespace C1105CreateWithDelegates;

public class C1105Program
{
  public static void Main()
  {
    var source = DelegateBasedSource.GetFilePusher(Path.Combine(Environment.CurrentDirectory, "Test.txt"));
    var subscriber = new MySubscriber<string>();
    source.Subscribe(subscriber);
  }
}