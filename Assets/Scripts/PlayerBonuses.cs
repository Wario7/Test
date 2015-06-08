using UnityEngine;
using System.Collections;

public class PlayerBonuses : MonoBehaviour {

	private static PlayerBonuses instance;
	private BulletFiring bulletFiring;
	private int bonusesTaken;
	private DisplayManager displayManager;

	public static PlayerBonuses getInstance(){
		return instance;
	}

	void Start(){
		displayManager = DisplayManager.Instance ();
		bonusesTaken = 0;
		instance = this;
		bulletFiring = GetComponentInChildren<BulletFiring> ();
//		bulletFiring = BulletFiring.getInstance ();
	}

	public void FirstBonus(){
		bulletFiring.fireRate = 0.2f;
		bonusesTaken++;
	}

	public void SecondBonus(){
		bulletFiring.opPowered = true;
	}

	public void grantBonus(){
		if (bonusesTaken == 0) {
			PlayerBonuses.getInstance ().FirstBonus ();
			displayManager.DisplayMessage ("Bonus fire rate!!!");
			bonusesTaken++;
		} else {
			PlayerBonuses.getInstance ().SecondBonus ();
			displayManager.DisplayMessage ("OP POWER!!!");
		}
	}
}
