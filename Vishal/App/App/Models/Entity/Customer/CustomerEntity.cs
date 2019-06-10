using App.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace App.Models.Entity.Customer
{

    public class CustomerEntity
    {
        public CustomerEntity()
        {
            this.countryList = new List<SelectListItem>();
            this.stateList = new List<SelectListItem>();
            this.cityList = new List<SelectListItem>();
        }
        public int customerId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "CustomerNameReq")]
        [Display(ResourceType = typeof(Labels), Name = "CustomerNameLbl")]
        public string customerName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "EmailAddressReq")]
        [Display(ResourceType = typeof(Labels), Name = "EmailLbl")]
        public string emailAddress { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "PhoneNoReq")]
        [Display(ResourceType = typeof(Labels), Name = "PhoneLbl")]
        public string phoneNo { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "MobileLbl")]
        public string mobileNo { get; set; }
        public List<SelectListItem> countryList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "CountryReq")]
        [Display(ResourceType = typeof(Labels), Name = "CountryLbl")]
        public string countryId { get; set; }
        public string countryName { get; set; }
        public List<SelectListItem> stateList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "StateReq")]
        [Display(ResourceType = typeof(Labels), Name = "StateLbl")]
        public string stateId { get; set; }
        public string stateName { get; set; }
        public List<SelectListItem> cityList { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "CityReq")]
        [Display(ResourceType = typeof(Labels), Name = "CityLbl")]
        public string cityId { get; set; }
        public string cityName { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "AddressReq")]
        [Display(ResourceType = typeof(Labels), Name = "AddressLbl")]
        public string address { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMsg), ErrorMessageResourceName = "PincodeReq")]
        [Display(ResourceType = typeof(Labels), Name = "PincodeLbl")]
        public string pincode { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "WebsiteLbl")]
        public string website { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "FaxLbl")]
        public string faxNo { get; set; }
        public string status { get; set; }
        public string operType { get; set; }
        public string userId { get; set; }
        public int reportId { get; set; }
    }
}