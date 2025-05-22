using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Vector3 offset;
    public GameObject player;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }


    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
