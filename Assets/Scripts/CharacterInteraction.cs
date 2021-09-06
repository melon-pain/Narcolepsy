using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Runtime.InteropServices;

/// <see>https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-messagebox</see>
public static class NativeWinAlert
{
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern System.IntPtr GetActiveWindow();

    public static System.IntPtr GetWindowHandle()
    {
        return GetActiveWindow();
    }

    [DllImport("user32.dll", SetLastError = true)]
    static extern int MessageBox(IntPtr hwnd, String lpText, String lpCaption, uint uType);

    /// <summary>
    /// Shows Error alert box with OK button.
    /// </summary>
    /// <param name="text">Main alert text / content.</param>
    /// <param name="caption">Message box title.</param>
    public static void Error(string text, string caption)
    {
        try
        {
            MessageBox(GetWindowHandle(), text, caption, (uint)(0x00000000L | 0x00000010L));
        }
        catch (Exception ex) { }
    }
}

public class CharacterInteraction : MonoBehaviour
{
    RaycastHit[] hits;

    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            hits = Physics.SphereCastAll(this.transform.position + Vector3.up, 1.0f, Vector3.forward, 1.0f);
            foreach (RaycastHit hit in hits)
            {
                if(hit.collider.tag == "Interactable")
                {
                    Debug.Log("Interact");
                    NativeWinAlert.Error("Error", "Error");
                    UnityEditor.EditorApplication.isPlaying = false;
                    Application.Quit();
                    break;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position + Vector3.up, 1.0f);
    }
}
