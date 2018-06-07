using System;
using System.Collections.Generic;
using GameModel.StarSystem;

namespace ConverterTools
{
    public class ColonyReportReader : FileReader
    {
        public IEnumerable<Colony> ReadColonies()
        {
            var colonies = new List<Colony>();
            Colony current = null;
            foreach (var line in Lines)
                if (line.StartsWith("Colony:"))
                {
                    current.ColonyID = int.Parse(line.Substring(8));
                }
                else if (current != null)
                {
                    if (line.StartsWith("world id  :"))
                        current.PlanetID = int.Parse(line.Substring(12));
                    if (line.StartsWith("system    :"))
                        current.SystemID = int.Parse(line.Substring(12));
                    if (line.StartsWith("race      :"))
                        current.FounderID = int.Parse(line.Substring(12));
                    if (line.StartsWith("Moon base:"))
                        current.MoonID = int.Parse(line.Substring(11));
                    try
                    {
                        if (line.StartsWith("allegiance:"))
                            current.AllegianceID = int.Parse(line.Substring(12));
                    }
                    catch (Exception)
                    {
                        current.AllegianceID = null;
                    }
                }

            return colonies;
        }
    }
}