using System.Reactive;
using System.Reactive.Linq;

namespace C0801FromEvents
{
  public class C0801Program
  {
    public static void Main()
    {
      //Events.NameBasedWrapping();
      Events.DelegateBasedWrapped();
      Console.ReadLine();
    }
  }

  public static class Events
  {
    public static void NameBasedWrapping()
    {
      string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
      var watcher = new FileSystemWatcher(path);
      watcher.EnableRaisingEvents = true;

      IObservable<EventPattern<FileSystemEventArgs>> changes =
        Observable.FromEventPattern<FileSystemEventArgs>(watcher, nameof(watcher.Created));

      changes.Subscribe(evt => Console.WriteLine(evt.EventArgs.FullPath));
    }

    public static void DelegateBasedWrapped()
    {
      string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
      var watcher = new FileSystemWatcher(path);
      watcher.EnableRaisingEvents = true;

      IObservable<EventPattern<FileSystemEventArgs>> changes =
        Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
          handler => watcher.Created += handler, handler => watcher.Created -= handler);

      changes.Subscribe(evt => Console.WriteLine(evt.EventArgs.FullPath));
    }
  }
}