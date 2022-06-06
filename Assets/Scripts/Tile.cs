using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MyEnum
{
    blue, yellow, black, red
}
public class Tile : MonoBehaviour
{
    [SerializeField] public int Number;
    [SerializeField] public MyEnum Color;
    //[SerializeField] public int ID;
}
