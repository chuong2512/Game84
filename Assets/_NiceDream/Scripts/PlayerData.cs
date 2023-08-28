using UnityEngine;
using UnityEngine.Serialization;

public class Constant
{
    public static string DataKey_PlayerData = "player_data";
    public static int countSong = 20;
    public static int priceUnlockSong = 10;
}

public class PlayerData : BaseData
{
    public int intDiamond;
    [FormerlySerializedAs("currentSong")] public int crtMusicalIns;
    [FormerlySerializedAs("listSongs")] public bool[] listMusical;
    public bool isUnlock;

    public override void Init()
    {
        prefString = Constant.DataKey_PlayerData;
        if (PlayerPrefs.GetString(prefString).Equals(""))
        {
            ResetData();
        }

        base.Init();
    }


    public override void ResetData()
    {
        intDiamond = 0;
        crtMusicalIns = 0;
        listMusical = new bool[Constant.countSong];
        isUnlock = false;

        //listMusical[0] = true;
        for (int i = 0; i < listMusical.Length; i++)
        {
            listMusical[i] = true;
        }
        
        Save();
    }

    public void AddDiamond(int a)
    {
        intDiamond += a;

        Save();
    }

    public bool CheckCanUnlock(int price, int id)
    {
        if(intDiamond < price) return false;
        SubDiamond(price);
        Unlock(id);
        return true;
    }
    public bool CheckLock(int id)
    {
        return this.listMusical[id];
    }

    public void Unlock(int id)
    {
        if (!listMusical[id])
        {
            listMusical[id] = true;
        }

        Save();
    }
   

    public void UnlockPack()
    {
        isUnlock = true;
        Save();
    }
    public void SubDiamond(int a)
    {
        intDiamond -= a;

        if (intDiamond < 0)
        {
            intDiamond = 0;
        }

        Save();
    }

    public void ChooseSong(int i)
    {
        crtMusicalIns = i;
        Save();
    }
}