using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnCursorLock.AddListener(LockCursor);
        EventManager.OnLevelFail.AddListener(UnlockCursor);
        EventManager.OnLevelSuccess.AddListener(UnlockCursor);
    }
    void OnDisable()
    {
        EventManager.OnCursorLock.RemoveListener(LockCursor);
        EventManager.OnLevelFail.RemoveListener(UnlockCursor);
        EventManager.OnLevelSuccess.RemoveListener(UnlockCursor);
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
