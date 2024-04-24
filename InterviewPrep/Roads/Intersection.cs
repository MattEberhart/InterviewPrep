namespace InterviewPrep.Roads;

public class Intersection
{
    public string CoordinateId => $"{Longitude}_{Latitude}";
    

    public string Longitude { get; set; }

    public string Latitude { get; set; }
}