﻿using Core.Domain;

namespace Core.Application.Common.Interfaces;

public interface ILeaveDistributionRepository : IGenericRepository<LeaveDistribution>
{
    Task<LeaveDistribution> GetLeaveDistributionWithDetails(Guid uid);
    Task<List<LeaveDistribution>> GetLeaveDistributionWithDetails();
    Task<List<LeaveDistribution>> GetLeaveDistributions(Guid userUid);
    Task<bool> DistributionExists(string employeeUid, Guid leaveTypeUid, int period);
    Task AddDistribution(List<LeaveDistribution> leaveDistributions);
    Task<LeaveDistribution> GetUserDistributionsByLeaveTypeId(Guid userUid, int leaveTypeId);
    Task<LeaveDistribution> GetUserDistributionsByLeaveTypeUid(Guid userUid, Guid leaveTypeUid);
}
