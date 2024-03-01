using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Vector3 RotationOffset;
    public Vector3 PositionOffset;
    [SerializeField] private Transform MainPlayer;
    private void FixedUpdate()
    {
        transform.position=Vector3.Lerp(transform.position, MainPlayer.position+PositionOffset,0.9f);
        transform.LookAt(MainPlayer.position,Vector3.forward);
        transform.eulerAngles=RotationOffset+new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z);
    }
}
