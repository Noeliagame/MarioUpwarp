using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimits : MonoBehaviour
{
    public GameObject target;

    private float target_poseX;
    private float target_poseY;

    private float posX;
    private float posY;

    public float rightMax;
    public float leftMax;

    public float heightMax;
    public float heightMin;

    public float speed;
    public bool cameraOn = true;
    // Start is called before the first frame update

    private void Awake()
    {
        posX = target_poseX + rightMax;
        posY = target_poseY + heightMin;
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), 1);
    }

    void Move_Cam()
    {
        if (cameraOn)
        {
            if (target)
            {
                target_poseX = target.transform.position.x;
                target_poseY = target.transform.position.y;

                if(target_poseX > rightMax && target_poseX < leftMax)
                {
                    posX = target_poseX;
                }                
                
                if(target_poseY < heightMax && target_poseY > heightMin)
                {
                    posY = target_poseY;
                }

            }
                transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), speed*Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move_Cam();
    }
}
