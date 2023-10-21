using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Item", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int score;
    public AudioClip audio;
}
