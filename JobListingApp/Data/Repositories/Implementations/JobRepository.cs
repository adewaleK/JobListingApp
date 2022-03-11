using JobListingApp.Data.Repositories.Interfaces;
using JobListingApp.Models;
using JobListingApp.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Data.Repositories.Implementations
{
    public class JobRepository : IJobRepository
    {
        private readonly DataContext _context;
        public JobRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<JobToReturnDto> GetJobByJobId(string JobId)
        {
            return await _context.Jobs.Where(job => job.Id == JobId).Select(job => new JobToReturnDto()
            {

                Id = job.Id,
                JobTitle = job.JobTitle,
                CompanyName = job.CompanyName,
                Location = job.Location,
                MinimumSalary = job.MinimumSalary,
                MaximumSalary = job.MaximumSalary,
                Duration = job.Duration,
                CategoryName = job.Category.CategoryName

            }).FirstOrDefaultAsync();

        }

        public async Task<List<JobToReturnDto>> GetAllJobsAsync()
        {
            return await _context.Jobs.Select(job => new JobToReturnDto() { 
            
               Id = job.Id,
               JobTitle = job.JobTitle,
               CategoryName = job.CompanyName,
               Location = job.Location,
               MinimumSalary = job.MinimumSalary,
               MaximumSalary = job.MaximumSalary,
               Duration = job.Duration,
               CompanyName = job.Category.CategoryName
            
            }).ToListAsync();
           
        }

        public async Task<bool> CreateJob(Job model)
        {
            await _context.Jobs.AddAsync(model);
            return await SaveChanges();
        }

        public async Task<bool> RemoveJob(string id)
        {
            //_context.Jobs.Remove(job);
            //return SaveChanges();
            var jobtodelete = await _context.Jobs.FirstOrDefaultAsync(b => b.Id == id);
            _context.Jobs.Remove(jobtodelete);
            _context.SaveChanges();
            return true;

            //if (jobtodelete == null) 
            //{
            //    return false;
            //}
            //else
            //{
            //    _context.Jobs.Remove(jobtodelete);
            //    _context.SaveChanges();
            //    return true;
            //}
           
        }

        public async Task<UpdatedJobDto> UpdateJobAsync(string jobId, JobToUpdateDto model)
        {
            //_context.Jobs.Update(model);
            //return await SaveChanges();

            var job = await _context.Jobs.Where(b => b.Id == jobId).FirstOrDefaultAsync();

            if (job == null) return null;

            job.JobTitle = model.JobTitle;
            job.CompanyName = model.CompanyName;
            job.Duration = model.Duration;
            job.CategoryId = jobId;
            job.Location = model.Location;
            job.MinimumSalary = model.MinimumSalary;
            job.MaximumSalary = model.MaximumSalary;
            _context.SaveChanges();

            var jobToreturn = new UpdatedJobDto()
            {
                JobTitle = job.JobTitle,
                CompanyName = job.CompanyName,
                Location = job.Location,
                Duration = job.Duration,
                CategoryId = job.CategoryId,
                MinimumSalary = job.MinimumSalary,
                MaximumSalary = job.MaximumSalary,
            };

            return jobToreturn;        
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
