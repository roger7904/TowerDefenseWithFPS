using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextenemyUI : MonoBehaviour
{
    public Text Nextenemytext;
    private string nexte;

    // Update is called once per frame
    void Update()
    {
        nexte="";

        for (int i = 0; i < WaveSpawner.waveflag.count.Length; i++)
        {
            if (WaveSpawner.waveflag.enemy[i].name == "weillin(water)")
            {
                nexte =nexte+ "weilin(water) * "+WaveSpawner.waveflag.count[i]+"\n";
            }
            else if (WaveSpawner.waveflag.enemy[i].name == "tzuyen(water)")
            {
                nexte =nexte+ "tzuyen(water) * "+WaveSpawner.waveflag.count[i]+"\n";
            }
            else if (WaveSpawner.waveflag.enemy[i].name == "journey(water)")
            {
                nexte =nexte+ "journey(water) * "+WaveSpawner.waveflag.count[i]+"\n";
            }else if (WaveSpawner.waveflag.enemy[i].name == "weillin(wood)")
            {
                nexte =nexte+ "weilin(wood) * "+WaveSpawner.waveflag.count[i]+"\n";
            }
            else if (WaveSpawner.waveflag.enemy[i].name == "tzuyen(wood)")
            {
                nexte =nexte+ "tzuyen(wood) * "+WaveSpawner.waveflag.count[i]+"\n";
            }
            else if (WaveSpawner.waveflag.enemy[i].name == "journey(wood)")
            {
                nexte =nexte+ "journey(wood) * "+WaveSpawner.waveflag.count[i]+"\n";
            }else if (WaveSpawner.waveflag.enemy[i].name == "weillin(fire)")
            {
                nexte =nexte+ "weilin(fire) * "+WaveSpawner.waveflag.count[i]+"\n";
            }
            else if (WaveSpawner.waveflag.enemy[i].name == "tzuyen(fire)")
            {
                nexte =nexte+ "tzuyen(fire) * "+WaveSpawner.waveflag.count[i]+"\n";
            }
            else if (WaveSpawner.waveflag.enemy[i].name == "journey(fire)")
            {
                nexte =nexte+ "journey(fire) * "+WaveSpawner.waveflag.count[i]+"\n";
            }
        }

        Nextenemytext.text = "NextEnemy:\n"+nexte;


    }
}
