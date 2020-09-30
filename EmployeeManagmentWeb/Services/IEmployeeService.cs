﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagmentModels;

namespace EmployeeManagmentWeb.Services
{
    public interface IEmployeeService
    {

        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int id);

        Task<Employee> UpdateEmployee(Employee updatedEmployee);

        Task<Employee> CreateEmployee(Employee newEmployee);

        Task DeleteEmployee(int id);
    }
}
