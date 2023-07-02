namespace C01_Define
{
  internal class C01Program
  {
    static void Main(string[] args)
    {
      Demo();
    }

    static void Demo()
    {
      var a = new NamedContainer<int>(42, "The answer");
      var b = new NamedContainer<int>(99, "Number of red balloons");
      var c = new NamedContainer<string>("Programming C#", "Book title");

      var namedInts = new List<NamedContainer<int>> { a, b };
    }
  }

  public class NamedContainer<T>
  {
    public NamedContainer(T item, string name)
    {
      Item = item;
      Name = name;
    }

    public T Item { get; }
    public string Name { get; }
  }
}