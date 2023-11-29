namespace ProjetoTransacoesImobiliarias.Services;

public class ServiceRepository
{
    public UserService UserService { get; private set; }
    public ClientService ClientService { get; private set; }
    public PropertyService PropertyService { get; private set; }
    public AuthenticationService AuthenticationService { get; private set; }

    public bool StartServices()
    {
        UserService = new UserService();
        if (!UserService.LoadUsersFromJson())
        {
            return false;
        }

        ClientService = new ClientService(UserService);
        if(!ClientService.LoadClientsFromJson())
        {
            return false;
        }
        
        
        PropertyService = new PropertyService(UserService, ClientService);
        if (!PropertyService.LoadPropertiesFromJson())
        {
            return false;
        }
        
        AuthenticationService = new AuthenticationService(UserService);

        return true;
    }
}