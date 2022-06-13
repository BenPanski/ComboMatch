using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class Machasanit : MonoBehaviour
{
    public static Machasanit Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    [Header("Inisialze Lists")]
    [SerializeField] List<RectTransform> SpacesInMachsanit;
    public List<Tile> _Tiles = new List<Tile>();

    [Header("RunTime Lists")]
    [Space]
    public List<Tile> TilesInMachsanit = new List<Tile>();
    public List<Tile> MacsanitMesudert = new List<Tile>();

    [Header("Variables")]
    [Space]
    //public GameObject conButton;
    public Canvas gameCanvas;
    public Button butt;
    public int Raws;
    public TextMeshProUGUI loose;
    [SerializeField] private int JokerCost;
    [SerializeField] private int BurnCost;
    [SerializeField] private int MachsanitSize;
    [SerializeField] private int SplitCost;



    //public List<Tile> sortedTileNums;
    //public List<Tile> sortedTileColors;
    [Header("Counters")]
    [Space]
    public bool moreThen3;
    public int NumberOfOnes, NumberOftwos, NumberOfthrees, NumberOffours, NumberOffives, NumberOfsix;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        //Variables
        Tile newTile;
        List<Tile> _newTilesList = new List<Tile>();

        //Shuffle Tiles
        for (int i = 0; i < _Tiles.Count; i++)
        {
            Tile temp = _Tiles[i];
            int randomIndex = Random.Range(i, _Tiles.Count);
            _Tiles[i] = _Tiles[randomIndex];
            _Tiles[randomIndex] = temp;
        }

        //Fix Tiles Position + Instantiate
        foreach (var item in _Tiles)
        {
            for (int i = 0; i < Raws; i++)
            {
                newTile = Instantiate(item, new Vector3(item.transform.position.x, item.transform.position.y - i), Quaternion.identity);
                newTile.GetComponent<Tile>().Layer = i + 2;
                newTile.gameObject.transform.SetParent(gameCanvas.transform, true);
                newTile.transform.localScale = new Vector3(25, 25, 25);
                _newTilesList.Add(newTile);
            }

        }

        foreach (var sort in _newTilesList)
        {
            sort.transform.position = new Vector3(sort.transform.position.x, sort.transform.position.y * Random.Range(0.2f, 0.4f));
        }

    }

    private void Update()
    {
        //if (NumberOfOnes >= 3 || NumberOftwos >= 3 || NumberOfthrees >= 3 || NumberOffours >= 3 || NumberOffives >= 3 || NumberOfsix >= 3)
        //{
        //    conButton.SetActive(true);
        //    moreThen3 = true;

        //}
        //else
        //{
        //    conButton.SetActive(false);
        //    moreThen3 = false;

        //}

    }
    public void AddTile(Tile tile)
    {


        if (tile._Interactable)
        {
            if (TilesInMachsanit.Count < 6)
            {
                TilesInMachsanit.Add(tile);
                print("Inside");
                Seder();
                
            }
            tile._Interactable = false;
        }

        if (TilesInMachsanit.Count == 6 && NumberOfOnes < 3 && NumberOftwos < 3 && NumberOfthrees < 3 && NumberOffours < 3 && NumberOffives < 3 && NumberOfsix < 3)
        {
            loose.gameObject.SetActive(true);
            print("YouLoose");
        }

        // tile.gameObject.SetActive(false);
    }

    public void Seder()
    {
        // RummyThing();
        SederInMachsanit();
        CheckForMatch();

    }
    //void SederInMachsanit()
    //{
    //    //MacsanitMesudert.Add(NumberOfOnes);
    //    //MacsanitMesudert.Add(NumberOftwos);
    //    //MacsanitMesudert.Add(NumberOfthrees);
    //    //MacsanitMesudert.Add(NumberOffours);
    //    //MacsanitMesudert.Add(NumberOffives);
    //    //MacsanitMesudert.Add(NumberOfsix);

    //    RezefLoop();
    //}

    private void Sidur(int Seira, int Mispar, int Rezef)
    {
        if (Seira == Rezef)
        {
            foreach (var item in TilesInMachsanit)
            {

                if (item.Number == Mispar)
                {
                    MacsanitMesudert.Add(item);
                    
                    print(item);
                }
            }
        }
    }
    private void SederInMachsanit()
    {
        MacsanitMesudert.Clear();
        for (int i = 5; i >= 0; i--)
        {
            Sidur(NumberOfOnes, 1, i);
            Sidur(NumberOftwos, 2, i);
            Sidur(NumberOfthrees, 3, i);
            Sidur(NumberOffours, 4, i);
            Sidur(NumberOffives, 5, i);
            Sidur(NumberOfsix, 6, i);


        }

            for (int i = 0; i < MacsanitMesudert.Count; i++)
            {
                MacsanitMesudert[i].transform.position = SpacesInMachsanit[i].transform.position;
            }
        
        ComboMaker(NumberOfOnes, 1);
        ComboMaker(NumberOftwos, 2);
        ComboMaker(NumberOfthrees, 3);
        ComboMaker(NumberOffours, 4);
        ComboMaker(NumberOffives, 5);
        ComboMaker(NumberOfsix, 6);
    }
    //public void ConfirmList()
    //{
    //    if (moreThen3)
    //    {

    //        foreach (var item in MacsanitMesudert)
    //        {
    //            item.gameObject.SetActive(false);
    //        }
    //        //conButton.SetActive(false);
    //        MacsanitMesudert = new List<Tile>(0);
    //        TilesInMachsanit = new List<Tile>(0);
    //    }
    //}

    public void ComboMaker(int numberOf, int imgNumber)
    {

        if (numberOf >= 2)
        {
            
            foreach (var Combo in TilesInMachsanit)
            {
                if (Combo.Number == imgNumber)
                {
                    StartCoroutine(Wait(Combo));
                    // Combo._Interactable = true;
                }
            }
        }


    }
    public IEnumerator Wait(Tile tile)
    {
        yield return new WaitForSeconds(0.15f);
        tile._Comboabol = true;

    }
    public void DestoryCombo(int num)
    {
        int counter = 0;
        foreach (var item in MacsanitMesudert)
        {
            if (item.Number == num)
            {
                Destroy(item.gameObject);
                counter++;
                TilesInMachsanit.Remove(item);
                
            }
        }
        Combos(counter);
        Seder();
    }

    public void Combos(int amount)
    {
        switch (amount)
        {
            case 3:
                print("Destoryed 3");
                break;
            case 4:
                print("Destoryed 4 with splash");
                break;
            case 5:
                print("Destoryed 5 with fire");
                break;
            case 6:
                print("GG");
                break;
            default:
                break;
        }
    }

    /* private void RummyThing()
     {
         for (int i = 0; i < TilesInMachsanit.Count; i++) // if the numbers are the same add to sorted list
         {
             if (TilesInMachsanit.Count >= i + 2)
             {
                 if (TilesInMachsanit[i].Number == TilesInMachsanit[i + 1].Number)
                 {
                     if (!sortedTileNums.Contains(TilesInMachsanit[i]))
                     {
                         sortedTileNums.Add(TilesInMachsanit[i]);
                     }
                     if (!sortedTileNums.Contains(TilesInMachsanit[i + 1]))
                     {
                         sortedTileNums.Add(TilesInMachsanit[i + 1]);
                     }
                 }
             }
         }
     }*/

    private void CheckForMatch()
    {
        NumberOfOnes = 0;
        NumberOftwos = 0;
        NumberOfthrees = 0;
        NumberOffours = 0;
        NumberOffives = 0;
        NumberOfsix = 0;
        foreach (var item in TilesInMachsanit)
        {
            switch (item.Number)
            {
                case 1:
                    NumberOfOnes++;
                    break;
                case 2:
                    NumberOftwos++;
                    break;
                case 3:
                    NumberOfthrees++;
                    break;
                case 4:
                    NumberOffours++;
                    break;
                case 5:
                    NumberOffives++;
                    break;
                case 6:
                    NumberOfsix++;
                    break;
                default:
                    Debug.Log("error in switch");
                    break;


            }
            foreach (var Combo in TilesInMachsanit)
            {
                if (Combo.Number == JokerCost)
                {
                    JokerCombo();
                }
                else if (Combo.Number == BurnCost)
                {
                    BurnCombo();
                }
                else if (Combo.Number == MachsanitSize)
                {
                    MachsanitSizeCombo();
                }
                else if (Combo.Number == SplitCost)
                {
                    SplitCombo();
                }

            }
        }
    }

    private void SplitCombo()
    {
    }

    private void MachsanitSizeCombo()
    {
    }

    private void BurnCombo()
    {
    }

    private void JokerCombo()
    {
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
