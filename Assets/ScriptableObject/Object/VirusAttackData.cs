using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Object/VirusAttack")]
public class VirusAttackData : GameData
{
    string KEY_HP = "VIRUS_ATTACK_HP";
    string KEY_RANGE = "VIRUS_ATTACK_RANGE";
    string KEY_DAMAGE = "VIRUS_ATTACK_DAMAGE";
    string KEY_TIME = "VIRUS_ATTACK_RESPAWN_TIME";


    [Header("저장 데이터")]
    public float hp;
    public float range;
    public float damage;
    public float tiime;

    public override void ProcessData(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            for (int j = 0; j < columnSize; j++)
            {
                hp = float.Parse(column[0]);
                range = float.Parse(column[1]);
                damage = float.Parse(column[2]);
                tiime = float.Parse(column[3]);

            }
        }
        SaveDataToPrefs();
        isLoaded = true;
    }

    public override void SaveDataToPrefs()
    {
        PlayerPrefs.SetFloat(key + KEY_HP, hp);
        PlayerPrefs.SetFloat(key + KEY_RANGE, range);
        PlayerPrefs.SetFloat(key + KEY_DAMAGE, damage);
        PlayerPrefs.SetFloat(key + KEY_TIME, tiime);

    }

    public override void LoadDataFromPrefs()
    {
        if (PlayerPrefs.HasKey(key + KEY_HP))
            hp = PlayerPrefs.GetFloat(key + KEY_HP);

        if (PlayerPrefs.HasKey(key + KEY_RANGE))
            range = PlayerPrefs.GetFloat(key + KEY_RANGE);

        if (PlayerPrefs.HasKey(key + KEY_DAMAGE))
            damage = PlayerPrefs.GetFloat(key + KEY_DAMAGE);

        if (PlayerPrefs.HasKey(key + KEY_TIME))
            tiime = PlayerPrefs.GetFloat(key + KEY_TIME);
    }
}
