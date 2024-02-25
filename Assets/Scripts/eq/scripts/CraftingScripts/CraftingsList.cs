using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingsList : MonoBehaviour
{
    public List<string> item1 = new List<string>(new[] { "item2", "item3" });
    public List<string> item2 = new List<string>(new[] { "item1", "item3" });
    public List<string> item3 = new List<string>(new[] { "item1", "item2" });

    public List<string> allItemsToCraft = new List<string>(new[] {"item1","item2","item3"});
}
