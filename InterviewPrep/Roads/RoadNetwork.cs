namespace InterviewPrep.Roads;

public class RoadNetwork
{
    private List<Road> _roads;

    private Dictionary<string, List<RoadSegment>> _intersections;

    public RoadNetwork(List<Road> Roads)
    {
        _roads = Roads;
    }

    public Dictionary<string, List<RoadSegment>> GetNonByPass4WayIntersections()
    {
        Dictionary<string, List<RoadSegment>> intersections = new Dictionary<string, List<RoadSegment>>();
        foreach (var road in _roads)
        {
            foreach (var segment in road.Segments)
            {
                if (!segment.IsByPass)
                {
                    if (intersections.TryGetValue(segment.Start.CoordinateId, out var startSegments))
                    {
                        intersections[segment.Start.CoordinateId].Add(segment);
                    }
                    else
                    {
                        intersections.Add(segment.Start.CoordinateId, new List<RoadSegment>() { segment });
                    }
                    
                    if (intersections.TryGetValue(segment.End.CoordinateId, out var endSegments))
                    {
                        intersections[segment.End.CoordinateId].Add(segment);
                    }
                    else
                    {
                        intersections.Add(segment.End.CoordinateId, new List<RoadSegment>() { segment });
                    }
                }
            }
        }

        return intersections
            .Where(kvp => kvp.Value.Count() == 4)
            .Where(kvp => kvp.Value.Where(_ => !_.IsByPass).Count() == 0)
            .ToDictionary(kvp =>
                {
                    var roadNames = kvp.Value.Select(_ => _.Name).Distinct().ToArray();
                    return $"{roadNames[0]} and {roadNames[1]}";
                },
                kvp => kvp.Value);
    }
}