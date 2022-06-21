using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MyEnum
{
    blue, yellow, black, red
}
public class Tile : MonoBehaviour
{
    [SerializeField] public int Layer;
    [SerializeField] public int Number;
    [SerializeField] public MyEnum Color;
    [SerializeField] public bool _Comboabol = false;
    public bool _Interactable = true;
    public bool isJoker;
    float counter = 0;

    public GameObject VFX;
    //[SerializeField] public int ID;


    private void Start()
    {
        transform.SetSiblingIndex(Layer);
    }
    public void ComboMaker()
    {

        if (_Comboabol && !_Interactable)
        {
            Machasanit.Instance.DestoryCombo(Number);
        }

    }
    private void Update()
    {
        if (_Comboabol)
        {
            StartCoroutine(waitsec());
        }

    }


    private IEnumerator waitsec()
    {
        yield return new WaitForSeconds(1f);
        VFX.SetActive(true);
    }
}
