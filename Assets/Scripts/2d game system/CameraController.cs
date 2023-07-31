using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] public Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.position.x , player.position.y, transform.position.z);
    }
}
