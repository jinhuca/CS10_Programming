using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

namespace C1111FilterItems;

public partial class MainWindow
{
  public MainWindow()
  {
    InitializeComponent();
    InitializeEvents();
  }

  private void InitializeEvents()
  {
    IObservable<EventPattern<MouseEventArgs>> mouseMoves 
      = Observable.FromEventPattern<MouseEventArgs>(background, nameof(background.MouseMove));
      
    IObservable<Point> dragPositions = mouseMoves
      .Where(move => Equals(Mouse.Captured, background))
      .Select(move => move.EventArgs.GetPosition(background));
      
    dragPositions.Subscribe(point => { line.Points.Add(point); });
  }

  private void OnBackgroundMouseDown(object sender, MouseButtonEventArgs e)
  {
    background.CaptureMouse();
  }

  private void OnBackgroundMouseUp(object sender, MouseButtonEventArgs e)
  {
    if (Equals(Mouse.Captured, background))
    {
      background.ReleaseMouseCapture();
    }
  }
}