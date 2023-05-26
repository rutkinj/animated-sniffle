using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] Image red;
    [SerializeField] Image blue;
    [SerializeField] Image green;
    List<KeyType> keys = new List<KeyType>();

    public void AddKey(KeyType keyType)
    {
        keys.Add(keyType);
        //truly shameful but I'm running out of time lol
        if(keyType == KeyType.Red){
            red.enabled = true;
        }
        else if(keyType == KeyType.Green){
            green.enabled = true;
        }
        else if (keyType == KeyType.Blue){
            blue.enabled = true;
        }
    }

    public void RemoveKey(KeyType keyType)
    {
        keys.Remove(keyType);
    }

    public bool IsHoldingKey(KeyType keyType)
    {
        return keys.Contains(keyType);
    }
}
