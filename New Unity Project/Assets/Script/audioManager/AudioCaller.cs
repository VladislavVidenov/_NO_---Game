using System;
using UnityEngine;
using System.Collections;

public class AudioCaller : MonoBehaviour
{
    [SerializeField] private String lightAttackSFX      = "LightAttack_2";
    [SerializeField] private String heavyAttackSFX      = "HeavyAttack_1";
    [SerializeField] private String blockSFX            = "Block";
    [SerializeField] private String jumpSFX             = "Jump";
    [SerializeField] private String specialAttackSFX    = "SpecialAttack";
    [SerializeField] private String walking             = "Walk";

    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void PlayLightAttack()
    {
        audioManager.playSFX(lightAttackSFX);
    }

    public void PlayHeavyAttack()
    {
        audioManager.playSFX(heavyAttackSFX);
    }

    public void PlayBlock()
    {
        audioManager.playSFX(blockSFX);
    }

    public void PlayJump()
    {
        audioManager.playSFX(jumpSFX);
    }

    public void PlaySpecialAttack()
    {
        audioManager.playSFX(specialAttackSFX);
    }

    public void PlayWalking() {
        audioManager.playSFX(walking);
    }
}
