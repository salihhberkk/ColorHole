using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using DG.Tweening;
public class PlayerMovement : MonoSingleton<PlayerMovement>
{
    [SerializeField] float speed;
    [SerializeField] float swipeSensitivity;

    public void StartHandlePlayer()
    {
        LeanTouch.OnFingerUpdate += HandlePlayer;
    }
    public void StopHandlePlayer()
    {
        LeanTouch.OnFingerUpdate -= HandlePlayer;
    }
    private void HandlePlayer(LeanFinger obj)
    {
        gameObject.transform.position += Vector3.right * (obj.ScaledDelta.x * swipeSensitivity);
        gameObject.transform.position += Vector3.forward * (obj.ScaledDelta.y * swipeSensitivity);

        var clampXPos = Mathf.Clamp(gameObject.transform.position.x, -4f, 4f);
        var clampZPos = Mathf.Clamp(gameObject.transform.position.z, -3.5f, 9.5f);
        gameObject.transform.position = new Vector3(clampXPos, gameObject.transform.position.y,
              clampZPos);
    }
}
