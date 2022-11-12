using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MainCamera : MonoBehaviour
{
    public Transform t_Target;	
	private float f_CamOffSet_Y = -5;

	void LateUpdate()
	{	
		float f_CamOffSet_Y_Ajusted = t_Target.position.y < f_CamOffSet_Y ? f_CamOffSet_Y : t_Target.position.y;
		Vector3 t_New_Position = new Vector3(t_Target.position.x, f_CamOffSet_Y_Ajusted, t_Target.position.z);
		transform.position = t_New_Position;
	}
}
