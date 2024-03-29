using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveTeam
{
    public static void SaveNewTeam(TeamBuilder team)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "team.docx";
        FileStream stream = new FileStream(path, FileMode.Create);

        TeamData data = new TeamData(team);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static TeamData LoadTeam()
    {
        string path = Application.persistentDataPath + "team.docx";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TeamData data = formatter.Deserialize(stream) as TeamData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
