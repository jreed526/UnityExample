using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public RoundCounter roundCounter; //NEW

    void Start() {
        basketList = new List<GameObject>();
        //Find a GameObject named RoundCounter in Scene Hierarchy
        GameObject roundGO = GameObject.Find("RoundCounter");  //NEW
        //Get the RoundCounter (Script) component of roundGO
        roundCounter = roundGO.GetComponent<RoundCounter>(); //NEW

        for (int i=0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed() {
        //Destroy all of the falling Apples
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        GameObject[] poisonAppleArray=GameObject.FindGameObjectsWithTag("PoisonApple");
            foreach(GameObject tempGO in appleArray) {
                Destroy(tempGO);
            }
            foreach(GameObject tempGO in poisonAppleArray) {
                Destroy(tempGO);
            }

        //Destroy one of the Baskets
        //Get the index of the last Basket in basketList
        int basketIndex = basketList.Count -1;
        //Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        //Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        //Increment roundCounter +1
        roundCounter.round += 1; //NEW

        //If there are no Baskets left, restart the game
        if(basketList.Count==0) {
            SceneManager.LoadScene("_Game_Over");
        }
    }
}