using UnityEngine;
using System.Collections;

public class JumpPad : MonoBehaviour {
    [Range(1,10)]public float boostStrength=1;

    GameManager instance;
    GameObject player;
    void Start()
    {


        player = GameManager.Instance.Player;
    }
}
