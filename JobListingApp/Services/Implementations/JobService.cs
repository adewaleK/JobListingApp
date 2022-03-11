using JobListingApp.Data.Repositories.Interfaces;
using JobListingApp.Models;
using JobListingApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Services.Implementations
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;   
        }
        public async Task<JobToReturnDto> AddJob(JobToAddDto model, string categoryId)
        {
            var job = new Job()
            {
                JobTitle = model.JobTitle,
                CompanyName = model.CompanyName,
                Location = model.Location,
                Duration = model.Duration,
                MinimumSalary = model.MinimumSalary,
                MaximumSalary = model.MaximumSalary,
                CategoryId = categoryId
            };

            var createdJob =  await _jobRepository.CreateJob(job);

            var jobToReturn = new JobToReturnDto()
            {
                Id = job.Id,
                JobTitle = job.JobTitle,
                CompanyName = job.CompanyName,
                Location = job.Location,
                Duration = job.Duration,
                MinimumSalary = job.MinimumSalary,
                MaximumSalary = job.MaximumSalary,
            };

            return jobToReturn;

        }

        public  async Task<bool> DeleteJob(string JobId)
        {
           var toDelete = await _jobRepository.RemoveJob(JobId);
           if (!toDelete) return false;
           return true;
        }

        public async Task<List<JobToReturnDto>> GetAllJobsAsync()
        {
            var jobs = await _jobRepository.GetAllJobsAsync();

            if (jobs == null) return null;
            return (jobs);
        }

        public async Task<JobToReturnDto> GetJobByIdAsync(string jobId)
        {
            var job =  await _jobRepository.GetJobByJobId(jobId);
            if (job == null) return null;
            return job;
        }

        public async Task<UpdatedJobDto> UpdateJobAsync(JobToUpdateDto model, string jobId)
        {
            var jobUpdate = await _jobRepository.UpdateJobAsync(jobId, model);
            if (jobUpdate == null) return null;

            return jobUpdate;
             
        }
    }
}
