using System.Reactive.Linq;

namespace C0901Intervals;

public class C0901Program
{
  public static void Main()
  {
    //Intervals.RegularIntervals();
    Intervals.TwoSubscribers();
    Console.ReadLine();
  }
}

public static class Intervals
{
  public static void RegularIntervals()
  {
    IObservable<long> src = Observable.Interval(TimeSpan.FromSeconds(1));
    src.Subscribe(evt => Console.WriteLine($"Event {evt} at {DateTime.Now:T}"));
  }

  public static void TwoSubscribers()
  {
    IObservable<long> src = Observable.Interval(TimeSpan.FromSeconds(1));
    src.Subscribe(evt => Console.WriteLine($"Event {evt} at {DateTime.Now:T}"));
    Thread.Sleep(2000);
    src.Subscribe(evt => Console.WriteLine($"Event {evt} at {DateTime.Now:T} (2nd subscriber)"));
  }
}