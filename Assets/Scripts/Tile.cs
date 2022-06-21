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
    public Machasanit m;
    public bool _Interactable = true;
    public bool isJoker;
    float counter = 0;
    //[SerializeField] public int ID;


    private void Start()
    {
        SetLayer();
        m = FindObjectOfType<Machasanit>();
    }
    [ContextMenu("Set Layer")]
    private void SetLayer()
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
        counter += (Time.deltaTime * 1.5f);
        if (isJoker)
        {
            Number = (int)counter;
        }
        if (counter > 6)
        {
            counter = 1;
        }

    }


    private void ClickOnTile()
    {


    }


    public IEnumerator FlyToCoru(RectTransform startPos, RectTransform endPos, float duration)
    {
        float t = 0;
        while (t < duration)
        {
            yield return new WaitForEndOfFrame();

            for (int i = 0; i < m.MacsanitMesudert.Count; i++)
            {
                startPos = (RectTransform)m.MacsanitMesudert[i].transform;
                endPos = (RectTransform)m.MachsanitSlots[i].transform;

                t += Time.deltaTime;
                startPos.anchoredPosition = Vector2.Lerp(startPos.anchoredPosition, endPos.anchoredPosition, t / duration);
                //print("Inside");
            }
            //duration = 0;
        }
    }


}
