using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace C1112GroupOperators;

public partial class MainWindow
{
  public MainWindow()
  {
    InitializeComponent();
    InitializeEvents();
  }

  private void InitializeEvents()
  {
    IObservable<EventPattern<MouseEventArgs>> downs = Observable.FromEventPattern<MouseEventArgs>(background, nameof(background.MouseDown));
    IObservable<EventPattern<MouseEventArgs>> ups = Observable.FromEventPattern<MouseEventArgs>(background, nameof(background.MouseUp));
    IObservable<EventPattern<MouseEventArgs>> allMoves = Observable.FromEventPattern<MouseEventArgs>(background, nameof(background.MouseMove));

    var dragPointSets =
      from mouseDown in downs
      join move in allMoves
        on ups equals allMoves into m
      select m.Select(e => e.EventArgs.GetPosition(background));

    dragPointSets.Subscribe(dragPoints =>
    {
      var currentLine = new Polyline { Stroke = Brushes.Blue, StrokeThickness = 2 };
      background.Children.Add(currentLine);
      dragPoints.Subscribe(point => { currentLine.Points.Add(point); });
    });
  }
}