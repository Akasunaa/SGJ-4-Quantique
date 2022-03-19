using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    /* Tiles 0 to 3 are for the first zone
     Tiles 4 to 7 are for the second zone
     Tiles 8 to 11 are for the third */
    [SerializeField] Tile[] _tiles;
    [SerializeField] Tilemap _tilemap;
    [SerializeField] Grid _mapGrid;
    [SerializeField] AudioSource[] audioSources; 

    public Tile[] Tiles { get { return (_tiles); } }
    public Tilemap Tilemap { get { return (_tilemap); } }
    public Grid MapGrid { get { return (_mapGrid); } }

    public void Awake()
    {
        if (_tiles == null)
            Debug.LogError("No tiles specified");
        if (_tilemap == null)
            Debug.LogError("No tilemap specified");
        if (_mapGrid == null)
            Debug.LogError("No grid specified");

        Zone.NewZone += ChangeAudio;
        Zone.NewZone += IsWinning;
            

    }

    private void OnDestroy()
    {
        Zone.NewZone -= ChangeAudio;
        Zone.NewZone += IsWinning;
    }

    private void ChangeAudio(int nbZone)
    {
        for (int i=0; i < audioSources.Length; i++)
        {
            audioSources[i].Pause();
        }
        audioSources[nbZone-1].Play();
        
    }

    private void IsWinning(int nbZone)
    {
        if (nbZone == 4)
        {
            print("youpi en fait");
        }
    }


}
