using InterviewPrep.Roads;

namespace IntervewPrepTests;

public class RoadNetworkTests
{
    [Test]
    public void GetFourWayIntersectionsTest()
    {
        Road fourtieth = new Road()
        {
            Name = "NE 40th",
            Segments = new List<RoadSegment>()
            {
                new RoadSegment()
                {
                    Name = "NE 40th",
                    Start = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "0"
                    },
                    End = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "1"
                    }
                },
                new RoadSegment()
                {
                    Name = "NE 40th",
                    Start = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "1"
                    },
                    End = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "2"
                    }
                },
                new RoadSegment()
                {
                    Name = "NE 40th",
                    Start = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "2"
                    },
                    End = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "3"
                    }
                },
                new RoadSegment()
                {
                    Name = "NE 40th",
                    Start = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "3"
                    },
                    End = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "4"
                    }
                },
                new RoadSegment()
                {
                    Name = "NE 40th",
                    Start = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "4"
                    },
                    End = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "5"
                    },
                    IsByPass = true
                },
                new RoadSegment()
                {
                    Name = "NE 40th",
                    Start = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "5"
                    },
                    End = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "6"
                    },
                    IsByPass = true
                },
                new RoadSegment()
                {
                    Name = "NE 40th",
                    Start = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "6"
                    },
                    End = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "7"
                    },
                    IsByPass = true
                },
                new RoadSegment()
                {
                    Name = "NE 40th",
                    Start = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "7"
                    },
                    End = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "8"
                    }
                }
            }
        };

        Road onefoureight = new Road()
        {
            Name = "148th Ave NE",
            Segments = new List<RoadSegment>()
            {
                new RoadSegment()
                {
                    Name = "148th Ave NE",
                    Start = new Intersection()
                    {
                        Longitude = "0",
                        Latitude = "1"
                    },
                    End = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "1"
                    },
                },
                new RoadSegment()
                {
                    Name = "148th Ave NE",
                    Start = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "1"
                    },
                    End = new Intersection()
                    {
                        Longitude = "2",
                        Latitude = "1"
                    },
                }
            }
        };
        
        Road onefivezero = new Road()
        {
            Name = "150th Ave NE",
            Segments = new List<RoadSegment>()
            {
                new RoadSegment()
                {
                    Name = "150th Ave NE",
                    Start = new Intersection()
                    {
                        Longitude = "0",
                        Latitude = "2"
                    },
                    End = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "2"
                    },
                },
                new RoadSegment()
                {
                    Name = "150th Ave NE",
                    Start = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "2"
                    },
                    End = new Intersection()
                    {
                        Longitude = "2",
                        Latitude = "2"
                    },
                }
            }
        };
        
        Road onefivesix = new Road()
        {
            Name = "156th Ave NE",
            Segments = new List<RoadSegment>()
            {
                new RoadSegment()
                {
                    Name = "156th Ave NE",
                    Start = new Intersection()
                    {
                        Longitude = "0",
                        Latitude = "7"
                    },
                    End = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "7"
                    },
                },
                new RoadSegment()
                {
                    Name = "156th Ave NE",
                    Start = new Intersection()
                    {
                        Longitude = "1",
                        Latitude = "7"
                    },
                    End = new Intersection()
                    {
                        Longitude = "2",
                        Latitude = "7"
                    },
                }
            }
        };

        RoadNetwork network = new RoadNetwork(new List<Road>()
        {
            fourtieth, onefoureight, onefivezero, onefivesix
        });

        var intersections = network.GetNonByPass4WayIntersections();

        Console.WriteLine(intersections);
    }
}