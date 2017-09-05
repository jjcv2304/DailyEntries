using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using DailyEntry.Core.Services;
using DailyEntry.Core.ViewModel;
using DailyEntry.WebAPI.Filters;
using DailyEntry.WebAPI.Services;
using System.Web.Http.Cors;

namespace DailyEntry.WebAPI.Controllers
{
    public class WorkoutTypeController : ApiController
    {

        private readonly IServiceDailyTracker _service;
        private readonly IDailyEntryIdentityService _identityService;

        public WorkoutTypeController(IDailyEntryIdentityService identityService, IServiceDailyTracker service)
        {
            _identityService = identityService;
            _service = service;
        }

        public IHttpActionResult Get()
        {
            var workoutTypes = _service.GetWorkoutTypes();
            return Ok(workoutTypes);
        }
    }
}