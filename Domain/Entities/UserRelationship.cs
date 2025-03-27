using Domain.Abstraction;
using Domain.Enums;

namespace Domain.Entities
{
    public class UserRelationship : BaseEntity
    {

        public int RequesterId { get; set; } // elaqeni yaradan
        public User Requester { get; set; }

        public int ReceiverId { get; set; } // elaqeni qebul eden
        public User Receiver { get; set; }

        public RelationshipStatus Status { get; set; } // Follow, Pending, Connected, Blocked ...

    }

}
