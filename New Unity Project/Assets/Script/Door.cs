using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public Keys[] RequiredItem { get { return requiredItem; } }

    [SerializeField]private Keys[] requiredItem;


}
