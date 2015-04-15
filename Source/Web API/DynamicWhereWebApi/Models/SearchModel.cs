using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Extensions;
using Common;
using System.Reflection;

namespace DynamicWhereWebApi
{
    public class SearchModel
    {    
        [SearchCriteria]
        public String FirstName { get; set; }

        [SearchCriteria]
        public String LastName { get; set; }

        [SearchCriteria]
        public String PresidentNumber { get; set; }

        [SearchCriteria]
        public Nullable<DateTime> StartDate { get; set; }

        [SearchCriteria]
        public Nullable<DateTime> EndDate { get; set; }

        [SearchCriteria]
        public String TermCount { get; set; }

        [SearchCriteria]
        public Nullable<Boolean> Alive { get; set; }
        
        public String SearchOperator { get; set; }

        public Expression<Func<Model.President, Boolean>> ToExpression()
        {
            Expression<Func<Model.President, Boolean>> result = null;

            int presidentNumberIntValue = 0;
            if(PresidentNumber.HasValue() && Int32.TryParse(PresidentNumber, out presidentNumberIntValue) && presidentNumberIntValue > 0)
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.PresidentNumber == presidentNumberIntValue;
                result = AppendExpression(result, expr);
            }

            if (FirstName.HasValue())
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.FirstName.Like(FirstName);
                result = AppendExpression(result, expr);
            }

            if (LastName.HasValue())
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.LastName.Like(LastName);
                result = AppendExpression(result, expr);
            }

            if (StartDate.HasValue)
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.TookOffice >= StartDate;
                result = AppendExpression(result, expr);
            }

            if (EndDate.HasValue)
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.LeftOffice <= EndDate;
                result = AppendExpression(result, expr);
            }

            if(Alive.HasValue)
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.IsAlive == Alive;
                result = AppendExpression(result, expr);
            }

            var termCounntIntValue = 0;
            if (TermCount.HasValue() && Int32.TryParse(TermCount, out termCounntIntValue) && termCounntIntValue > 0)
            {
                Expression<Func<Model.President, Boolean>> expr = model => model.Terms.Count() == termCounntIntValue;
                result = AppendExpression(result, expr);
            }

            return result;
        }

        /// <summary>
        /// Returns true, if this view model has criteria to search against
        /// </summary>        
        public Boolean HasCriteria()
        {
            //get the properites of this object
            var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            var searchProperties = properties.Where(p => p.CustomAttributes.Select(a => a.AttributeType).Contains(typeof(SearchCriteriaAttribute)));

            return searchProperties.Where(sp => sp.GetValue(this).ToStringInstance().HasValue()).Any();
        }

        private Expression<Func<Model.President, Boolean>> AppendExpression(Expression<Func<Model.President, Boolean>> left, Expression<Func<Model.President, Boolean>> right)
        {
            Expression<Func<Model.President, Boolean>> result;

            switch (SearchOperator)
            {
                case "ANY":

                    //the initial case starts off with a left epxression as null. If that's the case,
                    //then give the short-circuit operator something to trigger on for the right expression
                    if (left == null)
                    { left = model => false; }

                    result = ExpressionExtension<Model.President>.OrElse(left, right);
                    break;
                case "ALL":

                    if (left == null)
                    { left = model => true; }

                    result = ExpressionExtension<Model.President>.AndAlso(left, right);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return result;

        }
    }
}