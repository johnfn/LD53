
using System.Collections.Generic;

public enum LayerMask {
  Wall,
  Spikes,
}

public static class Globals {
  public static Dictionary<uint, LayerMask> LayerMasks = new() {
    [1] = LayerMask.Wall,
    [2] = LayerMask.Spikes,
  };
}