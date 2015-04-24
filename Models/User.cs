using System;

namespace FirstsStepsRUI.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
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
    }

    public enum UserGroup
    {
        Admin,
        Worker
    }
}
