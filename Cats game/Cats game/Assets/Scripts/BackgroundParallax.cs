using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    [SerializeField] private bool infinityVertical;
    [SerializeField] private bool infinityHorizontal;

    private Transform camTransform;
    private Vector3 lastCamPosition;
    private float textureUnitSizeX;
    private float textureUnitSizeY;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
        lastCamPosition = camTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = (texture.width / sprite.pixelsPerUnit) * transform.localScale.x;
        textureUnitSizeY = (texture.height / sprite.pixelsPerUnit) * transform.localScale.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 deltaMovement = camTransform.position - lastCamPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCamPosition = camTransform.position;

        if (infinityVertical)
        {
            if (Mathf.Abs(camTransform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float offsetPositionY = (camTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(transform.position.x, camTransform.position.y + offsetPositionY);
            }
        }
        if (infinityHorizontal)
        {
            if (Mathf.Abs(camTransform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float offsetPositionX = (camTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(camTransform.position.x + offsetPositionX, transform.position.y);
            }
        }
    }
}
