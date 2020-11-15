using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform characterPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(characterPosition.position.x, characterPosition.position.y + 3, transform.position.z);
    }
}
