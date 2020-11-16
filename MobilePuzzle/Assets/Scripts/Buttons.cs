using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Buttons : MonoBehaviour
{
    public GameObject LevelButton;
    public GameObject LevelMenu;
    public GameObject FinishText;
    public bool CheckLevelMenu;
    int PlacedPieces;
    string ScaneName;

    //Sahne Yükleme
    public void ScaneLoad(string ScaneName)
    {
        SceneManager.LoadScene(ScaneName);
    }

    //Resim Seçilince Button Açma Test!!!
    public void LevelButtonActivety()
    {
        LevelButton.SetActive(true);
    }

    // Resim Seçme Basic Level
    public void PlayGameLevel1(int LevelNumer)
    {
        PlayerPrefs.SetInt("Level", LevelNumer);
        SceneManager.LoadScene("Level1");
    }

    // Resim Seçme high level
    public void PlayGameLevel2(int LevelNumer2)
    {
        PlayerPrefs.SetInt("Level", LevelNumer2);
        SceneManager.LoadScene("Level2");
    }


    //Level-resim Seçim Versiyon 1 -- Delete!!!
    public void SelectPuzzle(Image Photo)
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject.Find("Pieces" + i).transform.Find("image").GetComponent<SpriteRenderer>().sprite = Photo.sprite;
        }

    }

    //Oyundan Çıkış
    public void AplicationQuit()
    {

        Application.Quit();
        Debug.Log("Çıktı");

    }
    //Bölüm Sonu Menü Aktifleştirme 
    public void LevelEnd()
    {
        PlacedPieces = Camera.main.GetComponent<DragAndDrop>().PlacedPieces;
        ScaneName = Camera.main.GetComponent<DragAndDrop>().ScaneName;
        if (ScaneName == "Level1" && PlacedPieces >= 9)
        {
            FinishText.SetActive(true);
            LevelMenu.SetActive(true);
        }
        if (ScaneName == "Level2" && PlacedPieces >= 36)
        {
            FinishText.SetActive(true);
            LevelMenu.SetActive(true);

        }

    }

    //Pause Buttonu Aç Kapat
    public void PauseButton()
    {
        if (LevelMenu.activeSelf == true)
        {
            LevelMenu.SetActive(false);
        }
        else
        {
            LevelMenu.SetActive(true);
        } 
      
            
        
    }


    public void Start()
    {
        LevelMenu.SetActive(false);
    }
    public void Update()
    {

        LevelEnd();
    }

}
