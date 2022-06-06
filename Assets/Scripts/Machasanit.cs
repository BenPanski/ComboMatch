using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machasanit : MonoBehaviour
{
    [SerializeField] List<RectTransform> SpacesInMachsanit;
    public List<Tile> _Tiles = new List<Tile>();
    public List<Tile> TilesInMachsanit = new List<Tile>();
    public List<Tile> MacsanitMesudert = new List<Tile>();

    //public List<Tile> sortedTileNums;
    //public List<Tile> sortedTileColors;

    public int NumberOfOnes, NumberOftwos, NumberOfthrees, NumberOffours, NumberOffives, NumberOfsix;


    public void AddTile(Tile tile)
    {
        if (SpacesInMachsanit.Count > 0)
        {
            //tile.transform.position = SpacesInMachsanit[TilesInMachsanit.Count].position;
            TilesInMachsanit.Add(tile);
            
            Seder(tile);
        }
        tile.gameObject.SetActive(false);
    }

    public void Seder(Tile tile)
    {
        // RummyThing();
        CheckForMatch();
        SederInMachsanit();
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
        for (int i = 5; i > 0; i--)
        {
            Sidur(NumberOfOnes, 1, i);
            Sidur(NumberOftwos, 2, i);
            Sidur(NumberOfthrees, 3, i);
            Sidur(NumberOffours, 4, i);
            Sidur(NumberOffives, 5, i);
            Sidur(NumberOfsix, 6, i);
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
        }
    }


}
