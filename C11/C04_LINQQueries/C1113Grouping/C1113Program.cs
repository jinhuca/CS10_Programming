using System.ComponentModel.Design;
using System.Reactive;
using System.Reactive.Linq;

namespace C1113Grouping;

public class C1113Program
{
  public static void Main()
  {
    GroupEvents();
    Console.ReadLine();
  }

  private static void GroupEvents()
  {
    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    var w = new FileSystemWatcher(path);
    IObservable<EventPattern<FileSystemEventArgs>> changes =
      Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
        handler => w.Changed += handler, handler => w.Changed -= handler);
    w.IncludeSubdirectories=true;
    w.EnableRaisingEvents = true;

    IObservable<IGroupedObservable<string, string>> folders =
      from change in changes
      group Path.GetFileName(change.EventArgs.FullPath)
        by Path.GetDirectoryName(change.EventArgs.FullPath);

    folders.Subscribe(f =>
    {
      Console.WriteLine($"New folder ({f.Key})");
      f.Subscribe(file => Console.WriteLine($"File changed in folder {f.Key}, {file}"));
    });
  }
}