using App.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Models.Entity.Employee
{
    public class EmployeeEntity
    {
        public EmployeeEntity()
        {
            this.genderList = new List<SelectListItem>();
            this.empTypeList = new List<SelectListItem>();
            this.desigList = new List<SelectListItem>();
            this.specializationList = new List<SelectListItem>();
            this.deptList = new List<SelectListItem>();
            this.jobTypeList = new List<SelectListItem>();
            this.maritalStatusList = new List<SelectListItem>();
            this.religionList = new List<SelectListItem>();
            this.bgList = new List<SelectListItem>();
            this.countryList = new List<SelectListItem>();
            this.stateList = new List<SelectListItem>();
            this.cityList = new List<SelectListItem>();
            this.bankNameList = new List<SelectListItem>();
            this.branchList = new List<SelectListItem>();
        }
        public string empId { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "EmployeeNameReq")]
        [Display(ResourceType = typeof(Labels), Name = "EmployeeNameLbl")]
        public string empName { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "FatherNameReq")]
        [Display(ResourceType = typeof(Labels), Name = "FatherNameLbl")]
        public string fatherName { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "GenderReq")]
        [Display(ResourceType = typeof(Labels), Name = "GenderLbl")]
        public string genderId { get; set; }
        public string genderName { get; set; }
        public List<SelectListItem> genderList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "DOBReq")]
        [Display(ResourceType = typeof(Labels), Name = "DOBLbl")]
        public string dob { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "DOJReq")]
        [Display(ResourceType = typeof(Labels), Name = "DOJLbl")]
        public string doj { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "EmpTypeReq")]
        [Display(ResourceType = typeof(Labels), Name = "EmpTypeLbl")]
        public string empTypeId { get; set; }
        public string empTypeName { get; set; }
        public List<SelectListItem> empTypeList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "DesignationReq")]
        [Display(ResourceType = typeof(Labels), Name = "DesignationLbl")]
        public string desigid { get; set; }
        public string desigName { get; set; }
        public List<SelectListItem> desigList { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "ExpLbl")]
        public int exp { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "SpecializationLbl")]
        public string specializationId { get; set; }
        public string specializationName { get; set; }
        public List<SelectListItem> specializationList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "DeptReq")]
        [Display(ResourceType = typeof(Labels), Name = "DeptLbl")]
        public string deptId { get; set; }
        public string deptName { get; set; }
        public List<SelectListItem> deptList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "JobTypeReq")]
        [Display(ResourceType = typeof(Labels), Name = "JobTypeLbl")]
        public string jobTypeId { get; set; }
        public string jobTypeName { get; set; }
        public List<SelectListItem> jobTypeList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "MaritalStatusReq")]
        [Display(ResourceType = typeof(Labels), Name = "MaritalStatusLbl")]
        public string marialStatusId { get; set; }
        public string maritalStatusName { get; set; }
        public List<SelectListItem> maritalStatusList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "ReligionReq")]
        [Display(ResourceType = typeof(Labels), Name = "ReligionLbl")]
        public string religionId { get; set; }
        public string religionName { get; set; }
        public List<SelectListItem> religionList { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "BloodGroupLbl")]
        public string bgId { get; set; }
        public string bgName { get; set; }
        public List<SelectListItem> bgList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "MobileNoReq")]
        [Display(ResourceType = typeof(Labels), Name = "MobileLbl")]
        public string mobileNo { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "InstitutionLbl")]
        public string institutionName { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "DesignationLbl")]
        public string designation { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "PhoneLbl")]
        public string phoneNo { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "HouseNoReq")]
        [Display(ResourceType = typeof(Labels), Name = "HouseNoLbl")]
        public string houseNo { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "TownReq")]
        [Display(ResourceType = typeof(Labels), Name = "TownLbl")]
        public string town { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "DistrictLbl")]
        public string district { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "CountryReq")]
        [Display(ResourceType = typeof(Labels), Name = "CountryLbl")]
        public string countryId { get; set; }
        public string countryName { get; set; }
        public List<SelectListItem> countryList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "StateReq")]
        [Display(ResourceType = typeof(Labels), Name = "StateLbl")]
        public string stateId { get; set; }
        public string stateName { get; set; }
        public List<SelectListItem> stateList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "CityReq")]
        [Display(ResourceType = typeof(Labels), Name = "CityLbl")]
        public string cityId { get; set; }
        public string cityName { get; set; }
        public List<SelectListItem> cityList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "PincodeReq")]
        [Display(ResourceType = typeof(Labels), Name = "PincodeLbl")]
        public string pincode { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "QualificationLbl")]
        public string qualification { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "YearOfPassingLbl")]
        public string yearOfPassing { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "CollegeNameLbl")]
        public string college { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "PercentageLbl")]
        public string percentage { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "PanNoLbl")]
        public string panNo { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "BankAccountNoReq")]
        [Display(ResourceType = typeof(Labels), Name = "BankAccountNoLbl")]
        public string bankAccountNo { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "PfNoLbl")]
        public string pfNo { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "EsiNoLbl")]
        public string esiNo { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "DrivingLicenseLbl")]
        public string drivingLicense { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "BankNameReq")]
        [Display(ResourceType = typeof(Labels), Name = "BankNameLbl")]
        public string bankId { get; set; }
        public string bankName { get; set; }
        public List<SelectListItem> bankNameList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "BranchNameReq")]
        [Display(ResourceType = typeof(Labels), Name = "BranchNameLbl")]
        public string branchId { get; set; }
        public string branchName { get; set; }
        public List<SelectListItem> branchList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "IFSCReq")]
        [Display(ResourceType = typeof(Labels), Name = "IFSCLbl")]
        public string ifscCode { get; set; }
        public string operType { get; set; }
        public string status { get; set; }
    }
}