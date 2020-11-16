using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sounds : MonoBehaviour
{
    public AudioSource MyAudioSource;
    public AudioClip ApplauseAudioClip;

    // Ses Ayarları ve Durumları
    public void Start()
    {

    }
    void Update()
    {

        if ((Camera.main.GetComponent<DragAndDrop>().ScaneName == "Level1") && (Camera.main.GetComponent<DragAndDrop>().PlacedPieces == 9))
        {
            MyAudioSource.clip = ApplauseAudioClip;
            MyAudioSource.PlayOneShot(ApplauseAudioClip);
            Debug.Log("Applause Sound");
            Camera.main.GetComponent<DragAndDrop>().PlacedPieces++;
        }
        if ((Camera.main.GetComponent<DragAndDrop>().ScaneName == "Level2") && (Camera.main.GetComponent<DragAndDrop>().PlacedPieces == 36))
        {
            MyAudioSource.clip = ApplauseAudioClip;
            MyAudioSource.PlayOneShot(ApplauseAudioClip);
            Debug.Log("Applause Sound");
            Camera.main.GetComponent<DragAndDrop>().PlacedPieces++;

        }



    }
}
