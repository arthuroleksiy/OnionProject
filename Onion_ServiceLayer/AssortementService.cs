using System;
using System.Collections.Generic;
using System.Text;
using Onion_DomainLayer;
using Onion_PersistanceLayer;

namespace Onion_ServiceLayer
{
    /// <summary>
    /// Assortement class with business logic
    /// </summary>
    public class AssortementService
    {
        /// <summary>
        ///  Method that returns supermarket assortment
        /// </summary>
        /// <returns>Collection of <see cref="IItem"/></returns>
        public IEnumerable<IItem> GetAssortement()
        {
            NullReferenceException nullReferenceException = new NullReferenceException("Assortement");

            if (MockAssortementRepsotory.Assortement is null)
                throw nullReferenceException;

            return MockAssortementRepsotory.Assortement;
        }
    }
}
