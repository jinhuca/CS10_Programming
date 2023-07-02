namespace C1102ImplementColdSource_FilePusher;

public class C0102Program
{
  public static void Main()
  {
    var source = new FilePusher(Path.Combine(Environment.CurrentDirectory, "Test.txt"));
    var subscriber = new MySubscriber<string?>();
    source.Subscribe(subscriber);
  }
}