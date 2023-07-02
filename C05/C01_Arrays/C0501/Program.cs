using System.Reflection;

namespace C0501;

public class Program
{
  public static void Main(string[] args)
  {
    demo1();

    int[] numbers = new int[10];
    string[] strings = new string[numbers.Length];
    numbers[0] = 42;
    numbers[1] = numbers.Length;
    numbers[2] = numbers[0] + numbers[1];
    numbers[numbers.Length - 1] = 99;

    Console.WriteLine(GetCopyrightForType(numbers));
  }

  private static string GetCopyrightForType(object o)
  {
    Assembly asm = o.GetType().Assembly;
    var copyrightAttribute =
      (AssemblyCopyrightAttribute)asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true)[0];
    return copyrightAttribute.Copyright;
  }

  private static void demo1()
  {
    Console.WriteLine("Enter array size: ");
    int size = Console.Read();
    int[] arr = new int[size];
    arr[0] = 42;
    //arr[1] = 43;
    //arr[2] = 44;
    arr[7] = 90;
    
    foreach (var element in arr)
    {
      Console.WriteLine(element);
    }

    Console.WriteLine($"The size of array is: {arr.Length}");
  }
}