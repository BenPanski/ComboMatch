using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using Spine;
using Spine.Collections;

public enum MyEnum
{
    blue, yellow, black, red
}
public class Tile : MonoBehaviour
{
    [Header("Counters")]
    [Space]
    [SerializeField] public int Layer;
    [SerializeField] public int Number;
    [SerializeField] public MyEnum Color;
    [SerializeField] public bool _Comboabol = false;
    public bool _Interactable = true;
    public bool isJoker;
    public bool _GettingDestoryed = false;
    Machasanit m;
    public GameObject VFX;
    [Header("Variables")]
    [Space]
    public float encloseSpeed;
    public float smallestSize;
    //[SerializeField] public int ID;
    public SkeletonGraphic mSprite;
    public AnimationReferenceAsset refanim;
    public string currentState;
    public string changeState;
    public Image childImg;
    public bool CheckForLayer;

    private void Start()
    {
        m = FindObjectOfType<Machasanit>();
        if (CheckForLayer)
        {
        Layer = GetComponentInParent<LayerGiver>()._Layer;
        }
        currentState = "";
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
        if (_Comboabol)
        {
            StartCoroutine(waitsec());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //print(mSprite.ToString());

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
        yield return new WaitForSeconds(1f);
        //VFX.SetActive(true);
    }

    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timescale)
    {
        // mSprite.state.SetAnimation(0,animation,loop).TimeScale = timescale; 
        mSprite.AnimationState.SetAnimation(0, animation, loop).TimeScale = timescale;
    }

    public void SetAnimationState(string state)
    {
        if (state.Equals(""))
        {
            return;
        }
        if (state.Equals("Surfboard"))
        {
            SetAnimation(refanim, false, 1f);
        }
    }
}
