using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;   // game object position reference
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position;    //only calculate offset once at the start
    }

    // Update is called once per frame
    void LateUpdate()   // LateUpdate is called after Update each frame
    {
        transform.position = player.transform.position + offset;
    }
}
