﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AptiSummit.Api.Controllers.Values
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// List of values in the system. 20 items a page.
        /// </summary>
        /// <param name="index">(optional) first item to retrieve in response.</param>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ValuesListViewModel), 200)]
        public IActionResult Get(int? index)
        {
            var model = ValuesListViewModel.Create(FakeValues.Instance.Values, index.GetValueOrDefault(), 20);
            return Ok(model);
        }

        /// <summary>
        /// Specific value 
        /// </summary>
        /// <param name="id">values id</param>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ValueItemViewModel), 200)]
        [ProducesResponseType(typeof(ILinkItem), 404)]
        public IActionResult Get(int id)
        {
            var model = ValueItemViewModel.Create(FakeValues.Instance.Values.FirstOrDefault(x => x.Id == id));

            if (model == null)
                return NotFound(new LinkItem
                {
                    Rel = "values",
                    Href = "/api/values",
                    Description = "List of values in the system",
                });

            return Ok(model);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
