using JobListingApp.Models.DTOs;
using JobListingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet("get-job/{jobId}")]
        public async Task<IActionResult> GetJobById(string jobId)
        {
            var job = await  _jobService.GetJobByIdAsync(jobId);

            if (job == null) return NotFound("no job found with that Id");

            return Ok(job);
        }

        [HttpGet("get-jobs")]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();

            if (jobs == null) return NotFound("no jobs found");

            return Ok(jobs);
        }

        [HttpPost("create-job")]

        public async Task<IActionResult> CreateJob([FromBody] JobToAddDto model, string categoryId)
        {
          
            if (!ModelState.IsValid)
                return BadRequest("Invalid valid");
            var response = await _jobService.AddJob(model, categoryId);
            if (response == null)
            {
                return BadRequest("Article failed to Add");
            }
            return Ok(response);
        }


        [HttpPut("update-job")]
        public async Task<IActionResult> UpdateJob([FromBody] JobToUpdateDto model, [FromRoute] string jobId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await _jobService.UpdateJobAsync(model, jobId);
            if (response == null)
            {
                return BadRequest("Job could not be updated.");
            }
            return Ok("Job has been successfully updated");
        }

        [HttpDelete("delete-job")]

        public async Task<IActionResult> DeleteJob([FromQuery] string jobId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            var isDeleted = await _jobService.DeleteJob(jobId);
            if (!isDeleted)
            {   
                return BadRequest("Category not Deleted");
            }
            return Ok("Category Successfully Deleted");

        }
    }
}
