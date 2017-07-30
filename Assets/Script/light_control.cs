using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exploder.Demo
{
	public class light_control : MonoBehaviour {

		private ExploderObject Exploder;
		private GameObject gameObject;


		string strId;

		// Use this for initialization
		void Start () {
			//Debug.Log("start!");


		}

		// Update is called once per frame
		void Update () {

			//Debug.Log (gameObject);
			if(this){
				Vector3 tmp = this.transform.position;

				if(-4.5f > tmp.y){
					Exploder = this.GetComponent<ExploderObject>();


					if (Exploder)
					{
						//Debug.Log ("out!!");
						Exploder.ExplodeRadius();
					}
				}
			}
			//Debug.Log (tmp.y);

		}

		/// クリックされた
/*
		public void OnMouseDown()
		{
			Debug.Log("OnMouseDown!");


			//gameObject = this.gameObject;
			Debug.Log (gameObject);

//			Exploder = gameObject.GetComponent<ExploderObject>();
			Exploder = this.GetComponent<ExploderObject>();


			if (Exploder)
			{
				Debug.Log ("boom!!");
				Exploder.ExplodeRadius();
			}

			//gameObject = getClickObject ();
			// 破棄する
			//DestroyObj();
		}
*/



	}


}