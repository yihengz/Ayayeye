﻿using UnityEngine;
using System.Collections;

public class NumGenerator : MonoBehaviour {
	public GameObject[] digits;
	public Color c;

	void Start() {
		//c = Color.white;
		c.a = 0;
	}

	public void Generate(int num, Vector3 pos, GameObject father) {
		if (num <= 0) {
			Debug.Log("score less or equal to zero");
			return ;
		}

		GameObject new_holder = new GameObject("score");
		new_holder.transform.position = pos;
		new_holder.transform.localScale = Vector3.zero;

		int l = num.ToString().Length;
		float pos_x = -l * 0.5f * 0.25f;
		for (; num > 0; num /= 10, pos_x += 0.25f) {
			int digit = num % 10;
			GameObject newdigit = Instantiate(digits[digit]);
			newdigit.GetComponent<Renderer>().material.color = c;
			newdigit.transform.parent = new_holder.transform;
			newdigit.transform.localPosition = new Vector3(pos_x, 0, 0);
			newdigit.transform.localScale = Vector3.one;
		}
		new_holder.transform.LookAt(Vector3.zero);
		new_holder.transform.parent = father.transform;
		new_holder.AddComponent<Poping>();
		new_holder.GetComponent<Poping>().Pop();
	}

}
