using Application.CQRS.Comments.DTOs;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Comments.Commands;

public class AddCommentCommand : IRequest<Result<CommentDto>>
{
    public int PostId { get; set; }
    public string Content { get; set; }
}
