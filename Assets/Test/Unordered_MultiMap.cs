using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;


public class Unordered_MultiMap<V>
{
    // 1
    Dictionary<string, List<V>> _dictionary = new Dictionary<string, List<V>>();

    // 2
    public void Add(string key, V value)
    {
        List<V> list;
        if (this._dictionary.TryGetValue(key, out list))
        {
            list.Add(value);
        }
        else
        {
            list = new List<V>();
            list.Add(value);
            this._dictionary[key] = list;
        }
    }

    // 3
    public IEnumerable<string> Keys
    {
        get
        {
            return this._dictionary.Keys;
        }
    }

    // 4
    public List<V> this[string key]
    {
        get
        {
            List<V> list;
            if (!this._dictionary.TryGetValue(key, out list))
            {
                list = new List<V>();
                this._dictionary[key] = list;
            }
            return list;
        }
    }
}


