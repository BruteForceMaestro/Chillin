// Decompiled with JetBrains decompiler
// Type: Chillin.PluginConfig
// Assembly: Chillin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 084DA1FB-F6CC-4767-906C-DF11D5DFA953
// Assembly location: C:\Users\dimas\Downloads\Chillin.dll

using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace Chillin
{
  public class Config : IConfig
  {
    public bool IsEnabled { get; set; } = true;

    [Description("Наборы предметов, которые могут выпасть")]
    public List<List<int>> ItemsSet { get; set; } = new List<List<int>>()
    {
      new List<int>() { 17, 24 },
      new List<int>() { 16, 16, 16, 33, 33 },
      new List<int>() { 18, 18, 18, 18, 18 },
      new List<int>() { 13, 29, 29, 32 },
      new List<int>() { 25, 25, 25, 31 },
      new List<int>() { 14, 15, 15 },
      new List<int>() { 20, 22, 22, 22, 34 }
    };

    public bool GodMode { get; set; } = true;

    [Description("Легальный валхак")]
    public bool Vision939Wallhack { get; set; }

    [Description("Броадкаст, который будет отправлен игрокам, когда они станут туториалами. Если пусто, броадкаст отправлен не будет")]
    public string BroadcastMsg { get; set; } = string.Empty;

    [Description("Длительность броадкаста в секундах")]
    public ushort BroadcastTime { get; set; }

    [Description("Координаты, на которые могут быть телепортированы игроки. Координаты можно посмотреть через player spec. info\n  # Башня: 55 1020 -45\n  # Под мостом: -1 994 -11\n  # Ещё одна башня: 179 991 29\n  # За 3-ми воротами: 196 994 -109")]
    public List<Chillin.Coords> Coords { get; set; } = new List<Chillin.Coords>()
    {
      new Chillin.Coords(55, 1020, -45),
      new Chillin.Coords(-1, 994, -11),
      new Chillin.Coords(179, 991, 29),
      new Chillin.Coords(196, 994, -108)
    };
  }
}
