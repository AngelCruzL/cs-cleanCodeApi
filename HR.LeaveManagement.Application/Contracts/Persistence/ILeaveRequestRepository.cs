using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
  Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
  Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetails();
  Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetails(string userId);
}