using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{

	[SerializeField]
	private Color _color = Color.white;

	private void OnDrawGizmos()
	{
		Gizmos.color = _color;
		Gizmos.DrawWireSphere(transform.position, 1f);
	}

}
