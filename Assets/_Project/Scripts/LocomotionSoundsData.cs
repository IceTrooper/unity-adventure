using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Adventure/Sounds", fileName = "LocomotionSounds")]
public class LocomotionSoundsData : ScriptableObject
{
    public List<AudioClip> walkFootstepSounds;
    public List<AudioClip> jumpSounds;
    public AudioClip land;
}
