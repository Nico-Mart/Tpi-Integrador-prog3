namespace Domain.Entities
{
    public class Admin : User
    {
        public Admin() 
        {
            UserType = Enum.UserType.Admin;
        }
    }
}
