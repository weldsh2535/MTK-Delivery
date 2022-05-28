namespace MTK_Delivery
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string phonenumber, string password);
    }
}
