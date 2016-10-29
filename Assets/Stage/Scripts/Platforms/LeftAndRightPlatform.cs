using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

namespace PlatformerPro
{
	/// <summary>
	/// A platform that moves up and down between two set points at a fixed speed.
	/// </summary>
	public class LeftAndRightPlatform : Platform
	{
		/// <summary>
		/// The distance from starting position to the highest extent.
		/// </summary>
		public float leftOffset;

		/// <summary>
		/// The distance from starting position to the lowest extent.
		/// </summary>
		public float rightOffset;

		/// <summary>
		/// The speed the platform moves at.
		/// </summary>
		public float speed;

		/// <summary>
		/// Should we parent when the head collides with this platform (used when you have hang from ceiling).
		/// </summary>
		public bool parentOnHeadCollission;

		//// <summary>
		/// Cached reference to the transform.
		/// </summary>
		protected Transform myTransform;

		/// <summary>
		/// The top extent.
		/// </summary>
		protected float leftExtent;

		/// <summary>
		/// The bottom extent.
		/// </summary>
		protected float rightExtent;

		/// <summary>
		/// The position the platform started at.
		/// </summary>
		protected Vector2 startingPosition;


		/// <summary>
		/// Unit update hook.
		/// </summary>
		void Update()
		{

			if (Activated) DoMove();
		}

		/// <summary>
		/// Init this instance.
		/// </summary>
		override protected void Init()
		{
			base.Init();
			if (transform.lossyScale != Vector3.one)
			{
				Debug.LogError("Moving platforms should have a scale of (1,1,1). " +
				               "If you wish to make them larger change the size of the collider and make the visual component a child of the platform.");
			}
			myTransform = transform;
			rightExtent = transform.position.x - rightOffset;
			leftExtent = transform.position.x + leftOffset;
		}

		/// <summary>
		/// Do the move.
		/// </summary>
		protected virtual void DoMove()
		{
			if (speed > 0)
			{
				// We have the additional check so we can beter support platforms starting at the wrong spot
				if (myTransform.position.x >= leftExtent)
				{
					speed *= -1;
					if (automaticDeactivation == PlatformDeactivationType.DEACTIVATE_ON_EXTENT) Activated = false;
				}
				else
				{
					float distance = speed * TimeManager.FrameTime;
					myTransform.Translate(distance, 0, 0);
					if (myTransform.position.y > leftExtent)
					{
						float difference = distance - (myTransform.position.x - leftExtent);
						myTransform.position = new Vector3(myTransform.position.y, leftExtent - difference, myTransform.position.z);
						speed *= -1;
						if (automaticDeactivation == PlatformDeactivationType.DEACTIVATE_ON_EXTENT) Activated = false;
					}
				}
			}
			else if (speed < 0)
			{
				if (myTransform.position.x <= rightExtent)
				{
					speed *= -1;
					if (automaticDeactivation == PlatformDeactivationType.DEACTIVATE_ON_EXTENT) Activated = false;
				}
				else
				{

					float distance = speed * TimeManager.FrameTime;
					myTransform.Translate(distance, 0,  0);
					if (myTransform.position.x < rightExtent)
					{
						float difference = distance - (myTransform.position.x - rightExtent);
						myTransform.position = new Vector3( rightExtent - difference, myTransform.position.y, myTransform.position.z);
						speed *= -1;
						if (automaticDeactivation == PlatformDeactivationType.DEACTIVATE_ON_EXTENT) Activated = false;
					}
				}
			}
		}

		/// <summary>
		/// If the collission is a foot try to parent.
		/// </summary>
		/// <param name="character">Character.</param>
		/// <param name="type">Type of raycast.</param>
		override protected bool CustomCollide(PlatformCollisionArgs args)
		{
			if (args.RaycastCollider.RaycastType == RaycastType.FOOT)
			{
				return true;
			}
			if (parentOnHeadCollission && args.RaycastCollider.RaycastType == RaycastType.HEAD)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Called when the character is parented to this platform.
		/// </summary>
		override public void Parent()
		{
			if (automaticActivation == PlatformActivationType.ACTIVATE_ON_STAND) Activated = true;
			if (automaticDeactivation == PlatformDeactivationType.DEACTIVATE_ON_STAND) Activated = false;
		}
		
		/// <summary>
		/// Called when the character is unparented from this platform.
		/// </summary>
		override public void UnParent()
		{
			if (automaticActivation == PlatformActivationType.ACTIVATE_ON_LEAVE) Activated = true;
			if (automaticDeactivation == PlatformDeactivationType.DEACTIVATE_ON_LEAVE) Activated = false;
		}

		/// <summary>
		/// Draw handles for showing extents
		/// </summary>
		void OnDrawGizmos() {
			float top =0.0f; float bottom = 0.0f;

			if (GetComponent<Collider2D>() is EdgeCollider2D)
			{
				EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
				for (int i = 0; i < edgeCollider.points.Length; i++)
				{
					if (edgeCollider.points[i].x > bottom) bottom = edgeCollider.points[i].x;
					if (edgeCollider.points[i].x < top) top = edgeCollider.points[i].x;
				}
			}
			else if (GetComponent<Collider2D>() is BoxCollider2D)
			{
				BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
				bottom = boxCollider.size.x / 2.0f;
				top = boxCollider.size.x / -2.0f;
			}

			// Gizmos.color = Platform.GizmoColor;
			// Gizmos.DrawLine(transform.position,  transform.position + new Vector3(0, leftOffset + bottom,  0));
			// Gizmos.DrawLine(transform.position + new Vector3(0.25f, leftOffset + bottom, 0), transform.position + new Vector3( -0.25f, topOffset + right, 0));
			// Gizmos.DrawLine(transform.position,  transform.position + new Vector3(0, -rightOffset + top,  0));
			// Gizmos.DrawLine(transform.position + new Vector3(0.25f, -rightOffset + top,  0),  transform.position + new Vector3(-0.25f,-bottomOffset + left, 0));
		}
	}

}