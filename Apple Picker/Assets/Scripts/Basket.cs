using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Basket : MonoBehaviour {
    public ScoreCounter scoreCounter;
    public ApplePicker applePicker;
    void Start() {
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Get the ScoreCOunter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();

        // Find a GameObject named ApplePicker in the Scene Hierarchy
       // GameObject applePickerGO = GameObject.Find("ApplePicker");
        // Get the ApplePicker (Script) component of applePickerGO
       // applePicker = applePickerGO.GetComponent<ApplePicker>();
    }

    void Update() {
        //Get the current screen postiion of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //Camera's z pos sets how far to push the mouse into 3D
        //If line causes NullReferenceException, select the Main Camera in the hierarchy and set tag to MainCamera in Inspector
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x pos of this Basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll) {
        //Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple")){
            Destroy(collidedWith);

            //Increase the score
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);

        } else if (collidedWith.CompareTag("PoisonApple")){
            Destroy(collidedWith);
            
            //If you collect a PoisonApple, game over
            SceneManager.LoadScene("_Game_Over");

        }
    }
}
