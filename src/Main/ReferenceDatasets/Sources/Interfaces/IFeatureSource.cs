using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using USC.GISResearchLab.Common.Addresses;
using USC.GISResearchLab.Common.Core.Geocoders.FeatureMatching;
using USC.GISResearchLab.Common.Core.Maths.NumericStrings;
using USC.GISResearchLab.Common.Geographics.Units;
using USC.GISResearchLab.Geocoding.Core.Algorithms.FeatureInterpolationMethods.Interfaces;
using USC.GISResearchLab.Geocoding.Core.Algorithms.FeatureMatchingMethods;
using USC.GISResearchLab.Geocoding.Core.Algorithms.FeatureMatchScorers;
using USC.GISResearchLab.Geocoding.Core.Configurations;
using USC.GISResearchLab.Geocoding.Core.Metadata.FeatureMatchingResults;
using USC.GISResearchLab.Geocoding.Core.Metadata.Qualities;
using USC.GISResearchLab.Geocoding.Core.Queries.Parameters;
using USC.GISResearchLab.Geocoding.Core.ReferenceDatasets.ReferenceFeatures;
using USC.GISResearchLab.Geocoding.Core.ReferenceDatasets.ReferenceFeatureSets;
using USC.GISResearchLab.Geocoding.Core.ReferenceDatasets.ReferenceSourceQueries;

namespace USC.GISResearchLab.Common.Core.Geocoders.ReferenceDatasets.Sources.Interfaces
{
    public interface IFeatureSource : IDisposable, ICloneable
    {
        TraceSource TraceSource { get; set; }
        int Reads { get; set; }

        int Hits { get; set; }
        int Misses { get; set; }

        bool HasCoverageRestrictions { get; set; }
        string[] CoverageRestrictionsAllowable { get; set; }
        string[] CoverageRestrictionsNotAllowable { get; set; }
        string CoverageRestrictionsString { get; }

        bool IsRelaxable { get; }
        bool IsFuzzyable { get; }
        bool IsCacheable { get; }
        bool IsSoundexable { get; }

        string Name { get; set; }
        string Description { get; set; }
        string Vintage { get; set; }
        string ShortName { get; set; }
        string IdFieldNamePrimary { get; set; }
        string IdFieldNameSecondary { get; set; }
        AttributeWeightingScheme AttributeWeightingScheme { get; set; }

        Unit CoordinateUnits { get; set; }
        //List<ReferenceSourceQuery> ReferenceSourceQueries { get; set; }
        AddressComponents[] RequiredAddressComponents { get; }
        AddressComponents AddressComponent { get; set; }
        string RequiredAddressComponentsString { get; }

        List<IInterpolationMethod> InterpolationMethods { get; set; }

        GeocodeQualityType geocodeQualityType { get; set; }
        FeatureMatchingGeographyType FeatureMatchingGeographyType { get; set; }
        ReferenceFeatureType ReferenceFeatureType { get; set; }
        NumericStringManager NumericStringManager { get; set; }

        AddressFormatType AddressFormatType { get; set; }

        bool ValidateParameters(StreetAddress address, bool shouldThrowException);
        bool ValidateCoverageRestrictions(StreetAddress address, bool shouldThrowException);

        ReferenceSourceQueryResultSet GetFeaturesWithScoring(ParameterSet parameterSet, GeocoderConfiguration geocoderConfiguration);
        FeatureMatchingResult DoFeatureMatching(ParameterSet parameterSet, GeocoderConfiguration geocoderConfiguration);

        ReferenceSourceQueryResultSet GetFeatures(ParameterSet parameterSet, GeocoderConfiguration geocoderConfiguration, ReferenceSourceQuery[] referenceSourceQueries);

        ReferenceFeatureSet GetFeaturesFromRawDataRow(ParameterSet parameterSet, GeocoderConfiguration geocoderConfiguration, StreetAddress address, DataRow dataRow);
        MatchedFeature GetMatchedFeatureFromReferenceFeature(StreetAddress address, IReferenceFeature referenceFeature);

        void AddInterpolationMethod(IInterpolationMethod interpolationMethod);

        //void AddReferenceSourceQuery(ReferenceSourceQuery referenceSourceQuery);

        void Hit();
        void Miss();
        void Read();
    }
}
