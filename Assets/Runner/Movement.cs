 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Vuforia
{
	public class Movement : MonoBehaviour, ITrackableEventHandler
	{

		public AnimationClip run;
		public AnimationClip idle;
		public GameObject player;

		public Animation ani;

		public bool runNow;
		public bool finish = false;

		public Camera cam;

		public Collider camCol;

		public Transform center;
		public float degreesPerSecond = -30.0f;
		private Vector3 v;

		private TrackableBehaviour mTrackableBehaviour;

		// Use this for initialization
		void Start () 
		{
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}

			v = player.transform.position - center.position;
			ani = player.GetComponent<Animation>();
			camCol = cam.GetComponent<Collider>();
		}

		// Update is called once per frame
		void Update () 
		{

			if(runNow && !finish)
			{
				ani.CrossFade(run.name);
				v = Quaternion.AngleAxis (degreesPerSecond * Time.deltaTime, Vector3.down) * v;
				player.transform.position = new Vector3(center.position.x + v.x, 0, center.position.z + v.z);
				player.transform.Rotate (player.transform.rotation.x, 31*Time.deltaTime, player.transform.rotation.z);
			}
			else
			{
				ani.CrossFade(idle.name);
			}
		}


		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
			    newStatus == TrackableBehaviour.Status.TRACKED ||
			    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
			}
			else
			{
				OnTrackingLost(newStatus);
			}
		}

		private void OnTrackingFound()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			
			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}
			
			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
		}
		
		
		private void OnTrackingLost(TrackableBehaviour.Status s)
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			
			if(s != TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				// Disable rendering:
				foreach (Renderer component in rendererComponents)
				{
					component.enabled = false;
				}
				
				// Disable colliders:
				foreach (Collider component in colliderComponents)
				{
					component.enabled = false;
				}
				
				Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
			}
		}

		public void StopGame(bool gameState)
		{
			runNow = gameState;
		}

		public void GameFinish(bool fin)
		{
			if(fin)
			{
				runNow = false;
				finish = true;
			}
		}



	}
}
