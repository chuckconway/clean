using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Clean.Common.Data.Ordering;

namespace Clean.Common.Data.Specifications
{
    public class DataSpecification<TType> : IDataSpecification<TType> where TType : class
    {
        /// <summary>
        /// The collection of filters for the specification
        /// </summary>
        public IList<Expression<Func<TType, bool>>> Filters { get; } = new List<Expression<Func<TType, bool>>>();

        /// <summary>
        /// The order direction for the specification
        /// </summary>
        public IList<IOrderBy<TType>> Orders { get; } = new List<IOrderBy<TType>>();


        /// <summary>
        /// Set the Where condition.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public DataSpecification<TType> Where(Expression<Func<TType, bool>> filter)
        {
            Filters.Add(filter);
            return this;
        }

        /// <summary>
        /// Set additional conditions to the specification.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public DataSpecification<TType> And(Expression<Func<TType, bool>> filter)
        {
            return Where(filter);
        }

        /// <summary>
        /// Set the Ascending order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSpecification<TType> Ascending(Expression<Func<TType, object>> order)
        {
            Orders.Add(new Ascending<TType>
            {
                Order = order
            });

            return this;
        }

        /// <summary>
        /// Set the Descending order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSpecification<TType> Descending(Expression<Func<TType, object>> order)
        {
            Orders.Add(new Descending<TType>
            {
                Order = order
            });

            return this;
        }
    }
}