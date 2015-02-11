namespace FirstsStepsRUI.Models
{
    public class Menu
    {
        public MenuOption Option { get; private set; }

        public Menu(MenuOption option)
        {
            Option = option;
        }

        public override string ToString()
        {
            string name;
            switch (Option)
            {
                default:
                    name = Option.ToString();
                    break;
            }

            return name;
        }
        
    }

    public enum MenuOption
    {
        Login,
        User,
        Placeholder
    }
}
