using UnityEngine;

public class ItemController : MonoBehaviour
{
  void Update()
    {
        transform.Rotate(new Vector3(0.0f, 45, 0.0f) * Time.deltaTime);
    }
}
