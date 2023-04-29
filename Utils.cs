using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Godot;

class Utils {
  public static string ToString(object? what) {
    if (what == null) {
      return "null";
    }

    if (what is List<dynamic> l) {
      return "[" + string.Join(", ", l.Select(i => Utils.ToString(i)).ToList()) + "]";
    } else if (what is IEnumerable<dynamic> e) {
      return "[" + string.Join(", ", e.Select(i => Utils.ToString(i)).ToList()) + "]";
    } else if (what is bool[] ba) {
      return "[" + string.Join(", ", ba.Select(i => Utils.ToString(i)).ToList()) + "]";
    } else if (what.GetType().IsArray) {
      return "[" + string.Join(", ", ((dynamic[])what).Select(i => Utils.ToString(i)).ToList()) + "]";
    } else if (what is Dictionary<string, dynamic>) {
      return "{" + string.Join(", ", ((Dictionary<string, dynamic>)what).Select(i => i.Key + ": " + Utils.ToString(i.Value)).ToList()) + "}";
    } else if (what is string s) {
      return "\"" + s + "\"";
    }

    return what.ToString() ?? "null";
  }

  public static void print(
    object? what,
    [CallerArgumentExpressionAttribute("what")] string? whatExpression = null
  ) {
    GD.PrintS(whatExpression + "=" + Utils.ToString(what));
  }

  public static void print(
    object? what,
    object? what2,
    [CallerArgumentExpressionAttribute("what")] string? whatExpression = null,
    [CallerArgumentExpressionAttribute("what2")] string? what2Expression = null
  ) {
    GD.PrintS(
      whatExpression + "=" + Utils.ToString(what) + ", " +
      what2Expression + "=" + Utils.ToString(what2)
    );
  }

  public static void print(
    object? what,
    object? what2,
    object? what3,
    [CallerArgumentExpressionAttribute("what")] string? whatExpression = null,
    [CallerArgumentExpressionAttribute("what2")] string? what2Expression = null,
    [CallerArgumentExpressionAttribute("what3")] string? what3Expression = null
  ) {
    GD.PrintS(
      whatExpression + "=" + Utils.ToString(what) + ", " +
      what2Expression + "=" + Utils.ToString(what2) + ", " +
      what3Expression + "=" + Utils.ToString(what3)
    );
  }
}