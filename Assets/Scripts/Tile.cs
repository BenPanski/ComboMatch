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
<<<<<<< HEAD
<<<<<<< HEAD
    //public bool _GettingDestoryed = false;
=======
    public bool isJoker;
    public bool _GettingDestoryed = false;
>>>>>>> parent of b7eb5e5 (GitHubFix)
    Machasanit m;
    [Header("Variables")]
    [Space]
    public float encloseSpeed;
    public float smallestSize;
    //[SerializeField] public int ID;

    public string currentState;
    public string changeState;
    public Image childImg;
    public bool CheckForLayer;
    [Header("Variables")]
    [Space]
    public SkeletonGraphic refanim;
    public SkeletonDataAsset _dataAsset;
    public GameObject VFX;
    private void Start()
    {
        m = FindObjectOfType<Machasanit>();
        if (CheckForLayer)
        {
        Layer = GetComponentInParent<LayerGiver>()._Layer;
        }
        //currentState = "";
        // mSprite.startingAnimation = "Starfish";
        //mSprite.startingAnimation.
=======
    public bool isJoker;
    float counter = 0;
    //[SerializeField] public int ID;


    private void Start()
    {
        SetLayer();
    }
    [ContextMenu("Set Layer")]
    private void SetLayer()
    {
        transform.SetSiblingIndex(Layer);
>>>>>>> 1386105adf5b57928f1c965bb0cc40999c133bdb
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
<<<<<<< HEAD
        if (_Comboabol && firstClosed)
        {
            SetVFX();
=======
        counter += (Time.deltaTime * 1.5f);
        if (isJoker)
        {
            Number = (int)counter;
>>>>>>> 1386105adf5b57928f1c965bb0cc40999c133bdb
=======
        if (_Comboabol)
        {
            StartCoroutine(waitsec());
>>>>>>> parent of b7eb5e5 (GitHubFix)
        }
        if (counter > 6)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            print("PressedE");
=======
            counter = 1;
>>>>>>> 1386105adf5b57928f1c965bb0cc40999c133bdb
=======
            SetAnimationState();
            print("Pressed E");
>>>>>>> parent of b7eb5e5 (GitHubFix)
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

            for (int i = 0; i < Machasanit.Instance.MacsanitMesudert.Count; i++)
            {
                startPos = (RectTransform)Machasanit.Instance.MacsanitMesudert[i].transform;
                endPos = (RectTransform)Machasanit.Instance.MachsanitSlots[i].transform;

                startPos.anchoredPosition = Vector2.Lerp(startPos.anchoredPosition, endPos.anchoredPosition, t / duration);
                //print("Inside");
                t += Time.deltaTime;
            }
            //duration = 0;
        }
    }
<<<<<<< HEAD
    private IEnumerator waitsec()
    {
        yield return new WaitForSeconds(1f);
        //VFX.SetActive(true);
    }

    public void SetAnimationState()
    {
        refanim.skeletonDataAsset = _dataAsset;
        refanim.Initialize(_dataAsset);
        print("Set Anim");
    }
=======


>>>>>>> 1386105adf5b57928f1c965bb0cc40999c133bdb
}
