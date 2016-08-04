using UnityEngine;
using System.Collections;
using System;
using LitJson;
using UnityEngine.UI;
using System.Text.RegularExpressions; 

public class NewBehaviourScript : MonoBehaviour {

	private string path = "http://api.jugemkey.jp/api/horoscope/free";
	public string dd = "";
	public JsonData jsonData;
	public DecodeData[] decodeData;

	public Text text;
	public string aw;

	IEnumerator Start() {
		dd = DateTime.Now.ToString("yyyy/MM/dd");
		using (WWW www = new WWW (path + "/" + dd)) {
			yield return www;

			if (!string.IsNullOrEmpty (www.error)) {
				yield break;
			}
			aw = www.text.Replace (dd, "hoge");
			jsonData = JsonMapper.ToObject(www.text);
			decodeData = JsonMapper.ToObject<DecodeData[]>(aw);
		}
	}

	public void OnValueChanged(int res)
	{
		Dropdown dropM = GameObject.FindGameObjectWithTag("month").GetComponent<Dropdown>();
		Dropdown dropD = GameObject.FindGameObjectWithTag("day").GetComponent<Dropdown>();
//		Debug.Log (dropM.value + ":" + dropD.value);
		if (dropM.value == 0 || dropD.value == 0) {
			return;
		}
		string sss = GetAtomFromBirthday (dropM.value.ToString("00"), dropD.value.ToString("00"));
		Debug.Log (sss);
//		Debug.Log (decodeData[0].horoscope.hoge[0].content);

//		foreach(JsonData r in jsonData ["horoscope"] [dd] ) {
//			string sign = (string)r ["sign"];
//			if (sign.Equals (sss)) {
//				Debug.Log ((string)r ["content"]);
//			}
//		}
//			Debug.Log ((string)jsonData ["horoscope"] [dd] [result] ["content"]);

	}

	// Update is called once per frame
	void Update () {

	}

	public string GetAtomFromBirthday(string month, string day)
	{
		string md = month + day;
		if (Regex.IsMatch (md, @"\A0(?:3(?:2[123456789]|3[01])|4(?:0[123456789]|1\d))\z")) {
			return "牡羊座";
		}
		if (Regex.IsMatch (md, @"\A0(?:5(?:0[123456789]|1\d|20)|4(?:2\d|30))\z")) {
			return "牡牛座";
		}
		if (Regex.IsMatch (md, @"\A0(?:6(?:0[123456789]|2[01]|1\d)|5(?:2[123456789]|3[01]))\z")) {
			return "双子座";
		}
		if (Regex.IsMatch (md, @"\A0(?:7(?:0[123456789]|2[012]|1\d)|6(?:2[23456789]|30))\z")) {
			return "蟹座";
		}
		if (Regex.IsMatch (md, @"\A0(?:8(?:0[123456789]|2[012]|1\d)|7(?:2[3456789]|3[01]))\z")) {
			return "獅子座";
		}
		if (Regex.IsMatch (md, @"\A0(?:9(?:0[123456789]|2[012]|1\d)|8(?:2[3456789]|3[01]))\z")) {
			return "乙女座";
		}
		if (Regex.IsMatch (md, @"\A(?:10(?:0[123456789]|2[0123]|1\d)|09(?:2[3456789]|30))\z")) {
			return "天秤座";
		}
		if (Regex.IsMatch (md, @"\A1(?:1(?:0[123456789]|2[01]|1\d)|0(?:2[456789]|3[01]))\z")) {
			return "蟹座";
		}
		if (Regex.IsMatch (md, @"\A1(?:2(?:0[123456789]|2[01]|1\d)|1(?:2[23456789]|30))\z")) {
			return "射手座";
		}
		if (Regex.IsMatch (md, @"\A(?:12(?:2[23456789]|3[01])|01(?:0[123456789]|1\d))\z")) {
			return "山羊座";
		}
		if (Regex.IsMatch (md, @"\A0(?:2(?:0[123456789]|1[012345678])|1(?:3[01]|2\d))\z")) {
			return "水瓶座";
		}
		if (Regex.IsMatch (md, @"\A0(?:3(?:0[123456789]|1\d|20)|2(?:2\d|19))\z")) {
			return "魚座";
		}
		return "";
	}

	public class DecodeData
	{
		public Horoscope horoscope;
	}
	public class Horoscope
	{
		public Hoge[] hoge;
	}
	public class Hoge
	{
		public string content;
		public string item;
		public int money;
		public int total;
		public int job;
		public string color;
		public int day;
		public int love;
		public int rank;
		public string sign;
	}
}

