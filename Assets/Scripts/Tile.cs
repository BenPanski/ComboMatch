using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using Spine;
using Spine.Collections;

//public enum MyEnum
//{
//    blue, yellow, black, red
//}
public class Tile : MonoBehaviour
{
    [Header("Counters")]
    [Space]
    [SerializeField] public int Layer;
    [SerializeField] public int Number;
    //[SerializeField] public MyEnum Color;
    //public bool isJoker;
    [SerializeField] public bool _Comboabol = false;
    public bool _Interactable = true;
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
        if (_Comboabol && firstClosed)
        {
            SetVFX();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            print("PressedE");
        }
    }

    private void FixedUpdate()
    {
        //if (_GettingDestoryed)
        //{
        //transform.localScale -= new Vector3(encloseSpeed, encloseSpeed, encloseSpeed);
        //}
        //if (transform.localScale.x < smallestSize)
        //{
        //    Destroy(gameObject);
        //}
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

                t += Time.deltaTime;
                startPos.transform.position = Vector2.Lerp(startPos.transform.position, endPos.transform.position, t / duration);
                //print("Inside");
            }
            //duration = 0;
        }
    }
    public IEnumerator FlyToED(float duration)
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
                endPos = m.winTile;

                t += Time.deltaTime;
                startPos.anchoredPosition = Vector2.Lerp(startPos.anchoredPosition, endPos.anchoredPosition, t / duration);
                //print("Inside");
            }
            //duration = 0;
        }
    }
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
}
