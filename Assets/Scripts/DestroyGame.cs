using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DestroyGame : MonoBehaviour
{
    [SerializeField] private PostProcessVolume volume;
    private Error error;

    public void OnTriggerEnter()
    {
        volume.profile.TryGetSettings<Error>(out error);
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        float time = 0.0f;
        while (time < 1.0f)
        {
            error.blend.value += 0.02f;
            time += 0.02f;
            yield return new WaitForSeconds(0.01f);
        }

        NativeWinAlert.Error("Only HOME", "HOME");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
