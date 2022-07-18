using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton Code
    // A public reference to this script
    public static UIManager instance = null;

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
    private Canvas canvas;

    [SerializeField]
    private GameObject leavesCrunchedCountText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLeavesCrunchedText(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLeavesCrunchedText(int leavesCrunched)
	{
        leavesCrunchedCountText.GetComponent<TMP_Text>().text 
            = "Leaves \nCrunched: \n" + leavesCrunched;
	}
}
