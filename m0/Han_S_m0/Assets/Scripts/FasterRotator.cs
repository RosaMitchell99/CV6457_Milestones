using UnityEngine;

public class FasterRotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (30,75,60) * Time.deltaTime);  
    }
}
