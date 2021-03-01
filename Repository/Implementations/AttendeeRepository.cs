using MomentumRegistrationApi.Entities;
using MomentumRegistrationApi.Settings;

namespace MomentumRegistrationApi.Repository.Implementations
{
    public interface IAttendeeRepository : IRepository<AttendeeRegistration>
    {
        
    }
    public class AttendeeRepository:Repository<AttendeeRegistration>,IAttendeeRepository
    {
        public AttendeeRepository(ICustomMongoClient mongoClient) : base(mongoClient) { }
    }
}