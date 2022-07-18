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
    private Sprite[] leafSprites;

    private int leafSpawnCount;
    private int leavesLeftCount;
    private int leafCrunchCount;

    private float xBounds = 8.5f;
    private float yBounds = 4.65f;

    // Start is called before the first frame update
    void Start()
    {
        // Load Leaf Sprites
        leafSprites = Resources.LoadAll<Sprite>("Images/Leaves");

        CreateLeaves();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Fills the screen with leaves
    /// </summary>
    private void CreateLeaves()
	{
        leafSpawnCount += 100;
        leavesLeftCount = leafSpawnCount;

        for(int i = 0; i < leafSpawnCount; i++)
        {
            // Get a random position within bounds
            Vector3 randPos = new Vector3(
                Random.Range(-xBounds, xBounds),
                Random.Range(-yBounds, yBounds),
                0.0f);

            // Create the new leaf
            GameObject newLeaf = Instantiate(leafPrefab, randPos, Quaternion.identity, leafParent.transform);
            newLeaf.name = "Leaf" + i;

            // Set the leaf's sprite to a random leaf
            int randLeafSpriteIndex = Random.Range(0, leafSprites.Length);
            newLeaf.GetComponent<SpriteRenderer>().sprite = leafSprites[randLeafSpriteIndex];

            // Set the leaf's sorting layer to the leaf layer, so it is in front of the background
            newLeaf.GetComponent<SpriteRenderer>().sortingLayerName = "Leaf";

            // Randomly rotate the leaf
            int randDegrees = Random.Range(0, 360);
            newLeaf.transform.localEulerAngles = new Vector3(0.0f, 0.0f, randDegrees);

            // Randomly flip the leaf
            if(Random.Range(0.0f, 1.0f) > 0.5f)
                newLeaf.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    /// <summary>
    /// Logic for after a leaf has been crunched
    /// </summary>
    public void LeafCrunched()
	{
        // Play a crunching sound
        AudioManager.instance.PlayRandomClip();

        // Count the lead being crunched
        leavesLeftCount--;
        leafCrunchCount++;

        UIManager.instance.UpdateLeavesCrunchedText(leafCrunchCount);

        // Repopulate the screen if all leaves have been crunched
        if(leavesLeftCount == 0)
            CreateLeaves();
    }
}
