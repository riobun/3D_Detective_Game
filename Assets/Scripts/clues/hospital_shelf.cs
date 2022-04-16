using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hospital_shelf : MonoBehaviour
{
    public int MoveSpeed = 1;
    public GameObject shelf;
    Vector3 target;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(6, shelf.transform.position.y, shelf.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            shelf.transform.position = Vector3.MoveTowards(shelf.transform.position, target, MoveSpeed * Time.deltaTime);
        }
        

    }

    public void OnMouseDown()
    {
        move = true;
    }
}
