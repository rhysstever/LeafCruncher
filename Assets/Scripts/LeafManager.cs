using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour
{
    #region Singleton Code
    // A public reference to this script
    public static LeafManager instance = null;

    // Awake is called even before start 
    // (I think its at the very beginning of runtime)
    private void Awake()
    {
        // If the reference for this script is null, assign it this script
        if(instance == null)
            instance = this;
        // If the reference is to something else (it already exists)
        // than this is not needed, thus destroy it
        else if(instance != this)
            Destroy(gameObject);
    }
    #endregion

    [SerializeField]
    private GameObject leafPrefab, leafParent;

    public int leafCount;

    private float xBounds = 8.5f;
    private float yBounds = 4.65f;

    // Start is called before the first frame update
    void Start()
    {
        CreateLeaves();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLeaves()
	{
        for(int i = 0; i < leafCount; i++)
        {
            // Get a random position
            Vector3 randPos = new Vector3(
                Random.Range(-xBounds, xBounds),
                Random.Range(-yBounds, yBounds),
                0.0f);

            // Create the new leaf
            GameObject newLeaf = Instantiate(leafPrefab, randPos, Quaternion.identity, leafParent.transform);
            newLeaf.name = "Leaf" + i;
        }
	}
}
