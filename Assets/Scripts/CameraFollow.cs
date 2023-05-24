using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform playerTransform; 
    
    void Start() {
        
    }

    void Update() {
        float cameraY = transform.position.y;
        if (playerTransform.position.y <= 130) cameraY = playerTransform.position.y + 5;

			transform.position = new Vector3(playerTransform.position.x, cameraY, transform.position.z);

    }

}
