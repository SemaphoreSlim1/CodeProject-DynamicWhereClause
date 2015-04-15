using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DynamicWhereWebApi.Controllers
{
    public class PresidentsController : ApiController
    {
        public IHttpActionResult Get(String firstName ="", 
            String lastName = "", 
            String presidentNumber = "", 
            DateTime? startDate = null, 
            DateTime? endDate = null, 
            String termCount = "",
            Boolean? IsAlive = null,
            String searchOperator = "ANY")
        {
            var searchModel = new SearchModel
            {
                FirstName = firstName,
                LastName = lastName,
                PresidentNumber = presidentNumber,
                StartDate = startDate,
                EndDate = endDate, 
                TermCount = termCount,
                SearchOperator = searchOperator
            };

            var presidents = PresidentRepository.GetAllPresidents();

            if (searchModel.HasCriteria())
            {
                presidents = presidents.Where(searchModel.ToExpression());
            }

            return Ok(presidents);
        }
    }
}
