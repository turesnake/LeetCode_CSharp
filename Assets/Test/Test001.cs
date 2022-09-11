

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;


public class Test001
{
    public static void Main()
    {
        // Just types covering some different assemblies
        Type[] sampleTypes = new[] { 
            typeof(List<>), 
            typeof(string), 
            typeof(Enumerable), 
            typeof(XmlReader)                         
        };

        // All the types in those assemblies
        // 这些程序集 里的所有类型....
        IEnumerable<Type> allTypes = sampleTypes.Select(t => t.Assembly)
                                               .SelectMany(a => a.GetTypes());

        // Grouped by namespace, but indexable
        ILookup<string, Type> lookup = allTypes.ToLookup(t => t.Namespace);

        foreach (Type type in lookup["System"])
        {
            // Console.WriteLine("{0}: {1}", 
            //                   type.FullName, type.Assembly.GetName().Name);

            Debug.Log( type.FullName + ": " + type.Assembly.GetName().Name );
        }
    }
}

