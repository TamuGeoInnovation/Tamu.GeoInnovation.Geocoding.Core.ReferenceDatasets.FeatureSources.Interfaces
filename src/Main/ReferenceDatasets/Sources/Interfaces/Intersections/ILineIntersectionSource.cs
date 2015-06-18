using USC.GISResearchLab.Common.Geometries;

namespace USC.GISResearchLab.Common.Geocoders.ReferenceDatasets.Sources.Interfaces.Intersections
{
    public interface ILineIntersectionSource
    {
        Geometry[] GetIntersectingLines(double lat, double lon, string state);
    }
}
