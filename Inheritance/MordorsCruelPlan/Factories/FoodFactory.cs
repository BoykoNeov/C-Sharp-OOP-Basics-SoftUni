using System;
using System.Collections.Generic;
using System.Linq;

public static class FoodFactory
{
    private static Dictionary<string, string> validFoodsLowerCase;

    static FoodFactory()
    {
        validFoodsLowerCase = typeof(Food)
        .Assembly.GetTypes()
        .Where(t => t.IsSubclassOf(typeof(Food)) && !t.IsAbstract).Select(t => t.Name).ToDictionary(t => t.ToLower(), t => t);
    }

    public static IReadOnlyCollection<string> ValidFoods
    {
        get => validFoodsLowerCase.Values;
    }

    public static Food CreateFood(string foodName)
    {
        Food newFood = null;

        if (validFoodsLowerCase.ContainsKey(foodName.ToLower()))
        {
            newFood = Activator.CreateInstance(Type.GetType(validFoodsLowerCase[foodName.ToLower()])) as Food;
        }
        else
        {
            newFood = new EverythingElse();
        }

        return newFood;
    }


    // Some ideas from StackOverflow:

    //public static class ReflectiveEnumerator
    //{
    //    static ReflectiveEnumerator() { }

    //    public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
    //    {
    //        List<T> objects = new List<T>();
    //        foreach (Type type in
    //            Assembly.GetAssembly(typeof(T)).GetTypes()
    //            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
    //        {
    //            objects.Add((T)Activator.CreateInstance(type, constructorArgs));
    //        }

    //        objects.Sort();
    //        return objects;
    //    }
    //}

    // A few notes:

    // Don't worry about the "cost" of this operation - you're only going to be doing it once(hopefully) and even then it's not as slow as you'd think.
    //You need to use Assembly.GetAssembly(typeof(T)) because your base class might be in a different assembly.
    //You need to use the criteria type.IsClass and !type.IsAbstract because it'll throw an exception if you try to instantiate an interface or abstract class.
    // I like forcing the enumerated classes to implement IComparable so that they can be sorted.
    // Your child classes must have identical constructor signatures, otherwise it'll throw an exception. This typically isn't a problem for me.
}