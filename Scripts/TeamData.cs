using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TeamData
{
    public List<string> team;

    public TeamData(TeamBuilder builder)
    {
        team = builder.team;
    }
}
