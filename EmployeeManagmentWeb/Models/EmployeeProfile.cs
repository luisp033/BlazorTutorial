using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagmentModels;

namespace EmployeeManagmentWeb.Models
{
    public class EmployeeProfile :Profile
    {

        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(d => d.ConfirmEmail, o => o.MapFrom(s => s.Email));
                
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}
