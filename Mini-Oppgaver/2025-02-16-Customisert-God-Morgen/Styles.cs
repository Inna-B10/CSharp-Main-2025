using System;
using System.Drawing;

namespace _2025_02_16_Customisert_God_Morgen;
public class StylesClass
{
  public const string RESET_ALL = "\x1b[0m";
  public const string ITALIC = "\x1B[3m";
  public const string RESET_ITALIC = "\x1B[23m";
  public const string BOLD = "\x1B[1m";
  public const string RESET_BOLD = "\x1B[22m";
  public const string INVERSE = "\x1B[7m";
  public const string RESET_INVERSE = "\x1B[27m";
  public const string ERROR = "\x1B[38;5;196m\x1B[48;5;189m";

  public static string GetColor(string time)
  {
    return time switch
    {
      "morning" => "\x1B[38;5;46m",
      "day" => "\x1B[38;5;21m",
      "evening" => "\x1B[38;5;202m",
      "night" => "\x1B[38;5;55m",
      _ => "\x1B[38;5;16m",
    };
  }
}
