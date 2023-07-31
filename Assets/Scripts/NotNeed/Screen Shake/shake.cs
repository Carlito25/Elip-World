using UnityEngine;

public class shake : MonoBehaviour
{
    private Animator camAnim;

    public void camShake()
    {
        camAnim.SetTrigger("shake");
    }
}
