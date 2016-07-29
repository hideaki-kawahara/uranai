using UnityEngine;
using System.Collections;
using System;
using LitJson;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

	private string path = "http://api.jugemkey.jp/api/horoscope/free";
	public string dd = "";
	public JsonData jsonData;

	public Text text;

	IEnumerator Start() {
		dd = DateTime.Now.ToString("yyyy/MM/dd");
		using (WWW www = new WWW (path + "/" + dd)) {
			yield return www;

			if (!string.IsNullOrEmpty (www.error)) {
				yield break;
			}
			jsonData = JsonMapper.ToObject(www.text);
		}
	}

	public void OnValueChanged(int result)
	{
		if (result == 0) {
			Debug.Log ("選択してください");
		} else {
			Debug.Log ((string)jsonData ["horoscope"] [dd] [result] ["content"]);

		}
	}

	// Update is called once per frame
	void Update () {

	}
}

