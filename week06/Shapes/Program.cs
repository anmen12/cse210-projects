using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("red", 1.2));
        shapes.Add(new Rectangle("blue", 3.3, 7.1));
        shapes.Add(new Circle("orange", 5));
        
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()} | Area: {shape.GetArea()}\n");
        }
    }
}