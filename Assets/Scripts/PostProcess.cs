using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcess : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _postProvessVolume;
    private MotionBlur _motionBlur;

    private void Start()
    {
        _postProvessVolume.profile.TryGetSettings(out _motionBlur);
    }

    public void MotionBlurOnOff(bool value)
    {
        _motionBlur.active = value;
    }
}
