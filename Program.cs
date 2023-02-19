using Kaizen_Case2.Models;
using System.Text.Json;

#region Parsing
string receipt = File.ReadAllText(@"./response.json").Trim();
var lines = JsonSerializer.Deserialize<List<Line>>(receipt);
#endregion
string result = "";

#region Normalizing Positions
lines = lines.Where(x => x.locale != "tr").Select(v =>
{

    Vertex avgVert = new Vertex();
    avgVert.x = Convert.ToInt32((v.boundingPoly.vertices[0].x + v.boundingPoly.vertices[1].x + v.boundingPoly.vertices[2].x + v.boundingPoly.vertices[3].x) / 4);
    avgVert.y = Convert.ToInt32((v.boundingPoly.vertices[0].y + v.boundingPoly.vertices[1].y + v.boundingPoly.vertices[2].y + v.boundingPoly.vertices[3].y) / 4);
    v.boundingPoly.avg = avgVert;
    return v;
}).OrderBy(l => l.boundingPoly.avg.y).ThenBy(l => l.boundingPoly.avg.x).ToList();

#endregion

#region Printing
for (int i = 0; i < lines.Count - 1; i++)
{
    var curr = lines[i];
    var next = lines[i + 1];
    var prev_endY = curr.boundingPoly.avg.y;

    var next_endY = next.boundingPoly.avg.y;

    result += i == lines.Count - 2 ? next.description + " " : curr.description + " ";
   
    if (next_endY - prev_endY > 10)
    {
        result += "\n";

    }
    
}

Console.WriteLine(result);
#endregion