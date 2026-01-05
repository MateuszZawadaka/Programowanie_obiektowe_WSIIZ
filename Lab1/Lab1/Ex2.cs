using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
  class Ex2
  {
    private float[] numbers;
    private float calculatedValue;



    public void setNumbers()
    {
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine($"Podaj liczbę nr{i}");
        numbers[i] = float.Parse(Console.ReadLine());

      }
      Console.WriteLine("Wybrane liczby: ");
      foreach (float number in numbers)
      {
        
        Console.Write($", {number}");
      }
    }

    public float sum()
    {
      calculatedValue = 0;
      foreach (float number in numbers)
      {
        calculatedValue = calculatedValue + number;
      }
      return calculatedValue;
    }

    public float multiplication()
    {
      calculatedValue = 1;
      foreach (float number in numbers)
      {
        calculatedValue = calculatedValue * number;
      }
      return calculatedValue;
    }

    public float average()
    {
      calculatedValue = 0;
      calculatedValue =  sum() / numbers.Length;
      return calculatedValue;
    }

    public float minValue()
    {
      float minValue = numbers[0];
      
      foreach(float number in numbers)
      {
        if(number < minValue)
        {
          minValue = number;
        }
      }
      return minValue;
    }


    public float maxValue()
    {
      float maxValue = numbers[0];
      foreach(float number in numbers)
      {
        if(number> maxValue)
        {
          maxValue = number;
        }
      }
      return maxValue;
    }

    public Ex2()
    {
      numbers = new float[10];
    }


    }
}
