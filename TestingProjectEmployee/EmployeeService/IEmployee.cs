using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProjectEmployee.EmployeeService
{
    public interface IEmployee<T>
    {
        IEnumerable<T> GetAll();
        List<T> GetEmp(int id);
        int Add(T t);
        int Delete(int id);
    }
}
