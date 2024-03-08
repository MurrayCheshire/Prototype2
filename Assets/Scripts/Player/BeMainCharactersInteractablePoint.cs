using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BeMainCharactersInteractablePoint : MonoBehaviour
{
    void Update()
    {
        this.transform.position = GameManager.instance.player.transform.position + 
                                  GameManager.instance.player.GetComponent<CharacterController2D>().lastMotionVector3D;
    }
}
