using System;
namespace fundamentals.tutorial.SafeCast;


/*
 
 Difference between IS and AS operators
 
 /// 'is'

 Purpose: Used to check if an object is compatible with a certain type.
 Result: Returns a bool (true or false).

    object obj = "Hello, World!";
    if (obj is string)
    {
        Console.WriteLine("obj is a string.");
    }
    else
    {
        Console.WriteLine("obj is not a string.");

 /// 'as'

 Purpose: Used to try to cast an object to a certain type.
 Result: Returns the object casted to the desired type if possible; otherwise, returns null. Note that it
         won't throw an exception if the cast is not successful, unlike a direct cast.

    object obj = "Hello, World!";
    string str = obj as string;

    if (str != null)
    {
        Console.WriteLine($"str has a value: {str}");
    }
    else
    {
        Console.WriteLine("str is null.");
    }

}

 */



public class IsAndAsOperators
{
	public IsAndAsOperators()
	{
	}

    static void RunTest()
    {
        var g = new Giraffe();
        var a = new Animal();
        FeedMammals(g);
        FeedMammals(a);
        // Output:
        // Eating.
        // Animal is not a Mammal

        SuperNova sn = new SuperNova();
        TestForMammals(g);
        TestForMammals(sn);
    }

    static void FeedMammals(Animal a)
    {
        if (a is Mammal m)
        {
            m.Eat();
        }
        else
        {
            // variable 'm' is not in scope here, and can't be used.
            Console.WriteLine($"{a.GetType().Name} is not a Mammal");
        }
    }

    static void TestForMammals(object o)
    {
        // You also can use the as operator and test for null
        // before referencing the variable.
        var m = o as Mammal;
        if (m != null)
        {
            Console.WriteLine(m.ToString());
        }
        else
        {
            Console.WriteLine($"{o.GetType().Name} is not a Mammal");
        }
    }
    // Output:
    // I am an animal.
    // SuperNova is not a Mammal

    class Animal
    {
        public void Eat() { Console.WriteLine("Eating."); }
        public override string ToString()
        {
            return "I am an animal.";
        }
    }
    class Mammal : Animal { }
    class Giraffe : Mammal { }

    class SuperNova { }


}


