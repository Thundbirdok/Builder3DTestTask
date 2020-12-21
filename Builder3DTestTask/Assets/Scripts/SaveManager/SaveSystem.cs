using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class SaveSystem
{

    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    public static void Save(string json)
    {

        if (!Directory.Exists(SAVE_FOLDER))
        {

            Directory.CreateDirectory(SAVE_FOLDER);

        }

        File.WriteAllText(SAVE_FOLDER + "/save.txt", json);

    }

    public static string Load()
    {

        if (!File.Exists(SAVE_FOLDER + "/save.txt"))
        {

            Debug.Log("Save not found");

            return "";

        }

        return File.ReadAllText(SAVE_FOLDER + "/save.txt");

    }

}

