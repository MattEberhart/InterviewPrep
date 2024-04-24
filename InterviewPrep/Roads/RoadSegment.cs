namespace InterviewPrep.Roads;

public class RoadSegment
{
    public string Name { get; set; }

    public Intersection Start { get; set; }

    public Intersection End { get; set; }

    public bool IsByPass { get; set; } = false;
}