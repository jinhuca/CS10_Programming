using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows;
using static System.Threading.SynchronizationContext;

namespace C0601ObserveOnExample
{
  public partial class MainWindow
  {
    public MainWindow()
    {
      InitializeComponent();
      InitializeSequence();
    }

    private void InitializeSequence()
    {
      IObservable<Trade> trades = GetTradeStream();
      IObservable<Trade> tradesInUiContext = trades.ObserveOn(Current!);
      tradesInUiContext.Subscribe(t =>
      {
        tradeInfoTextBox.AppendText($"{t.StockName}: {t.Number} at {t.UnitPrice}\r\n");
      });
    }

    private IObservable<Trade> GetTradeStream()
    {
      return Trade.TestStreamSlow();
    }
  }
}
