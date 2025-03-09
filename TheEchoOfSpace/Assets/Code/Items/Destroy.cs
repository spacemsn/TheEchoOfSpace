using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject destroyerTarget;
    public float delay;

    public void OnDestroy()
    {
        Destroy(gameObject, delay);
    }
}
