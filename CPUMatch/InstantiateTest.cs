using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTest : MonoBehaviour
{
    public GameObject originalCell1;
    public Transform cellsBox;
    public List<GameObject> cellsArr = new List<GameObject>();
    public GameObject[] Arr = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        originalCell1 =  GameObject.Find("Cell1");
        cellsBox = GameObject.Find("Cells").transform;
        cellsArr.Add(Instantiate(originalCell1, new Vector3(-60, 0, -40), Quaternion.identity,cellsBox));
        cellsArr[0].name = "Cell1" + "-1 ";
    }

    // Update is called once per frame


}
