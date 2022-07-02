using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum MyEnum
//{
//    blue, yellow, black, red
//}
public class Tile : MonoBehaviour
{
    [SerializeField] public int Layer;
    [SerializeField] public int Number;
    //[SerializeField] public MyEnum Color;
    //public bool isJoker;
    [SerializeField] public bool _Comboabol = false;
    public bool _Interactable = true;
<<<<<<< HEAD
    //public bool _GettingDestoryed = false;
    Machasanit m;
    [Header("Variables")]
    [Space]
    //public string currentState;
    //public string changeState;
    public Image childImg;
    public bool CheckForLayer;
    [Header("Variables")]
    [Space]
    public SkeletonGraphic backGroundGraphic;
    public SkeletonGraphic tileGraphic;
    public SkeletonDataAsset _dataAsset;
    public AnimationReferenceAsset encloseAnim;
    public AnimationReferenceAsset backGroundAnim;
    public GameObject VFX;
    bool firstClosed = true;
    private void Start()
    {
        StartCoroutine(waitsec());   
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
        if (_Comboabol && firstClosed)
        {
            SetVFX();
=======
        counter += (Time.deltaTime * 1.5f);
        if (isJoker)
        {
            Number = (int)counter;
>>>>>>> 1386105adf5b57928f1c965bb0cc40999c133bdb
        }
        if (counter > 6)
        {
<<<<<<< HEAD
            print("PressedE");
=======
            counter = 1;
>>>>>>> 1386105adf5b57928f1c965bb0cc40999c133bdb
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
        yield return new WaitForSeconds(0.01f);
        VFX.SetActive(false);
    }

    public void SetAnimation(SkeletonGraphic skeleton,AnimationReferenceAsset animation, bool loop, float timescale)
    {
        // mSprite.state.SetAnimation(0,animation,loop).TimeScale = timescale; 
        skeleton.AnimationState.SetAnimation(0, animation, loop).TimeScale = timescale;
    }

    public void SetAnimationState(string state)
    {
        if (state.Equals(""))
        {
            return;
        }
        if (state.Equals("Surfboard"))
        {
            SetAnimation(tileGraphic,encloseAnim, false, 1f);
        }
    }

    public void EncloseAnimation()
    {
        VFX.SetActive(false);
        tileGraphic.timeScale = 1;
    }
    public void SetVFX()
    {
        firstClosed = false;
        backGroundGraphic.skeletonDataAsset = _dataAsset;
        backGroundGraphic.Initialize(_dataAsset);
        VFX.SetActive(true);
        print("Set Anim");
        SetAnimation(backGroundGraphic,backGroundAnim, true, 1f);
    }
=======


>>>>>>> 1386105adf5b57928f1c965bb0cc40999c133bdb
}
