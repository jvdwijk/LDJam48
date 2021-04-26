using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    private const string PLAYER_PREF_PREFIX = "worm_skin_";

    private static SkinManager instance;

    public static SkinManager Instance => instance;


    private SkinData currentskin;

    public Skin Current => currentskin.skin;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        instance = this;

        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].unlocked = PlayerPrefs.GetInt(PLAYER_PREF_PREFIX + skins[i].skin.Name) > 0 || skins[i].unlocked;
        }

        currentskin = skins[0];
    }

    [SerializeField]
    private SkinData[] skins;

    public SkinData[] Skins => skins;

    public void SetSkin(SkinData selectSkin)
    {
        currentskin = selectSkin;
    }

    public void Unlock(string name)
    {
        
        SkinData skin = GetByName(name);
        PlayerPrefs.SetInt(PLAYER_PREF_PREFIX + name, 1);
        print("select " + PLAYER_PREF_PREFIX + name);
        if (skin != null)
        {
            skin.unlocked = true;
        }

    }

    private SkinData GetByName(string name)
    {
        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i].skin.name == name)
                return skins[i];
        }
        return null;
    }

    [System.Serializable]
    public class SkinData
    {
        [SerializeField]
        public int price;

        [SerializeField]
        public bool unlocked;

        [SerializeField]
        public Skin skin;
    }

}
