// Decompiled with JetBrains decompiler
// Type: Chillin.EventHandlers
// Assembly: Chillin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 084DA1FB-F6CC-4767-906C-DF11D5DFA953
// Assembly location: C:\Users\dimas\Downloads\Chillin.dll

using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Chillin
{
  public class EventHandlers
  {
    private readonly System.Random _random = new System.Random();
    private bool _isRoundEnded = false;
    private List<ItemType> _items = new List<ItemType>();
    private Vector3 _position;
    public PluginConfig config = new PluginConfig();

    public void OnWaitingForPlayers()
    {
      this._isRoundEnded = false;
      this._items.Clear();
    }

    public void OnRoundEnd(RoundEndedEventArgs ev)
    {
      
      int num = this._random.Next(0, config.Coords.Count);
      int num2 = this._random.Next(0, config.Coords.Count);
      this._position = new Vector3(config.Coords[num].X, config.Coords[num].Y, config.Coords[num].Z);
      this._items = config.ItemsSet[num2].Cast<ItemType>().ToList<ItemType>();
      this._isRoundEnded = true;
      this.SpawnPlayers();
    }

    public void OnPlayerJoin(JoinedEventArgs ev)
    {
      if (!this._isRoundEnded)
        return;
      SpawnPlayer(ev.Player);
    }

    public void SpawnPlayers()
    {
      foreach (Player player in Player.List)
        SpawnPlayer(player);
      string broadcastMsg = config.BroadcastMsg;
      ushort broadcastTime = config.BroadcastTime;
      if (!string.IsNullOrWhiteSpace(broadcastMsg) && broadcastTime > (ushort) 0)
      {
        Map.ClearBroadcasts();
        Map.Broadcast(broadcastTime, broadcastMsg, (Broadcast.BroadcastFlags) 0);
      }
    }  
         
    public void SpawnPlayer(Player player)
    {
      player.SetRole(RoleType.Tutorial);
      player.ResetInventory(this._items);
      player.IsGodModeEnabled = config.GodMode;
      player.Position.Set(this._position.x, this._position.y, this._position.z); 
      if (config.Vision939Wallhack)
        player.EnableEffect((EffectType) 20, 0.0f, false);
    }
  }
}
