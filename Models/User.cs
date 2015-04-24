using System;

namespace FirstsStepsRUI.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Code { get; set; }
        public bool Blocked { get; set; }
        public UserGroup Group { get; set; }

        public User(int id, string code, bool blocked, UserGroup userGroup)
        {
            Id = id;
            Code = code;
            Blocked = blocked;
            Group = userGroup;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", Id, Code);
        }

        public static string GetGroupName(UserGroup group)
        {
            switch (group)
            {
                case UserGroup.Admin:
                    return "Administrator";
                default:
                    return group.ToString();
            }
        }
    }

    public enum UserGroup
    {
        Admin,
        Worker
    }
}
