using UnityEngine;
using System.Collections;

public class ShowCursor : MonoBehaviour
{
    public bool cursorState;

    void Start()
    {
        toggleCursor(cursorState);
    }

    void Update()
    {
    }

    public void toggleCursor(bool State)
    {
        Cursor.visible = State;
    }
}
