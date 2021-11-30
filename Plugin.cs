// Decompiled with JetBrains decompiler
// Type: Chillin.Plugin
// Assembly: Chillin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 084DA1FB-F6CC-4767-906C-DF11D5DFA953
// Assembly location: C:\Users\dimas\Downloads\Chillin.dll

using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace Chillin
{
  public class Plugin : Plugin<PluginConfig>
  {
    private EventHandlers _handlers;

    EventHandlers EventHandler = new EventHandlers();
    public virtual string Name => "Chillin";

    public virtual string Prefix => "Chillin";

    public virtual string Author => "Dark7eamplar#2683";

    public virtual PluginPriority Priority => (PluginPriority) 0;

    public virtual Version Version => new Version(1, 0, 1); 

    public virtual Version RequiredExiledVersion => new Version(3, 7);

    public static Plugin Instance { get; private set; }

    public override void OnEnabled()
    {
      base.OnEnabled();
      EventHandler = new EventHandlers();
      // ISSUE: method pointer
      Server.RoundEnded += EventHandler.OnRoundEnd;
      // ISSUE: method pointer
      Player.Joined += EventHandler.OnPlayerJoin;
      // ISSUE: method pointer
      Server.WaitingForPlayers += EventHandler.OnWaitingForPlayers;
    }

    public override void OnDisabled()
    {
      EventHandler = null;
      Server.RoundEnded -= EventHandler.OnRoundEnd;
      // ISSUE: method pointer
      Player.Joined -= EventHandler.OnPlayerJoin;
      // ISSUE: method pointer
      Server.WaitingForPlayers -= EventHandler.OnWaitingForPlayers;
      base.OnDisabled();
    }
  }
}
