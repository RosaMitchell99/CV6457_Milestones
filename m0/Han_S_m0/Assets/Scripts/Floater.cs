using UnityEngine;

public class Floater : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Move the object up and down (slightly)
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time) * 0.15f + 1, transform.position.z);
    }
}
