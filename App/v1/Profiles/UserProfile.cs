using App.v1.DTOs.Auth.Login;
using App.v1.DTOs.User;
using App.v1.DTOs.User.Edit;
using App.v1.Models;
using AutoMapper;

namespace App.v1.Profiles;

public class UserProfile : Profile{
    public UserProfile()
    {
        CreateMap<LoginDTORequest, User>();
        CreateMap<CreateUserDTO, User>();
        CreateMap<EditUserRequest, User>();
    }
}