using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour
{
    public Sprite[] Levels;
    public GameObject SelectedPiece;
    int OIL = 1;
    public int PlacedPieces = 0;
    public string ScaneName;
    public int ChechkLevel;
    public int LevelPieces;

    //Level Açılış Ayarları
    void Start()
    {
        ScaneName = SceneManager.GetActiveScene().name;

        if (ScaneName == "Level1")
            ChechkLevel = 1;
        if (ScaneName == "Level2")
            ChechkLevel = 2;

        switch (ChechkLevel)
        {
            case 1:
                LevelPieces = 9;
                break;
            case 2:
                LevelPieces = 36;
                break;
        }
        for (int i = 0; i < LevelPieces; i++)
        {
            GameObject.Find("Pieces" + i).transform.Find("image").GetComponent<SpriteRenderer>().sprite = Levels[PlayerPrefs.GetInt("Level")];
        }

    }

    //Parça Seçme, Sürükleme, Bırakma
    public void SelectPiece()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonDown(0) && hit.transform.CompareTag("Puzzle") && (!hit.transform.GetComponent<Pieces>().InRightPosition))
        {
            SelectedPiece = hit.transform.gameObject;
            SelectedPiece.GetComponent<Pieces>().Selected = true;
            SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
            OIL++;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<Pieces>().Selected = false;
                SelectedPiece = null;
            }
        }

        if (SelectedPiece != null)
        {
            Vector3 MausePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MausePoint.x, MausePoint.y + 2, 0);
        }
    }

    

    void Update()
    {
        
        SelectPiece();
    }

}
