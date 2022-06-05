using Heyscot_DataAccess;
using Heyscot_DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static Heyscot_DataAccess.Enums.Enums;

namespace heyscot_blazor.Data
{
    public class MatchTalentService
    {
        private readonly MatchCustomerTalent matchTalents;
        private readonly string connectionString = "Server=localhost;Database=heyscot;Uid=root;Pwd=123@a123;";

        public MatchTalentService()
        {
            matchTalents = new MatchCustomerTalent(connectionString);
        }

        public async Task<CustomerTalents> FetchMatchesAsync(int selectedItem)
        {
            try
            {
                string selectedItemText = Enum.GetName(typeof(DropDownList), selectedItem);
                var customerTalents = matchTalents.GetCustomerTalents(selectedItemText);

                return await Task.FromResult(customerTalents);
            }
            catch
            {
                CustomerTalents customerTalents = new CustomerTalents();
                return await Task.FromResult(customerTalents);
            }
        }

        public List<SelectListItem> GetDropdownData()
        {
            try
            {
                List<SelectListItem> dropdown = Enum.GetValues(typeof(DropDownList)).Cast<DropDownList>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                }).ToList();

                return dropdown;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
