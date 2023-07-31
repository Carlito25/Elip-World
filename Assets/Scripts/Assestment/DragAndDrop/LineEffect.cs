
using UnityEngine;
using UnityEngine.UI;

public class LineEffect : MonoBehaviour
{
    private Image firstLine;

    private void Awake()
    {
        firstLine = GetComponent<Image>();
    }

    private void Update()
    {
        if (Actions.onButtonImage?.Invoke().color == Color.green)
        {
            firstLine.color = Color.green;
            Debug.Log("first line will turn green");
        }
    }

    private void greenLine()
    {
        firstLine.color = Color.green;
    }
}
