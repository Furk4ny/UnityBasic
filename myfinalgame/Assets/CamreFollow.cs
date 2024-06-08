
using UnityEngine;

public class CamreFollow : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 cameraoffset;
    public Vector3 targetedposition;
    private Vector3 velocity=Vector3.zero;


    public float smooothTime = 0.3f;

    void LateUpdate()
    {
        transform.position = targetObject.transform.position+cameraoffset;
        
    }
}
