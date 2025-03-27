using Application.CQRS.Posts.Commands;
using Application.CQRS.Posts.DTOs;
using Application.CQRS.Users.Commands;
using Application.CQRS.Users.DTOs;
using AutoMapper;
using Domain.Entities;


namespace Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //user
        CreateMap<User, GetUserByEmailResponse>().ReverseMap();
        CreateMap<CreateUserCommand, User>().ReverseMap();
        CreateMap<UpdateUserCommand, User>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>();

        //post
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<CreatePostCommand, Post>().ReverseMap();
        CreateMap<UpdatePostCommand, Post>().ReverseMap();
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
    }
}