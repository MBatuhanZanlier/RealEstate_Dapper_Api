﻿namespace RealEstate_Dapper_UI.Dtos.EmployeeDtos
{
    public class CreateEmployeeDto
    {
        
        public string EmployeeName { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string EmployeeImageUrl { get; set; }
        public bool EmployeeStatus { get; set; }
    }
}