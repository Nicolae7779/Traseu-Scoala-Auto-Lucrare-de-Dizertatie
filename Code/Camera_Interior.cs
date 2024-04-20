using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MoveCamera : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;

    public float time_delay = 0f;

    public float time = 0.25f;

    public float Move_speed = 1f;
    public float RIGHT_LEFT = 0f;
    public float UP_DOWN = 0f;
    public float FRONT_BACK = 0f;


    // Position
    public float X = 100f;
    public float Y = 100f;
    public float Z = 100f;


    private void Start()
    {
        transform.rotation = UnityEngine.Quaternion.Euler(0, 0, 0);
        transform.position = new UnityEngine.Vector3(X, Y, Z);
    }


    void Update()
    {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);

            switch (rec.rgdwPOV[0])
            {
                case (0):
                    time_delay += Time.deltaTime;
                    if (time_delay > time)
                    {
                        UP_DOWN += Time.deltaTime * Move_speed;
                        transform.position = new UnityEngine.Vector3(X + RIGHT_LEFT, Y + UP_DOWN, Z + FRONT_BACK);
                    }
                    break;

                case (4500):
                    FRONT_BACK += Time.deltaTime * Move_speed;
                    transform.position = new UnityEngine.Vector3(X + RIGHT_LEFT, Y + UP_DOWN, Z + FRONT_BACK);
                    break;


                case (9000):
                    time_delay += Time.deltaTime;
                    if (time_delay > time)
                    {
                        RIGHT_LEFT += Time.deltaTime * Move_speed;
                        transform.position = new UnityEngine.Vector3(X + RIGHT_LEFT, Y + UP_DOWN, Z + FRONT_BACK);
                    }
                    break;


                case (13500):
                    FRONT_BACK -= Time.deltaTime * Move_speed;
                    transform.position = new UnityEngine.Vector3(X + RIGHT_LEFT, Y + UP_DOWN, Z + FRONT_BACK);
                    break;


                case (18000):
                    time_delay += Time.deltaTime;
                    if (time_delay > time)
                    {
                        UP_DOWN -= Time.deltaTime * Move_speed;
                        transform.position = new UnityEngine.Vector3(X + RIGHT_LEFT, Y + UP_DOWN, Z + FRONT_BACK);
                    }
                    break;


                case (22500):
                    FRONT_BACK -= Time.deltaTime * Move_speed;
                    transform.position = new UnityEngine.Vector3(X + RIGHT_LEFT, Y + UP_DOWN, Z + FRONT_BACK);
                    break;


                case (27000):
                    time_delay += Time.deltaTime;
                    if (time_delay > time)
                    {
                        RIGHT_LEFT -= Time.deltaTime * Move_speed;
                        transform.position = new UnityEngine.Vector3(X + RIGHT_LEFT, Y + UP_DOWN, Z + FRONT_BACK);
                    }
                    break;


                case (31500):
                    FRONT_BACK += Time.deltaTime * Move_speed;
                    transform.position = new UnityEngine.Vector3(X + RIGHT_LEFT, Y + UP_DOWN, Z + FRONT_BACK);
                    break;


                default:
                    //actualState += "POV : CENTER\n"; 
                    time_delay = 0;
                    break;
            }
        }
    }
}
