using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!this.enabled) return;
        //var col = other.gameObject.GetComponent<Collectable>();
        //var y = col.lenght * 5;
        var y = 5;

        var newVector = Vector3.zero;
        newVector.y = y;
        gameObject.transform.parent = other.gameObject.transform;
        gameObject.transform.position = newVector;
        this.enabled = false;
    }
}
