using System.Reactive;
using System.Reactive.Linq;

namespace C0902Timers
{
  public class C0902Program
  {
    public static void Main(string[] args)
    {
      //Timers.SingleItem();
      Timers.Interval();
    }
  }

  public static class Timers
  {
    public static void SingleItem()
    {
      IObservable<long> src = Observable.Timer(TimeSpan.FromSeconds(1));
      src.Subscribe(evt => Console.WriteLine($"Event {evt} at {DateTime.Now:T}"));
      Console.ReadLine();
    }

    public static void Timestamped()
    {
      IObservable<Timestamped<long>> src = Observable.Interval(TimeSpan.FromSeconds(1)).Timestamp();
      src.Subscribe(evt => Console.WriteLine($"Event {evt.Value} at {evt.Timestamp.ToLocalTime():T}"));
      Console.ReadLine();
    }

    public static void Interval()
    {
      IObservable<long> ticks = Observable.Interval(TimeSpan.FromSeconds(0.75));
      IObservable<TimeInterval<long>> timed = ticks.TimeInterval();
      timed.Subscribe(evt => Console.WriteLine($"Event {evt.Value} took {evt.Interval.TotalSeconds:F3}"));
      Console.ReadLine();
    }
  }
}