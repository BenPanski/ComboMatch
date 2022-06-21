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
    Machasanit m;

    public GameObject VFX;
    //[SerializeField] public int ID;


    private void Start()
    {
<<<<<<< HEAD
        m = FindObjectOfType<Machasanit>();
=======
        SetLayer();
        m = FindObjectOfType<Machasanit>();
    }
    [ContextMenu("Set Layer")]
    private void SetLayer()
    {
>>>>>>> d090a0c7235e53feadcb9196728c1367b38b8e27
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
<<<<<<< HEAD
        counter += (Time.deltaTime * 1.5f);
        if (isJoker)
        {
            Number = (int)counter;
        }
        if (counter > 6)
=======
        if (_Comboabol)
>>>>>>> test
        {
            StartCoroutine(waitsec());
        }

    }

    public IEnumerator FlyToCoru(float duration)
    {
        RectTransform startPos;
        RectTransform endPos;
        float t = 0;
        while (t < duration)
        {
            yield return new WaitForEndOfFrame();
            for (int i = 0; i < m.MacsanitMesudert.Count; i++)
            {
                startPos = (RectTransform)m.MacsanitMesudert[i].transform;
                endPos = (RectTransform)m.MachsanitSlots[i].transform;

<<<<<<< HEAD
                t += Time.deltaTime;
                startPos.anchoredPosition = Vector2.Lerp(startPos.anchoredPosition, endPos.anchoredPosition, t / duration);
                //print("Inside");
            }
            //duration = 0;
        }
    }
    public IEnumerator FlyToED(float duration)
    {
        RectTransform startPos;
        RectTransform endPos;
=======
<<<<<<< HEAD
    private void ClickOnTile()
    {


    }


    public IEnumerator FlyToCoru(RectTransform startPos, RectTransform endPos, float duration)
    {
>>>>>>> d090a0c7235e53feadcb9196728c1367b38b8e27
        float t = 0;
        while (t < duration)
        {
            yield return new WaitForEndOfFrame();
<<<<<<< HEAD
            for (int i = 0; i < m.MacsanitMesudert.Count; i++)
            {
                startPos = (RectTransform)m.MacsanitMesudert[i].transform;
                endPos = m.winTile;
=======

            for (int i = 0; i < m.MacsanitMesudert.Count; i++)
            {
                startPos = (RectTransform)m.MacsanitMesudert[i].transform;
                endPos = (RectTransform)m.MachsanitSlots[i].transform;
>>>>>>> d090a0c7235e53feadcb9196728c1367b38b8e27

                t += Time.deltaTime;
                startPos.anchoredPosition = Vector2.Lerp(startPos.anchoredPosition, endPos.anchoredPosition, t / duration);
                //print("Inside");
            }
            //duration = 0;
        }
    }
<<<<<<< HEAD
=======


=======
>>>>>>> d090a0c7235e53feadcb9196728c1367b38b8e27
    private IEnumerator waitsec()
    {
        yield return new WaitForSeconds(1f);
        VFX.SetActive(true);
    }
>>>>>>> test
}
