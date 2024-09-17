using Microsoft.EntityFrameworkCore;
using Project.DataBase;
using Project.Filters.StudentFilters;
using Project.Models;

namespace Project.Interfaces.StudenstInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);

        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken);

        public Task<Student[]> GetDeletedStudentsAsync(StudentDeleteFilter filter, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbCotext _dbContext;
        public StudentService(StudentDbCotext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return students;
        }

        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.FirstName == filter.Name).ToArrayAsync(cancellationToken);

            return students;
        }

        public Task<Student[]> GetDeletedStudentsAsync(StudentDeleteFilter filter, CancellationToken cancellationToken)
        {
            var students = _dbContext.Set<Student>().Where(w => w.IsDeleted == filter.IsDelete).ToArrayAsync(cancellationToken);

            return students;
        }
    }
}
