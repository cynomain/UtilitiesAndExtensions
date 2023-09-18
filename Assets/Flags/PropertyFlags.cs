using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyFlags
{
    private HashSet<string> flags;

    public bool Contains(string name) => flags.Contains(name);

    public void Add(string name)
    {

    }
}
