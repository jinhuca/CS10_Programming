namespace C1106CreateWithAsyncDelegate;

public class C1106Program
{
  public static void Main()
  {
    var source = DelegateBasedSource.GetFilePusher(Path.Combine(Environment.CurrentDirectory, "Test.txt"));
    var subscriber = new MySubscriber<string>();
    source.Subscribe(subscriber);
  }
}