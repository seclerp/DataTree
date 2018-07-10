using System;
using System.Linq;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

namespace DataTree.Example.MainTree
{
  public class GameData : Node
  {
    public static Lazy<GameData> Instance { get; } = new Lazy<GameData>(() => new GameData());
    
    private GameData() : base("GameData")
    {
      var meta = new Node("Meta",
        new Node("Nickname", "Some Nickname"), 
        new Node("Password", "Some Password")
      );

      var units = new Node("Units",
        new Node("Unit1", 
          new Node("Name", "Unit1"), 
          new Node("Health", 10), 
          new Node("Damage", 15), 
          new Node("Defence", 5)
        ),
        new Node("Unit2", 
          new Node("Name", "Unit2"), 
          new Node("Health", 15), 
          new Node("Damage", 10), 
          new Node("Defence", 7)
        ),
        new Node("Unit3", 
          new Node("Name", "Unit3"), 
          new Node("Health", 150), 
          new Node("Damage", 100), 
          new Node("Defence", 70)
        )
      );
      
      CommitChildren(new[]
      {
        meta, units
      }, 
        null);
    }

    [MenuItem("DataTree/Debug GameData")]
    public static void ShowMenu()
    {
      Debug.Log(JsonConvert.SerializeObject(Instance.Value));
    }

    private static Random Random = new Random();
    [MenuItem("DataTree/Randomize Units props")]
    public static void RandomizeUnitProps()
    {
      Instance.Value.GetNode("Units").ExecuteCommand(units =>
      {
        foreach (var child in units.Children)
        {
          child.GetNode("Health").CommitData(_ => Random.Next(1, 21));
          child.GetNode("Damage").CommitData(_ => Random.Next(1, 21));
          child.GetNode("Defence").CommitData(_ => Random.Next(1, 21));
        }
      });
    }

    [MenuItem("DataTree/Add random unit")]
    public static void AddRandom()
    {
      var units = Instance.Value.GetNode("Units");
      
      var newUnit = new Node($"Unit{units.Children.Count + 1}",
        new Node("Name", $"Unit{units.Children.Count + 1}"),
        new Node("Health", Random.Next(1, 21)),
        new Node("Damage", Random.Next(1, 21)),
        new Node("Defence", Random.Next(1, 21))
      );
      
      units.CommitChildren(new[] { newUnit }, null);
    }
    
    [MenuItem("DataTree/Remove last unit")]
    public static void RemoveLast()
    {      
      var units = Instance.Value.GetNode("Units");
      
      units.CommitChildren(
        null, 
        new[]
        {
          units.Children.Last()
        }
      );
    }
  }
}