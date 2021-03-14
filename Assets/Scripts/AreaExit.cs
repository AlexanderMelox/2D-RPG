using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour {

    public string areaToLoad;

    public string areaTransitionName;

    public AreaEntrance entrance;

    // Start is called before the first frame update
    void Start() {
        entrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // Check to see if what's colliding is the player object
        // The tag can be checked at the top of an object in the inspector
        if (collision.tag == "Player") {
            SceneManager.LoadScene(areaToLoad);

            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
