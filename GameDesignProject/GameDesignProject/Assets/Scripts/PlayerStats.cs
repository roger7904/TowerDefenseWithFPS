using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;

	void Start ()
	{
		if(Levelloader.iscomefromload){
			Money = PlayerPrefs.GetInt("money");
			Lives = PlayerPrefs.GetInt("lives");
		}else{
			Money = startMoney;
			Lives = startLives;
		}
		Rounds = 0;
	}

}
