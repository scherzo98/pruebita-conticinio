using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Audio/Player", fileName = "New Player Sheet")]
public class PlayerAudioData : ScriptableObject
{
    [Header("Movement")]
    [FMODUnity.EventRef]
    public string footsteps = null;
    [FMODUnity.EventRef]
    public string jump = null;
    [FMODUnity.EventRef]
    public string dash = null;
    [FMODUnity.EventRef]
    public string land = null;

    [Header("Attacks")]
    [FMODUnity.EventRef]
    public string[] swordAttacks = null;
    [FMODUnity.EventRef]
    public string hammerAttack = null;
    [FMODUnity.EventRef]
    public string shield = null;
}
    
