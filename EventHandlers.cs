// Decompiled with JetBrains decompiler
// Type: Chillin.EventHandlers
// Assembly: Chillin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 084DA1FB-F6CC-4767-906C-DF11D5DFA953
// Assembly location: C:\Users\dimas\Downloads\Chillin.dll

using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using System.Linq;
using MEC;
using UnityEngine;

namespace Chillin
{
    public class EventHandlers
    {
        private System.Random _random = new System.Random();
        private bool _isRoundEnded = false;
        private List<ItemType> _items = new List<ItemType>();
        private Vector3 _position;

        public void OnWaitingForPlayers()
        {
            this._isRoundEnded = false;
            this._items.Clear();
        }

        public void OnRoundEnd(RoundEndedEventArgs _)
        {
            int num = this._random.Next(0, Plugin.Instance.Config.Coords.Count);
            int num2 = this._random.Next(0, Plugin.Instance.Config.Coords.Count);
            this._position = new Vector3(Plugin.Instance.Config.Coords[num].X, Plugin.Instance.Config.Coords[num].Y, Plugin.Instance.Config.Coords[num].Z);
            this._items = Plugin.Instance.Config.ItemsSet[num2].Cast<ItemType>().ToList();
            this._isRoundEnded = true;
            SpawnPlayers();
        }

        public void OnPlayerJoin(JoinedEventArgs ev)
        {
            if (ev.Player == null)
            {
                return;
            }
            if (!this._isRoundEnded)
                return;
            Timing.RunCoroutine(SpawnPlayer(ev.Player));
        }

        public void SpawnPlayers()
        {
            foreach (Player player in Player.List) {
                Timing.RunCoroutine(SpawnPlayer(player));
            }
            string broadcastMsg = Plugin.Instance.Config.BroadcastMsg;
            ushort broadcastTime = Plugin.Instance.Config.BroadcastTime;
            if (!string.IsNullOrWhiteSpace(broadcastMsg) && broadcastTime > (ushort)0)
            {
                Map.ClearBroadcasts();
                Map.Broadcast(broadcastTime, broadcastMsg, (Broadcast.BroadcastFlags)0);
            }
        }

        public IEnumerator<float> SpawnPlayer(Player player)
        {
            player.SetRole(RoleType.Tutorial, lite: true);
            yield return Timing.WaitForOneFrame;
            player.ResetInventory(this._items);
            player.IsGodModeEnabled = Plugin.Instance.Config.GodMode;
            player.Position = new Vector3(this._position.x, this._position.y, this._position.z);
            if (Plugin.Instance.Config.Vision939Wallhack)
                player.EnableEffect((EffectType)20, 0.0f, false);
        }
    }
}
