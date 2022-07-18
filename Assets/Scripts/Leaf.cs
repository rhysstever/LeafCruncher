using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnMouseDown()
	{
        // Count the leaf being crunched
        LeafManager.instance.LeafCrunched();

        // Destroy the leaf
        Destroy(gameObject);
    }
}
