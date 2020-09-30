using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagmentModels;
using EmployeeManagmentWeb.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagmentWeb.Pages
{
    public class DisplayEmployeeBase:ComponentBase
    {

        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }

        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        //[Inject]
        //public NavigationManager NavigationManager { get; set; }

        protected UtilComponents.ConfirmBase DeleteConfirmation { get; set; }
        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }


        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {

            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);

                // Callback para a página mãe fazer o refresh
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
                //NavigationManager.NavigateTo("/", true);
            }

        }

    }
}
