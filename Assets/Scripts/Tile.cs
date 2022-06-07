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
    [SerializeField] public bool _Comboabol = false;
    public bool _Interactable = true;
    //[SerializeField] public int ID;

    public void ComboMaker()
    {

        StartCoroutine(wait());

    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
        if (_Comboabol && !_Interactable)
        {
            Machasanit.Instance.DestoryCombo(Number);
        }

    }

}
