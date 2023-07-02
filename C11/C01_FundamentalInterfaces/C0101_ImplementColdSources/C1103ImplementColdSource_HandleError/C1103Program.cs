namespace C1103ImplementColdSource_HandleError;

public class C1103Program
{
  public static void Main()
  {
    var source = new FilePusherErrorHandle(Path.Combine(Environment.CurrentDirectory, "Test.txt"));
    var subscriber = new MySubscriber<string>();
    source.Subscribe(subscriber);
    Console.ReadLine();
  }
}