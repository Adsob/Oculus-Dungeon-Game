using UnityEngine;
using System.Collections;

public class AnimationButton : MonoBehaviour {


	public Light licht;
	public Light licht2;
	public Animation anim;



	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Player") {

			anim.Play ("Klick");
			licht.color = Color.red;
			licht2.color = Color.green;

		}

	}

}
