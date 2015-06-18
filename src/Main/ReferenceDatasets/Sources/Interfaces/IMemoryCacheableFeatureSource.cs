using USC.GISResearchLab.Common.Core.Geocoders.FeatureMatching;

namespace USC.GISResearchLab.Common.Geocoders.ReferenceDatasets.Sources.Interfaces
{
    public interface IMemoryCacheableFeatureSource
    {
        void AddToFeatureCache(string sql, MatchedFeature geometry);
        MatchedFeature GetFromFeatureCache(string sql);
    }
}
