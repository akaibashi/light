using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Exploder.Demo
{
	public class game_control : MonoBehaviour {

		private ExploderObject Exploder;

		public float interval = 1.0f;
		public GameObject lightPrefab = null;

		public List<GameObject> DrugGameObjectList;

		private bool nextIsRed;
		private float timer;



		private bool isDrug = false;

		// Use this for initialization
		void Start () {
			timer = 0;
			nextIsRed = true;
		}
		
		// Update is called once per frame
		void Update () {

			// 生成
			timer -= Time.deltaTime;
			if (timer < 0.0) {
				float offsX = Random.Range (-5.0f, 5.0f);
				float offsY = Random.Range (0.0f, 5.0f);
				float offsZ = Random.Range (0.0f, 0.0f);
				Vector3 position = transform.position + new Vector3 (offsX, offsY, offsZ);

				Instantiate (lightPrefab, position, Quaternion.identity);

				nextIsRed = !nextIsRed;
				timer = interval;
			}




			// 押された
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log ("push!");
				isDrug = true;
			}


			// 繋げる
			GameObject tapGameObject = getClickObject();
			if(tapGameObject){

				Debug.Log ("add obj!");

				DrugGameObjectList.Add (tapGameObject);
			}



			// 離された
			if (Input.GetMouseButtonUp (0)) {
				Debug.Log ("mouseUp!");

				isDrug = false;

				foreach(var drugObj in DrugGameObjectList){

					Debug.Log (drugObj);
					if(drugObj){
						Exploder = drugObj.GetComponent<ExploderObject>();
						if (Exploder)
						{
							Debug.Log ("boom!!");
							Exploder.ExplodeRadius();
						}
					}
				}
			}

		}


		// 左クリックしたオブジェクトを取得する関数(3D)
		public GameObject getClickObject() {
			GameObject result = null;
			if(isDrug){
				// 左クリックされた場所のオブジェクトを取得
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(ray, out hit)){
					result = hit.collider.gameObject;



					if(DrugGameObjectList.Contains(result)){

						result = null;
					}

				}

			}
			return result;


			/*
			GameObject result = null;
			// 左クリックされた場所のオブジェクトを取得
			if(Input.GetMouseButtonDown(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(ray, out hit)){
					result = hit.collider.gameObject;
					}
				}
			return result;
			*/
		}

	}
}