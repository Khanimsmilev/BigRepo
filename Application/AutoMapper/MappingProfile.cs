using Application.CQRS.Messages.Commands;
using Application.CQRS.Messages.DTOs;
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

        //message
        CreateMap<CreateMessageCommand, Message>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => false))
            .ReverseMap();

        CreateMap<Message, MessageResponseDto>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToString("yyyy-MM-dd HH:mm"))).ReverseMap();
        
        CreateMap<CreateMessageDto, Message>()
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())  
            .ForMember(dest => dest.IsRead, opt => opt.Ignore()) 
            .ReverseMap();

    }
}