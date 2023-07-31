using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform currentCheckpoint;
    private Health playerHealth;
    private PopupInfo removeInfoButtons;
    [SerializeField] private GameObject deadPopup;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        removeInfoButtons = GetComponent<PopupInfo>();
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
        deadPopup.SetActive(false);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.transform.tag == "PopupInfo")
    //    {
    //        currentCheckpoint = collision.transform;
    //        collision.GetComponent<Collider2D>().enabled = false;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.transform.tag == "PopupInfo")
    //    {
    //        removeInfoButtons.removeInfoButton();
    //    }
    //}
}
