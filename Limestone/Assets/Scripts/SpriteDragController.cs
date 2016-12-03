using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDragController : MonoBehaviour {

    public Vector3 offset;
    public GameObject tower;

    void Start()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -6.0f));
    }

    void Update()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -6.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    }

    void OnMouseUp()
    {
        GameObject towerInstance = Instantiate(tower);
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -6.0f);
        towerInstance.transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        Destroy(transform.gameObject);
    }
}
