using JobListingApp.Models;
using JobListingApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Data.Repositories.Interfaces
{
    public interface IJobRepository
    {
        Task<JobToReturnDto> GetJobByJobId(string JobId);
        Task<List<JobToReturnDto>> GetAllJobsAsync();
        Task<bool> CreateJob(Job model);
        Task<bool> RemoveJob(string id);
        Task<UpdatedJobDto> UpdateJobAsync(string jobId, JobToUpdateDto model);
        Task<bool> SaveChanges();
    }
}
