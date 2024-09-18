using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Inscribed")]
    // Prefab for instanciating apples
    public GameObject applePrefab;

    //Prefab for instanciating Poison Apples
    public GameObject poisApplePrefab;

    //Speed at which the AppleTree moves
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    //Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    //Seconds between Poison Apples instantiations
    public float poisonDropDelay = 10f;

    void Start() {
        // Start dropping apples
        Invoke("DropApple", 2f);
        Invoke("DropPoisonApple", 5f);
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    void DropPoisonApple() {
        GameObject poisonApple = Instantiate<GameObject>(poisApplePrefab);
        poisonApple.transform.position = transform.position;
        Invoke("DropPoisonApple", poisonDropDelay);
    }

    // Update is called once per frame
    void Update() {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing Direction
        if(pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);
       // } else if (Random.value < changeDirChance) {
         //   speed *= -1; // Change direction
        }
    }

    void FixedUpdate() {
        //Random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance) {
            speed *= -1; // Change direction
        }
    }
}
