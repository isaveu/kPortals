﻿using UnityEngine;

namespace kTools.PortalsOld
{
	[ExecuteInEditMode]
    [AddComponentMenu("kTools/Portals/PortalOccluder")]
	[RequireComponent(typeof(BoxCollider))]
	public sealed class PortalOccluder : MonoBehaviour 
	{
		private BoxCollider m_BoxCollider;
		public BoxCollider boxCollider
		{
			get 
			{
				if(m_BoxCollider == null)
					m_BoxCollider = GetComponent<BoxCollider>();
				return m_BoxCollider;
			}
		}

		private void OnEnable()
		{
#if UNITY_EDITOR
            // Collapse BoxCollider UI as user shouldnt edit it
			UnityEditorInternal.InternalEditorUtility.SetIsInspectorExpanded(boxCollider, false);
#endif
		}

		// -------------------------------------------------- //
        //                       GIZMOS                       //
        // -------------------------------------------------- //

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
			// Draw Icon
			Gizmos.DrawIcon(transform.position, "kTools/Portals/PortalVolume icon.png", true);

			// Draw Gizmos
			Matrix4x4 cubeTransform = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
			Matrix4x4 oldGizmosMatrix = Gizmos.matrix;
			Gizmos.matrix = Gizmos.matrix * cubeTransform;
			Gizmos.color = DebugColors.occluder.fill;
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
			Gizmos.color = DebugColors.occluder.wire;
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
			Gizmos.matrix = oldGizmosMatrix;
        }
#endif
	}
}