﻿
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.Ordre;
using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Users
{
    public class BrukerFullViewModel
    {
        public BrukerFullViewModel()
        {
            UpsertModel = new UserViewModel();
            BrukerList = new List<UserViewModel>();
        }
        public UserViewModel UpsertModel { get; set; }
        public List<UserViewModel> BrukerList { get; set; }

    }


    public class UserViewModel
    {
        public UserViewModel()
        {
            BrukerList = new List<UserEntity>();
        }
        public int Id { get; set; }
        public string? Fornavn { get; set; }
        public string? Etternavn { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public List<UserEntity> User { get; set; }
        public List<UserEntity> BrukerList { get; set; }
    }
}


