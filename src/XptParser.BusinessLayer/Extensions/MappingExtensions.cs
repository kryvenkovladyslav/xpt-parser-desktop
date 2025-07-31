using XptParser.Domain;
using System.Linq;
using SasXptParser.Abstract;

namespace XptParser.BusinessLayer
{
    /// <summary>
    /// Provides extension methods for mapping SAS XPT records to business-layer domain models
    /// </summary>
    internal static class MappingExtensions
    {
        /// <summary>
        /// Maps a <see cref="SasXptLibraryHeaderRecord"/> to a <see cref="XptLibraryHeader"/>
        /// </summary>
        /// <param name="record">The source library header record</param>
        /// <returns>The mapped <see cref="XptLibraryHeader"/></returns>
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

        /// <summary>
        /// Maps a <see cref="SasXptMemberDescriptorHeaderRecord"/> to a <see cref="XptMemberDescriptorHeader"/>
        /// </summary>
        /// <param name="record">The source member descriptor header record</param>
        /// <returns>The mapped <see cref="XptMemberDescriptorHeader"/></returns>
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

        /// <summary>
        /// Maps a <see cref="SasXptVariable"/> to a <see cref="XptVariable"/>
        /// </summary>
        /// <param name="variable">The source variable</param>
        /// <returns>The mapped <see cref="XptVariable"/></returns>
        internal static XptVariable ToXptVariable(this SasXptVariable variable)
        {
            return new XptVariable
            {
                Label = variable.Label,
                Name = variable.Name
            };
        }

        /// <summary>
        /// Maps a <see cref="SasXptObservation"/> to a <see cref="XptObservation"/>
        /// </summary>
        /// <param name="observation">The source observation</param>
        /// <returns>The mapped <see cref="XptObservation"/></returns>
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

        /// <summary>
        /// Maps a <see cref="SasXptDocument"/> to a <see cref="XptDocument"/>, including its header, descriptor, variables, and observations
        /// </summary>
        /// <param name="document">The source SAS XPT document</param>
        /// <returns>The mapped <see cref="XptDocument"/></returns>
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