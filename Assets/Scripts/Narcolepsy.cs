using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Narcolepsy : MonoBehaviour
{
    [SerializeField] private PostProcessVolume volume;
    private Vignette vignette;

    private void Awake()
    {
        volume.profile.TryGetSettings<Vignette>(out vignette);
    }

    public void UpdateNarcolepsy(float seconds)
    {
        if (seconds <= 60)
        {
            vignette.intensity.value = 1.0f - (seconds / 60.0f);
        }
    }
}
