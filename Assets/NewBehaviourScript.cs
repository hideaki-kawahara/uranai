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
		Debug.Log (result );
		if (result == 0) {
			Debug.Log ("選択してください");
		} else {
			string aa = GetAtomFromBirthday (3, 9);
//			Debug.Log (aa);
//			Debug.Log ((string)jsonData ["horoscope"] [dd] [result] ["content"]);

		}
	}

	// Update is called once per frame
	void Update () {

	}

	public string GetAtomFromBirthday(int month, int day)
	{
		float fBirthDay = Convert.ToSingle(month.ToString("D") + '.' + day.ToString("D2"));
		float[] atomBound = { 1.20F, 2.20F, 3.21F, 4.21F, 5.21F, 6.22F, 7.23F, 8.23F, 9.23F, 10.23F, 11.21F, 12.22F, 13.20F };
		string[] atoms = { "水瓶座", "魚座", "牡羊座", "牡牛座", "双子座", "蟹座", "獅子座", "乙女座", "天秤座", "蠍座", "射手座", "山羊座" };
		string ret = string.Empty;
		for(int i = 0; i < atomBound.Length - 1; i++)
		{
			if (atomBound[i] <= fBirthDay && atomBound[i + 1] > fBirthDay)
			{
				ret = atoms[i];
				break;
			}
		}
		return ret;
	}
}

