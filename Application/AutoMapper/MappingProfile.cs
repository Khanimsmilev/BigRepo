using Application.CQRS.Comments.Commands;
using Application.CQRS.Comments.DTOs;
using Application.CQRS.Likes.Command;
using Application.CQRS.Likes.DTOs;
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
        // User
        CreateMap<User, GetUserByEmailResponse>().ReverseMap();
        CreateMap<CreateUserCommand, User>().ReverseMap();
        CreateMap<UpdateUserCommand, User>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>();
        CreateMap<User, UserDto>();

        // Post
        CreateMap<Post, PostDto>()
            .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
            .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.Comments.Count))
            .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.Likes.Count))
            .ForMember(dest => dest.IsLikedByCurrentUser, opt => opt.Ignore());

        CreateMap<AddPostCommand, Post>();
        CreateMap<UpdatePostCommand, Post>();

        // Comment
        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));

        CreateMap<AddCommentCommand, Comment>();

        // Like
        CreateMap<Like, LikeDto>()
            .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));

        CreateMap<AddLikeCommand, Like>();



        //message
/*        CreateMap<CreateMessageCommand, Message>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => false))
            .ReverseMap();

        CreateMap<Message, MessageResponseDto>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToString("yyyy-MM-dd HH:mm"))).ReverseMap();

        CreateMap<CreateMessageDto, Message>()
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.IsRead, opt => opt.Ignore())
            .ReverseMap();*/
    }
}