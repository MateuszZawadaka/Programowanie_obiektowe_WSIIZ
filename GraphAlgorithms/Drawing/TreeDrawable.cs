using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;

namespace GraphAlgorithms.Drawing
{
  public class TreeDrawable : IDrawable
  {
    public int[]? Parent { get; set; }
    public int[]? Level { get; set; }
    public int? Highlight { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
      if (Parent == null || Level == null)
        return;

      float nodeRadius = 20;
      float levelHeight = 80;
      float width = dirtyRect.Width;

      var positions = new Dictionary<int, PointF>();
      var levelCount = new Dictionary<int, int>();

      for (int i = 0; i < Level.Length; i++)
      {
        int lvl = Level[i];
        if (!levelCount.ContainsKey(lvl))
          levelCount[lvl] = 0;

        float x = 80 + levelCount[lvl] * 100;
        float y = 60 + lvl * levelHeight;

        positions[i] = new PointF(x, y);
        levelCount[lvl]++;
      }

      // rysuj krawędzie
      canvas.StrokeColor = Colors.Black;
      canvas.StrokeSize = 2;

      for (int i = 0; i < Parent.Length; i++)
      {
        if (Parent[i] != -1)
        {
          var p1 = positions[Parent[i]];
          var p2 = positions[i];
          canvas.DrawLine(p1, p2);
        }
      }

      // rysuj wierzchołki
      foreach (var kv in positions)
      {
        int v = kv.Key;
        var p = kv.Value;

        canvas.FillColor = (Highlight == v)
            ? Colors.Orange
            : Colors.LightBlue;

        canvas.FillCircle(p, nodeRadius);
        canvas.DrawCircle(p, nodeRadius);

        canvas.FontSize = 14;
        canvas.FontColor = Colors.Black;
        canvas.DrawString(
          v.ToString(),
          p.X - nodeRadius,
          p.Y - nodeRadius,
          nodeRadius * 2,
          nodeRadius * 2,
          HorizontalAlignment.Center,
          VerticalAlignment.Center);

      }
    }
  }
}
