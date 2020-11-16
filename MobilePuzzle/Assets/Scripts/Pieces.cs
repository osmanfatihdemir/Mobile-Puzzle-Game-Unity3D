using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;


public class Pieces : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;


    //Başlangıç Parça Konumlandırma
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-9f, 5f), Random.Range(-3.5f, 3f));
    }

    //Level da parçanın konum kontrolü (Parça bulunması gereken konuma geldimi ?)
    void Update()
    {
        if (Vector3.Distance(transform.position, RightPosition) < 0.5f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                    Camera.main.GetComponent<DragAndDrop>().PlacedPieces++;
                }
            }
        }
    }
}
