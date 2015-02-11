using System;

namespace FirstsStepsRUI.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public bool Active { get; private set; }
        public UserGroup Group { get; private set; }

        public User(int id, string code, bool active, UserGroup userGroup)
        {
            Id = id;
            Code = code;
            Active = active;
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
