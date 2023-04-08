using FileDBSerializing.ObjectSerializer;
using StampDataModel;

using (var fs = File.OpenRead("stamp.filedb"))
{
    var newstamp = FileDBConvert.DeserializeObject<Stamp>(fs, new FileDBSerializerOptions()
    {
        IgnoreMissingProperties = true
    });

    int i = 0; 
}

var streetEntries = new List<StreetPoint>
{
    new StreetPoint(1, 5),
    new StreetPoint(5, 3)
};
var stamp = new Stamp()
{
    StampPath = 5000001,
    IconGUID = 101325,
    BuildingInfo = new List<Building>()
    {
        new Building() {
            Pos = new float[2]{ 5, 3 },
            Dir = 1.4f, 
            GUID = 1337
        },
        new Building() {
            Pos = new float[2]{ 9, 2 },
            Dir = 1.4f,
            GUID = 1337
        }
    },
    StreetInfo = new()
    {
        (101308, streetEntries)
    },
    StreetCount = 5,
    RailwayInfos = new List<RailwaySegment>()
    { 
        new RailwaySegment(1,5,2,6),
        new RailwaySegment(9,9,5,3),
        new RailwaySegment(9,11,9,11)
    },

};

using (var fs = File.Create("stamp"))
{
    FileDBConvert.SerializeObject(stamp, new FileDBSerializerOptions()).CopyTo(fs);

}

    