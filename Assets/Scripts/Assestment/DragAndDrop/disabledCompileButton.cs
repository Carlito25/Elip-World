
using UnityEngine;
using UnityEngine.UI;

public class disabledCompileButton : MonoBehaviour
{
    [SerializeField] private Button compileButton;
    public static int numberOfCompile;
    private void Start()
    {
        numberOfCompile = 2;
    }
    private void Update()
    {
        if (numberOfCompile == 0)
        {
          compileButton.interactable = false;          
        }
    }
    public void reduceNumberOfCompile()
    {
        --numberOfCompile;
    }

}
