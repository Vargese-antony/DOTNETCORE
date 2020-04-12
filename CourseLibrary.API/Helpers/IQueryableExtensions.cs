using CourseLibrary.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace CourseLibrary.API.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySort<T>( this IQueryable<T> source, 
            string orderBy, 
            Dictionary<string, PropertyMappingValue> mappingDictionary )
        {
            if(source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if(mappingDictionary == null)
            {
                throw new ArgumentNullException(nameof(mappingDictionary));
            }

            if(string.IsNullOrWhiteSpace(orderBy))
            {
                return source;
            }
            var orderByString = string.Empty;

            var orderByAfterSplit = orderBy.Split(",");

            foreach (var orderByClause in orderByAfterSplit.Reverse())
            {
                var trimmedOrderByClause = orderByClause.Trim();

                var orderDescending = trimmedOrderByClause.EndsWith("desc");

                var indexOfFirstSpace = trimmedOrderByClause.IndexOf(" ");
                var propertName = indexOfFirstSpace == -1 ? trimmedOrderByClause : trimmedOrderByClause.Remove(indexOfFirstSpace);

                if(!mappingDictionary.ContainsKey(propertName))
                {
                    throw new ArgumentException($"Key mapping for {propertName} not found");
                }
                var propertyMappingValue = mappingDictionary[propertName];
                if(propertyMappingValue == null)
                {
                    throw new ArgumentNullException("propertymapping value");
                }

                foreach (var destinationProperty in propertyMappingValue.DestinatioProperties)
                {
                    if(propertyMappingValue.Revert)
                    {
                        orderDescending = !orderDescending;
                    }

                    orderByString = orderByString +
                        (string.IsNullOrWhiteSpace(orderByString) ? string.Empty : ", ")
                        + destinationProperty
                        + (orderDescending ? " descending" : " ascending");
                }
            }
            return source.OrderBy(orderByString);
        }
    }
}
