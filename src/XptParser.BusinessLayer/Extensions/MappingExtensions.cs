using XptParser.Domain;
using System.Linq;
using SasXptParser.Abstract;

namespace XptParser.BusinessLayer
{
    internal static class MappingExtensions
    {
        internal static XptLibraryHeader ToXptLibraryHeader(this SasXptLibraryHeaderRecord record)
        {
            return new XptLibraryHeader
            {
                Version = record.Version,
                OperationSystem = record.OperationSystem,
                CreatedDateTime = record.CreatedDateTime,
                LastModifiedDateTime = record.LastModifiedDateTime,
            };
        }

        internal static XptMemberDescriptorHeader ToXptMemberDescriptorHeader(this SasXptMemberDescriptorHeaderRecord record)
        {
            return new XptMemberDescriptorHeader
            {
                Label = record.Label,
                Version = record.Version,
                DataSet = record.DataSet,
                DataSetName = record.DataSetName,
                OperationSystem = record.OperationSystem,
                CreatedDateTime = record.CreatedDateTime,
                ModifiedDateTime = record.ModifiedDateTime,
            };
        }

        internal static XptVariable ToXptVariable(this SasXptVariable variable)
        {
            return new XptVariable
            {
                Label = variable.Label,
                Name = variable.Name
            };
        }

        internal static XptObservation ToXptObservation(this SasXptObservation observation)
        {
            return new XptObservation
            {
                Identifier = observation.Identifier,
                Label = observation.Label,
                Name = observation.Name,
                Value = observation.Value
            };
        }


        internal static XptDocument ToXptDocument(this SasXptDocument document)
        {
            var xptVariables = document.DataRecord.Variables.Select(variable => variable.ToXptVariable()).ToList();
            var xptObservations = document.DataRecord.Observations.Select(observation => observation.ToXptObservation()).ToList();

            return new XptDocument
            {
                LibraryHeader = document.LibraryHeaderRecord.ToXptLibraryHeader(),
                MemberDescriptor = document.MemberDescriptorRecord.ToXptMemberDescriptorHeader(),
                Variables = xptVariables,
                Observations = xptObservations
            };
        }
    }
}