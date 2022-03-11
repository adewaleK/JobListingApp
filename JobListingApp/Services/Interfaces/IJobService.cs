using JobListingApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Services
{
    public interface IJobService
    {
        Task<JobToReturnDto> AddJob(JobToAddDto model, string categoryId);
        Task<JobToReturnDto> GetJobByIdAsync(string categoryId);
        Task<List<JobToReturnDto>> GetAllJobsAsync();
        Task<bool> DeleteJob(string JobId);
        Task<UpdatedJobDto> UpdateJobAsync(JobToUpdateDto model, string jobId);
    }
}
